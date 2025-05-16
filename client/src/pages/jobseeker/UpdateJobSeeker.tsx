import React, { useEffect } from 'react';
import PersonalDetailsUpdate from "../../components/jobseekers/updatejobseeker/PersonalDetailsUpdate.tsx";
import FetchJobSeeker from "../../services/jobseeker/FetchJobSeeker.ts";
import { useAuth } from "../../hooks/authentication/useAuth.ts";
import { JobSeeker } from "../../types/jobseeker/JobSeeker.ts";

const UpdateJobSeeker = () => {
    const { user } = useAuth();
    const [profile, setProfile] = React.useState<JobSeeker>();
    useEffect(() => {
        const fetchJobSeekerData = async () => {
            const profile = await FetchJobSeeker(user?.id ?? "");
            setProfile(profile);
        }
        fetchJobSeekerData().then()
    }, [user]);
    return (
        <div className="text-white px-4 mt-8 mx-auto flex flex-col w-full md:w-2/3 gap-8 py-4">
            <PersonalDetailsUpdate user={user} profile={profile}/>

            {/*<AddressUpdate/>*/}
        </div>
    );
};

export default UpdateJobSeeker;
