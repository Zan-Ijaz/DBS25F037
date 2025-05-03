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
  const [username, setUsername] = useState("");
  const [usernameAvailable, setUsernameAvailable] = useState(null);
  const [checkingUsername, setCheckingUsername] = useState(false);
  const [emailAvailable, setEmailAvailable] = useState(null);
  const [checkingEmail, setCheckingEmail] = useState(false);

  const toggleForm = () => {
    setFormOpen(!formOpen);
    setError("");
    setMenuOpen(false);
  };

  const checkUsernameAvailability = async (name) => {
    setCheckingUsername(true);
    setUsernameAvailable(null);
    try {
      const res = await fetch("https://skillhub.runasp.net/api/Users/check-username", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ userName: name }),
      });
      const data = await res.json();
      setUsernameAvailable(!data.exists);
    } catch (err) {
      console.error(err);
      setUsernameAvailable(false);
    } finally {
      setCheckingUsername(false);
    }
  };

  const checkEmailAvailability = async (email) => {
    setCheckingEmail(true);
    setEmailAvailable(null);
    try {
      const res = await fetch("https://skillhub.runasp.net/api/Users/check-email", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ email }),
      });
      const data = await res.json();
      setEmailAvailable(!data.exists);
    } catch (err) {
      console.error(err);
      setEmailAvailable(false);
    } finally {
      setCheckingEmail(false);
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    // Only validate for registration
    if (!isLogin) {
      if (!email || !password || !username) {
        setError("All fields are required");
        return;
      }

      if (password.length < 8) {
        setError("Password must be at least 8 characters");
        return;
      }

      if (username.length <= 6 || !usernameAvailable) {
        setError("Username is not valid or unavailable");
        return;
      }

      if (!emailAvailable) {
        setError("Email is already taken");
        return;
      }
    }

    const userData = isLogin 
      ? { email, password }
      : { email, password, userName: username };

    try {
      const endpoint = isLogin ? "login" : "register";
      const res = await fetch(`https://skillhub.runasp.net/api/Users/${endpoint}`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(userData),
      });

      if (!res.ok) {
        const errorData = await res.json();
        throw new Error(errorData.message || (isLogin ? "Login failed" : "Registration failed"));
      }

      const data = await res.json();
      alert(data.message || (isLogin ? "Login successful!" : "Registration successful!"));
      
      // Reset form
      setEmail("");
      setPassword("");
      setUsername("");
      setUsernameAvailable(null);
      setEmailAvailable(null);
      toggleForm();

    } catch (err) {
      console.error("API Error:", err);
      setError(err.message || "Cannot connect to server. Please try again later.");
    }
  };

  return (
    <>
      <nav className="w-full py-4 px-4 sm:px-6 bg-white sticky top-0 z-50 shadow">
        <div className="flex justify-between items-center">
          <div className="flex items-center">
            <span className="text-xl font-bold">SkillHub</span>
          </div>

          <ul className="hidden md:flex space-x-6 font-medium text-gray-700">
            <li className="hover:text-green-600 cursor-pointer">Home</li>
            <li className="hover:text-green-600 cursor-pointer">Find Talent</li>
            <li className="hover:text-green-600 cursor-pointer">Works</li>
            <li className="hover:text-green-600 cursor-pointer">About Us</li>
            <li className="hover:text-green-600 cursor-pointer">Contact Us</li>
          </ul>

          <div className="hidden md:flex items-center flex-1 max-w-[270px] mx-4">
            <div className="w-full h-[40px] border border-gray-300 rounded-md overflow-hidden flex">
              <input
                type="text"
                placeholder="Search..."
                className="w-full h-full text-sm px-3 outline-none"
              />
              <div className="h-[60%] w-px bg-gray-300 my-auto" />
              <button className="h-full px-3 py-1 flex items-center justify-center">
                <Search className="text-gray-500 h-4 w-4" />
              </button>
            </div>
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

          <div className="md:hidden flex items-center space-x-4">
            <button onClick={() => setMenuOpen(!menuOpen)}>
              {menuOpen ? <X className="w-6 h-6" /> : <Menu className="w-6 h-6" />}
            </button>
          </div>
        </div>

        {menuOpen && (
          <div className="md:hidden absolute top-full left-0 w-full bg-white shadow-lg py-4 px-4">
            <ul className="space-y-4 font-medium text-gray-700">
              <li className="hover:text-green-600 cursor-pointer">Home</li>
              <li className="hover:text-green-600 cursor-pointer">Find Talent</li>
              <li className="hover:text-green-600 cursor-pointer">Works</li>
              <li className="hover:text-green-600 cursor-pointer">About Us</li>
              <li className="hover:text-green-600 cursor-pointer">Contact Us</li>
            </ul>

            <div className="mt-4 pt-4 border-t border-gray-200">
              <div className="w-full h-[40px] border border-gray-300 rounded-md overflow-hidden flex mb-4">
                <input
                  type="text"
                  placeholder="Search..."
                  className="w-full h-full text-sm px-3 outline-none"
                />
                <div className="h-[60%] w-px bg-gray-300 my-auto" />
                <button className="h-full px-3 py-1 flex items-center justify-center">
                  <Search className="text-gray-500 h-4 w-4" />
                </button>
              </div>

              <div className="flex space-x-4">
                <button
                  className="text-sm px-4 py-1 border border-green-600 text-green-600 rounded-full hover:bg-green-50 flex-1"
                  onClick={() => {
                    setIsLogin(true);
                    setFormOpen(true);
                  }}
                >
                  Login
                </button>
                <button
                  className="text-sm px-4 py-1 bg-green-600 text-white rounded-full hover:bg-green-700 flex-1"
                  onClick={() => {
                    setIsLogin(false);
                    setFormOpen(true);
                  }}
                >
                  Join
                </button>
              </div>
            </div>
          </div>
        )}
      </nav>

      {/* Form Overlay */}
      <div
        className={`fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50 transition-opacity duration-300 ${
          formOpen ? "opacity-100 visible" : "opacity-0 invisible"
        }`}
      >
        <div className="relative bg-white rounded-xl shadow-lg overflow-hidden w-[95%] max-w-4xl h-[90vh] md:h-[75vh] transition-all duration-500 flex flex-col md:flex-row">
          {/* Mobile Close Button */}
          <button
            onClick={toggleForm}
            className="absolute top-4 right-4 text-gray-500 hover:text-black text-2xl md:hidden z-30"
          >
            ✕
          </button>

          {/* Desktop Image Panel */}
          <div
            className={`hidden md:block w-full md:w-1/2 h-1/3 md:h-full bg-cover bg-center transition-all duration-700 ease-in-out ${
              isLogin ? "translate-x-0" : "translate-x-full"
            }`}
            style={{
              backgroundImage: "url('https://fiverr-res.cloudinary.com/npm-assets/layout-service/standard.0638957.png')"
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

          {/* Form Section */}
          <div
            className={`w-full md:w-1/2 h-full p-6 md:p-8 overflow-y-auto transition-all duration-700 ease-in-out ${
              isLogin ? "md:translate-x-0" : "md:-translate-x-full"
            }`}
          >
            {/* Desktop Close Button */}
            <button
              onClick={toggleForm}
              className="hidden md:block absolute top-4 right-4 text-gray-500 hover:text-black text-2xl"
            >
              ✕
            </button>

            <h2 className="text-xl font-bold mb-4">
              {isLogin ? "Login to your account" : "Create a new account"}
            </h2>

            <form onSubmit={handleSubmit} className="flex flex-col gap-4">
              {error && <p className="text-red-500 text-sm">{error}</p>}

              {!isLogin && (
                <div>
                  <label className="block text-sm font-semibold mb-1">Username</label>
                  <input
                    type="text"
                    className="w-full px-4 py-2 border rounded-md outline-none"
                    value={username}
                    onChange={(e) => {
                      const name = e.target.value;
                      setUsername(name);
                      if (name.length > 6) {
                        checkUsernameAvailability(name);
                      } else {
                        setUsernameAvailable(null);
                      }
                    }}
                    placeholder="Choose a username"
                  />
                  {username.length > 0 && username.length <= 6 && (
                    <p className="text-red-500 text-xs mt-1">Must be more than 6 characters</p>
                  )}
                  {checkingUsername && username.length > 6 && (
                    <p className="text-gray-500 text-xs mt-1">Checking availability...</p>
                  )}
                  {usernameAvailable === false && (
                    <p className="text-red-500 text-xs mt-1">Username is already taken</p>
                  )}
                  {usernameAvailable === true && (
                    <p className="text-green-600 text-xs mt-1">Username is available</p>
                  )}
                </div>
              )}

              <div>
                <label className="block text-sm font-semibold mb-1">Email</label>
                <input
                  type="email"
                  className="w-full px-4 py-2 border rounded-md outline-none"
                  value={email}
                  onChange={(e) => {
                    setEmail(e.target.value);
                    if (!isLogin && e.target.value.length > 0) {
                      checkEmailAvailability(e.target.value);
                    }
                  }}
                  placeholder="name@example.com"
                />
                {!isLogin && checkingEmail && email.length > 0 && (
                  <p className="text-gray-500 text-xs mt-1">Checking email availability...</p>
                )}
                {!isLogin && emailAvailable === false && (
                  <p className="text-red-500 text-xs mt-1">Email is already taken</p>
                )}
                {!isLogin && emailAvailable === true && (
                  <p className="text-green-600 text-xs mt-1">Email is available</p>
                )}
              </div>

              <div className="relative">
                <label className="block text-sm font-semibold mb-1">Password</label>
                <input
                  type={showPassword ? "text" : "password"}
                  className="w-full px-4 py-2 border rounded-md outline-none"
                  value={password}
                  onChange={(e) => setPassword(e.target.value)}
                  placeholder={isLogin ? "Enter your password" : "At least 8 characters"}
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
                  isLogin 
                    ? (email && password) 
                      ? "bg-green-600 text-white hover:bg-green-700" 
                      : "bg-gray-300 text-gray-500 cursor-not-allowed"
                    : (email && password.length >= 8 && username.length > 6 && usernameAvailable && emailAvailable)
                      ? "bg-green-600 text-white hover:bg-green-700"
                      : "bg-gray-300 text-gray-500 cursor-not-allowed"
                }`}
                disabled={
                  isLogin 
                    ? !email || !password
                    : !email || password.length < 8 || username.length <= 6 || !usernameAvailable || !emailAvailable
                }
              >
                {isLogin ? "Login" : "Create Account"}
              </button>
            </form>

            <div className="mt-4 text-sm text-center">
              {isLogin ? (
                <p>
                  Don’t have an account?{" "}
                  <span
                    className="text-green-600 cursor-pointer font-medium"
                    onClick={() => setIsLogin(false)}
                  >
                    Continue
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