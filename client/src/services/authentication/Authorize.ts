import axios from "axios";
import { LogUser } from "../../types/authentication/LogUser.ts";

export const Authorize = async ({ email, password, rememberMe }: LogUser) => {
    const baseUrl = import.meta.env.VITE_API_BASE_URL;
    const url = `${baseUrl}/authentication/login?rememberMe=${rememberMe}`;

    try {
        const response = await axios.post(url, { email, password }, {
            withCredentials: true,
        });

        console.log("RESPONSE: ", response);
        return response;
    } catch (error) {
        console.error("Error logging in:", error);
        throw new Error("Authorize failed");
    }
};

