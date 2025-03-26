import { JobResponseHeadersContext } from "../context/JobResponseHeadersContext.tsx";
import { useContext } from "react";

export function useJobResponseHeadersContext(){
    return  useContext(JobResponseHeadersContext);
}