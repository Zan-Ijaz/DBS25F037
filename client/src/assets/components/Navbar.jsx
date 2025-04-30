import React, { useState } from "react";
import { Eye, EyeOff, Menu, Search, X } from "lucide-react";
import { CiCircleCheck } from "react-icons/ci";

const Navbar = () => {
  const [isLogin, setIsLogin] = useState(true);
  const [formOpen, setFormOpen] = useState(false);
  const [menuOpen, setMenuOpen] = useState(false);
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [showPassword, setShowPassword] = useState(false);
  const [error, setError] = useState("");

  const toggleForm = () => {
    setFormOpen(!formOpen);
    setError("");
    setMenuOpen(false);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!email || !password) {
      setError("Email and password are required.");
      return;
    }

    if (password.length < 8) {
      setError("Password must be at least 8 characters long.");
      return;
    }

    const userData = { email, password };

    try {
      const res = await fetch("http://skillhub.runasp.net/api/Users/register", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(userData),
      });

      const data = await res.json();
      if (!res.ok) {
        setError(data.message || "Registration failed.");
        return;
      }

      alert(data.message || "Registration successful.");
      setEmail("");
      setPassword("");
      toggleForm();
    } catch (err) {
      console.error(err);
      setError("Something went wrong. Please try again later.");
    }
  };

  return (
    <>
      <nav className="w-full py-4 px-6 bg-white sticky top-0 z-50 shadow">
        <div className="flex justify-between items-center">
          <div className="flex items-center space-x-2">
            <span className="text-xl font-bold">SkillHub</span>
          </div>

          <ul className="hidden md:flex space-x-6 font-medium text-gray-700">
            <li className="hover:text-green-600 cursor-pointer">Home</li>
            <li className="hover:text-green-600 cursor-pointer">Find Talent</li>
            <li className="hover:text-green-600 cursor-pointer">Works</li>
            <li className="hover:text-green-600 cursor-pointer">About Us</li>
            <li className="hover:text-green-600 cursor-pointer">Contact Us</li>
          </ul>

          <div className="hidden md:flex items-center w-[270px] h-[40px] border border-gray-300 rounded-md overflow-hidden">
            <input
              type="text"
              placeholder="Search..."
              className="w-full h-full text-sm px-3 outline-none"
            />
            <div className="h-[60%] w-px bg-gray-300 mx-[2px]" />
            <button className="h-full px-3 py-1 flex items-center justify-center">
              <Search className="text-gray-500 h-4 w-4" />
            </button>
          </div>

          <div className="hidden md:flex space-x-4">
            <button
              className="text-sm px-4 py-1 border border-green-600 text-green-600 rounded-full hover:bg-green-50"
              onClick={() => {
                setIsLogin(true);
                setFormOpen(true);
              }}
            >
              Login
            </button>
            <button
              className="text-sm px-4 py-1 bg-green-600 text-white rounded-full hover:bg-green-700"
              onClick={() => {
                setIsLogin(false);
                setFormOpen(true);
              }}
            >
              Join
            </button>
          </div>

          <div className="md:hidden">
            <button onClick={() => setMenuOpen(!menuOpen)}>
              {menuOpen ? <X className="w-6 h-6" /> : <Menu className="w-6 h-6" />}
            </button>
          </div>
        </div>

        {/* Mobile menu */}
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
              <input
                type="text"
                placeholder="Search..."
                className="border px-3 py-1 rounded-md"
              />
              <button
                className="text-sm border border-green-600 text-green-600 rounded-full py-2 hover:bg-green-50"
                onClick={() => {
                  setIsLogin(true);
                  toggleForm();
                }}
              >
                Login
              </button>
              <button
                className="text-sm bg-green-600 text-white rounded-full py-2 hover:bg-green-700"
                onClick={() => {
                  setIsLogin(false);
                  toggleForm();
                }}
              >
                Join
              </button>
            </div>
          </div>
        )}
      </nav>

      {/* Overlay Form */}
      <div
        className={`fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50 transition-opacity duration-300 ${
          formOpen ? "opacity-100 visible" : "opacity-0 invisible"
        }`}
      >
        <div className="relative bg-white rounded-xl shadow-lg overflow-hidden w-[95vw] max-w-4xl h-[85vh] transition-all duration-500 flex">

          {/* Sliding Image */}
          <div
            className={`absolute top-0 left-0 h-full w-1/2 bg-cover bg-center transition-all duration-700 ease-in-out z-10 ${
              isLogin ? "translate-x-0" : "translate-x-full"
            }`}
            style={{
              backgroundImage:
                'url("https://fiverr-res.cloudinary.com/npm-assets/layout-service/standard.0638957.png")',
            }}
          >
            <div className="p-6 md:p-10">
              <h1 className="text-white text-2xl font-bold">Success Starts Here</h1>
              <div className="mt-4 flex flex-col gap-2">
                <p className="flex items-center gap-2 text-white text-sm">
                  <CiCircleCheck className="text-green-600" /> Get Quality Work — On Time
                </p>
                <p className="flex items-center gap-2 text-white text-sm">
                  <CiCircleCheck className="text-green-600" /> Connect with Top Talent
                </p>
              </div>
            </div>
          </div>

          {/* Sliding Form */}
          <div
            className={`absolute top-0 right-0 h-full w-1/2 bg-white p-8 overflow-y-auto transform transition-all duration-700 ease-in-out z-20 ${
              isLogin ? "translate-x-0" : "-translate-x-full"
            }`}
          >
            <button
              onClick={toggleForm}
              className="absolute top-4 right-4 text-gray-500 hover:text-black text-2xl"
            >
              ✕
            </button>

            <h2 className="text-xl font-bold mb-4 mt-2">
              {isLogin ? "Login to your account" : "Create a new account"}
            </h2>

            <form onSubmit={handleSubmit} className="flex flex-col gap-4 mt-4">
              {error && <p className="text-red-500 text-sm">{error}</p>}

              <div>
                <label className="block text-sm font-semibold mb-1">Email</label>
                <input
                  type="email"
                  className="w-full px-4 py-2 border rounded-md outline-none"
                  value={email}
                  onChange={(e) => setEmail(e.target.value)}
                  placeholder="name@example.com"
                />
              </div>

              <div className="relative">
                <label className="block text-sm font-semibold mb-1">Password</label>
                <input
                  type={showPassword ? "text" : "password"}
                  className="w-full px-4 py-2 border rounded-md outline-none"
                  value={password}
                  onChange={(e) => setPassword(e.target.value)}
                  placeholder="At least 8 characters"
                />
                <button
                  type="button"
                  onClick={() => setShowPassword(!showPassword)}
                  className="absolute right-4 top-9 text-gray-600"
                >
                  {showPassword ? <EyeOff size={20} /> : <Eye size={20} />}
                </button>
              </div>

              {!isLogin && (
                <div className="text-gray-500 text-sm space-y-1">
                  <div className="flex items-center gap-1">
                    <CiCircleCheck className={`${password.length >= 8 ? "text-green-600" : "text-gray-400"}`} />
                    <span className={`${password.length >= 8 ? "text-green-600" : "text-gray-400"}`}>Minimum 8 characters</span>
                  </div>
                  <div className="flex items-center gap-1">
                    <CiCircleCheck className={`${/[A-Z]/.test(password) ? "text-green-600" : "text-gray-400"}`} />
                    <span className={`${/[A-Z]/.test(password) ? "text-green-600" : "text-gray-400"}`}>1 uppercase letter</span>
                  </div>
                  <div className="flex items-center gap-1">
                    <CiCircleCheck className={`${/[a-z]/.test(password) ? "text-green-600" : "text-gray-400"}`} />
                    <span className={`${/[a-z]/.test(password) ? "text-green-600" : "text-gray-400"}`}>1 lowercase letter</span>
                  </div>
                  <div className="flex items-center gap-1">
                    <CiCircleCheck className={`${/\d/.test(password) ? "text-green-600" : "text-gray-400"}`} />
                    <span className={`${/\d/.test(password) ? "text-green-600" : "text-gray-400"}`}>1 number</span>
                  </div>
                </div>
              )}

              <button
                type="submit"
                className={`mt-4 py-2 rounded-md transition ${
                  email && password.length >= 8
                    ? "bg-green-600 text-white hover:bg-green-700"
                    : "bg-gray-300 text-gray-500 cursor-not-allowed"
                }`}
                disabled={!(email && password.length >= 8)}
              >
                {isLogin ? "Login" : "Register"}
              </button>
            </form>

            {/* Text-based toggle */}
            <div className="mt-4 text-sm text-center">
              {isLogin ? (
                <p>
                  Don’t have an account?{" "}
                  <span
                    className="text-green-600 cursor-pointer font-medium"
                    onClick={() => setIsLogin(false)}
                  >
                    Sign up
                  </span>
                </p>
              ) : (
                <p>
                  Already have an account?{" "}
                  <span
                    className="text-green-600 cursor-pointer font-medium"
                    onClick={() => setIsLogin(true)}
                  >
                    Login
                  </span>
                </p>
              )}
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default Navbar;
