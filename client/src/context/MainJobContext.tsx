import { createContext, useState } from "react";
import { Job } from "../types/job/Job.ts";

type MainJobContextType = {
    mainJob: Job | undefined;
    updateMainJob: (job: Job) => void;
};

export const MainJobContext = createContext<MainJobContextType | undefined>(undefined);

export function MainJobProvider({ children }: { children: React.ReactNode }) {
    const [mainJob, setMainJob] = useState<Job | undefined>(undefined);

    const updateMainJob = (job: Job) => {
        setMainJob(job);
    };

    return (
        <MainJobContext.Provider value={{ mainJob, updateMainJob }}>
            {children}
        </MainJobContext.Provider>
    );
}

