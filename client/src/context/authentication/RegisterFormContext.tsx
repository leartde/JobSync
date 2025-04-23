import { RegisterJobSeeker } from "../../types/jobseeker/RegisterJobSeeker.ts";
import { RegisterUser } from "../../types/authentication/RegisterUser.ts";
import { RegisterEmployer } from "../../types/employer/RegisterEmployer.ts";
import { createContext, useState } from "react";

 type RegisterFormContextType = {
   registerForm: RegisterFormType;
    updateRegisterForm: (changes: Partial<RegisterFormType>) => void;
    updateUserData: (changes: Partial<RegisterUser>) => void;
    updateRoleData: (changes: Partial<RegisterJobSeeker | RegisterEmployer>) => void;
    userData: RegisterUser;
    roleData: RegisterJobSeeker | RegisterEmployer;
}

type RegisterFormType = {
     type: "jobseeker" | "employer" | null;
    steps: number;
    currentStep: number;
    userData: RegisterUser;
    roleData : RegisterJobSeeker | RegisterEmployer
}
export const RegisterFormContext = createContext<RegisterFormContextType | undefined>(undefined);

export function RegisterFormProvider({ children }: { children }) {
    const [registerForm, setRegisterForm] = useState<RegisterFormType>({
        type: null,
        steps: 4,
        currentStep: 0,
        userData: {
            email: "",
            password: "",
            role: null
        },
        roleData: {} as RegisterJobSeeker | RegisterEmployer
    });

    const updateRegisterForm = (changes: Partial<RegisterFormType>) => {
        setRegisterForm(prev => ({
            ...prev,
            ...changes,
            userData: changes.userData ? {
                ...prev.userData,
                ...changes.userData
            } : prev.userData,
            roleData: changes.roleData ? {
                ...prev.roleData,
                ...changes.roleData
            } : prev.roleData
        }));
    };

    const updateUserData = (changes: Partial<RegisterUser>) => {
        updateRegisterForm({
            userData: {
                ...registerForm.userData,
                ...changes
            }
        });
    };

    const updateRoleData = (changes: Partial<RegisterJobSeeker | RegisterEmployer>) => {
        updateRegisterForm({
            roleData: {
                ...registerForm.roleData,
                ...changes
            }
        });
    };

    return (
        <RegisterFormContext.Provider
            value={{
                registerForm,
                updateRegisterForm,
                updateUserData,
                updateRoleData,
                userData: registerForm.userData,
                roleData: registerForm.roleData
            }}
        >
            {children}
        </RegisterFormContext.Provider>
    );
}
