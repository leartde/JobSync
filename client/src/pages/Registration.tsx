import React, { useEffect } from "react";
import RoleSelection from "../components/authentication/RoleSelection.tsx";
import { RegisterFormProvider } from "../context/authentication/RegisterFormContext.tsx";
import { useRegisterFormContext } from "../hooks/authentication/useRegisterFormContext.ts";

import JobSeekerRegistration from "../components/authentication/jobseeker/JobSeekerRegistration.tsx";

const RegistrationPage = () => {
    const { registerForm} = useRegisterFormContext();
    const [currentStep, setCurrentStep] = React.useState<number | undefined>();
    useEffect(() => {
            setCurrentStep(registerForm?.currentStep);
    }, [registerForm?.currentStep]);
    return (
        <>
            { (currentStep == 0) && <RoleSelection/>}
            {(registerForm.type === "jobseeker" && currentStep > 0) && <JobSeekerRegistration/>}
        </>
    );
}
const Registration = () => {
    return (
        <RegisterFormProvider>
            <RegistrationPage/>
        </RegisterFormProvider>
    );

}

export default Registration;
