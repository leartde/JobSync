import api from "../../utils/api.ts";

const DeleteBookmark = async(jobSeekerId: string, jobId: string) => {
    const url = `/jobseekers/${jobSeekerId}/bookmarks/${jobId}`;
    try {
        const response = await api.delete(url);
        if (response.status === 200) return true;
    } catch (error) {
        console.error("Error deleting bookmark:", error);
    }
    return false;
}

export default DeleteBookmark;