import StickyPreview from './StickyPreview';
import Skills from './Skills.tsx';
import Location from './Location.tsx';
import Details from './Details.tsx';
import Benefits from './Benefits.tsx';
import Description from './Description.tsx';

import { useMainJobContext } from "../../../hooks/useMainJobContext.ts";

const JobPreview = () => {
    const { mainJob } = useMainJobContext();
    return (
        <div id="preview" className='flex w-1/2 max-h-[600px]  bg-gray-50 flex-col max-md:w-full  rounded-md  overflow-scroll'>

            {/* //STICKY PREVIEW */}
            <StickyPreview image={mainJob?.imageUrl} title={mainJob?.title} type={mainJob?.type} employer={mainJob?.employer} address={mainJob?.address} pay={mainJob?.pay}/>

            {/* SKILLS SECTION */}
            <Skills skills={mainJob?.skills || []}/>

            {/* DETAILS SECTION */}
            <Details pay={mainJob?.pay} jobType={mainJob?.type} hasMultipleSpots = {mainJob?.hasMultipleSpots} />

            {/* LOCATION SECTION */}
            <Location address={mainJob?.address}/>

            {/* BENEFITS SECTION */}
            <Benefits benefits={mainJob?.benefits}/>

            {/* FULL DESCRIPTION */}
            <Description description={mainJob?.description}/>

        </div>
    );
}
export default JobPreview;
