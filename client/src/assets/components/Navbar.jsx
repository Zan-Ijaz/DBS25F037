import React, { useState } from "react";
import { Search, Menu, X, Check } from "lucide-react";

const Navbar = () => {
  const [menuOpen, setMenuOpen] = useState(false);
  const [formOpen, setFormOpen] = useState(false);
  const [userName, setUserName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  

  const toggleForm = () => {
    setFormOpen(!formOpen);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
  
    const userData = {
      userName,
      email,
      password,
    };
  
    try {
      const res = await fetch("http://skillhub.runasp.net/api/Users/register", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(userData),
      });
  
      if (!res.ok) {
        const errorResponse = await res.json();
        alert(errorResponse.message); // Show error message if any
        return;
      }
  
      const result = await res.json();
      alert(result.message); // Display the success message
      setFormOpen(false); // Close form
      setUserName("");
      setEmail("");
      setPassword("");
    } catch (err) {
      console.error(err.message);
      alert("An error occurred while registering the user.");
    }
  };
  
  
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
          <button className="text-sm px-4 py-1 bg-green-600 text-white rounded-full hover:bg-green-700" onClick={() => setFormOpen(true)}>
            Join
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
            <button className="text-sm px-4 py-2 bg-green-600 text-white rounded-full hover:bg-green-700" onClick={toggleForm}>
              Join
            </button>
          </div>
        </div>
      )}
{formOpen && (
  <div className="fixed inset-0 z-50 bg-black bg-opacity-50 flex items-center justify-center">
    <div
      className="
        bg-white 
        shadow-xl 
        rounded-lg 
        overflow-hidden 
        w-[100vw] h-[100vh]
        md:w-[80vw] md:h-[90vh]
        flex flex-col md:flex-row
      "
    >
      {/* Left Side */}
      <div
        className="w-full md:w-[45%] h-1/3 md:h-full bg-cover bg-center"
        style={{
          backgroundImage:
            'url("https://fiverr-res.cloudinary.com/npm-assets/layout-service/standard.0638957.png")',
        }}
      >
        
        <h1 className="text-white ">Your Journey Starts Here</h1>
        <div>
        
          <h6> <Check />  Get Quality Work — On Time</h6>
          <h6> <Check />  Connect with Top Talent Worldwide</h6>
          <h6> <Check /> </h6>
        </div>
      </div>

      {/* Right Side */}
      <div className="relative w-full md:w-[55%] h-2/3 md:h-full bg-red-50 p-8 flex flex-col justify-center items-left p-[40px]">
        {/* Close Button INSIDE the Form Section */}
        <button
          onClick={() => setFormOpen(false)}
          className="absolute top-4 right-4 text-gray-600 hover:text-black transition"
        >
          <X className="w-6 h-6" />
        </button>

        <h1>Create a new account</h1>

        <h3 className="text-bold ">Email</h3>
        <input 
        type="text"
        placeholder="name@email.com"
        value={email}
        className="text-gray-600"
        onChange = {(e) => setEmail(e.target.value)} />

<h3 className="text-bold ">User Name</h3>
        <input 
        type="text"
        placeholder="name@email.com"
        value={userName}
        className="text-gray-600" 
        onChange={(e) => setUserName(e.target.value)}/>

<h3 className="text-bold ">Password</h3>
        <input 
        type="text"
        placeholder="name@email.com"
        value={password}
        className="text-gray-600"
        onChange={(e) => setPassword(e.target.value)} />
        
        <button onClick={(e) => handleSubmit(e)}>
          Submit
        </button>
        {/* Add your form here */}
      </div>
    </div>
  </div>
)}


    </nav>
  );
};

export default Navbar;
