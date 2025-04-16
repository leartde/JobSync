import React from 'react';
import { useRegisterFormContext } from "../../../hooks/authentication/useRegisterFormContext.ts";
import {
    ButtonsGroup,
    DefaultInputDiv,
    InputGroup,
    MultiStepFormWrapper,
} from "./FormComponents.tsx";

const ContactDetails = () => {
    const { registerForm, updateRegisterForm } = useRegisterFormContext();
    return (
        <MultiStepFormWrapper title="Contact Details" role="jobseeker" steps={4} currentStep={3}>
            <DefaultInputDiv size="default" label="Country" id="country" type="select"
                             options={[
                                 { value: "", label: "---",disabled:true },
                                 { value: "US", label: "United States" },
                                 { value: "CN", label: "Canada" },
                                 { value: "UK", label: "United Kingdom" },
                                 { value: "AUS", label: "Australia" }
                             ]}/>
            <DefaultInputDiv size="default" label="Street" id="street" type="text"/>
            <InputGroup size="small">
                <DefaultInputDiv size="small" label="City" id="city" type="text"/>
                <DefaultInputDiv size="small" label="State" id="state" type="text"/>
                <DefaultInputDiv size="small" label="Zip" id="zip" type="text"/>

            </InputGroup>
            <DefaultInputDiv size="default" label="Phone Number" id="phone" type="text"/>

            <ButtonsGroup
                onClick={(newStep) => updateRegisterForm({ currentStep: newStep })}
                currentStep={registerForm.currentStep}
            />

        </MultiStepFormWrapper>

    );
};

export default ContactDetails;
