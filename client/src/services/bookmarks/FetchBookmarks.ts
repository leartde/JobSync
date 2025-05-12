import api from "../../utils/api.ts";

const FetchBookmarks = async(jobSeekerId: string) => {
    const url = `/jobseekers/${jobSeekerId}/bookmarks`;
    try{
        const res = await api.get(url);
        if (res.status == 200)return res.data;
    }
    catch {
        return false;
    }
}

export default FetchBookmarks;