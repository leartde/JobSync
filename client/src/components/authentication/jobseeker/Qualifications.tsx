import React from 'react';
import { useRegisterFormContext } from "../../../hooks/authentication/useRegisterFormContext.ts";
import { ButtonsGroup } from "./FormComponents.tsx";

const Qualifications = () => {
    const { registerForm, updateRegisterForm } = useRegisterFormContext();
    return (
        <div className="mx-auto w-1/2 md:w-2/3 xl:w-1/3 rounded-md mt-16 flex flex-col items-center bg-white p-6">
            <h1 className="text-xl font-bold text-black mb-4">
                Register as a <span className="text-red-500">job seeker</span>
            </h1>
            <div className="w-full">
                <form className="w-full flex flex-col gap-2 items-start p-2" action="">
                    <legend className="text-md font-semibold">
                        Skills and qualifications
                    </legend>
                    <div className="flex w-full max-md:flex-col justify-between gap-2 mt-2">
                        <div className="max-md:w-full w-1/2 flex flex-col">
                            <label className="text-sm" htmlFor="firstname">
                                Add a resume
                            </label>
                            <input
                                className="px-2 border border-gray-400 rounded-sm outline-none"
                                id="firstname"
                                type="file"
                            />
                        </div>
                    </div>



                    <ButtonsGroup  onClick={(newStep) => updateRegisterForm({ currentStep: newStep })} currentStep={4} buttonType="submit" >

                    </ButtonsGroup>
                </form>

            </div>
        </div>
    );
};

export default Qualifications;
