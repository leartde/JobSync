import api from "../../utils/api.ts";

const FetchJobSeeker = async (jobSeekerId: string) => {
        const url = `/jobseekers/${jobSeekerId}`;
        try{
            const response = await api.get(url);
                return response.data;
        }
        catch (error) {
            console.error("Error fetching job seeker data:", error);
            throw error;
        }
}

export default  FetchJobSeeker;