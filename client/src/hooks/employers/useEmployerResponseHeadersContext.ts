import { useContext } from "react";
import { EmployerResponseHeadersContext } from "../../context/employers/EmployerResponseHeadersContext.tsx";

export function useEmployerResponseHeadersContext() {
    return useContext(EmployerResponseHeadersContext);
}