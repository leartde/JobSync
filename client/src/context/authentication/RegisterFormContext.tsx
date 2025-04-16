import { RegisterJobSeeker } from "../../types/jobseeker/RegisterJobSeeker.ts";
import { RegisterUser } from "../../types/authentication/RegisterUser.ts";
import { RegisterEmployer } from "../../types/employer/RegisterEmployer.ts";
import { createContext, useState } from "react";

 type RegisterFormContextType = {
   registerForm: RegisterFormType;
    updateRegisterForm: (changes: Partial<RegisterFormType>) => void;
}

type RegisterFormType = {
     type: "jobseeker" | "employer" | null;
    steps: number;
    currentStep: number;
    setCurrentStep: (step: number) => void;
    formData : {
        userData: RegisterUser;
        roleData? : RegisterJobSeeker | RegisterEmployer
    }
    setFormData: (
        formData: {
            userData: RegisterUser;
            roleData : RegisterJobSeeker | RegisterEmployer
        }
    ) => void;
}
export const RegisterFormContext = createContext<RegisterFormContextType | undefined>(undefined);

export function RegisterFormProvider({ children }: { children: React.ReactNode }) {
    const [registerForm, setRegisterForm] = useState<RegisterFormType>(null);
    const updateRegisterForm = (changes: Partial<RegisterFormType>) => {
        setRegisterForm(prev => ({
            ...prev,
            ...changes
        }));
    };


    return (
        <RegisterFormContext.Provider value={{registerForm, updateRegisterForm}} >
            {children}
        </RegisterFormContext.Provider>
    );
}