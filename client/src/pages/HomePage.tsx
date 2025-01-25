import JobCardsColumn from '../components/jobs/JobCardsColumn';
import JobPreview from '../components/jobs/jobPreview/JobPreview';
import SearchBar from '../components/SearchBar';
import { useLoaderData } from "react-router-dom";
import { useEffect, useState } from "react";
import FetchAllJobs, { JobResponse } from "../services/job/FetchAllJobs.ts";
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

const HomePage = () => {
    const [jobs, setJobs] = useState([]);
    useEffect(() => {
        const getData = async () => {
            try {
                const data : JobResponse = await FetchAllJobs({
                    jobType: "FullTime",
                    searchTerm: "",
                    orderBy: "createdAt",
                    pageSize: 5,
                    pageNumber: 1,
                    isTakingApplications: true,
                    hasMultipleSpots: false,
                });

                if (data?.jobs) {
                    console.log("Fetched jobs: ", data.jobs);
                    setJobs(data.jobs);
                } else {
                    console.error("Data is undefined or jobs are missing.");
                }
            } catch (error) {
                console.error("Error in getData: ", error);
            }
        };

        getData().then();
    }, []);

    const mainJob  = useLoaderData();
    return (
        <div className='flex flex-col'>
            <SearchBar/>
            <div className="mt-6 space-x-8 relative top-12 flex w-3/4 mx-auto  ">
                <JobCardsColumn url={`/jobs/${mainJob.employerId}/${mainJob.id}`} jobs={jobs}/>
                <JobPreview
                    Id={mainJob.id}
                    title={mainJob.title}
                    createdAt={mainJob.createdAt}
                    description={mainJob.description}
                    employer={mainJob.employer}
                    employerId={mainJob.employerId}
                    hasMultipleSpots={mainJob.hasMultipleSpots}
                    isTakingApplications={mainJob.isTakingApplications}
                    type={mainJob.type}
                    pay={mainJob.pay}
                    image={mainJob.imageUrl || ""}
                    skills={mainJob.skills || []}
                    benefits={mainJob.benefits || []}
                 address={mainJob.address || "Remote"} />

            </div>
        </div>
    );
}

export default HomePage;
