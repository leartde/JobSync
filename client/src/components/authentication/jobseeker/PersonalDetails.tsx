import React, { useState } from "react";
import { useRegisterFormContext } from "../../../hooks/authentication/useRegisterFormContext.ts";
import {
    ButtonsGroup,
    DefaultInputDiv,
    InputGroup,
    MultiStepFormWrapper,
} from "./FormComponents.tsx";
import { RegisterJobSeeker } from "../../../types/jobseeker/RegisterJobSeeker.ts";

const PersonalDetails = () => {
    const { registerForm, updateRegisterForm, roleData, updateRoleData } = useRegisterFormContext();

    const [formData, setFormData] = useState<RegisterJobSeeker>({
        FirstName: (roleData as RegisterJobSeeker)?.FirstName || "",
        MiddleName: (roleData as RegisterJobSeeker)?.MiddleName || "",
        LastName: (roleData as RegisterJobSeeker)?.LastName || "",
        Gender: (roleData as RegisterJobSeeker)?.Gender || "",
        BirthDate: (roleData as RegisterJobSeeker)?.BirthDate || new Date()
    });

    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        const { id, value } = e.target;
        setFormData(prev => ({
            ...prev,
            [id]: value
        }));
    };

    const handleButton = (newStep: number) => {
        updateRegisterForm({ currentStep: newStep });
        updateRoleData(formData);
    };

    return (
        <>
            <InputGroup>
                <DefaultInputDiv
                    onChange={handleInputChange}
                    value={formData.FirstName}
                    label="First Name"
                    id="FirstName"
                    type="text"
                />
                <DefaultInputDiv
                    onChange={handleInputChange}
                    value={formData.MiddleName}
                    label="Middle Name"
                    id="MiddleName"
                    type="text"
                />
            </InputGroup>

            <InputGroup>
                <DefaultInputDiv
                    onChange={handleInputChange}
                    value={formData.LastName}
                    label="Last Name"
                    id="LastName"
                    type="text"
                />
                <DefaultInputDiv
                    onChange={handleInputChange}
                    value={formData.Gender}
                    label="Gender"
                    id="Gender"
                    type="select"
                    options={[
                        { value: "", label: "---", disabled: true },
                        { value: "male", label: "Male" },
                        { value: "female", label: "Female" }
                    ]}
                />
            </InputGroup>

            <DefaultInputDiv
                onChange={handleInputChange}
                value={(formData.BirthDate)?.toString()}
                id="BirthDate"
                label="Birthdate"
                type="date"
            />

            <ButtonsGroup
                onClick={handleButton}
                currentStep={registerForm.currentStep}
            />
        </>
    );
};

export default PersonalDetails;