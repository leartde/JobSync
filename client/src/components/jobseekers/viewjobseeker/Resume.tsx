import React from 'react';
import { Link } from "react-router-dom";

type ResumeProps = {
    resumeLink? : string
}
const Resume = ({resumeLink}:ResumeProps) => {
    return (
        <div className="flex flex-col w-1/2 p-8 gap-4">
            <h2 className="text-white text-3xl font-semibold">Resume</h2>

            {resumeLink ? (
                    <div className="flex flex-col gap-2"><p className="text-white text-lg">Download your resume here</p>
                        <Link
                            to={resumeLink}
                            className="bg-red-500 w-1/3 text-white px-4 py-2 rounded-md">Download</Link></div>) :
                (<p className="text-white text-lg">You have not uploaded a resume yet</p>)}
        </div>
    );
};

export default Resume;
