import axios from "axios";

const GetJobSeeker = async (jobSeekerId: string) => {
     const baseUrl = import.meta.env.VITE_API_BASE_URL;
        const url = `${baseUrl}/jobseeker/${jobSeekerId}`;
        try{
            const response = await axios.get(url);
            return response.data;
        }
        catch (error) {
            console.error("Error fetching job seeker data:", error);
            throw error;
        }
}