import React from 'react';
import {  FaMapPin, FaSistrix } from 'react-icons/fa6';

const SearchBar = () => {
    return (
        <div className="flex  p-4 text-gray-900 justify-center w-[80%] border-b-2 mx-auto border-white mt-8 items-center space-x-4">
            <form className=' bg-white max-md:flex-col max-md:py-2 max-md:w-full px-2 items-center flex rounded-lg'>
                     <div className='max-md:w-full rounded-lg  justify-start flex items-center p-2'>
                         <FaSistrix className='text-2xl' />
                         <input type="text" placeholder="Job title or company" className=' outline-none  bg-transparent p-2'/>

                     </div>
                     <div className='max-md:w-full rounded-lg   flex items-center p-2 '>
                         <FaMapPin className='text-2xl' />
                         <input type="text" placeholder="Address or 'remote'" className=' outline-none bg-transparent p-2'/>

                     </div>
                     
                        <button className='text-white  bg-red-500 py-2 px-4 rounded-lg'>
                            Search
                        </button>
                     </form>
            </div>
       
    );
}

export default SearchBar;
