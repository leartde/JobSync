import React from "react";
type DefaultInputDivProps = {
    label: string;
    id: string;
    type: string;
    options?: { value: string;
        label: string;
        disabled?: boolean
    }[];
}

 export const CustomForm = ({ children,title }) => {
    return <form className="w-full flex flex-col gap-2 items-start p-2" action="">
        <legend className="text-md font-semibold">
            {title}
        </legend>
        {children}</form>;
 };

export const MultiStepFormWrapper = ({ children, role, currentStep, steps,title }) => {
    return (
        <div className="mx-auto w-1/2 md:w-2/3 xl:w-1/3 rounded-md mt-16 flex flex-col items-center bg-white p-6">
            <h1 className="text-xl font-bold text-black mb-4">
                Register as {role.startsWith('e') ? 'an' : 'a'} <span className="text-red-500">{role}</span>
            </h1>
            <div className="w-full">
                <CustomForm title={title}>
                    {children}
                </CustomForm>
                <p className="float-right text-md text-red-500">{currentStep}/{steps}</p>

            </div>
        </div>
    )
}

export const DefaultInputDiv = ({ label, id, type, options,size }: DefaultInputDivProps) =>{
    return (
        <div className={`flex flex-col ${
            size === "small"
                ? "w-full md:w-1/5"
                : size === "big"
                    ? "w-full md:w-3/4"
                    : "w-full md:w-1/2"
        }`}>

            <label className="text-sm" htmlFor={id}>
                {label}
            </label>
            {(type === "text" || type === "email" || type === "birthday" || type === "password" || type === "date") && (
                <input
                    className="px-1 border border-gray-400 outline-none"
                    id={id}
                    name={id}
                    type={type}
                />
            )
            }
            {type === "select" &&
                <select className="border border-gray-400 outline-none px-1">
                    {options?.map((option, index) => (
                        <option key={index} disabled={option.disabled} value={option.value}>
                            {option.label}
                        </option>
                    ))}
                </select>
            }
        </div>
    )

}


export const InputGroup = ({ children, size="default" }) => {
    return (
        <div className={`w-full flex max-md:flex-col ${size === "small" ? "justify-start gap-6" : "justify-between gap-2 mt-2"}`}>
            {children}
        </div>
    );
};






export const StepButton = ({ direction, currentStep, onClick,buttonType }) => {
    return (
        <button type={buttonType}
                onClick={onClick}
                className={`${currentStep < direction?'bg-red-500':'bg-blue-500'} text-white py-1 w-20 text-md text-center font-medium px-4 rounded-lg`}>

            {currentStep < direction?
                currentStep != 4?"Next":"Finish"
                :"Back"}
        </button>
    )
}

export const ButtonsGroup = ({ currentStep, onClick,buttonType ="button" }) => {
    return (
        <div className="flex gap-2 relative top-4">
            <StepButton
                buttonType = "button"
                onClick={() => onClick(currentStep > 1 ?currentStep - 1:null)}
                currentStep={currentStep}
                direction={currentStep - 1}
            />
            <StepButton
                buttonType = {buttonType}
                onClick={() => onClick(currentStep + 1)}
                currentStep={currentStep}
                direction={currentStep + 1}
            />
        </div>
    )
}


