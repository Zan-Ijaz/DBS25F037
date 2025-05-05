import React from 'react';

const InfiniteLogoCarousel = () => {
  const logos = [
    { src: '/images/apple-logo.png', alt: 'Apple' },
    { src: '/images/microsoft.png', alt: 'Microsoft' },
    { src: '/images/logo.png', alt: 'Logo' },
    { src: '/images/groupon.png', alt: 'Groupon' },
    { src: '/images/adidas.png', alt: 'Adidas' },
  ];

  const duplicatedLogos = [...logos, ...logos];

  return (
    <div
      className="relative overflow-hidden py-12"
      style={{
        background: 'linear-gradient(to bottom, #ffffff 0%, #3A467B 50%, #ffffff 100%)',
      }}
    >
      <div className="relative z-10">
        {/* Title */}
        <h1 className="text-white text-center font-medium text-4xl md:text-6xl px-4  mt-[130px] md:px-[120px] md:pb-16">
          We have helped global brands to shape their products
        </h1>

        {/* Logo Carousel */}
        <section
          className="w-full overflow-hidden flex place-items-center pt-8 pb-20"
          style={{
            maskImage: 'linear-gradient(to right, rgba(0,0,0,0) 0%, rgb(0,0,0) 12.5%, rgb(0,0,0) 87.5%, rgba(0,0,0,0) 100%)',
            WebkitMaskImage: 'linear-gradient(to right, rgba(0,0,0,0) 0%, rgb(0,0,0) 12.5%, rgb(0,0,0) 87.5%, rgba(0,0,0,0) 100%)',
          }}
        >
          <div
            className="flex animate-infinite-scroll"
            style={{
              display: 'flex',
              flexDirection: 'row',
              padding: '0',
              margin: '0',
              whiteSpace: 'nowrap',
              width: 'max-content', 
            }}
          >
            <ul
              className="flex gap-12"
              style={{
                display: 'flex',
                flexDirection: 'row',
                padding: '0',
                margin: '0',
                whiteSpace: 'nowrap',
              }}
            >
              {duplicatedLogos.map((logo, index) => (
                <li key={index} className="flex-shrink-0 px-16 py-4">
                  <img
                    src={logo.src}
                    alt={logo.alt}
                    className="h-[60px] w-auto object-contain hover:opacity-100 transition-opacity duration-300"
                  />
                </li>
              ))}
            </ul>
          </div>
        </section>

        {/* Background CTA Section */}
        <div
          className="flex flex-col md:flex-row justify-center items-center m-4 rounded-lg p-5 gap-6"
          style={{
            backgroundImage:
              'url(https://fiverr-res.cloudinary.com/image/upload/f_auto,q_auto/v1/attachments/generic_asset/asset/0c5d27341258f57a0e7c798074aeaa96-1743599633530/Background%20_%20Go%20section.png)',
            backgroundSize: 'cover',
            backgroundRepeat: 'no-repeat',
            backgroundPosition: 'center',
          }}
        >
          <div className="w-full md:w-1/2 text-white text-left md:text-left">
            <h2 className="text-2xl md:text-4xl font-semibold mb-4">
              Instant results. <br />Top talent.
            </h2>
            <p className="text-base md:text-lg leading-relaxed pt-[25px] pr-10">
              Get what you need faster from freelancers who trained their own personal AI Creation Models. Now you can browse, prompt, and generate instantly. And if you need a tweak or change, the freelancer is always there to help you perfect it.
            </p>
          </div>

          <div className="w-full md:w-1/2">
            <video
              src="https://fiverr-res.cloudinary.com/video/upload/v1/video-attachments/generic_asset/asset/f4b1924c68e6916c6d100527c7ff3d9c-1743494584325/Image%20model"
              autoPlay
              muted
              loop
              className="w-full rounded-lg"
            ></video>
          </div>
        </div>
      </div>

      {/* Animation Styles */}
      <style jsx>{`
        @keyframes infinite-scroll {
          0% {
            transform: translateX(0);
          }
          100% {
            transform: translateX(-50%); /* Ensure logos move to the left by 50% of the total width */
          }
        }

        .animate-infinite-scroll {
          animation: infinite-scroll 8s linear infinite; /* Adjusted duration for smooth scroll */
        }
      `}</style>
    </div>
  );
};

export default InfiniteLogoCarousel;
