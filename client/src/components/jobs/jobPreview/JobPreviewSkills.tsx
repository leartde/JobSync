import React from 'react';
import { FaCheck, FaRegLightbulb } from 'react-icons/fa6';


type JobPreviewSkillsProps = {
    skills: string[];

}
const JobPreviewSkills = ({skills}: JobPreviewSkillsProps) => {
    return (
        <div className='flex flex-col p-6 border border-gray-300'>
            <h2 className='text-base font-medium'>Profile insights</h2>
            <p className='text-xs text-gray-600'>You have <span className='text-green-900 font-semibold'> matching skills</span> based on your profile and the job description</p>
            <div className="flex mt-3 gap-2 items-center">
            <FaRegLightbulb className='text-22xk' />
            <p className='font-medium '>Skills</p>
            </div>
            <div className="flex gap-2">
                {skills.map((skill)=>(
                    <div className="flex p-2 items-center gap-2 font-semibold bg-green-100 border rounded-md border-green-200 text-green-900 text-sm">

                    <FaCheck/>
                    <span>{skill}</span>
                    </div>

                    ))}


            </div>

        </div>
    );
}

export default JobPreviewSkills;
