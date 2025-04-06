import { createContext, useState } from "react";
import { ResponseHeaders } from "../../types/ResponseHeaders.ts";

type JobResponseHeadersContextType = {
    headers: ResponseHeaders;
    updateHeaders: (headers: ResponseHeaders) => void;
}

const defaultJobResponseHeaders: ResponseHeaders = {
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
    const [headers, setHeaders] = useState<ResponseHeaders>(defaultJobResponseHeaders);
    const updateHeaders = (newHeaders: ResponseHeaders) => {
        setHeaders(newHeaders);
    }
    return (
        <JobResponseHeadersContext.Provider value={{ headers,updateHeaders}}>
            {children}
        </JobResponseHeadersContext.Provider>
    );
}

