import axios from "axios";
import { Job } from "../../components/jobs/JobCardsColumn.tsx";

type JobParameters = {
    jobType? : string;
    searchTerm? : string;
    hasMultipleSpots? : boolean;
    isTakingApplications: boolean;
    orderBy? : string;
    pageSize: number;
    pageNumber: number;
}

type Headers = {
    totalPages: number;
    hasNext: boolean;
    hasPrevious: boolean;
    pageSize: number;
    currentPage: number;
}

export type JobResponse = {
    jobs: Job[];
    headers: Headers;
    totalPages: number;
    hasNext: boolean;
    hasPrevious: boolean;
    currentPage: number;
    url: string;
}

const FetchJobs = async ({jobType, searchTerm, hasMultipleSpots, isTakingApplications, orderBy, pageSize, pageNumber } : JobParameters) => {
  try{
      let url = `http://localhost:5248/api/jobs?pageSize=${pageSize}`;
      if(jobType && jobType.trim() != ""){
          url += `&jobType=${jobType}`;
      }
      if(searchTerm && searchTerm.trim() != ""){
          url += `&searchTerm=${searchTerm}`;
      }
        if(hasMultipleSpots){
            url += `&hasMultipleSpots=${hasMultipleSpots}`;
        }
        if(isTakingApplications){
            url += `&isTakingApplications=${isTakingApplications}`;
        }
        if(orderBy && orderBy.trim() != ""){
            url += `&orderBy=${orderBy}`;
        }
        if(pageNumber && pageNumber > 0){
            url += `&pageNumber=${pageNumber}`;
        }
        const response = await axios.get(url);
           console.log("URL: ", url);
        if(response.status == 200){
            const headers = response.headers["x-pagination"];
            const parsedHeader : Headers = JSON.parse(headers);
            const totalPages = parsedHeader.totalPages;
            const hasNext = parsedHeader.hasNext;
            const hasPrevious = parsedHeader.hasPrevious;
            const currentPage = parsedHeader.currentPage;
            const jobs: Job[] = response.data;
            const jobData : JobResponse = {
                jobs: jobs,
                headers: parsedHeader,
                totalPages : totalPages,
                hasNext: hasNext,
                hasPrevious: hasPrevious,
                currentPage: currentPage,
                url: url
            }
            return jobData;
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