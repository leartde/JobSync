import React, { useState } from "react";
import { useRegisterFormContext } from "../../../hooks/authentication/useRegisterFormContext.ts";
import {
    ButtonsGroup,
    DefaultInputDiv,
    InputGroup,
} from "../FormComponents.tsx";
import { RegisterJobSeeker } from "../../../types/jobseeker/RegisterJobSeeker.ts";
import { personalDetailsSchema } from "../../../schemas/jobseeker/PersonalDetails.schema.ts";

type PersonalDetailsErrors = {
    firstName?: string;
    middleName?: string;
    lastName?: string;
    gender?: string;
    birthDate?: string;
};

const PersonalDetails = () => {
    const { registerForm, updateRegisterForm, roleData, updateRoleData } = useRegisterFormContext();
    const [errors, setErrors] = useState<PersonalDetailsErrors>({});

    const [formData, setFormData] = useState<RegisterJobSeeker>({
        firstName: (roleData as RegisterJobSeeker)?.firstName || "",
        middleName: (roleData as RegisterJobSeeker)?.middleName || "",
        lastName: (roleData as RegisterJobSeeker)?.lastName || "",
        gender: (roleData as RegisterJobSeeker)?.gender || "",
        birthDate: (roleData as RegisterJobSeeker)?.birthDate
            ? new Date((roleData as RegisterJobSeeker).birthDate)
            : new Date()
    });

    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        const { id, value } = e.target;
        setFormData(prev => ({
            ...prev,
            [id]: id === "birthDate" ? new Date(value) : value
        }));
    };

    const handleButton = (newStep: number) => {
        if (newStep < registerForm.currentStep) {
            updateRegisterForm({ currentStep: newStep });
            updateRoleData(formData);
            return;
        }
        setErrors({});
        const validationData = {
            ...formData,
        };
            const result = personalDetailsSchema.safeParse(validationData);

            if (!result.success) {
                const newErrors = result.error.errors.reduce((acc, error) => {
                    const fieldName = error.path[0] as keyof PersonalDetailsErrors;
                    return {
                        ...acc,
                        [fieldName]: error.message
                    };
                }, {} as PersonalDetailsErrors);

                setErrors(newErrors);
            } else {
                updateRegisterForm({ currentStep: newStep });
                updateRoleData(formData);
            }
    }

    return (
        <>
            <InputGroup>
                <DefaultInputDiv
                    onChange={handleInputChange}
                    value={formData.firstName}
                    label="First Name"
                    id="firstName"
                    type="text"
                    error={errors.firstName}
                    required
                />
                <DefaultInputDiv
                    onChange={handleInputChange}
                    value={formData.middleName}
                    label="Middle Name"
                    id="middleName"
                    type="text"
                    error={errors.middleName}
                />
            </InputGroup>

            <InputGroup>
                <DefaultInputDiv
                    onChange={handleInputChange}
                    value={formData.lastName}
                    label="Last Name"
                    id="lastName"
                    type="text"
                    error={errors.lastName}
                    required
                />
                <DefaultInputDiv
                    onChange={handleInputChange}
                    value={formData.gender}
                    label="Gender"
                    id="gender"
                    type="select"
                    error={errors.gender}
                    required
                    options={[
                        { value: "", label: "Select Gender", disabled: true },
                        { value: "Male", label: "Male" },
                        { value: "Female", label: "Female" }
                    ]}
                />
            </InputGroup>

            <DefaultInputDiv
                onChange={handleInputChange}
                value={formData.birthDate?.toString()}
                id="birthDate"
                label="Birthdate"
                type="date"
                error={errors.birthDate}
                required
            />

            <ButtonsGroup
                onClick={handleButton}
                currentStep={registerForm.currentStep}
            />
        </>
    );
};

export default PersonalDetails;