import JobCard from "./JobCard";
import { Job } from "../../pages/HomePage.tsx";
import { useSearchParams } from "react-router-dom";
import { useMainJobContext } from "../../hooks/useMainJobContext.tsx";

type JobCardsColumnProp = {
    jobs: Job[];
}

const JobCardsColumn = ({jobs}: JobCardsColumnProp) => {
    const { updateMainJob } = useMainJobContext();
    const [, setSearchParams] = useSearchParams();
    
    const handleJobClick = (job: Job) => {
        updateMainJob(job);
        setSearchParams({
            employerId: job.employerId,
            jobId: job.id
        });
        if (window.innerWidth < 768) {
            window.scrollTo({ top: 0, behavior: 'smooth' });
        }
    };
    
    return (
        <div className='max-h-[80vh] max-md:mt-16 overflow-scroll gap-4 p-2 max-md:w-full w-1/3 flex flex-col'>
            {jobs.map((job: Job) => (
                <JobCard 
                    onClick={() => handleJobClick(job)} 
                    key={job.id}  
                    job={job}
                />
            ))}
        </div>
    );
}

export default JobCardsColumn;
