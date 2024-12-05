import React from "react";
import {FaArrowRight, FaBars, FaHouse, FaSuitcase, FaUser } from "react-icons/fa6";

const Navbar = () => {
    const [open, setOpen] = React.useState(false);
    return (
        <nav className="sticky bg-black top-0 w-[90%] flex mx-auto  flex-row gap-4 text-2xl  border-red-100 border-b-2  p-4">
            <ul className="flex flex-row space-x-12 text-white max-md:hidden">
                <li><a  href="#">Job<span
                    className="text-red-500 under">Sync </span></a></li>
                <li><a href="#">Home</a></li>
                <li><a href="#">Employers</a></li>
                <li><a href="#">Profile</a></li>
            </ul>

            <div className="w-full flex flex-row justify-between space-x-12 text-white md:hidden">
                <p><a href="#">Job<span
                    className="text-red-500 ">Sync </span></a></p>
                <div className="relative">
                    <div className="">
                        <button onClick={() => setOpen(!open)} className=" cursor-pointer"><FaBars/></button>

                    </div>
                    <div>
                        <div className={`absolute top-16 right-0 rounded-lg bg-gray-200  py-2 px-6  ${open ? 'block' : 'hidden'}`}>

                        <ul className=" flex flex-col space-y-4 text-black">
                            <li className="hover:border-b-2  hover:border-red-500"><a className="flex justify-between gap-4" href="#">Home <FaHouse/></a></li>
                                <li className="hover:border-b-2 hover:border-red-500"><a className="flex justify-between gap-4" href="#">Employers <FaSuitcase /></a></li>
                            <li className="hover:border-b-2 hover:border-red-500"><a className="flex justify-between gap-4" href="#">Profile <FaUser/></a></li>
                            <li className="hover:border-b-2 hover:border-red-500"><a className="flex justify-between gap-4" href="#">Logout <FaArrowRight/></a></li>

                        </ul>
                    </div>
                    </div>
                </div>


            </div>

        </nav>
    );
};

export default Navbar;
