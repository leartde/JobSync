import api from "../../utils/api.ts";

const DeleteJobApplication = async (jobSeekerId:string,jobId:string)=>{
    const url = `/jobseekers/${jobSeekerId}/applications/${jobId}`;
  try{
      const res = await api.delete(url);
      if (res.status === 200)return true;
  }
  catch (error){
        console.error("Error deleting job application:", error);
  }
}
export default DeleteJobApplication;
