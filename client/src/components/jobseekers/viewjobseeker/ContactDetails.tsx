import React from 'react';
import { FaFemale, FaMailBulk, FaMale } from "react-icons/fa";
import { FaAddressBook, FaPhone } from "react-icons/fa6";
import { JobSeeker } from "../../../types/jobseeker/JobSeeker.ts";
import { User } from "../../../types/authentication/User.ts";
import { Link } from "react-router-dom";


type ContactDetailsProps = {
    profile: JobSeeker | undefined;
    user : User | null
}
const ContactDetails = ({profile, user}:ContactDetailsProps) => {
    return (
        <div className="flex flex-col p-8 w-1/2 text-white border border-gray-600 rounded-lg shadow-sm">
            <div className="w-full flex justify-between">
                <h1 className="text-white text-4xl font-semibold">
                    {profile?.firstName} {profile?.middleName} {profile?.lastName}
                </h1>
                <p className="text-4xl">
                    {profile?.gender.toLowerCase() === "male" ? <FaMale/> : <FaFemale/>}
                </p>
            </div>
            <div className="flex text-lg  justify-between  flex-col gap-4 mt-8 w-full">
                <div className="flex gap-4"><FaMailBulk/><p> {user?.email}</p></div>
                <div className="flex gap-4"><FaPhone/> <p>{profile?.phone}</p></div>
                <div className="flex gap-4"><FaAddressBook/> <p>{profile?.address}</p></div>
            </div>
            <div className="flex justify-start mt-4">
                <Link to="/profile-update" className="hover:bg-gray-900 bg-gray-800 text-white px-4 py-2 rounded-md">
                    Edit Contact Details
                </Link>
            </div>
        </div>
    );
};

export default ContactDetails;
