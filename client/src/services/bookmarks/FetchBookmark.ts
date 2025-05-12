import api from "../../utils/api.ts";

const FetchBookmark = async (jobSeekerId: string, jobId:string) => {
    const url = `/jobseekers/${jobSeekerId}/bookmarks/${jobId}`;
    try {
        const response = await api.get(url);
        if (response.status === 200) return response.data;
    } catch {
        return false;
    }
}

export default FetchBookmark;