export type RegisterUser = {
    email: string;
    password: string;
    role: "jobseeker" | "employer" | null;
}