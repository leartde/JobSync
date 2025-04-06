import { Job } from "./Job.ts";
import { ResponseHeaders } from "../ResponseHeaders.ts";

export type JobResponse = {
    jobs: Job[];
    headers: ResponseHeaders;
}