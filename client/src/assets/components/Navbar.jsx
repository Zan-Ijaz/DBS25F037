import React, { useState } from "react";
import { Search, Menu, X } from "lucide-react";

const Navbar = () => {
  const [menuOpen, setMenuOpen] = useState(false);

  return (
    <nav className="w-full py-4 px-6 bg-white sticky top-0 z-50">
      <div className="flex justify-between items-center">
        {/* Logo */}
        <div className="flex items-center space-x-2">
          <span className="text-xl font-bold">SkillHub</span>
        </div>

        {/* Desktop Links */}
        <ul className="hidden md:flex space-x-6 font-medium text-gray-700">
          <li className="hover:text-green-600 cursor-pointer">Home</li>
          <li className="hover:text-green-600 cursor-pointer">Find Talent</li>
          <li className="hover:text-green-600 cursor-pointer">Works</li>
          <li className="hover:text-green-600 cursor-pointer">About Us</li>
          <li className="hover:text-green-600 cursor-pointer">Contact Us</li>
        </ul>

        {/* Search Bar */}
        <div className="hidden md:flex items-center w-[270px] h-[40px] border border-gray-300 rounded-md overflow-hidden">
          <input
            type="text"
            placeholder="Search..."
            className="w-full h-full text-sm px-3 outline-none transition-all duration-200 hover:z-10 hover:border hover:border-black hover:rounded-md"
          />
          <div className="h-[60%] w-px bg-gray-300 mx-[2px]" />
          <button className="h-full px-3 py-1 flex items-center justify-center transition-all duration-200 hover:z-10 hover:border hover:border-black hover:rounded-md">
            <Search className="text-gray-500 h-4 w-4 hover:text-black" />
          </button>
        </div>

        {/* Buttons */}
        <div className="hidden md:flex space-x-4">
          <button className="text-sm px-4 py-1 border border-green-600 text-green-600 rounded-full hover:bg-green-50">
            Login
          </button>
          <button className="text-sm px-4 py-1 bg-green-600 text-white rounded-full hover:bg-green-700">
            Join Us
          </button>
        </div>

        {/* Mobile Toggle */}
        <div className="md:hidden">
          <button onClick={() => setMenuOpen(!menuOpen)}>
            {menuOpen ? <X className="w-6 h-6" /> : <Menu className="w-6 h-6" />}
          </button>
        </div>
      </div>

      {/* Mobile Menu */}
      {menuOpen && (
        <div className="md:hidden mt-4 space-y-4">
          <ul className="space-y-2 font-medium text-gray-700">
            <li>Home</li>
            <li>Find Talent</li>
            <li>Works</li>
            <li>About Us</li>
            <li>Contact Us</li>
          </ul>

          <div className="flex flex-col gap-3 mt-4">
            <div className="flex items-center border border-gray-300 rounded-2xl px-3 py-1">
              <input
                type="text"
                placeholder="Search..."
                className="w-full focus:outline-none text-sm"
              />
              <Search className="text-gray-500 h-4 w-4" />
            </div>

            <button className="text-sm px-4 py-2 border border-green-600 text-green-600 rounded-full hover:bg-green-50">
              Login
            </button>
            <button className="text-sm px-4 py-2 bg-green-600 text-white rounded-full hover:bg-green-700">
              Join Us
            </button>
          </div>
        </div>
      )}
    </nav>
  );
};

export default Navbar;
