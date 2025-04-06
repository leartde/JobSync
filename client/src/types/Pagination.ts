import { ResponseHeaders } from "./ResponseHeaders.ts";

export type PaginationProps = {
    headers: ResponseHeaders;
    updateParameters: (params: { PageNumber: number }) => void;


};
