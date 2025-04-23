import React, { useState, KeyboardEvent, useEffect } from 'react';
import { useRegisterFormContext } from "../../../hooks/authentication/useRegisterFormContext.ts";
import { RegisterJobSeeker } from "../../../types/jobseeker/RegisterJobSeeker.ts";

const SkillsInput = () => {
    const [inputValue, setInputValue] = useState('');
    const { roleData, updateRoleData } = useRegisterFormContext();
    const [skills, setSkills] = useState<string[]>((roleData as RegisterJobSeeker).Skills || []);

    const handleAddSkill = () => {
        if (inputValue.trim() && !skills.includes(inputValue.trim())) {
            setSkills(prevSkills => [...prevSkills, inputValue.trim()]);
            setInputValue('');
        }
    };

    const handleKeyDown = (e: KeyboardEvent<HTMLInputElement>) => {
        if (e.key === 'Enter') {
            e.preventDefault();
            handleAddSkill();
        }
    };

    const handleSkillClick = (index: number) => {
        setSkills(prevSkills => prevSkills.filter((_, i) => i !== index));
    };

    useEffect(() => {
        updateRoleData({ Skills: skills });
    }, [skills]);

    return (
        <div className="flex flex-col gap-4 w-full">
            <div className="flex flex-col w-full md:w-1/2">
                <label className="text-sm mb-1" htmlFor="skill">
                    Add some skills
                </label>
                <input
                    className="px-2 py-1 border border-gray-400 rounded outline-none focus:border-blue-500"
                    id="skill"
                    name="skill"
                    type="text"
                    maxLength={35}
                    value={inputValue}
                    onChange={(e) => setInputValue(e.target.value)}
                    onKeyDown={handleKeyDown}
                />
            </div>

            <div className="w-full min-h-20 border border-gray-300 rounded p-3 flex flex-wrap gap-2">
                {skills.length > 0 ? (
                    skills.map((skill, index) => (
                        <div
                            key={index}
                            className="max-h-8 px-3 py-1 bg-gray-100 rounded-full cursor-pointer hover:bg-gray-200 transition-colors"
                            onClick={() => handleSkillClick(index)}
                        >
                            <span className="2 text-sm">{skill}</span>
                        </div>
                    ))
                ) : (
                    <p className="text-gray-400 text-sm">No skills added yet</p>
                )}
            </div>
            {skills.length > 0 &&
                <button
                    onClick={() => setSkills([])}
                    className="self-start text-sm text-white bg-gray-600 p-1 rounded-md"
                >
                    Clear all
                </button>
            }
        </div>
    );
};

export default SkillsInput;