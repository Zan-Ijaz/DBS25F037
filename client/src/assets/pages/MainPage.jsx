import React, { useState } from "react";
import { Search, ArrowRight } from "lucide-react";
import "../css/MainPage.css";

const MainPage = () => {
  const [menuOpen, setMenuOpen] = useState(false);

  const toggleMenu = () => setMenuOpen(!menuOpen);

  return (
    <div className="mx-4 mt-2 bg-emerald-300 main-containner rounded-2xl sm:px-10">
      {/* Navbar */}
      <nav className="py-4">
        <div className="flex items-center justify-between">
          {/* Logo */}
          <h4>SkillHub
          </h4>

          {/* Desktop Nav Links */}
          <ul className="hidden gap-8 text-sm font-medium text-black md:flex">
            <li><a href="#">Home</a></li>
            <li><a href="#">Find Freelancer</a></li>
            <li><a href="#">Find Jobs</a></li>
            <li><a href="#">Contact Us</a></li>
          </ul>

          {/* Desktop Buttons */}
          <div className="items-center hidden gap-3 md:flex">
            <button className="px-4 py-1 text-black border border-black rounded-full hover:bg-gray-100">Login</button>
            <button className="px-4 py-1 text-white bg-black rounded-full hover:bg-gray-800">Join Us</button>
          </div>

          {/* Hamburger (Mobile) */}
          <button onClick={toggleMenu} className="text-black md:hidden">
            {menuOpen ? (
              <svg xmlns="http://www.w3.org/2000/svg" className="w-6 h-6" fill="none" stroke="currentColor" strokeWidth={2}>
                <path strokeLinecap="round" strokeLinejoin="round" d="M6 18L18 6M6 6l12 12" />
              </svg>
            ) : (
              <svg xmlns="http://www.w3.org/2000/svg" className="w-6 h-6" fill="none" stroke="currentColor" strokeWidth={2}>
                <path strokeLinecap="round" strokeLinejoin="round" d="M4 6h16M4 12h16M4 18h16" />
              </svg>
            )}
          </button>
        </div>

        {/* Mobile Menu */}
        <div className={`md:hidden ${menuOpen ? "block" : "hidden"} transition-all duration-300`}>
          <ul className="flex flex-col items-center gap-4 py-4 text-black bg-gray-100">
            <li><a href="#">Home</a></li>
            <li><a href="#">Find Freelancer</a></li>
            <li><a href="#">Find Jobs</a></li>
            <li><a href="#">Contact Us</a></li>
          </ul>
          <div className="flex flex-col items-center gap-3 pb-4">
            <button className="px-4 py-1 text-black border border-black rounded-full hover:bg-gray-100">Login</button>
            <button className="px-4 py-1 text-white bg-black rounded-full hover:bg-gray-800">Join Us</button>
          </div>
        </div>
      </nav>

      {/* Heading */}
      <h1 className="text-[19vw] sm:text-[12vw] tracking-[0.9rem] font-black text-white leading-none text-center uppercase -m-9">
        FREELANCE
      </h1>

      {/* Hero Section */}
      <div className="flex flex-col-reverse items-center justify-between w-full py-6 md:flex-row hero-section">
        {/* Left CTA Section */}
        <div className="flex-1 space-y-6 my-14 fSection-CTA">
          {/* Search Bar */}
          <div className="flex items-center w-full max-w-md px-2 py-2 bg-white border border-gray-300 rounded-full shadow-sm">
            <Search className="w-5 h-5 ml-3 text-gray-500" />
            <input
              type="text"
              placeholder="Search for any service..."
              className="flex-1 px-3 py-2 text-gray-700 bg-transparent outline-none"
            />
            <button className="px-4 py-3 text-white bg-black rounded-full">
              <ArrowRight className="w-4 h-4" />
            </button>
          </div>

          {/* Popular Skills */}
          <div className="flex flex-wrap items-center gap-2">
            <p className="font-medium text-gray-800">Popular Skills:</p>
            {["Web Dev", "Graphic Design", "Database"].map((skill, i) => (
              <button
                key={i}
                className="px-3 py-1 text-sm text-gray-700 bg-white border border-gray-200 rounded-full hover:bg-gray-100"
              >
                {skill}
              </button>
            ))}
          </div>

          {/* Description */}
          <p className="max-w-xl text-lg text-gray-700">
            A freelance service web portal connects businesses with freelancers, facilitating project collaboration and hiring.
          </p>

          {/* Trusted Freelancers Card */}
          <div className="flex items-center gap-5 p-7 shadow-lg bg-[#F3FCFB] rounded-2xl w-[440px] ml-8">
            <div>
              <p className="font-medium text-black">Trusted Freelancers</p>
              <div className="flex mt-7">
                {["SirNazeef", "zain", "saad", "MYA", "fiza", "hanan", "abdullah"].map((name, i) => (
                  <img
                    key={i}
                    src={`images/${name}.jpeg`}
                    alt={name}
                    className="w-12 h-12 -ml-5 border-2 border-white rounded-full first:ml-0"
                  />
                ))}
              </div>
            </div>
            <div className="ml-5 text-left">
  <div className="flex gap-1 text-sm text-orange-500">
    <span>⭐</span>
    <span>⭐</span>
    <span>⭐</span>
    <span>⭐</span>
    <span>⭐</span>
  </div>
  <p className="mt-3 font-bold">200+</p>
  <p className="mt-2 text-sm">Satisfied Customers</p>
</div>

          </div>
        </div>

        {/* Right Hero Image */}
        <div className="relative flex-1 sSection-CTA">
          {/* <img
            src="images/hero.png"
            className="w-[300px] sm:w-[400px] md:w-[500px] lg:w-[580px] mx-auto md:absolute bottom-0"
            alt="hero"
          /> */}
        </div>
      </div>
    </div>
  );
};

export default MainPage;
