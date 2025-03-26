export type JobParameters = {
    JobType?: string | null;
    SearchTerm?: string | null;
    HasMultipleSpots?: boolean | null;
    IsTakingApplications?: boolean;
    OrderBy?: string | null;
    PageSize?: number;
    PageNumber?: number;
};