import { Outlet } from 'react-router-dom';
import './App.css'
import Navbar from "./components/Navbar.tsx";

function App() {

  return (
      <>
          <Navbar/>
          <div className="border-4 bg-blue-100 border-white mt-12 space-y-12  w-[90%] p-6  mx-auto ">
              <div className="text-2xl border-2 border-black p-4 text-white ">Aaaaaa</div>
              <div className="text-2xl border-2 border-black p-4 text-white">Aaaaaa</div>
              <div className="text-2xl border-2 border-black p-4 text-white">Aaaaaa</div>
              <div className="text-2xl border-2 border-black p-4 text-white">Aaaaaa</div>
              <div className="text-2xl border-2 border-black p-4 text-white">Aaaaaa</div>
              <div className="text-2xl border-2 border-black p-4 text-white">Aaaaaa</div>
              <div className="text-2xl border-2 border-black p-4 text-white">Aaaaaa</div>
              <div className="text-2xl border-2 border-black p-4 text-white">Aaaaaa</div>
              <div className="text-2xl border-2 border-black p-4 text-white">Aaaaaa</div>
              <div className="text-2xl border-2 border-black p-4 text-white">Aaaaaa</div>
          </div>


          <Outlet/>
      </>


  )

}

export default App
