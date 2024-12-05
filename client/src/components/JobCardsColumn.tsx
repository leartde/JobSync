import JobCard from "./JobCard";

const JobCardsColumn = () => {
    return (
        <div className=' gap-4 p-2 max-md:w-full   w-1/3 flex flex-col'>
            <JobCard/>
            <JobCard/>
            <JobCard/>
        </div>
    );
}

export default JobCardsColumn;
