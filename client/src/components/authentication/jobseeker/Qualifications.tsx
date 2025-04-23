import React from 'react';
import { useRegisterFormContext } from "../../../hooks/authentication/useRegisterFormContext.ts";
import { ButtonsGroup, DefaultInputDiv } from "./FormComponents.tsx";
import SkillsInput from "./SkillsInput.tsx";


const Qualifications = () => {
    const { updateRoleData, updateRegisterForm } = useRegisterFormContext();
    const handleResumeChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const file = e.target.files?.[0];
        if (file) {
            updateRoleData({ Resume: file });
        }
    }
    const handleButton = (newStep: number) => {
        updateRegisterForm({ currentStep: newStep });
    };
    return (


        <>
            <DefaultInputDiv onChange={handleResumeChange}  label="Upload your resume" id="resume" type="file"/>
              <SkillsInput/>
            <ButtonsGroup onClick={handleButton}  currentStep={4}
                          buttonType="submit">

            </ButtonsGroup>

        </>
    );
};

export default Qualifications;
