import JobCard from "./JobCard";
import { Job } from "../../pages/HomePage.tsx";


type JobCardsColumnProp = {
    jobs: Job[];
    url: string;
}
const JobCardsColumn = ({jobs, url}:JobCardsColumnProp) => {



    return (
        <div className='max-h-[80vh] max-md:mt-16 overflow-scroll gap-4 p-2 max-md:w-full w-1/3 flex flex-col'>{
                jobs.map((job) => (
                    <JobCard url={url} job={job}

                    >
                    </JobCard>
                ))
            }
        </div>

    );
}

export default JobCardsColumn;
