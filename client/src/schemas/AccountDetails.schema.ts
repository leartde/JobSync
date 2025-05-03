import { z } from "zod";

export const AccountDetailsSchema = z.object({
    email: z.string().email("Invalid email address"),
    password: z
        .string()
        .min(10, "Password must be at least 8 characters")
        .regex(/[a-zA-Z]/, "Password must contain at least one letter")
        .regex(/[0-9]/, "Password must contain at least one number"),

  confirmPassword : z.string()
}).refine(
    (data) => data.password === data.confirmPassword,
    {
        message: "Passwords don't match",
        path: ["confirmPassword"]
    }
);