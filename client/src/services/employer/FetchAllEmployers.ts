import { EmployerParameters } from "../../types/employer/EmployerParameters.ts";
import axios from "axios";
import { ResponseHeaders } from "../../types/ResponseHeaders.ts";
import { Employer } from "../../types/employer/Employer.ts";
import { EmployerResponse } from "../../types/employer/EmployerResponse.ts";

const FetchAllEmployers = async (
    {SearchTerm, Industry, PageSize, PageNumber, OrderBy} : EmployerParameters
) => {
    try {
        const baseUrl = import.meta.env.VITE_API_BASE_URL;
        let url = `${baseUrl}/employers?`;

        if (PageSize && PageSize > 0) {
            url += `PageSize=${PageSize}`;
        }
        if (SearchTerm && SearchTerm.trim() !== "") {
            url += `&SearchTerm=${SearchTerm}`;
        }
        if (Industry && Industry.trim() !== "") {
            url += `&Industry=${Industry}`;
        }
        if (OrderBy && OrderBy.trim() !== "") {
            url += `&OrderBy=${OrderBy}`;
        }
        if (PageNumber && PageNumber > 0) {
            url += `&PageNumber=${PageNumber}`;
        }

            const response = await axios.get(url);
        if (response.status === 200) {
            const headers = response.headers["x-pagination"];
            const parsedHeader : ResponseHeaders = JSON.parse(headers);
            const employers: Employer[] = response.data;
            const data : EmployerResponse =  {
                employers: employers,
                headers: parsedHeader
            }
          return data

        } else {
            const response = await axios.get(url);
            console.log(url)
            console.error("Error fetching employers: ", response.statusText);
        }
    } catch (e) {

        console.error("Error fetching employers: ", e);
    }
};



export default FetchAllEmployers;