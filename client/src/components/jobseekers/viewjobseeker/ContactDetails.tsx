import React from 'react';
import { FaMailBulk } from "react-icons/fa";
import { FaAddressBook, FaPhone } from "react-icons/fa6";
import { JobSeeker } from "../../../types/jobseeker/JobSeeker.ts";
import { User } from "../../../types/authentication/User.ts";


type ContactDetailsProps = {
    profile: JobSeeker | undefined;
    user : User | null
}
const ContactDetails = ({profile, user}:ContactDetailsProps) => {
    return (
        <div className="flex flex-col  p-8 w-1/2 text-white">
            <div className="flex w-full justify-between items-center">
                <h1 className="text-white text-4xl font-semibold">
                    {profile?.firstName} {profile?.middleName} {profile?.lastName}
                </h1>
                <div className="w-16 h-16 rounded-full bg-gray-400 px-2"></div>
            </div>
            <div className="flex text-lg  justify-between  flex-col gap-4 mt-8 w-full">
                <div className="flex gap-4"><FaMailBulk/><p> {user?.email}</p></div>
                <div className="flex gap-4"><FaPhone/> <p>{profile?.phone}</p></div>
                <div className="flex gap-4"><FaAddressBook/> <p>{profile?.address}</p></div>
            </div>
        </div>
    );
};

export default ContactDetails;
