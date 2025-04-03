import JobCardsColumn from '../components/jobs/JobCardsColumn';
import JobPreview from '../components/jobs/jobPreview/JobPreview';
import SearchBar from '../components/SearchBar';
import { useEffect, useState } from "react";
import FetchAllJobs  from "../services/job/FetchAllJobs.ts";
import { MainJobProvider } from "../context/MainJobContext.tsx";
import { useSearchParams } from "react-router-dom";
import { useMainJobContext } from "../hooks/useMainJobContext.ts";
import FetchJob from "../services/job/FetchJob.ts";
import { JobParametersProvider } from "../context/JobParametersContext.tsx";
import { useJobParametersContext } from "../hooks/useJobParametersContext.ts";
import { Job } from "../types/job/Job.ts";
import Pagination from "../components/Pagination.tsx";
import { JobResponse } from "../types/job/JobResponse.ts";
import { useJobResponseHeadersContext } from "../hooks/useJobResponseHeadersContext.ts";
import { JobResponseHeadersProvider } from "../context/JobResponseHeadersContext.tsx";
import Filters from "../components/jobs/jobFilters/Filters.tsx";



const HomePageContent = () => {
    const [jobs, setJobs] = useState<Job[]>([]);
    const { updateMainJob } = useMainJobContext();
    const { jobParameters } = useJobParametersContext();
    const { updateHeaders } = useJobResponseHeadersContext();
    const [searchParams, setSearchParams] = useSearchParams();
    const urlParams = {
    jobId: searchParams.get('jobId'),
    employerId: searchParams.get('employerId'),
    searchTerm: searchParams.get('searchTerm'),
    pageNumber: searchParams.get('pageNumber'),
    jobType: searchParams.get('jobType'),
    isRemote: searchParams.get('isRemote'),
    hasMultipleSpots: searchParams.get('hasMultipleSpots'),
    minimumPay: searchParams.get('minimumPay')
}

useEffect(() => {
    if (urlParams.searchTerm){
        jobParameters.SearchTerm = urlParams.searchTerm;
    }
    if(urlParams.pageNumber){
        jobParameters.PageNumber = parseInt(urlParams.pageNumber);
    }
    if (urlParams.jobType){
        jobParameters.JobType = urlParams.jobType;
    }
    if (urlParams.isRemote){
        jobParameters.IsRemote = urlParams.isRemote === 'true';
    }
    if (urlParams.hasMultipleSpots){
        jobParameters.HasMultipleSpots = urlParams.hasMultipleSpots === 'true';
    }
    if (urlParams.minimumPay){
        jobParameters.MinimumPay = parseFloat(urlParams.minimumPay);
    }
        const getData = async () => {
            try {
                const data: JobResponse = await FetchAllJobs({
                    JobType: jobParameters.JobType ?? null,
                    SearchTerm: jobParameters.SearchTerm ?? null,
                    OrderBy: jobParameters.OrderBy ?? null,
                    PageSize: jobParameters.PageSize ?? 10,
                    MinimumPay: jobParameters.MinimumPay ?? null,
                    IsRemote: jobParameters.IsRemote ?? null,
                    PageNumber: jobParameters.PageNumber,
                    IsTakingApplications: jobParameters.IsTakingApplications ?? true,
                    HasMultipleSpots: jobParameters.HasMultipleSpots ?? null
                });
                if (data?.jobs) {
                    setJobs(data.jobs);
                    updateHeaders(data.headers);
                    if (urlParams.jobId && urlParams.employerId) {
                        const selectedJob = await FetchJob(urlParams.employerId, urlParams.jobId);
                        if (selectedJob) {
                            updateMainJob(selectedJob);
                        }
                    } else if (data.jobs.length > 0) {
                        updateMainJob(data.jobs[0]);
                        setSearchParams({
                            employerId: data.jobs[0].employerId,
                            jobId: data.jobs[0].id });
                    }
                } else {
                    console.error("Data is undefined or job are missing.");
                }
            } catch (error) {
                console.error("Error in getData: ", error);
            }
        };

        getData().then();
    }, [urlParams.jobId, urlParams.employerId, jobParameters.SearchTerm, jobParameters.PageNumber, jobParameters.IsRemote, jobParameters.HasMultipleSpots, jobParameters.JobType, jobParameters.OrderBy, jobParameters.PageSize, jobParameters.MinimumPay, jobParameters.IsTakingApplications]);

    return (
        <div className='flex flex-col gap-4 '>
            <SearchBar/>
            {searchParams.has('searchTerm') && <Filters/>}
            <div className=" max-md:flex-col-reverse md:space-x-8 relative top-12 flex w-3/4 mx-auto  ">
                <JobCardsColumn jobs={jobs}/>
                <JobPreview/>
            </div>
            <Pagination/>
        </div>
    );
}

const HomePage = () => {
    return (
        <JobParametersProvider>
            <JobResponseHeadersProvider>
                <MainJobProvider>
                    <HomePageContent />
                </MainJobProvider>
            </JobResponseHeadersProvider>
        </JobParametersProvider>
    );
}

export default HomePage;
