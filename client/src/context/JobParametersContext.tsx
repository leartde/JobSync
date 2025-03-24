import { JobParameters } from "../services/job/FetchAllJobs.ts";
import { createContext, useState } from "react";

type JobParametersContextType = {
    jobParameters: JobParameters;
    updateJobParameters: (jobParameters: JobParameters) => void;
}

const defaultJobParameters: JobParameters = {
    JobType: null,
    SearchTerm: null,
    OrderBy: null,
    PageSize: 10,
    PageNumber: 1,
    IsTakingApplications: true,
    HasMultipleSpots: null
};

export const JobParametersContext = createContext<JobParametersContextType>({
    jobParameters: defaultJobParameters,
    updateJobParameters: () => {}
});

export function JobParametersProvider({ children }: { children: React.ReactNode }) {
    const [jobParameters, setJobParameters] = useState<JobParameters>(defaultJobParameters);

    const updateJobParameters = (newJobParameters: JobParameters) => {
        setJobParameters(newJobParameters);
    };

    return (
        <JobParametersContext.Provider value={{ jobParameters, updateJobParameters }}>
            {children}
        </JobParametersContext.Provider>
    );
}