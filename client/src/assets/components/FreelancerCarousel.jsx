import React, { useState, useEffect } from "react";
import { Search, ArrowRight } from "lucide-react";

const HeroSection = () => {
  const [activeIndex, setActiveIndex] = useState(0);
  const [primaryColor, setPrimaryColor] = useState("#834692");

  const slides = [
    {
      color: "#834692",
      primaryImage: "images/fiza.jpeg",
    //   primaryImage: "https://99designs-start-static.imgix.net/homepage/vegan-jerky.jpg",
      secondaryImages: [
        "https://99designs-start-static.imgix.net/homepage/vegan-jerky-background.png",
        "https://99designs-start-static.imgix.net/homepage/vegan-jerky-front.png",
        "https://99designs-start-static.imgix.net/homepage/vegan-jerky-packaging.png",
        "https://99designs-start-static.imgix.net/homepage/vegan-jerky-star.png",
      ],
      customer: "Vegan Jerky Co",
      designer: {
        name: "Mj.vass",
        avatar: "https://99designs-start-static.imgix.net/homepage/avatar-mjvass.jpg",
        role: "Packaging"
      }
    },
    // Add other slides similarly...
  ];

  const handlePrev = () => {
    setActiveIndex((prev) => (prev - 1 + slides.length) % slides.length);
  };

  const handleNext = () => {
    setActiveIndex((prev) => (prev + 1) % slides.length);
  };

  useEffect(() => {
    setPrimaryColor(slides[activeIndex].color);
  }, [activeIndex]);

  return (
    <div className="hero-section min-h-screen w-full flex flex-col lg:flex-row bg-gray-50">
      {/* Left Section (Keep your existing left side content) */}

      {/* Right Section - Carousel */}
      <div className="sSection relative w-full flex items-center justify-center px-10 py-12">
        <div className="relative w-full max-w-4xl">
          {slides.map((slide, index) => (
            <div 
              key={index}
              className={`absolute inset-0 transition-opacity duration-500 ${
                activeIndex === index ? "opacity-100" : "opacity-0"
              }`}
            >
              {/* Primary Image */}
              <div className="relative z-10 w-64 h-64 mx-auto">
                <img
                  src={slide.primaryImage}
                  className="w-full h-full object-cover rounded-lg shadow-xl"
                  alt="Design work"
                />
              </div>

              {/* Secondary Images */}
              <div className="absolute inset-0">
                <img 
                  src={slide.secondaryImages[0]}
                  className="absolute top-0 left-1/4 w-48 transform -rotate-12"
                  alt="background"
                />
                <img
                  src={slide.secondaryImages[1]}
                  className="absolute bottom-20 right-10 w-32 transform rotate-6"
                  alt="foreground"
                />
                {/* Add more positioned images as needed */}
              </div>

              {/* Customer Attribution */}
              <div className="absolute bottom-8 left-4 bg-white px-4 py-2 rounded-full shadow-sm">
                <span className="text-sm font-medium">
                  Created for {slide.customer}
                </span>
              </div>

              {/* Designer Attribution */}
              <div 
                className="absolute top-8 right-4 flex items-center gap-2 px-4 py-2 rounded-full"
                style={{ backgroundColor: primaryColor }}
              >
                <img 
                  src={slide.designer.avatar}
                  className="w-8 h-8 rounded-full"
                  alt="Designer"
                />
                <span className="text-white text-sm">
                  {slide.designer.role} by {slide.designer.name}
                </span>
              </div>
            </div>
          ))}

          {/* Navigation Dots */}
          <div className="absolute bottom-8 left-1/2 transform -translate-x-1/2 flex gap-2">
            {slides.map((_, index) => (
              <button
                key={index}
                onClick={() => setActiveIndex(index)}
                className={`w-3 h-3 rounded-full transition-colors ${
                  activeIndex === index ? "bg-gray-800" : "bg-gray-300"
                }`}
              />
            ))}
          </div>

          {/* Navigation Arrows */}
          <button
            onClick={handlePrev}
            className="absolute left-4 top-1/2 transform -translate-y-1/2 bg-white p-3 rounded-full shadow-lg"
          >
            ←
          </button>
          <button
            onClick={handleNext}
            className="absolute right-4 top-1/2 transform -translate-y-1/2 bg-white p-3 rounded-full shadow-lg"
          >
            →
          </button>
        </div>
      </div>
    </div>
  );
};

export default HeroSection;