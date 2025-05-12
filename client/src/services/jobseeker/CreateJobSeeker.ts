import { RegisterJobSeeker } from "../../types/jobseeker/RegisterJobSeeker";
import api from "../../utils/api.ts";

type CreateJobSeekerProps = {
    email: string;
    password: string;
    role: string;
    jobSeeker: RegisterJobSeeker;
};

const CreateJobSeeker = async ({ email, password, jobSeeker, role }: CreateJobSeekerProps) => {
    try {
        const formData = new FormData();

        formData.append("Email", email);
        formData.append("Password", password);
        formData.append("Role", role);

        formData.append("JobSeeker.FirstName", jobSeeker.firstName || "");
        formData.append("JobSeeker.MiddleName", jobSeeker.middleName || "");
        formData.append("JobSeeker.LastName", jobSeeker.lastName || "");
        formData.append("JobSeeker.Gender", jobSeeker.gender || "");
        const birthday = jobSeeker.birthDate ? new Date(jobSeeker.birthDate) : new Date();
        const formattedBirthday = `${birthday.getFullYear()}-${String(birthday.getMonth()+1).padStart(2, '0')}-${String(birthday.getDate()).padStart(2, '0')}`;

        formData.append("JobSeeker.BirthDate", formattedBirthday);

        formData.append("JobSeeker.Address.Street", jobSeeker.address?.street || "");
        formData.append("JobSeeker.Address.City", jobSeeker.address?.city || "");
        formData.append("JobSeeker.Address.ZipCode", jobSeeker.address?.zipCode?.toString() || "");

        const skills = Array.isArray(jobSeeker.skills) ? jobSeeker.skills : [];

        skills.forEach(skill => {
            formData.append('JobSeeker.Skills', skill);
        });

        if (jobSeeker?.resume) {
            formData.append("JobSeeker.Resume", jobSeeker.resume);
        }

        const url = `/authentication/register/jobseeker`;

        return await api.post(url, formData);

    } catch (e) {
        console.error("Error adding job seeker:", e);
    }
};

export default CreateJobSeeker;
