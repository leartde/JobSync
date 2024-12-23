import React from 'react';
import { FaMailBulk } from 'react-icons/fa';
import { FaLock } from 'react-icons/fa6';

const Authentication = () => {
    return (
        <div className='mx-auto w-3/4 md:w-1/3 lg:w-1/4 rounded-md mt-16 flex flex-col items-center bg-white py-12 px-6'>
            <h1 className='text-2xl font-bold text-black'>LOGIN</h1>
            <div className=' bg-white w-full'>
                <form className='flex p-4 gap-4 flex-col' action="">
                    <div className='flex p-2  bg-gray-300 items-center gap-2 rounded-md'>

<FaMailBulk className='text-white'/>
<input className='bg-gray-300 outline-none w-full' type="text"  placeholder='Email' />
                    </div>
                    <div className='flex p-2 bg-gray-300 items-center gap-2 rounded-md'>

<FaLock className='text-white'/>
<input className='w-full bg-gray-300 outline-none' type="text"  placeholder='Password' />
                    </div>
                    <div className=' mt-1 max-sm:flex-col max-sm:items-start flex gap-1'>
                    <input  type='checkbox' id='remember' name='remember'/>
                    <label  htmlFor="remember">Remember Me</label>
                    </div>
                    <button className='text-white h-12 text-md text-center font-medium  bg-red-500  px-4 rounded-lg'>
                        Login</button>
                        <div className='relative top-6'>
                               <p>Click <span className='text-blue-600'> <a href="/register">here</a> </span> to register instead.</p>
                        </div>
 
                </form>

            </div>
        </div>
    );
}

export default Authentication;
