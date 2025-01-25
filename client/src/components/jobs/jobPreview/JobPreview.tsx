
import StickyPreview from './StickyPreview';
import JobPreviewSkills from './JobPreviewSkills';
import JobPreviewLocation from './JobPreviewLocation';
import JobPreviewDetails from './JobPreviewDetails';
import JobPreviewBenefits from './JobPreviewBenefits';
import JobPreviewDescription from './JobPreviewDescription';

type jobProps = {
    title: string;
    type: string;
    employer: string;
    address: string;
    pay: string;
    image: string;
    skills: string[];
    description: string;
    benefits : string[]
}

const JobPreview = ({ title, type, description, employer, address, pay, image, skills, benefits } : jobProps) => {
    return (
        <div className='flex w-1/2 max-h-[600px]  bg-gray-50 flex-col  rounded-md max-md:hidden overflow-scroll'>

            {/* //STICKY PREVIEW */}
            <StickyPreview image={image}  title={title} type={type} employer={employer}  address={address} pay={pay}/>


        {/* SKILLS SECTION */}
        
       <JobPreviewSkills skills={skills}/>

        {/* DETAILS SECTION */}
          <JobPreviewDetails pay={pay} jobType={type} />

        {/* LOCATION SECTION */}
        <JobPreviewLocation address={address}/>



        {/* BENEFITS SECTION */}
        <JobPreviewBenefits benefits={benefits}/>

        {/* FULL DESCRIPTION */}
          <JobPreviewDescription description={description}/>


            

        </div>
    );
}
export default JobPreview;
