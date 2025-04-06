import { useContext } from "react";
import { JobParametersContext } from "../../context/jobs/JobParametersContext.tsx";

export function useJobParametersContext() {
    const context = useContext(JobParametersContext);
    if (context === undefined) {
        throw new Error('useJobParametersContext must be used within a JobParametersProvider');
    }
    return context;
}