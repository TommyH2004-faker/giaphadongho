import { useState } from "react";
import { Link, NavLink } from "react-router-dom";

export default function Navbar() {
  const [isOpen, setIsOpen] = useState(false);

  return (
    <nav className="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
      <div className="container">

        {/* Logo */} 
        <Link className="navbar-brand fw-bold" to="/">
             Nhà Thờ Họ
        </Link>

        {/* Toggle mobile */}
        <button
          className="navbar-toggler"
          type="button"
          onClick={() => setIsOpen(!isOpen)}
        >
          <span className="navbar-toggler-icon"></span>
        </button>

        {/* Menu */}
        <div
          className={`collapse navbar-collapse ${isOpen ? "show" : ""}`}
        >
          <ul className="navbar-nav me-auto mb-2 mb-lg-0">

            <li className="nav-item">
              <NavLink className="nav-link" to="/">
                Trang chủ
              </NavLink>
            </li>

            <li className="nav-item">
              <NavLink className="nav-link" to="/gioi-thieu">
                Giới thiệu
              </NavLink>
            </li>

            <li className="nav-item">
              <NavLink className="nav-link" to="/gia-pha">
                Gia phả
              </NavLink>
            </li>

            <li className="nav-item">
              <NavLink className="nav-link" to="/so-do-pha-he">
                Sơ đồ phả hệ
              </NavLink>
            </li>

            <li className="nav-item">
              <NavLink className="nav-link" to="/lien-he">
                Liên hệ
              </NavLink>
            </li>

          </ul>

          {/* Auth */}
          <div className="d-flex">
            <Link to="/dangnhap" className="btn btn-warning">
              Đăng nhập
            </Link>
          </div>
        </div>

      </div>
    </nav>
  );
}
