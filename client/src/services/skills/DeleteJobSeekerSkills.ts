import api from "../../utils/api.ts";

const DeleteJobSeekerSkill = async (jobSeekerId: string, skillId: string) => {
    const url = `/jobseekers/${jobSeekerId}/skills/${skillId}`;
    try {
        const response = await api.delete(url);
        if (response.status === 200) return true;
    } catch (error) {
        console.error("Error deleting job seeker skills:", error);
    }
    return false;
}

export default DeleteJobSeekerSkill;
