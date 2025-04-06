import { JobResponseHeadersContext } from "../../context/jobs/JobResponseHeadersContext.tsx";
import { useContext } from "react";

export function useJobResponseHeadersContext(){
    return  useContext(JobResponseHeadersContext);
}