import { Job } from "../../types/job/Job.ts";
import api from "../../utils/api.ts";

const FetchJobsForEmployer = async (id: string) => {
    const url = `/employers/${id}/jobs`;
    try{
        const response = await api.get(url);
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