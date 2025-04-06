import { createContext, useState } from "react";
import { JobParameters } from "../../types/job/JobParameters.ts";

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
    MinimumPay: null,
    IsRemote: null,
    IsTakingApplications: true,
    HasMultipleSpots: null
};

export const JobParametersContext = createContext<JobParametersContextType | undefined>(undefined);

export function JobParametersProvider({ children }: { children: React.ReactNode }) {
    const [jobParameters, setJobParameters] = useState<JobParameters>(defaultJobParameters);

    const updateJobParameters = (changes: Partial<JobParameters>) => {
        setJobParameters(prev => ({
            ...prev,
            ...changes
        }));
    };

    return (
        <JobParametersContext.Provider value={{ jobParameters, updateJobParameters }}>
            {children}
        </JobParametersContext.Provider>
    );
}