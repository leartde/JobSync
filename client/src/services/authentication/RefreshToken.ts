import api from "../../utils/api";

const RefreshToken = async (rememberMe: boolean) => {
const url = `/authentication/refresh?rememberMe=${rememberMe}`;
    try {
        const response = await api.post(url);
        if (response.status !== 200) {
            throw new Error("Invalid response status");
        }

        const newAccessToken = response.data.accessToken;
        const newRefreshToken = response.data.refreshToken;

        return { newAccessToken, newRefreshToken };
    } catch (error) {
        console.error("Refresh failed:", error);
        throw error;
    }
};

export default RefreshToken;
