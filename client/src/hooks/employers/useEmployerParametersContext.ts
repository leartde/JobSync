import { useContext } from "react";
import { EmployerParametersContext } from "../../context/employers/EmployerParametersContext.tsx";

export function useEmployerParametersContext(){
    const context = useContext(EmployerParametersContext);
    if (context === undefined) {
        throw new Error('useEmployerParametersContext must be used within a EmployerParametersProvider');
    }
    return context;
}