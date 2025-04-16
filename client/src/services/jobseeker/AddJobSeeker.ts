import { RegisterJobSeeker } from "../../types/jobseeker/RegisterJobSeeker.ts";
import axios from "axios";

const AddJobSeeker = async (jobSeeker: RegisterJobSeeker) => {
    try{
        const baseUrl = import.meta.env.VITE_API_BASE_URL;
        const url = `${baseUrl}/jobseekers`;
        const response = await axios.post(url, jobSeeker);
        if (response.status === 200) {
            return response.data;
        } else {
            console.error("Error adding job seeker: ", response.statusText);
        }
    } catch (e) {
        console.error("Error adding job seeker: ", e);
    }
}

export default AddJobSeeker;