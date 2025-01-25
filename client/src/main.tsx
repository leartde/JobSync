import  { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.tsx'
import {RouterProvider, createBrowserRouter } from 'react-router-dom'
import HomePage from './pages/HomePage.tsx'
import Authentication from './pages/Authentication.tsx'
import Registration from './pages/Registration.tsx'
import JobSeekerRegistration from './components/authentication/JobSeekerRegistration.tsx'
import fetchJob from "./services/job/FetchJob.ts";

const router = createBrowserRouter([
    {
        path : '/',
        element : <App />,
        children : [
          {
            path : '/jobs/:employerId/:jobId',
            element : <HomePage/>,
              loader :({params}) => fetchJob(params.employerId,params.jobId)
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
