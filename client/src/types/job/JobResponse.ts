import { Job } from "./Job.ts";
import { JobResponseHeaders } from "./JobResponseHeaders.ts";

export type JobResponse = {
    jobs: Job[];
    headers: JobResponseHeaders;
}