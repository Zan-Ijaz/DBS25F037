import React from "react";
import Navbar from "../components/Navbar";  
import HeroSection from "../components/HeroSection";  
import InfiniteScroll from "../components/InfiniteScroll"; 

const IndexPage = () => {
  return (
    <div>
      <Navbar />
      <HeroSection />
      <InfiniteScroll />
    </div>
  );
};

export default IndexPage;
