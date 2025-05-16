import React from 'react';

const AddressUpdate = () => {
    return (
        <div className="flex flex-start p-4 md:w-2/3 xl:w-1/2 border border-gray-600 rounded-lg shadow-sm">
            <form className="flex flex-col gap-4" action="" method="POST">
                <legend className="font-semibold">Update personal details</legend>
                <div className="flex items-center">
                    <label htmlFor="firstName" className="w-1/3">First Name</label>
                    <input type="text" name="firstName" id="firstName"
                           className="w-2/3 bg-gray-800 text-white py-1 px-2 rounded-md"/>
                </div>
                <div className="flex items-center">
                    <label htmlFor="middleName" className="w-1/3">Middle Name</label>
                    <input type="text" name="middleName" id="middleName"
                           className="w-2/3 bg-gray-800 text-white py-1 px-2 rounded-md"/>
                </div>
                <div className="flex items-center">
                    <label htmlFor="lastName" className="w-1/3">Last Name</label>
                    <input type="text" name="lastName" id="lastName"
                           className="w-2/3 bg-gray-800 text-white py-1 px-2 rounded-md"/>
                </div>
                <div className="flex items-center">
                    <label htmlFor="phone" className="w-1/3">Phone Number</label>
                    <input type="text" name="phone" id="phone"
                           className="w-2/3 bg-gray-800 text-white py-1 px-2 rounded-md"/>
                </div>
                <div className="flex items-center">
                    <label htmlFor="address" className="w-1/3">Gender</label>
                    <select className="w-2/3 bg-gray-800 text-white py-1 px-2 rounded-md">
                        <option>---</option>
                        <option>Male</option>
                        <option>Female</option>
                    </select>
                </div>
                <div className="flex items-center">
                    <label htmlFor="birhdate" className="w-1/3">Birthday</label>
                    <input type="date" name="birthday" id="birthday"
                           className="w-2/3 bg-gray-800 text-white py-1 px-2 rounded-md"/>
                </div>
                <div className="flex">
                    <button className="bg-red-500 px-8 py-1 rounded-md">
                        Save
                    </button>
                </div>
            </form>
        </div>
    );
};

export default AddressUpdate;
