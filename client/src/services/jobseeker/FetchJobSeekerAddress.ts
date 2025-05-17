import api from "../../utils/api.ts";

const FetchJobSeekerAddress = async (jobSeekerId: string) => {
    try {
        const url = `/jobseekers/${jobSeekerId}/address`;
        const response = await api.get(url);
        return response.data;
    } catch (error) {
        console.error("Error fetching job seeker address:", error);
        throw error;
    }
}

export default FetchJobSeekerAddress;