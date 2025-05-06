import { useAuth } from "./useAuth";
import RefreshToken from "../../services/authentication/RefreshToken.ts";
import { jwtDecode } from "jwt-decode";

export const useRefresh = () => {
    const { login, logout } = useAuth();

    const refresh = async () => {
        try {
            const rememberMe = localStorage.getItem("rememberMe") === "true";
            const { accessToken, refreshToken } = await RefreshToken(rememberMe);
            const decoded = jwtDecode(accessToken) as{
                id: string;
                email: string;
                role: "jobseeker" | "employer" | "admin";

            };
            const user = {
                id: decoded.id,
                email: decoded.email,
                role: decoded.role
            };

            await login({ accessToken, refreshToken }, rememberMe);

            return { accessToken, refreshToken, user };
        } catch (error) {
            console.error("Refresh failed:", error);
            await logout();
            throw error;
        }
    };

    return { refresh };
};