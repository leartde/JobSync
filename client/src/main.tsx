import  { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.tsx'
import {RouterProvider, createBrowserRouter } from 'react-router-dom'
import HomePage from './pages/HomePage.tsx'
import Authentication from './pages/Authentication.tsx'
import Registration from './pages/Registration.tsx'
import JobSeekerRegistration from './components/authentication/JobSeekerRegistration.tsx'
import Employers from "./pages/Employers.tsx";
import ViewEmployer from "./pages/ViewEmployer.tsx";

const router = createBrowserRouter([
    {
        path : '/',
        element : <App />,
        children : [
          {
            path : '/',
            element : <HomePage/>
          },
            {
                path :"/employers",
                element: <Employers/>
            },
            {
                path : '/employers/:id',
                element: <ViewEmployer/>
            },
            {
            path: '/login',
            element: <Authentication/>
          },
          {
            path: '/register',
            element: <Registration/>
          },
          {
            path :'/register/jobseeker',
            element : <JobSeekerRegistration/>
          }
        ]
    }
])

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <RouterProvider router={router}/>
  </StrictMode>,
)
