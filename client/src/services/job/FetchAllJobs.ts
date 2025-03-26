import axios from "axios";
import { Job } from "../../types/job/Job.ts";
import { JobParameters } from "../../types/job/JobParameters.ts";
import { JobResponseHeaders } from "../../types/job/JobResponseHeaders.ts";
import { JobResponse } from "../../types/job/JobResponse.ts";


const FetchJobs = async ({JobType, SearchTerm, HasMultipleSpots, IsTakingApplications, OrderBy, PageSize, PageNumber } : JobParameters) => {
    try{
        let url = `http://localhost:5248/api/jobs?`
        if(PageSize && PageSize > 0){
            url += `PageSize=${PageSize}`;
        }
        if(JobType && JobType.trim() != ""){
            url += `&JobType=${JobType}`;
        }
        if(SearchTerm && SearchTerm.trim() != ""){
            url += `&SearchTerm=${SearchTerm}`;
        }
        if(HasMultipleSpots){
            url += `&HasMultipleSpots=${HasMultipleSpots}`;
        }
        if(IsTakingApplications){
            url += `&IsTakingApplications=${IsTakingApplications}`;
        }
        if(OrderBy && OrderBy.trim() != ""){
            url += `&OrderBy=${OrderBy}`;
        }
        if(PageNumber && PageNumber > 0){
            url += `&PageNumber=${PageNumber}`;
        }
        const response = await axios.get(url);
        console.log("URL: ", url);
        console.log("RESPONSE: ", response);
        if(response.status === 200){
            const headers = response.headers["x-pagination"];
            const parsedHeader : JobResponseHeaders = JSON.parse(headers);
            const jobs: Job[] = response.data;
            const data : JobResponse =  {
                jobs: jobs,
                headers: parsedHeader
            }
            return data;
        }
        else{
            console.log("Error fetching jobs: ", response.statusText);
        }
    }
    catch (e)
    {
        console.log("Error fetching jobs: ", e);
    }
}

export default FetchJobs;