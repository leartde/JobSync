import React from "react";
import {FaArrowRight, FaBars, FaBell, FaHouse, FaPerson, FaSuitcase, FaUser } from "react-icons/fa6";

const Navbar = () => {
    const [open, setOpen] = React.useState(false);
    return (
        <nav className="sticky bg-black top-0 w-[90%] flex mx-auto  justify-between gap-4   border-red-100 border-b  p-4">
            
            <ul className="flex  text-md space-x-12 text-white max-md:hidden">
                <li><a  href="#">Job<span
                    className="text-red-500 under">Sync </span></a></li>
                <li><a href="#">Home</a></li>
                <li><a href="#">Companies</a></li>
                <li><a href="#">Help</a></li>
            </ul>

            <div className="flex  gap-6  items-center">

                <div className="text-white  text-2xl p-1 rounded-lg hover:text-red-500 hover:bg-red-300 cursor-pointer ">
                    <FaBell/>
                </div>
                <div className=" text-white p-1 text-2xl rounded-lg hover:text-red-500 hover:bg-red-300 cursor-pointer ">
                    <FaUser/>
                </div>
            </div>

            <div className="w-full flex  justify-between space-x-12 text-white md:hidden">
                <p><a href="#">Job<span
                    className="text-red-500 ">Sync </span></a></p>
                <div className="relative">
                    <div className="">
                        <button onClick={() => setOpen(!open)} className=" cursor-pointer"><FaBars/></button>

                    </div>
                    <div>
                        <div className={`absolute top-16 right-0 rounded-lg bg-gray-200  py-2 px-6  ${open ? 'block' : 'hidden'}`}>

                        <ul className=" flex flex-col  space-y-4 text-black">
                            <li className="hover:border-b-2  hover:border-red-500"><a className="flex justify-between gap-4" href="#">Home <FaHouse/></a></li>
                                <li className="hover:border-b-2 hover:border-red-500"><a className="flex justify-between gap-4" href="#"> Companies <FaSuitcase /></a></li>
                            <li className="hover:border-b-2 hover:border-red-500"><a className="flex justify-between gap-4" href="#">Help <FaUser/></a></li>
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
