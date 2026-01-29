import Footer from "../header-footer/Footer";
import Navbar from "../header-footer/Navbar";
import CultureSection from "./components/CultureSection";
import FeaturedSection from "./components/FeaturedSection";
import HeroSection from "./components/HeroSection";
import IntroSection from "./components/IntroSection";
import SearchSection from "./components/SearchSection";



const HomePage = () => {
  return (
    <>
        <Navbar />
      <main className="bg-light" style={{minHeight: '70vh'}}>
        <div className="container py-4">
          <HeroSection />
          <IntroSection />
          <SearchSection />
          <FeaturedSection />
          <CultureSection />
        </div>
      </main>
      <Footer />
    </>
  );
};

export default HomePage;
