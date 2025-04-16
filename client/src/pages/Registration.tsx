import React, { useEffect } from "react";
import RoleSelection from "../components/authentication/RoleSelection.tsx";
import { RegisterFormProvider } from "../context/authentication/RegisterFormContext.tsx";
import { useRegisterFormContext } from "../hooks/authentication/useRegisterFormContext.ts";
import UserRegistration from "../components/authentication/UserRegistration.tsx";
import PersonalDetails from "../components/authentication/jobseeker/PersonalDetails.tsx";
import ContactDetails from "../components/authentication/jobseeker/ContactDetails.tsx";
import Qualifications from "../components/authentication/jobseeker/Qualifications.tsx";

const RegistrationPage = () => {
    const { registerForm, updateRegisterForm } = useRegisterFormContext();
    const [currentStep, setCurrentStep] = React.useState<number | undefined>();
    useEffect(() => {
            setCurrentStep(registerForm?.currentStep);
    }, [registerForm?.currentStep]);
    return (
        <>
            { (currentStep == null || false) && <RoleSelection/>}
            { currentStep === 1 && <UserRegistration/>}
            { (currentStep === 2 && registerForm.type == "jobseeker" )&& <PersonalDetails/>}
            { (currentStep === 3 && registerForm.type == "jobseeker" )&& <ContactDetails/>}
            { (currentStep === 4 && registerForm.type == "jobseeker" )&& <Qualifications/>}
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
