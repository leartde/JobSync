import React, { useEffect, useState } from 'react';
import { RegisterJobSeeker } from "../../../types/jobseeker/RegisterJobSeeker.ts";
import { JobSeeker } from "../../../types/jobseeker/JobSeeker.ts";
import { User } from "../../../types/authentication/User.ts";
import UpdateJobSeeker from "../../../services/jobseeker/UpdateJobSeeker.ts";
import { toast } from "react-toastify";

type PersonalDetailsUpdateProps = {
    user: User | null,
    profile : JobSeeker | undefined
}
const PersonalDetailsUpdate = ({profile, user}:PersonalDetailsUpdateProps) => {
    const [formData,setFormData] = useState<RegisterJobSeeker>({
    });
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        setFormData({
            firstName: profile?.firstName,
            middleName: profile?.middleName,
            lastName: profile?.lastName,
            phone: profile?.phone,
            gender: profile?.gender,
            birthDate: profile?.birthday,
            file: new File([],""),
        })
    }, [profile]);
    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setFormData(prev => ({
            ...prev,
            [name]: value
        }));
    }

    const handleSubmit = async (e) => {
        e.preventDefault();
        setLoading(true);
        const result = await UpdateJobSeeker(user?.id ?? "", formData);
        if (result.status === 200)toast.success("Profile updated successfully");
        else toast.error("Error updating profile");
        setLoading(false);
    }

    return (
        <div className="flex flex-start p-4 md:w-2/3 xl:w-1/2 border border-gray-600 rounded-lg shadow-sm">
            {loading && (
                <div className="fixed text-black inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50">
                    <div className="bg-white p-8 rounded-lg shadow-lg text-center">
                        <p className="mt-4">Updating your profile...</p>
                    </div>
                </div>
            )}
            <form onSubmit={handleSubmit} className="flex flex-col gap-4" action="" method="POST">
                <legend className="font-semibold">Update personal details</legend>
                <div className="flex items-center">
                    <label htmlFor="firstName" className="w-1/3">First Name</label>
                    <input value={formData.firstName} onChange={handleInputChange} type="text" name="firstName" id="firstName"
                           className="w-2/3 bg-gray-800 text-white py-1 px-2 rounded-md"/>
                </div>
                <div className="flex items-center">
                    <label htmlFor="middleName" className="w-1/3">Middle Name</label>
                    <input value={formData.middleName} onChange={handleInputChange} type="text" name="middleName" id="middleName"
                           className="w-2/3 bg-gray-800 text-white py-1 px-2 rounded-md"/>
                </div>
                <div className="flex items-center">
                    <label htmlFor="lastName" className="w-1/3">Last Name</label>
                    <input value={formData.lastName} onChange={handleInputChange} type="text" name="lastName" id="lastName"
                           className="w-2/3 bg-gray-800 text-white py-1 px-2 rounded-md"/>
                </div>
                <div className="flex items-center">
                    <label htmlFor="phone" className="w-1/3">Phone Number</label>
                    <input value={formData.phone} onChange={handleInputChange} type="text" name="phone" id="phone"
                           className="w-2/3 bg-gray-800 text-white py-1 px-2 rounded-md"/>
                </div>
                <div className="flex items-center">
                    <label htmlFor="address" className="w-1/3">Gender</label>
                    <select value={formData.gender} onChange={handleInputChange} className="w-2/3 bg-gray-800 text-white py-1 px-2 rounded-md">
                        <option value="" disabled>---</option>
                        <option value="male">Male</option>
                        <option value="female">Female</option>
                    </select>
                </div>
                <div className="flex items-center">
                    <label htmlFor="birhdate" className="w-1/3">Birthday</label>
                    <input onChange={handleInputChange} value={formData.birthDate?.toString()} type="date" name="birthday" id="birthday"
                           className="w-2/3 bg-gray-800 text-white py-1 px-2 rounded-md"/>
                </div>
                <div className="flex">
                    <button className="hover:bg-red-400 bg-red-500 px-8 py-1 rounded-md">
                        Save
                    </button>
                </div>
            </form>
        </div>
    );
};

export default PersonalDetailsUpdate;
