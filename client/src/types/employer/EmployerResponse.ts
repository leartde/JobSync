import { Employer } from "./Employer.ts";
import { ResponseHeaders } from "../ResponseHeaders.ts";

export type EmployerResponse = {
    employers: Employer[],
    headers: ResponseHeaders
}