import api from "../../utils/api.ts";

const CreateJobSeekerSkills = async(jobSeekerId: string, skills: string[]) => {
    const url = `/jobseekers/${jobSeekerId}/skills`;
    try {
        const response = await api.post(url,skills );
        if (response.status === 200) return response;
    } catch (error) {
        console.error("Error creating job seeker skills:", error);
    }
}

export default CreateJobSeekerSkills;

