import { Address } from "../address/Address.ts";

export type RegisterJobSeeker = {
    UserId: string;
    FirstName: string;
    LastName: string;
    BirthDate: Date;
    Gender: string;
    Phone: string;
    SecondaryPhone?: string;
    Resume? : File;
    Address : Address;
    Skills : {name: string}[]
}