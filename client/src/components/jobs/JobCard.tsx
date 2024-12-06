import { FaAlignJustify } from "react-icons/fa6";

const JobCard = () => {
    return (
        <div className="flex flex-col bg-white px-12 py-6 border border-gray-800 rounded-md">
            <div className="flex justify-between items-center">
                <h1 className="text-lg font-semibold">Crew Member</h1>
                <FaAlignJustify className="cursor-pointer" />
            </div>
            <div className="text-sm mt-1">
                <p>Chipotle</p>
                <p>New York, NY 10027(Harlem Area)</p>
            </div>
            <div className="text-xs text-gray-600">
                 Lorem ipsum dolor sit, amet consectetur adipisicing elit. Dolore quibusdam enim esse fuga fugiat vel perspiciatis.
            </div>
            <div className="border-t border-gray-800 mt-4 relative top-2 pt-4     ">
                <a href="">
                    <p className="text-sm text-blue-500 underline">View similar jobs with this employer</p>
                </a>

            </div>
        </div>
    );
}

export default JobCard;
