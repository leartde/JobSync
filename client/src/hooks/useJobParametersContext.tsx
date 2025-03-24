import { JobParametersContext } from "../context/JobParametersContext.tsx";
import { useContext } from "react";

export function useJobParametersContext() {
    return useContext(JobParametersContext);
}