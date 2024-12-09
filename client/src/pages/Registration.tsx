import React from "react";
import { useMultistepForm } from "../hooks/useMultistepForm.ts";
import RoleSelection from "../components/authentication/RoleSelection.tsx";


const Registration = () => {

    const { steps, currentStepIndex } = useMultistepForm([]);

    return (
        <div
            className='mx-auto w-3/4 md:w-1/3 xl:w-1/4 rounded-md mt-16 flex flex-col items-center bg-white py-12 px-6'>

            <form action="">
                <RoleSelection/>
            </form>

        </div>
    );


}

export default Registration;
