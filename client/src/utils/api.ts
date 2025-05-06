// utils/api.ts
import axios from "axios";
import { useRefresh } from "../hooks/authentication/useRefresh.ts";

const api = axios.create({
    baseURL: import.meta.env.VITE_API_BASE_URL,
    withCredentials: true
});

api.interceptors.response.use(
    response => response,
    async error => {
        const originalRequest = error.config;

        if (error.response?.status === 401 && !originalRequest._retry) {
            originalRequest._retry = true;

            try {
                const { refresh } = useRefresh();
                await refresh();
                return api(originalRequest);
            } catch (refreshError) {
                console.error("Token refresh failed:", refreshError);
                throw refreshError;
            }
        }

        return Promise.reject(error);
    }
);

export default api;