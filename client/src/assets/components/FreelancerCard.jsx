import React from "react";
import { ArrowDown } from "lucide-react";

const FreelancerCard = ({ freelancer }) => {
  return (
    <div className="relative w-full max-w-xl p-6  flex flex-col items-center justify-center">
      {/* Top profile info */}
      
      {/* <div className="relative mt-6 flex items-center justify-center">
        {/* Left product images */}
        {/* <div className="flex flex-col gap-2 mr-4">
          {freelancer.products.slice(0, 2).map((img, idx) => (
            <img
              key={idx}
              src={img}
              alt=""
              className="w-16 h-16 rounded-lg object-cover shadow"
            />
          ))}
        </div> */} 

        {/* Main freelancer image */}
        <img
          src={freelancer.image}
          alt={freelancer.name}
          className="w-[350px] h-[350px] object-cover"
        />

        {/* Right product images */}
        {/* <div className="flex flex-col gap-2 ml-4">
          {freelancer.products.slice(1, 3).map((img, idx) => (
            <img
              key={idx}
              src={img}
              alt=""
              className="w-16 h-16 rounded-lg object-cover shadow"
            />
          ))}
        </div> */}
      </div>  
  );
};

export default FreelancerCard;
