// services/authentication/RefreshToken.ts
import axios from "axios";

const RefreshToken = async (rememberMe: boolean) => {
    const baseUrl = import.meta.env.VITE_API_BASE_URL;
    const url = `${baseUrl}/authentication/refresh`;

    try {
        const response = await axios.post(url, { rememberMe }, {
            withCredentials: true
        });

        if (response.status !== 200) {
            throw new Error("Invalid response status");
        }

        const accessToken = response.data.accessToken;
        const refreshToken = response.data.refreshToken;

        return { accessToken, refreshToken };
    } catch (error) {
        console.error("Refresh failed:", error);
        throw error;
    }
};

export default RefreshToken;