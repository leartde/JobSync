import React from 'react';

type SkillsProps = {
    skills?: string[];
}
const Skills = ({skills}:SkillsProps) => {
    return (
        <div className="flex flex-col w-1/2 p-8 gap-4">
            <h2 className="text-white text-3xl font-semibold">Skills</h2>

            <ul className="list-disc list-inside">
                {skills?.map((skill, index) => (
                    <li key={index} className="text-white text-lg">{skill}</li>
                ))}
            </ul>
        </div>
    );
};

export default Skills;
