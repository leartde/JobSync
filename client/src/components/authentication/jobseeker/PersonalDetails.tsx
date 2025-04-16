import React from "react";
import { useRegisterFormContext } from "../../../hooks/authentication/useRegisterFormContext.ts";
import {
    ButtonsGroup,
    DefaultInputDiv,
     InputGroup,
    MultiStepFormWrapper,
} from "./FormComponents.tsx";

const PersonalDetails = () => {
  const { registerForm, updateRegisterForm } = useRegisterFormContext();

  return (
      <MultiStepFormWrapper role="jobseeker" title="Personal Details" currentStep={registerForm.currentStep} steps={registerForm.steps}>
          <InputGroup>
             <DefaultInputDiv label="First Name" id="firstName" type="text"/>
            <DefaultInputDiv label="Middle Name" id="middleName" type="text"/>
          </InputGroup>
          <InputGroup>
            <DefaultInputDiv label="Last Name" id="lastName" type="text"/>
            <DefaultInputDiv
                label="Gender"
                id="gender"
                type="select"
                options={[
                  { value: "", label: "---",disabled:true  },
                  { value: "male", label: "Male" },
                  {value: "female", label:"Female"}
                ]}
            />

          </InputGroup>

          <DefaultInputDiv id="birthday" label="Birthday" type="date" />


            <ButtonsGroup
                onClick={(newStep) => updateRegisterForm({ currentStep: newStep })}
                currentStep={registerForm.currentStep}
            />

      </MultiStepFormWrapper>
  );
};

export default PersonalDetails;
