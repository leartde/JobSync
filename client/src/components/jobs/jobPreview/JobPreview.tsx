
import StickyPreview from './StickyPreview';
import JobPreviewSkills from './JobPreviewSkills';
import JobPreviewLocation from './JobPreviewLocation';
import JobPreviewDetails from './JobPreviewDetails';
import JobPreviewBenefits from './JobPreviewBenefits';
import JobPreviewDescription from './JobPreviewDescription';

const JobPreview = () => {
    return (
        <div className='flex w-1/2 max-h-[600px]  bg-gray-50 flex-col  rounded-md max-md:hidden overflow-scroll'>

            {/* //STICKY PREVIEW */}
            <StickyPreview/>


        {/* SKILLS SECTION */}
        
       <JobPreviewSkills/>

        {/* DETAILS SECTION */}
          <JobPreviewDetails/>

        {/* LOCATION SECTION */}
        <JobPreviewLocation/>



        {/* BENEFITS SECTION */}
        <JobPreviewBenefits/>

        {/* FULL DESCRIPTION */}
          <JobPreviewDescription/>


            

        </div>
    );
}

export default JobPreview;
