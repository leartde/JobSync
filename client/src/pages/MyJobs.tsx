import React, {  useState } from 'react';
import Applications from "../components/jobseekers/savedjobs/Applications.tsx";
import Bookmarks from "../components/jobseekers/savedjobs/Bookmarks.tsx";

type TabSwitcherProps = {
    targetTab: string;
    currentTab: string;
    onClick: () => void;
};

const TabSwitcher = ({targetTab,currentTab,onClick}: TabSwitcherProps) => {
    return <button onClick={onClick}
                   className={`flex-1 text-center py-2 font-medium ${
                       currentTab === targetTab
                           ? "border-b-4 border-red-500 text-red-500"
                           : "text-gray-500 hover:text-red-500"
                   }`}
    >
        {targetTab === "applications" ? "Job Applications" : "Bookmarked Jobs"}
    </button>
}

const MyJobs = () => {
    const [currentTab, setCurrentTab] = useState("applications");


    return (
        <div className="flex flex-col p-8 mt-4 items-center">
            <div className="flex border-b border-gray-300 w-full max-w-md">
                <TabSwitcher targetTab="applications" currentTab={currentTab} onClick={() => setCurrentTab("applications")}/>
                <TabSwitcher targetTab="bookmarks" currentTab={currentTab} onClick={() => setCurrentTab("bookmarks")}/>
            </div>

            <div className="flex flex-col gap-4 mt-4 w-full max-w-md max-h-96 overflow-auto">
                {currentTab === "applications" && <Applications/>}
                {currentTab === "bookmarks" && <Bookmarks/>}
            </div>

        </div>
    );
};

export default MyJobs;