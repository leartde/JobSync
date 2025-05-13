import api from "../../utils/api.ts";

const FetchJobSeekerSkills = async(jobSeekerId: string) => {
    const url = `/jobseekers/${jobSeekerId}/skills`;
    try {
        const response = await api.get(url);
        return response.data;
    } catch (error) {
        console.error("Error fetching job seeker skills:", error);
        throw error;
    }
}

export default FetchJobSeekerSkills;