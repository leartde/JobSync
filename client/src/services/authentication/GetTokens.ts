import api from "../../utils/api";

type Token  = {
    accessToken: string;
    refreshToken: string;

}
const GetTokens = async ()=>{
    try {
        const response = await api.get("/authentication/me");
        console.log("Tokens retrieved successfully:", response.data);
        const token : Token = {
            accessToken: response.data.accessToken,
            refreshToken: response.data.refreshToken
        };
        return token;
    } catch (error) {
        console.error("Error retrieving tokens:", error);
        throw error;
    }
}

export default GetTokens;