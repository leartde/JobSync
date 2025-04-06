import React, { useEffect, useState } from 'react';
import FetchAllEmployers from "../services/employer/FetchAllEmployers.ts";
import { EmployerResponse } from "../types/employer/EmployerResponse.ts";
import EmployerCardsColumn from "../components/employers/EmployerCardsColumn.tsx";
import { Employer } from "../types/employer/Employer.ts";
import { EmployerParametersProvider } from "../context/employers/EmployerParametersContext.tsx";
import { useEmployerParametersContext } from "../hooks/employers/useEmployerParametersContext.ts";
import EmployerSearch from "../components/employers/employerFilters/EmployerSearch.tsx";
import { useEmployerResponseHeadersContext } from "../hooks/employers/useEmployerResponseHeadersContext.ts";
import { EmployerResponseHeadersProvider } from "../context/employers/EmployerResponseHeadersContext.tsx";
import EmployersPagination from "../components/employers/employerFilters/EmployersPagination.tsx";

const EmployersPageContent = () => {
    const [employers,setEmployers] = useState<Employer[]>([]);
    const { employerParameters } = useEmployerParametersContext();
    const { updateHeaders } = useEmployerResponseHeadersContext();
       useEffect(() => {
            const getData = async () => {
                try{
                    const data : EmployerResponse = await FetchAllEmployers(employerParameters);
                    if (data?.employers){
                        setEmployers(data.employers);
                        updateHeaders(data.headers);
                    }
                }
                catch (e){
                    console.error("Error fetching employers: ", e);
                }

            }
            getData().then();
        }, [employerParameters.PageNumber,employerParameters.PageSize, employerParameters.SearchTerm]);

    return (
            <div className="flex flex-col items-center">
                <EmployerSearch/>
                <EmployerCardsColumn employers={employers}/>
                <EmployersPagination/>
            </div>
    );
};

const EmployersPage = () => {
    return (
        <EmployerParametersProvider>
            <EmployerResponseHeadersProvider>
                <EmployersPageContent/>
            </EmployerResponseHeadersProvider>
        </EmployerParametersProvider>
    )
}

export default EmployersPage;
