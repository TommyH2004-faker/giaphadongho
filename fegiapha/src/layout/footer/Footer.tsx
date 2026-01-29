import { Link } from "react-router-dom";

export default function Footer() {
  return (
    <footer className="bg-dark text-light pt-4 pb-2 mt-auto shadow-sm" style={{borderTop: '1px solid #eee'}}>
      <div className="container">
        <div className="row align-items-center gy-3">
          {/* Logo và tên website */}
          <div className="col-12 col-md-4 d-flex align-items-center mb-2 mb-md-0">
            <img
              src="/logoWeb.png"
              alt="Logo Nhà Thờ Họ"
              style={{height: 48, width: 'auto', borderRadius: 8, marginRight: 12, background: '#fff', padding: 2}}
            />
            <span className="fw-bold fs-5">Nhà Thờ Họ</span>
          </div>

          {/* Thông tin liên hệ */}
          <div className="col-12 col-md-4 text-center">
            <div>Địa chỉ: <span className="fw-semibold">Số nhà, Đường, Quận/Huyện, Tỉnh/TP</span></div>
            <div>Điện thoại: <a href="tel:0123456789" className="text-warning text-decoration-none">0123 456 789</a></div>
            <div>Email: <a href="mailto:info@nhathodongho.vn" className="text-warning text-decoration-none">info@nhathodongho.vn</a></div>
          </div>

          {/* Liên kết nhanh */}
          <div className="col-12 col-md-4 text-md-end text-center">
            <div className="mb-2">
              <Link to="/" className="text-light text-decoration-none me-3">Trang chủ</Link>
              <Link to="/gioi-thieu" className="text-light text-decoration-none me-3">Giới thiệu</Link>
              <Link to="/gia-pha" className="text-light text-decoration-none me-3">Gia phả</Link>
              <Link to="/lien-he" className="text-light text-decoration-none">Liên hệ</Link>
            </div>
            <div className="small text-secondary">&copy; {new Date().getFullYear()} Nhà Thờ Họ. All rights reserved.</div>
          </div>
        </div>
      </div>
    </footer>
  );
}
