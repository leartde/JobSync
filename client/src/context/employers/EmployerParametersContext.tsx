import { EmployerParameters } from "../../types/employer/EmployerParameters.ts";
import { createContext, useState } from "react";

type EmployerParametersContextType = {
    employerParameters: EmployerParameters;
    updateEmployerParameters: (employerParameters: EmployerParameters) => void;
}

const defaultEmployerParameters: EmployerParameters = {
    SearchTerm: null,
    OrderBy: null,
    PageSize: 10,
    PageNumber: 1,
    Industry: null,
};

export const EmployerParametersContext = createContext<EmployerParametersContextType | undefined>(undefined);
export function EmployerParametersProvider({ children }: { children: React.ReactNode }) {
    const [employerParameters, setEmployerParameters] = useState<EmployerParameters>(defaultEmployerParameters);

    const updateEmployerParameters = (changes: Partial<EmployerParameters>) => {
        setEmployerParameters(prev => ({
            ...prev,
            ...changes
        }));
    };

    return (
       <EmployerParametersContext.Provider value={{ employerParameters, updateEmployerParameters }}>
                {children}
            </EmployerParametersContext.Provider>
    );
}
