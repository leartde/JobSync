import React from 'react';

const JobPreviewBenefits = () => {
    return (
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
    );
}

export default JobPreviewBenefits;
