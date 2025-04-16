import { RegisterFormContext } from "../../context/authentication/RegisterFormContext.tsx";
import { useContext } from "react";

export const useRegisterFormContext = () => {
    const context = useContext(RegisterFormContext);
    if (context == undefined) {
        throw new Error("useRegisterFormContext must be used within a RegisterFormProvider");
    }
    return context;
}