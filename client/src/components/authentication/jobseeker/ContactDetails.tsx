import React, { useState } from 'react';
import { useRegisterFormContext } from "../../../hooks/authentication/useRegisterFormContext.ts";
import {
    ButtonsGroup,
    DefaultInputDiv,
    InputGroup,
    MultiStepFormWrapper,
} from "./FormComponents.tsx";
import { RegisterJobSeeker } from "../../../types/jobseeker/RegisterJobSeeker.ts";
import { Address } from "../../../types/address/Address.ts";

const ContactDetails = () => {
    const { registerForm, updateRegisterForm, roleData, updateRoleData } = useRegisterFormContext();

    const initialAddress = (roleData as RegisterJobSeeker)?.Address || {
        street: "",
        city: "",
        country: "",
        state: "",
        region: "",
        zipCode: 0
    };

    const [address, setAddress] = useState<Address>(initialAddress);
    const [phone, setPhone] = useState<string>((roleData as RegisterJobSeeker)?.Phone || "");



    const handleAddressChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        const { id, value } = e.target;
        setAddress(prev => ({
            ...prev,
            [id]: id === 'zipCode' ? Number(value) || 0 : value
        }));
    };

    const handlePhoneChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setPhone(e.target.value);
    };

    const handleButton = (newStep: number) => {
        updateRegisterForm({ currentStep: newStep });
        updateRoleData({
            Address: address,
            Phone: phone
        });
    };

    return (
        <>
            <DefaultInputDiv
                onChange={handleAddressChange}
                value={address.country}
                size="default"
                label="Country"
                id="country"
                type="select"
                options={[
                    { value: "", label: "---", disabled: true },
                    { value: "US", label: "United States" },
                    { value: "CN", label: "Canada" },
                    { value: "UK", label: "United Kingdom" },
                    { value: "AUS", label: "Australia" }
                ]}
            />
            <DefaultInputDiv
                value={address.street}
                onChange={handleAddressChange}
                size="default"
                label="Street"
                id="street"
                type="text"
            />
            <InputGroup size="small">
                <DefaultInputDiv
                    value={address.city}
                    onChange={handleAddressChange}
                    size="small"
                    label="City"
                    id="city"
                    type="text"
                />
                <DefaultInputDiv
                    value={address.state}
                    onChange={handleAddressChange}
                    size="small"
                    label="State"
                    id="state"
                    type="text"
                />
                <DefaultInputDiv
                    value={address.zipCode.toString()}
                    onChange={handleAddressChange}
                    size="small"
                    label="ZIP Code"
                    id="zipCode"
                    type="text"
                />
            </InputGroup>
            <DefaultInputDiv
                value={phone}
                onChange={handlePhoneChange}
                size="default"
                label="Phone Number"
                id="phone"
                type="text"
            />

            <ButtonsGroup
                onClick={handleButton}
                currentStep={registerForm.currentStep}
            />
        </>
    );
};

export default ContactDetails;