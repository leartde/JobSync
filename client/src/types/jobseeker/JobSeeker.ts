export type JobSeeker = {
    id: string;
    userId?: string;
    firstName: string;
    lastName: string;
    phone: string;
    secondaryPhone?: string;
    address: string;
    gender: string;
    photoUrl?: string;
    resumeUrl?: string;

}