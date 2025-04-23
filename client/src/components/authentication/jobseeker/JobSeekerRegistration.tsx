import React from 'react';
import { MultiStepFormWrapper } from "./FormComponents.tsx";
import { useRegisterFormContext } from "../../../hooks/authentication/useRegisterFormContext.ts";
import UserRegistration from "../UserRegistration.tsx";
import PersonalDetails from "./PersonalDetails.tsx";
import ContactDetails from "./ContactDetails.tsx";
import Qualifications from "./Qualifications.tsx";
import CreateJobSeeker from "../../../services/jobseeker/CreateJobSeeker.ts";
import { RegisterJobSeeker } from "../../../types/jobseeker/RegisterJobSeeker.ts";

const JobSeekerRegistration = () => {
    const { registerForm,userData,roleData} = useRegisterFormContext();
    const  currentStep  = registerForm.currentStep;
    const titles = {
        1: "Account Details",
        2: "Personal Details",
        3: "Contact Details",
        4: "Qualifications"
    };
    const handleSubmit = async (e) => {
        e.preventDefault();
        await CreateJobSeeker({ email: userData.email, password: userData.password,role:"jobseeker", addJobSeekerDto: (roleData as RegisterJobSeeker )} )
    }
    return (
        <MultiStepFormWrapper submit={handleSubmit} currentStep={currentStep} steps={4} title={titles[currentStep]} role="jobseeker">
            {currentStep === 1 && <UserRegistration  />}
            {currentStep === 2 && <PersonalDetails />}
            {currentStep === 3 && <ContactDetails />}
            {currentStep === 4 && <Qualifications />}
        </MultiStepFormWrapper>
    );
};

export default JobSeekerRegistration;
