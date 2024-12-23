import React from "react";
import { useNavigate } from "react-router-dom";

const JobSeekerRegistration = () => {
  const navigate = useNavigate();
  const [country, setCountry] = React.useState("");
  const changeCountry = (e: {
    target: { value: React.SetStateAction<string> };
  }) => {
    setCountry(e.target.value);
  };
  return (
    <div className="mx-auto w-1/2 md:w-2/3 xl:w-1/3 rounded-md mt-16 flex flex-col items-center bg-white p-6">
      <h1 className="text-xl font-bold text-black mb-4">
        Register as a <span className="text-red-500">job seeker</span>
      </h1>
      <div className=" w-full  ">
        <form className="w-full flex flex-col gap-2 items-start p-2" action="">
          <legend className="text-md font-semibold">
            Personal Information
          </legend>
          <div className="flex w-full max-md:flex-col justify-between gap-2 mt-2">
            <div className="max-md:w-full w-1/2 flex flex-col">
              <label className="text-sm" htmlFor="firstname ">
                First Name*
              </label>
              <input
                className=" border border-gray-400 rounded-sm outline-none"
                id="firstname"
                type="text"
              />
            </div>

            <div className=" max-md:w-full w-1/2 flex flex-col">
              <label className="text-sm" htmlFor="middlename ">
                Middle Name
              </label>
              <input
                className="border border-gray-400 outline-none"
                name="middlename"
                id="middlename"
                type="text"
              />
            </div>
          </div>
          <div className="w-full flex flex-col">
            <label className="text-sm" htmlFor="lastname ">
              Last Name*
            </label>
            <input
              className="border border-gray-400 outline-none"
              name="middlename"
              id="middlename"
              type="text"
            />
          </div>

          <div className="max-md:w-full flex flex-col">
            <label className="text-sm" htmlFor="lastname ">
              Country*
            </label>
            <select
              onChange={changeCountry}
              className="border border-gray-400 outline-none"
              name="country"
              id="country"
            >
              <option value="" disabled>
                Select a country
              </option>
              <option value="US">United States</option>
              <option value="CN">Canda</option>
              <option value="UK">United Kingdom</option>
              <option value="AUS">Australia</option>
            </select>
          </div>

          <div className="max-md:w-full flex flex-col w-3/4">
            <label className="text-sm" htmlFor="lastname ">
              Street Address*
            </label>
            <input
              className="border border-gray-400 w-full outline-none"
              name="street"
              id="street"
              type="text"
            />
          </div>
          <div className="w-full flex max-md:flex-col justify-start gap-6">
            <div className="flex flex-col md:w-1/5">
              <label className="text-sm" htmlFor="middlename ">
                City*
              </label>
              <input
                className="border border-gray-400 outline-none"
                name="middlename"
                id="middlename"
                type="text"
              />
            </div>
            {country == "US" && (
              <div className="w-full flex flex-col md:w-1/5 ">
                <label className="text-sm" htmlFor="middlename ">
                  State
                </label>
                <input
                  className="border border-gray-400 outline-none"
                  name="middlename"
                  id="middlename"
                  type="text"
                />
              </div>
            )}
            <div className="flex flex-col md:w-1/5">
              <label className="text-sm" htmlFor="middlename ">
                Zip*
              </label>
              <input
                className="border border-gray-400 outline-none"
                name="middlename"
                id="middlename"
                type="text"
              />
            </div>
          </div>
          <div className="flex gap-2 relative top-4">
            <button
              onClick={() => navigate("/register")}
              className="text-white py-1 w-20 text-md text-center font-medium  bg-blue-500  px-4 rounded-lg"
            >
              Back
            </button>
            <button type="button" className="text-white py-1 w-20 text-md text-center font-medium  bg-red-500  px-4 rounded-lg">
              Next
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default JobSeekerRegistration;
