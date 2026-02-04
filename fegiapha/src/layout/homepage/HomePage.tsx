
// import HeaderTop3Ho from "../header-footer/component/Header";
// import CarouselHo from "./components/Carousel";


// function HomePage() {
//   return (
//     <>
//       <CarouselHo />
//       <HeaderTop3Ho />
    
  
//     </>
//   );
// }

// export default HomePage;

import HeaderTop3Ho from "../header-footer/component/Header";
import CarouselHo from "./components/Carousel";

function HomePage() {
  return (
    <div className="container my-5">

    

      {/* ===== NHÀ THỜ HỌ TIÊU BIỂU ===== */}
      <section className="mb-4">
        <h2 className="home-section-title">
          Nhà Thờ Họ Tiêu Biểu
        </h2>
         <CarouselHo />
        <p className="home-section-desc">
          Những nhà thờ họ mang giá trị lịch sử, kiến trúc và văn hóa tiêu biểu trên
          khắp các vùng miền.
        </p>
      </section>

      {/* ===== CAROUSEL ===== */}
      <section>
        <HeaderTop3Ho />s
      </section>

    </div>
  );
}

export default HomePage;
