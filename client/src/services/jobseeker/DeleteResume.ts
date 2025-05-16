import api from "../../utils/api.ts";

const DeleteResume = async(id: string) => {
    try {
        const url = `/jobseekers/${id}/resume`;
        return await api.delete(url);
    } catch (e) {
        console.error("Error deleting resume:", e);
    }
}

export default DeleteResume;