import React from 'react';
import { useRegisterFormContext } from "../../hooks/authentication/useRegisterFormContext.ts";
import { RegisterUser } from "../../types/authentication/RegisterUser.ts";
import { ButtonsGroup, DefaultInputDiv, MultiStepFormWrapper } from "./jobseeker/FormComponents.tsx";


const UserRegistration = () => {
    const { registerForm, updateRegisterForm } = useRegisterFormContext();
    const userData:RegisterUser = {
        email: "",
        password: "",
        confirmPassword: "",
        role: registerForm.type ? registerForm.type : "jobseeker",
    };
    const handleInputChange = (e) => {
        const { name, value } = e.target;
        userData[name as keyof typeof userData] = value;
    };
    const handleSubmit = (e) => {
        e.preventDefault();
       updateRegisterForm({
           formData :{
               userData : userData,
           },
           currentStep: 2,
       });
    }

    return (

        <MultiStepFormWrapper steps={4} currentStep={1} role={registerForm.type} title="Account details">
            <DefaultInputDiv label="Email" id="email" type="email"/>
            <DefaultInputDiv label="Password" id="password" type="password"/>
            <DefaultInputDiv label="Confirm Password" id="confirmPassword" type="password"/>

            <ButtonsGroup                 onClick={(newStep) => updateRegisterForm({ currentStep: newStep })}
                                          currentStep={1}/>
        </MultiStepFormWrapper>
    );
};

export default UserRegistration;
