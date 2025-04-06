import { ResponseHeaders } from "../../types/ResponseHeaders.ts";
import { createContext, useState } from "react";

type EmployerResponseHeadersContextType = {
    headers: ResponseHeaders;
    updateHeaders: (headers: ResponseHeaders) => void;
}

const DefaultEmployerResponseHeaders : ResponseHeaders = {
    HasNext: false,
    HasPrevious: false,
    PageSize: 10,
    TotalPages: 0,
    CurrentPage: 1,
    TotalCount: 0,
}

export const EmployerResponseHeadersContext = createContext<EmployerResponseHeadersContextType>({
    headers: DefaultEmployerResponseHeaders,
    updateHeaders: () => {}
});

export function EmployerResponseHeadersProvider({ children }: { children: React.ReactNode }) {
    const [headers, setHeaders] = useState<ResponseHeaders>(DefaultEmployerResponseHeaders);
    const updateHeaders = (newHeaders: ResponseHeaders) => {
        setHeaders(newHeaders);
    }
    return (
        <EmployerResponseHeadersContext.Provider value={{ headers, updateHeaders }}>
            {children}
        </EmployerResponseHeadersContext.Provider>
    );
}
