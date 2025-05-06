export type User = {
    id: string;
    email: string;
    password?: string;
    role: "jobseeker" | "employer" | "admin";
    createdAt?: Date;
    emailConfirmed?: boolean;

}