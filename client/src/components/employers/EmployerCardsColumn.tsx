import React from 'react';
import { Employer } from "../../types/employer/Employer.ts";
import EmployerCard from "./EmployerCard.tsx";
type EmployerCardsColumnProp = {
    employers: Employer[]
}
const EmployerCardsColumn = ({employers}:EmployerCardsColumnProp) => {
    return (
        <div className="mt-8  w-3/4 flex flex-col items-center gap-6 ">
            {
                employers.map((employer: Employer) => (
                    <EmployerCard employer={employer} onClick={()=>null} key={employer.id}/>
                ))
            }
        </div>
    );
};

export default EmployerCardsColumn;
