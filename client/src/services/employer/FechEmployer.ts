import { Employer } from "../../types/employer/Employer.ts";
import api from "../../utils/api.ts";

const FetchEmployer = async (employerId: string | undefined) => {
    try {
        const url = `/employers/${employerId}`;
        const response = await api.get(url);
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