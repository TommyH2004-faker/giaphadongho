import React from "react";
import "./TinTuc.css";
const TinTuc = () => {
  return (
    <div className="container my-5">

      {/* Header */}
      <div className="text-center mb-5">
        <h1 className="page-title">Tin Tức Nhà Thờ Họ</h1>
        <p className="page-subtitle">
          Cập nhật những hoạt động, sự kiện và thông báo mới nhất từ các dòng họ
        </p>
      </div>

      {/* Danh sách tin */}
      <div className="row g-4">

        {[1, 2, 3, 4].map((item) => (
          <div className="col-md-6 col-lg-4" key={item}>
            <div className="news-card">
              <img
                src="https://via.placeholder.com/400x250"
                alt="news"
                className="news-image"
              />

              <div className="p-3">
                <h5 className="news-title">
                  Lễ khánh thành nhà thờ họ Nguyễn
                </h5>

                <p className="news-desc">
                  Buổi lễ được tổ chức long trọng với sự tham gia của đông đảo
                  con cháu trong dòng họ.
                </p>

                <button className="btn btn-outline-dark btn-sm">
                  Xem chi tiết
                </button>
              </div>
            </div>
          </div>
        ))}

      </div>
    </div>
  );
};

export default TinTuc;
