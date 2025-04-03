import React, { useEffect, useState } from 'react';
import { useJobParametersContext } from "../../../hooks/useJobParametersContext.ts";
import { useSearchParams } from "react-router-dom";

const Filters = () => {
    const { jobParameters,updateJobParameters } = useJobParametersContext();
    const [isRemote, setIsRemote] = useState<boolean | null | undefined >();
    const [hasMultipleSpots,setHasMultipleSpots] = useState<boolean | null | undefined>();
    const [jobType, setJobType] = useState<string | null | undefined>();
    const [minimumPay, setMinimumPay] = useState<number | null | undefined>();
    const [, setSearchParams] = useSearchParams();

    useEffect(() => {
        setIsRemote(jobParameters.IsRemote);
        setHasMultipleSpots(jobParameters.HasMultipleSpots);
        setJobType(jobParameters.JobType);
        setMinimumPay(jobParameters.MinimumPay);
    }, [jobParameters.IsRemote]);
    const handleIsRemote = () => {
        setIsRemote(!isRemote);
        if(!isRemote){
            updateJobParameters({
                IsRemote: true,
                PageNumber : 1
            });
            setSearchParams(prev => {
                const newParams = new URLSearchParams(prev);
                newParams.set('isRemote', 'true');
                return newParams;
            })

        }
            else{
                updateJobParameters({
                    IsRemote: null,
                    PageNumber : 1
                })
        setSearchParams(prev => {
            const newParams = new URLSearchParams(prev);
            newParams.delete('isRemote');
            return newParams;
        })}
        }

        const handleHasMultipleSpots = () => {
            setHasMultipleSpots(!hasMultipleSpots);
            if (!hasMultipleSpots) {
                updateJobParameters({
                    HasMultipleSpots: true,
                    PageNumber : 1
                });
                setSearchParams(prev => {
                    const newParams = new URLSearchParams(prev);
                    newParams.set('hasMultipleSpots', 'true');
                    return newParams;
                })

            } else {
                updateJobParameters({
                    HasMultipleSpots: null,
                    PageNumber : 1
                })
                setSearchParams(prev =>{
                    const newParams = new URLSearchParams(prev);
                    newParams.delete('hasMultipleSpots');
                    return newParams;
                })
            }
        }

        const handleJobType = (e) => {
            setJobType(e.target.value);
            updateJobParameters({
                JobType: e.target.value,
                PageNumber : 1
            });
            setSearchParams(prev => {
                const newParams = new URLSearchParams(prev);
                if(e.target.value != null && e.target.value != ''){
                    newParams.set('jobType', e.target.value);
                }
                else{
                    newParams.delete('jobType');
                }
                return newParams;
            })
        };

      const handleMinimumPay = (e) => {
            setMinimumPay(parseInt(e.target.value));
            updateJobParameters({
                MinimumPay: parseInt(e.target.value),
                PageNumber : 1
            });
            setSearchParams(prev => {
                const newParams = new URLSearchParams(prev);
                if(e.target.value != null && e.target.value != ''){
                    newParams.set('minimumPay', e.target.value);
                }
                else{
                    newParams.delete('minimumPay');
                }
                return newParams;
            })
      }
    return (
        <div className="max-md:flex-col max-md:items-center flex justify-center gap-4 py-2 ">
            <div className="flex gap-4">
                <button
                    onClick={handleIsRemote}
                    className={` text-sm border rounded-xl ${isRemote?'text-[#e4e2e0] bg-gray-800':'bg-[#e4e2e0] text-gray-800'}  px-4 py-2`}>
                    Remote
                </button>
                <button
                    onClick={handleHasMultipleSpots}
                    className={` text-sm border rounded-xl ${hasMultipleSpots?'text-[#e4e2e0] bg-gray-800':'bg-[#e4e2e0] text-gray-800'}  px-4 py-2`}>
                Has Multiple Spots
                </button>
            </div>
            <div className="flex gap-4">
                <select
                    value={jobType ?? ""}
                    onChange={handleJobType}
                    className="text-sm  border rounded-xl bg-[#e4e2e0] text-gray-800 px-4 py-2" name="type"
                        id="type">
                    <option  value ="">Job Type</option>
                    <option  value="fullTime">Full Time</option>
                    <option value="partTime">Part Time</option>
                </select>
                <select
                    value={minimumPay ?? ""}
                    onChange={handleMinimumPay}
                    className="text-sm border rounded-xl bg-[#e4e2e0] text-gray-800 px-4 py-2" name="pay"
                        id="pay">
                    <option value="">Minimum Pay</option>
                    <option value="15">$15+/hour</option>
                    <option value="17.5">$17.5+/hour</option>
                    <option value="20">$20+/hour</option>
                    <option value="25">$25+/hour</option>
                    <option value="30">$30+/hour</option>
                </select>
            </div>
        </div>
    );
};

export default Filters;
