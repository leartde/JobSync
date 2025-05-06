import axios from "axios";

const Logout = async () => {
    const baseUrl = import.meta.env.VITE_API_BASE_URL;
    const url = `${baseUrl}/authentication/logout`;

    try{
        return await axios.post(url);
    }
    catch (e){
        console.log("Error logging out:", e);
    }
}

export default Logout;