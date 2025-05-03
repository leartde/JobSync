import { Address } from "../address/Address.ts";

export type RegisterJobSeeker = {
    userId?: string;
    firstName?: string;
    middleName?: string;
    lastName?: string;
    birthDate?: Date;
    gender?: string;
    phone?: string;
    secondaryPhone?: string;
    resume? : File;
    address? : Address;
    skills? : string[];
}