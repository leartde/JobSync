import { z } from "zod";
const ALLOWED_FILE_TYPES = [
    'application/pdf',
    'application/msword',
    'application/vnd.openxmlformats-officedocument.wordprocessingml.document'
];
export const QualificationsSchema = z.object({
    resume: z.instanceof(File)
        .refine(file => file.size <= 5 * 1024 * 1024, {
            message: "File size must be less than 5MB"
        })
        .refine(file => ALLOWED_FILE_TYPES.includes(file.type), {
            message: "Only PDF and Word documents (.pdf, .doc, .docx) are allowed"
        })
        .optional()
        .or(z.literal(undefined))
        ,
    skills: z.array(z.string().regex(/^[a-zA-Z0-9 ]+$/, "Skill must contain only letters, numbers, and spaces"))
        .max(20,"You can add a maximum of 20 skills")

});
