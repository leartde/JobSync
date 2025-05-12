import api from "../../utils/api.ts";

const CreateJobApplication = async (jobSeekerId:string,jobId:string)=>{
    const url = `/jobseekers/${jobSeekerId}/applications/${jobId}`;
    try {
        const response = await api.post(url);
        console.log("Job application created successfully:", response.data);
        return response.data;
    } catch (error) {
        console.error("Error creating job application:", error);
        throw error;
    }
}

export default CreateJobApplication;