import axios from "axios";
import { Job } from "../../pages/HomePage.tsx";

export type JobParameters = {
    JobType?: string | null;
    SearchTerm?: string | null;
    HasMultipleSpots?: boolean | null;
    IsTakingApplications?: boolean;
    OrderBy?: string | null;
    PageSize?: number;
    PageNumber?: number;
};

type Headers = {
    totalPages: number;
    hasNext: boolean;
    hasPrevious: boolean;
    pageSize: number;
    currentPage: number;
}

export type JobResponse = {
    jobs: Job[];
    totalPages: number;
    hasNext: boolean;
    hasPrevious: boolean;
    currentPage: number;
}

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
            const parsedHeader : Headers = JSON.parse(headers);
            const totalPages = parsedHeader.totalPages;
            const hasNext = parsedHeader.hasNext;
            const hasPrevious = parsedHeader.hasPrevious;
            const currentPage = parsedHeader.currentPage;
            const jobs: Job[] = response.data;

            const data : JobResponse =  {
                jobs: jobs,
                totalPages : totalPages,
                hasNext: hasNext,
                hasPrevious: hasPrevious,
                currentPage: currentPage,
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