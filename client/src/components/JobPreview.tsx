import { CiBookmark, CiShare2 } from 'react-icons/ci';
import { FaExternalLinkAlt, FaRegLightbulb } from 'react-icons/fa';
import { FaCar, FaCashRegister, FaCheck, FaMapPin, FaMoneyBill } from 'react-icons/fa6';
import { PiMoneyLight, PiMoneyThin } from 'react-icons/pi';
import { RiSuitcaseLine } from 'react-icons/ri';
import { TbMapPin } from 'react-icons/tb';

const JobPreview = () => {
    return (
        <div className='flex w-1/2 max-h-[600px]  bg-gray-50 flex-col  rounded-md max-md:hidden overflow-scroll'>

            {/* //STICKY PREVIEW */}
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
      <div className='bg-[#E4E2E0] rounded-xl h-12 w-12 flex items-center justify-center'><CiBookmark className='font-semibold text-2xl'/></div>
      <div className='bg-[#E4E2E0] rounded-xl h-12 w-12 flex items-center justify-center'><CiShare2  className='font-semibold text-2xl'/></div>

                </div>
             </div>
            </div>


        {/* SKILLS SECTION */}
        <div className='flex flex-col p-6 border border-gray-300'>
            <h2 className='text-base font-medium'>Profile insights</h2>
            <p className='text-xs text-gray-600'>You have <span className='text-green-900 font-semibold'> matching skills</span> based on your profile and the job description</p>
            <div className="flex mt-3 gap-2 items-center">
            <FaRegLightbulb className='text-22xk' />
            <p className='font-medium '>Skills</p>
            </div>
            <div className="flex gap-2">
                <div className="flex p-2 items-center gap-2 font-semibold bg-green-100 border rounded-md border-green-200 text-green-900 text-sm">
                    
               <FaCheck/>
               <span>Cooking</span>
                </div>
                <div className="flex p-2 items-center gap-2 font-semibold bg-green-100 border rounded-md border-green-200 text-green-900 text-sm">
                    
               <FaCheck/>
               <span>Cooking</span>
                </div>
                <div className="flex p-2 items-center gap-2 font-semibold bg-green-100 border rounded-md border-green-200 text-green-900 text-sm">
                    
                    <FaCheck/>
                    <span>Cooking</span>
                     </div>

            </div>

        </div>


        {/* DETAILS SECTION */}
        <div className='flex flex-col p-6 border border-gray-300'>
            <h2 className='text-base font-medium'>Job Details</h2>
            <p className='text-xs text-gray-600'> Here's the job details that align with your profile. </p>
            <div className="flex mt-3 gap-2 items-center">
            <PiMoneyLight className='text-2xl' />
            <p className='font-medium '>Pay</p>
            </div>
            <div className="flex gap-2 ">
                <div className="flex p-2 items-center gap-2 font-semibold bg-green-100 border rounded-md border-green-200 text-green-900 text-sm">
                    
               <FaCheck/>
               <span>$18/hour</span>
                </div>

            </div>

            <div className="flex mt-3 gap-2 items-center">
            <RiSuitcaseLine className='text-2xl' />
            <p className='font-medium '>Job Type</p>
            </div>
            <div className="flex gap-2 ">
                <div className="flex p-2 items-center gap-2 font-semibold bg-green-100 border rounded-md border-green-200 text-green-900 text-sm">
                    
               <FaCheck/>
               <span>Full-Time</span>
                </div>

                <div className="flex p-2 items-center gap-2 font-semibold bg-green-100 border rounded-md border-green-200 text-green-900 text-sm">
                    
               <FaCheck/>
               <span>$18/hour</span>
                </div>

            </div>
            <div className='flex flex-col mt-4'>
                <p className='font-semibold text-md'>Encouraged to apply</p>
                <ul>
                    <li>16+ years old</li>
                    <li>16+ years old</li>
                </ul>

            </div>

        </div>

        {/* LOCATION SECTION */}
        <div className='flex flex-col gap-2 p-6 border border-gray-300'>
            <h2 className='text-base font-medium'>Location</h2>
            <div className="flex flex-col">
            <div className="flex text-sm gap-2 items-center">
                <FaCar/>
                <p className='font-semibold'>Estimated commute</p>

            </div>
              <p className='text-sm'>Over an hour from <a className='text-blue-700 underline' href="">503 Robin Dr.</a></p>
            </div>

            <div className="flex flex-col">
            <div className="flex text-sm gap-2 items-center">
                <TbMapPin className='text-lg'  />
                <p className='font-semibold'>Job Address</p>

            </div>
              <p className='text-sm'>72 W 125th St, New York, NY 10027</p>
            </div>

        </div>



        {/* BENEFITS SECTION */}
        <div className='flex flex-col gap-2 p-6 border border-gray-300'>
        <h2 className='text-base font-medium'>Benefits</h2>
        <ul className='list-disc px-4'>
            <li>Health Insurance</li>
            <li>Dental Insurance</li>
            <li>Opportunities for advancement</li>
            <li>Paid Holidays</li>
            <li>Paid Time Off</li>
        </ul>
        </div>

        {/* FULL DESCRIPTION */}
        <div className='flex flex-col gap-2 p-6 border border-gray-300'>
        <h2 className='text-base font-medium'>Full Description</h2>
        <p className='text-sm text-gray-600'>Lorem ipsum dolor sit, amet consectetur adipisicing elit. Cum ratione repudiandae optio maiores, magni aperiam ducimus qui explicabo numquam, iste ad sequi omnis eaque? Neque error atque quisquam earum nostrum. Labore voluptates itaque neque mollitia natus? Quo fugit voluptatibus, laudantium quas fuga ipsum laboriosam blanditiis sunt, cumque, dignissimos eos velit corrupti quod ea est pariatur. Sapiente ipsum a praesentium maiores exercitationem eveniet dolor cum! Officia natus, animi commodi perspiciatis esse sint eius quibusdam minus dignissimos architecto, optio facilis. Nesciunt expedita doloribus dolorum quo consequatur ducimus eveniet pariatur labore consectetur nemo quis hic soluta molestiae, nam quasi modi. Eligendi accusamus molestiae repudiandae sequi quisquam delectus dignissimos maxime, mollitia eos dicta velit ipsum quaerat vero autem odio vitae libero error temporibus. Dolores repudiandae eaque odit porro, corporis excepturi! Laboriosam alias doloremque vel culpa voluptatum animi doloribus rerum corporis omnis? Iusto, ullam. Aspernatur enim corporis maxime dolores, corrupti deserunt! Exercitationem nisi quisquam dolorem voluptates iure accusamus aut, necessitatibus ea, sint consequuntur molestiae harum laborum. Ipsum laboriosam ab in reprehenderit culpa optio recusandae quis animi necessitatibus fuga, provident cum, laborum deleniti iste maiores adipisci, laudantium nulla ea eveniet quidem mollitia nemo? Iure, deleniti ipsa. Iure animi unde beatae velit inventore deleniti quas error omnis.</p>
</div>


            

        </div>
    );
}

export default JobPreview;
