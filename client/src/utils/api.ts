import axios from "axios";

import RefreshToken from "../services/authentication/RefreshToken.ts";

const api = axios.create({
    baseURL: import.meta.env.VITE_API_BASE_URL,
    withCredentials: true
});

const refreshAuthToken = async () => {
    try {
        const rememberMe = localStorage.getItem("rememberMe") === "true";
        const { accessToken: newAccessToken, refreshToken: newRefreshToken } = await RefreshToken(rememberMe);
        return { newAccessToken, newRefreshToken };
    } catch (error) {
        console.error("Token refresh failed:", error);
        throw error;
    }
};

api.interceptors.response.use(
    response => response,
    async error => {
        const originalRequest = error.config;

        if (error.response?.status === 401 && !originalRequest._retry) {
            originalRequest._retry = true;

                const { newAccessToken } =  await refreshAuthToken();
                originalRequest.headers['Authorization'] = `Bearer ${newAccessToken}`;
                originalRequest.withCredentials = true;
                return api(originalRequest);

        }

        return Promise.reject(error);
    }
);


export default api;
