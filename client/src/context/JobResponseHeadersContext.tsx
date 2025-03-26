import { createContext, useState } from "react";
import { JobResponseHeaders } from "../types/job/JobResponseHeaders.ts";

type JobResponseHeadersContextType = {
    headers: JobResponseHeaders;
    updateHeaders: (headers: JobResponseHeaders) => void;
}

const defaultJobResponseHeaders: JobResponseHeaders = {
    HasNext: false,
    HasPrevious: false,
    PageSize: 10,
    TotalPages: 0,
    CurrentPage: 1,
    TotalCount: 0,
};

export const JobResponseHeadersContext = createContext<JobResponseHeadersContextType>({
    headers: defaultJobResponseHeaders,
    updateHeaders: () => {}
});

export function JobResponseHeadersProvider({ children }: { children: React.ReactNode }) {
    const [headers, setHeaders] = useState<JobResponseHeaders>(defaultJobResponseHeaders);
    const updateHeaders = (newHeaders: JobResponseHeaders) => {
        setHeaders(newHeaders);
    }
    return (
        <JobResponseHeadersContext.Provider value={{ headers,updateHeaders}}>
            {children}
        </JobResponseHeadersContext.Provider>
    );
}

