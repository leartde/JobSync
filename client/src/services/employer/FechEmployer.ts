import axios from "axios";
import { Employer } from "../../types/employer/Employer.ts";

const FetchEmployer = async (employerId: string | undefined) => {
    try {
        const baseUrl = import.meta.env.VITE_API_BASE_URL;
        const url = `${baseUrl}/employers/${employerId}`;
        const response = await axios.get(url);
        if (response.status === 200) {
            const employers : Employer = response.data;
            return employers;
        } else {
            console.error("Error fetching employer: ", response.statusText);
        }
    } catch (e) {
        console.error("Error fetching employer: ", e);
    }
}

export default FetchEmployer;