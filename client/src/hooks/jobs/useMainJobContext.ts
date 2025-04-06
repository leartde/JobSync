import { useContext } from "react";
import { MainJobContext } from "../../context/jobs/MainJobContext.tsx";

export function useMainJobContext() {
    const context = useContext(MainJobContext);

    if (context === undefined) {
        throw new Error('useMainJobContext must be used with a MainJobProvider');
    }

    return context;
}