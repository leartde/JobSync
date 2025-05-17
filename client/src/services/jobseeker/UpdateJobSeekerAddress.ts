import { Address } from "../../types/address/Address.ts";
import api from "../../utils/api.ts";

const UpdateJobSeekerAddress = async(id: string, address: Address) => {
    try {
        const formData = new FormData();
        formData.append("Street", address.street ?? "");
        formData.append("City", address.city ?? "");
        formData.append("State", address.state ?? "");
        formData.append("Country", address.country ?? "");
        formData.append("ZipCode", address.zipCode.toString() ?? "" );
        const url = `/jobseekers/${id}/address`;
        return await api.put(url, formData);
    } catch (e) {
        console.error("Error updating job seeker address:", e);
    }
}

export default UpdateJobSeekerAddress;