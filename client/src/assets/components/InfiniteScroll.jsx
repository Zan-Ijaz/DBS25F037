import React from 'react';

const InfiniteLogoCarousel = () => {
  const logos = [
    '/images/apple-logo.png',
    '/images/hp-logo.png',
    '/images/element-logo.png',
    '/images/makerbot-logo.png'
  ];

  // Duplicate the array twice for seamless loop
  const duplicatedLogos = [...logos, ...logos];

  return (
    <div 
      className="relative overflow-hidden py-12"
      style={{
        backgroundImage: 'url(images/1812875.jpg)',
        backgroundSize: 'cover',
        backgroundPosition: 'center',
        backgroundRepeat: 'no-repeat'
      }}
    >
      <div className="relative z-10">
        <div className='Scroll-text mb-16'>
          <h1 className='text-white text-center font-medium text-4xl md:text-6xl px-4 py-16 md:px-[120px] md:py-[120px]'>
            We have helped global brands to shape their products
          </h1>
        </div>

        <section 
          className="relative w-full h-32 mask-fade overflow-hidden"
          style={{
            maskImage: 'linear-gradient(to right, rgba(0, 0, 0, 0) 0%, rgb(0, 0, 0) 5%, rgb(0, 0, 0) 95%, rgba(0, 0, 0, 0) 100%)'
          }}
        >
          <ul className="flex h-full items-center animate-infinite-scroll">
            {duplicatedLogos.map((logo, index) => (
              <li 
                key={index}
                className="flex-shrink-0 w-[25%] px-8" // Each logo takes 25% width
                aria-hidden={index >= logos.length}
              >
                <img
                  src={logo}
                  alt="Company logo"
                  className="h-16 w-auto object-contain opacity-80 hover:opacity-100 transition-opacity mx-auto"
                />
              </li>
            ))}
          </ul>
        </section>
      </div>

      <style jsx>{`
        @keyframes infinite-scroll {
          0% { transform: translateX(0); }
          100% { transform: translateX(-50%); }
        }

        .animate-infinite-scroll {
          animation: infinite-scroll 20s linear infinite;
          width: 200%; // Double the width for 8 logos (2 sets of 4)
        }

        .mask-fade {
          mask-mode: alpha;
          mask-repeat: no-repeat;
          mask-composite: add;
        }

        @media (prefers-reduced-motion: reduce) {
          .animate-infinite-scroll {
            animation: none;
          }
        }
      `}</style>
    </div>
  );
};

export default InfiniteLogoCarousel;