import JobCardsColumn from '../components/jobs/JobCardsColumn';
import JobPreview from '../components/jobs/jobPreview/JobPreview';
import SearchBar from '../components/SearchBar';
import { useEffect, useState } from "react";
import FetchAllJobs, { JobResponse } from "../services/job/FetchAllJobs.ts";
import { MainJobProvider } from "../context/MainJobContext.tsx";
import { useSearchParams } from "react-router-dom";
import { useMainJobContext } from "../hooks/useMainJobContext.tsx";
import FetchJob from "../services/job/FetchJob.ts";
import { JobParametersProvider } from "../context/JobParametersContext.tsx";
import { useJobParametersContext } from "../hooks/useJobParametersContext.tsx";

export type Job = {
    id: string;
    title: string;
    employer: string;
    employerId: string;
    description: string
    address?: string;
    createdAt: string;
    pay: string;
    type:string;
    imageUrl? : string;
    isTakingApplications: boolean;
    hasMultipleSpots: boolean;
    skills?: string[];
    benefits?: string[];
}

const HomePageContent = () => {
    const [jobs, setJobs] = useState<Job[]>([]);
    const { updateMainJob } = useMainJobContext();
    const { jobParameters } = useJobParametersContext();
    const [searchParams, setSearchParams] = useSearchParams();
    const jobId = searchParams.get('jobId');
    const employerId = searchParams.get('employerId');

    useEffect(() => {
        const getData = async () => {
            try {
                const data: JobResponse = await FetchAllJobs({
                    JobType: jobParameters.JobType ?? null,
                    SearchTerm: jobParameters.SearchTerm ?? null,
                    OrderBy: jobParameters.OrderBy ?? null,
                    PageSize: jobParameters.PageSize ?? 10,
                    PageNumber: jobParameters.PageNumber ?? 1,
                    IsTakingApplications: jobParameters.IsTakingApplications ?? true,
                    HasMultipleSpots: jobParameters.HasMultipleSpots ?? null
                });

                if (data?.jobs) {
                    console.log("Fetched job: ", data.jobs);
                    setJobs(data.jobs);

                    if (jobId && employerId) {
                        const selectedJob = await FetchJob(employerId, jobId);
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
    }, [jobId, employerId, setSearchParams,jobParameters.SearchTerm]);
    console.log("SEARCHTERM:", jobParameters.SearchTerm)

    return (
        <div className='flex flex-col '>
            <SearchBar/>
            <div className="mt-6 max-md:flex-col-reverse md:space-x-8 relative top-12 flex w-3/4 mx-auto  ">
                <JobCardsColumn jobs={jobs}/>
                <JobPreview/>
            </div>
        </div>
    );
}

const HomePage = () => {
    return (
        <JobParametersProvider>
            <MainJobProvider>
                <HomePageContent />
            </MainJobProvider>
        </JobParametersProvider>
    );
}

export default HomePage;
