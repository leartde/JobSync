import { useRegisterFormContext } from "../../hooks/authentication/useRegisterFormContext.ts";
import { ButtonsGroup, DefaultInputDiv, MultiStepFormWrapper } from "./jobseeker/FormComponents.tsx";
import { useState } from "react"; // Import useState

const UserRegistration = () => {
    const {  updateRegisterForm,userData, updateUserData } = useRegisterFormContext();
    const [formData, setFormData] = useState({
        email: userData.email,
        password: "",
        confirmPassword: ""
    });

    const handleButton = (newStep: number) => {
        updateRegisterForm({ currentStep: newStep });
        updateUserData({
            email: formData.email,
            password: formData.password
        });
    }

    const handleInputChange = (e) => {
        const { id, value } = e.target;
        setFormData(prev => ({
            ...prev,
            [id]: value
        }));
    }

    return (
        <>
            <DefaultInputDiv
                onChange={handleInputChange}
                label="Email"
                id="email"
                type="email"
                value={formData.email}
            />
            <DefaultInputDiv
                onChange={handleInputChange}
                label="Password"
                id="password"
                type="password"
                value={formData.password}
            />
            <DefaultInputDiv
                onChange={handleInputChange}
                label="Confirm Password"
                id="confirmPassword"
                type="password"
                value={formData.confirmPassword}
            />
            <ButtonsGroup onClick={handleButton} currentStep={1} />

</>    );
}

export default UserRegistration;