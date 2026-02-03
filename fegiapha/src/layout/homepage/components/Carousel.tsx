import React, { useEffect, useState } from "react";
import getAllHo from "../../../api/HoApi";
import type { Ho } from "../../../model/entities";
import CarouselItemHo from "./Carouseltem";


const CarouselHo: React.FC = () => {
  const [hos, setHos] = useState<Ho[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    getAllHo()
      .then((data) => {
        setHos(data);
        setLoading(false);
      })
      .catch((err) => {
        setError(err.message);
        setLoading(false);
      });
  }, []);

  if (loading) return <h3>Đang tải dữ liệu...</h3>;
  if (error) return <h3>Gặp lỗi: {error}</h3>;

  // 👉 Chia thành nhóm 3
  const slides: Ho[][] = [];
  for (let i = 0; i < hos.length; i += 3) {
    slides.push(hos.slice(i, i + 3));
  }

  return (<div id="carouselHo"className="carousel slide carousel-dark" data-bs-ride="carousel"data-bs-interval="1000">
      <div className="carousel-inner">

        {slides.map((group, index) => (
          <div
            key={index}
            className={`carousel-item ${index === 0 ? "active" : ""}`}
          >
            <div className="row">
              {group.map((ho) => (
                <CarouselItemHo key={ho.id} ho={ho} />
              ))}
            </div>
          </div>
        ))}

      </div>

      {/* Nút trái */}
      <button
        className="carousel-control-prev"
        type="button"
        data-bs-target="#carouselHo"
        data-bs-slide="prev"
      >
        <span className="carousel-control-prev-icon"></span>
      </button>

      {/* Nút phải */}
      <button
        className="carousel-control-next"
        type="button"
        data-bs-target="#carouselHo"
        data-bs-slide="next"
      >
        <span className="carousel-control-next-icon"></span>
      </button>
    </div>
  );
};

export default CarouselHo;
