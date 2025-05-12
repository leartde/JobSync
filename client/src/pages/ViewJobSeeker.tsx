import React, { useEffect, useState } from 'react';
import { useAuth } from "../hooks/authentication/useAuth.ts";
import FetchJobSeeker from "../services/jobseeker/FetchJobSeeker.ts";
import { JobSeeker } from "../types/jobseeker/JobSeeker.ts";
import { FaMailBulk } from "react-icons/fa";
import { FaAddressBook, FaPhone } from "react-icons/fa6";
import { Link } from "react-router-dom";
import ContactDetails from "../components/jobseekers/viewjobseeker/ContactDetails.tsx";
import ResumeLink from "../components/jobseekers/viewjobseeker/Resume.tsx";
import Skills from "../components/jobseekers/viewjobseeker/Skills.tsx";

const ViewJobSeeker = () => {
    const { user } = useAuth();
    const [profile, setProfile] = useState<JobSeeker>();
    useEffect(() => {
        const fetchJobSeekerData = async () => {
            const profile = await FetchJobSeeker(user?.id ?? "");
            setProfile(profile);
        }
        fetchJobSeekerData().then()
    }, [user]);
    return (
        <div className=" text-white  px-4  mt-8 w-full flex flex-col items-center justify-center  py-4">
            {/*CONTACT DETAILS*/}
            <ContactDetails profile={profile} user={user}/>

            {/*RESUME*/}
            <ResumeLink resumeLink={profile?.resumeLink} />

            {/*SKILLS*/}
            <Skills skills={profile?.skills} />

            {/*UPDATE*/}

                <Link to="/update-profile" className="bg-red-500 text-white px-4 py-2 rounded-md">Update your profile</Link>
        </div>

    );
};

export default ViewJobSeeker;
