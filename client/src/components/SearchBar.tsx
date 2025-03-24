import React, { useState } from 'react';
import { FaMapPin, FaSistrix } from 'react-icons/fa6';
import { useJobParametersContext } from "../hooks/useJobParametersContext.tsx";
import { JobParameters } from "../services/job/FetchAllJobs.ts";

const SearchBar = () => {
    const { updateJobParameters } = useJobParametersContext();
    const [searchTerm, setSearchTerm] = useState<string>('');
    const handleSubmit = (e) => {
        e.preventDefault();
        updateJobParameters({
            SearchTerm: searchTerm
        })
    }

    return (
        <div className="flex p-4 text-gray-900 justify-center w-[80%] border-b-2 mx-auto border-white mt-8 items-center space-x-4">
            <form onSubmit={handleSubmit} className='bg-white max-md:flex-col max-md:p-2  max-xl:w-2/3 w-2/3  px-2 items-center flex rounded-lg'>
                <div className='w-full rounded-lg justify-start flex items-center p-2'>
                    <FaSistrix className='text-2xl' />
                    <input
                        value={searchTerm}
                        onChange={(e) => setSearchTerm(e.target.value)}
                        type="text"
                        placeholder="Job title,company or address"
                        className='outline-none bg-transparent p-2'
                    />
                </div>
                <button type="submit" className='text-white bg-red-500 py-2 px-4 rounded-lg'>
                    Search
                </button>
            </form>
        </div>
    );
}

export default SearchBar;