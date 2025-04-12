import axios from "axios";
import { Job } from "../../types/job/Job.ts";

const FetchJobsForEmployer = async (id: string) => {
    try{
        const baseUrl = import.meta.env.VITE_API_BASE_URL;
        const url = `${baseUrl}/employers/${id}/jobs`;
        const response = await axios.get(url);
        if(response.status === 200){
            const jobs :Job[] = response.data;
            return jobs;
        }
        else{
            console.error("Error fetching jobs for employer: ", response.statusText);
        }
    }
    catch (e) {
        console.error("Error fetching jobs for employer: ", e);
    }
}

export default FetchJobsForEmployer;