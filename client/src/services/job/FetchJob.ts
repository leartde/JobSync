import axios from "axios";
import { Job } from "../../types/job/Job.ts";

const FetchJob = async (employerId,jobId) => {
    try{
        const url : string = `http://localhost:5248/api/employers/${employerId}/jobs/${jobId}`;
        const response = await axios.get(url);
        if (response.status === 200){
            const job: Job = response.data;
            return job;
        }
        else{
            console.log("Error fetching the job " + response.statusText);
        }
    }
    catch (error){
        console.error("Error fetching job: ", error);
    }

}

export default FetchJob;