import React from 'react';
import { CiBookmark, CiShare2 } from 'react-icons/ci';
import { FaExternalLinkAlt } from 'react-icons/fa';

const StickyPreview = () => {
    return (
        <div className='border flex flex-col  bg-white sticky top-0  '>
             <img className='w-full h-full  rounded-md' src="https://d2q79iu7y748jz.cloudfront.net/s/_headerimage/1960x400/8a49f1a321d7b1562b38d0a6570f5630" alt="" />
             <img className='h-16 w-16 rounded-md absolute left-4 top-24' src='https://d2q79iu7y748jz.cloudfront.net/s/_squarelogo/256x256/900d48aaaffa96fadcdf784517d69dbd'/>
             <div className='mt-6  flex-col px-4'>
             <div className='flex flex-col'>
             <h1 className='font-semibold text-xl'>Crew Member</h1>
             <a className='underline  flex gap-1 items-center' href=""> <p>Chipotle </p><FaExternalLinkAlt /></a>
                <p>72 W 125th St, New York, NY 10027</p>
                <p>$17 - $18 an hour - Part-time, Full-time</p>
                
             </div>
                <div className='flex p-2 gap-2'>
                <button className='text-white flex items-center gap-2 h-12 text-md font-medium  bg-red-500  px-4 rounded-lg'>
                    Apply Now <FaExternalLinkAlt className='text-sm' />
</button>
      <div className='bg-[#E4E2E0] cursor-pointer rounded-xl h-12 w-12 flex items-center justify-center'><CiBookmark className='font-semibold text-2xl'/></div>
      <div className='bg-[#E4E2E0] cursor-pointer rounded-xl h-12 w-12 flex items-center justify-center'><CiShare2  className='font-semibold text-2xl'/></div>

                </div>
             </div>
            </div>
    );
}

export default StickyPreview;
