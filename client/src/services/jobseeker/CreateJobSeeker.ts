import axios from "axios";
import { RegisterJobSeeker } from "../../types/jobseeker/RegisterJobSeeker";

type CreateJobSeekerProps = {
    email: string;
    password: string;
    role: string;
    addJobSeekerDto: RegisterJobSeeker;
};

const CreateJobSeeker = async ({ email, password, addJobSeekerDto, role }: CreateJobSeekerProps) => {
    try {
        const formData = new FormData();

        formData.append("Email", email);
        formData.append("Password", password);
        formData.append("Role", role);

        formData.append("AddJobSeekerDto.FirstName", addJobSeekerDto.FirstName || "");
        formData.append("AddJobSeekerDto.MiddleName", addJobSeekerDto.MiddleName || "");
        formData.append("AddJobSeekerDto.LastName", addJobSeekerDto.LastName || "");
        formData.append("AddJobSeekerDto.Gender", addJobSeekerDto.Gender || "");
        const birthday = addJobSeekerDto.BirthDate ? new Date(addJobSeekerDto.BirthDate) : new Date();
        const formattedBirthday = `${birthday.getFullYear()}-${String(birthday.getMonth()+1).padStart(2, '0')}-${String(birthday.getDate()).padStart(2, '0')}`;

        formData.append("AddJobSeekerDto.BirthDate", formattedBirthday);

        formData.append("AddJobSeekerDto.Address.Street", addJobSeekerDto.Address?.street || "");
        formData.append("AddJobSeekerDto.Address.City", addJobSeekerDto.Address?.city || "");
        formData.append("AddJobSeekerDto.Address.ZipCode", addJobSeekerDto.Address?.zipCode?.toString() || "");

        const skills = Array.isArray(addJobSeekerDto.Skills) ? addJobSeekerDto.Skills : [];

        skills.forEach(skill => {
            formData.append('AddJobSeekerDto.Skills', skill);
        });

        if (addJobSeekerDto?.Resume) {
            formData.append("AddJobSeekerDto.Resume", addJobSeekerDto.Resume);
        }

        const baseUrl = import.meta.env.VITE_API_BASE_URL;
        const url = `${baseUrl}/authentication/register/jobseeker`;

        const response = await axios.post(url, formData);

        console.log("Response from server:", response.data);
        return response.data;

    } catch (e) {
        console.error("Error adding job seeker:", e);
    }
};

export default CreateJobSeeker;
