import JobCard from "./JobCard";
import { useEffect, useState } from "react";
import FetchAllJobs, { JobResponse } from "../../services/job/FetchAllJobs.ts";

export type Job = {
    id: number;
    title: string;
    employer: string;
    description: string
    address?: string;
    createdAt: string;
    pay: string;
    isTakingApplications: boolean;
    hasMultipleSpots: boolean;
    skills?: string[];
    benefits?: string[];

}

const JobCardsColumn = () => {
    const [jobs, setJobs] = useState<Job[]>([]);

    useEffect(() => {
        const getData = async() => {
            const data : JobResponse = await FetchAllJobs(
                {
                    jobType: "FullTime",
                searchTerm: "",
                orderBy: "createdAt",
                pageSize: 5,
                pageNumber: 1,
                isTakingApplications: true,
                hasMultipleSpots: false,
            });
            if (data?.jobs){
                setJobs(data.jobs);
            }
            console.log("URL: ", data.url)
        };
         getData();

    }, []);




    return (
        <div className='max-h-[80vh] max-md:mt-16 overflow-scroll gap-4 p-2 max-md:w-full   w-1/3 flex flex-col'>
            {
                jobs.map((job)=>(
                    <JobCard key={job.id} job={job} createdAt={job.createdAt} description={job.description} employer={job.employer} hasMultipleSpots={job.hasMultipleSpots} id={job.id} isTakingApplications={job.isTakingApplications} pay={job.pay} title={job.title}></JobCard>
                ))
            }
        </div>
    );
}

export default JobCardsColumn;
