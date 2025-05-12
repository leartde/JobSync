import api from "../../utils/api.ts";

const FetchJobSeekerApplications = async(jobSeekerId: string) =>{
    const url = `/jobseekers/${jobSeekerId}/applications`;
    try{
        const res = await api.get(url);
        if (res.status == 200)return res.data;
    }
    catch (e){
        console.error(e);
    }
}

export default FetchJobSeekerApplications;