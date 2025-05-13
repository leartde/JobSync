import React, { useEffect, useState } from 'react';
import { useAuth } from "../../hooks/authentication/useAuth.ts";
import FetchJobSeeker from "../../services/jobseeker/FetchJobSeeker.ts";
import { JobSeeker } from "../../types/jobseeker/JobSeeker.ts";
import ContactDetails from "../../components/jobseekers/viewjobseeker/ContactDetails.tsx";
import ResumeLink from "../../components/jobseekers/viewjobseeker/Resume.tsx";
import Skills from "../../components/jobseekers/viewjobseeker/Skills.tsx";

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
        <div className=" text-white px-4 mt-8 w-full flex flex-col items-center justify-center gap-8 py-4">
            <ContactDetails profile={profile} user={user}/>
            <ResumeLink id={user?.id} resumeName={profile?.resumeName} resumeLink={profile?.resumeLink} />

            <Skills />
        </div>

    );
};

export default ViewJobSeeker;
