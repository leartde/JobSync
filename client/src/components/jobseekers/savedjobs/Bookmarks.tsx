import React, { useEffect, useState } from 'react';
import { Link } from "react-router-dom";
import { FaTrash } from "react-icons/fa6";
import { Bookmark } from "../../../types/bookmark/Bookmark.ts";
import FetchBookmarks from "../../../services/bookmarks/FetchBookmarks.ts";
import { useAuth } from "../../../hooks/authentication/useAuth.ts";
import DeleteBookmark from "../../../services/bookmarks/DeleteBookmark.ts";

const Bookmarks = () => {
    const { user } = useAuth();
    const [bookmarks, setBookmarks] = useState<Bookmark[]>([]);
    useEffect(() => {
        const fetchBookmarkedJobs = async () => {
            const res = await FetchBookmarks(user?.id ?? "");
            setBookmarks(res);
        };
        fetchBookmarkedJobs().then();
    }, [user]);



    const DeleteTheBookmark = async (jobSeekerId:string, jobId: string) => {
        const res = await DeleteBookmark(jobSeekerId, jobId);
        if(res)setBookmarks(prev => prev.filter(app => app.jobId !== jobId));
    }

    return (
        <>
            {bookmarks.length > 0 ? (
                bookmarks.map((bookmark) => (
                    <div
                        key={bookmark.jobId}
                        className="p-2 border rounded-md shadow-sm text-white"
                    >
                        <Link to={`/?jobId=${bookmark.jobId}/employerId=${bookmark.employerId}`}
                              className="flex justify-between">
                            <p className="text-lg">{bookmark.job}</p>
                            <p className="text-sm">{bookmark.employer}</p>
                        </Link>
                        <div className="flex justify-end">
                            <button onClick={()=>DeleteTheBookmark(user?.id ?? "",bookmark.jobId)} className="text-red-500"> <FaTrash/> </button>
                        </div>
                    </div>
                ))
            ) : (
                <p className="text-gray-500">No bookmarked jobs found.</p>
            )}
        </>
    );
};

export default Bookmarks;
