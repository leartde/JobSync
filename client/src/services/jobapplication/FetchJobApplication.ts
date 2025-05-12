import api from "../../utils/api.ts";

const FetchJobApplication = async (jobId : string, jobSeekerId: string) => {
    const url = `/jobapplications/${jobId}/${jobSeekerId}`;
    try {
        const response = await api.get(url);
        if(response.status === 200)return response.data;
    } catch  {
        return false;
    }
}

export default FetchJobApplication;