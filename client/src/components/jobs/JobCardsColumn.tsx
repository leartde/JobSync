import JobCard from "./JobCard";

const JobCardsColumn = () => {
    return (
        <div className='max-h-[80vh] max-md:mt-16 overflow-scroll gap-4 p-2 max-md:w-full   w-1/3 flex flex-col'>
            <JobCard/>
            <JobCard/>
            <JobCard/>
            <JobCard/>
            <JobCard/>
        </div>
    );
}

export default JobCardsColumn;
