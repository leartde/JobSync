import api from "../../utils/api.ts";

const CreateBookmark = async (jobSeekerId:string,jobId:string)=>{
    const url = `/jobseekers/${jobSeekerId}/bookmarks/${jobId}`;
    try{
        const res = await api.post(url);
        if (res.status === 200)return true;
    }
    catch (error){
        console.error("Error creating bookmark:", error);
    }
}

export default CreateBookmark;