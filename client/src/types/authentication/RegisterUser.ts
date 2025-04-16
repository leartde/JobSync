export type RegisterUser = {
    email: string;
    password: string;
    confirmPassword: string;
    role: "jobseeker" | "employer" | "admin";
}