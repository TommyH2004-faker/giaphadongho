import { useState } from "react";
import { Link, NavLink, useNavigate } from "react-router-dom";
import { getAvatarByToken, getRoleByToken, isToken, logout } from "../../utils/JwtService";
import { Avatar, Button } from "@mui/material";
import { useAuth } from "../../utils/AuthContext";
export default function Navbar() {
  const [isOpen, setIsOpen] = useState(false);
  const navigate = useNavigate();
  const {setLoggedIn} = useAuth();
  return (
    <nav
      className="navbar navbar-expand-lg fixed-top"
      style={{
        backgroundColor: "#1a1a1a",             // nền tối cổ truyền
        borderBottom: "1px solid rgba(208,165,57,0.4)",
      }}
    >
      <div
        className="container d-flex align-items-center justify-content-between"
        style={{ gap: 24 }}
      >

        {/* Logo */}
        <div style={{ flex: "0 0 auto" }}>
          <Link
            className="navbar-brand d-flex align-items-center p-0 m-0"
            to="/"
            style={{ height: "90px" }}
          >
            <img
              src="/logoWeb.png"
              alt="Logo Nhà Thờ Họ"
              style={{
                height: "80px",
                width: "auto",
                objectFit: "contain",
              }}
            />
          </Link>
        </div>

        {/* Menu + Auth */}
        <div
          style={{ flex: 1, minWidth: 0 }}
          className="d-flex flex-column flex-lg-row align-items-center justify-content-end"
        >

          {/* Toggle mobile */}
          <button
            className="navbar-toggler align-self-end mb-2 mb-lg-0"
            type="button"
            onClick={() => setIsOpen(!isOpen)}
          >
            <span className="navbar-toggler-icon"></span>
          </button>

          {/* Collapse */}
          <div
            className={`collapse navbar-collapse ${isOpen ? "show" : ""}`}
            style={{ width: "100%" }}
          >
            <ul className="navbar-nav me-auto mb-2 mb-lg-0">

              {[
                { to: "/", label: "Trang chủ" },
                { to: "/gioi-thieu", label: "Giới thiệu" },
                { to: "/gia-pha", label: "Gia phả" },
                { to: "/so-do-pha-he", label: "Sơ đồ phả hệ" },
                { to: "/lien-he", label: "Liên hệ" },
              ].map((item) => (
                <li className="nav-item" key={item.to}>
                  <NavLink
                    to={item.to}
                    className="nav-link"
                    style={({ isActive }) => ({
                      color: isActive ? "#d0a539" : "white",
                      fontWeight: 500,
                    })}
                  >
                    {item.label}
                  </NavLink>
                </li>
              ))}

            </ul>

            {/* Auth */}
          {/* Biểu tượng đăng nhập */}
                {!isToken() && (
                    <div>
                        <Link to={"/dangnhap"}>
                            <Button>Đăng nhập</Button>
                        </Link>
                        <Link to={"/dangKy"}>
                            <Button>Đăng ký</Button>
                        </Link>
                    </div>
                )}
                {isToken() && (
                    <>
                        {/* <!-- Notifications --> */}
                        <div className='dropdown'>
                            <a
                                className='text-reset me-3 dropdown-toggle hidden-arrow'
                                href='#'
                                id='navbarDropdownMenuLink'
                                role='button'
                                data-mdb-toggle='dropdown'
                                aria-expanded='false'
                            >
                                <i className='fas fa-bell'></i>
                                <span className='badge rounded-pill badge-notification bg-danger'>
										1
									</span>
                            </a>
                            <ul
                                className='dropdown-menu dropdown-menu-end'
                                aria-labelledby='navbarDropdownMenuLink'
                            >
                                <li>
                                    <a className='dropdown-item' href='#'>
                                        Tin tức
                                    </a>
                                </li>
                                <li>
                                    <a className='dropdown-item' href='#'>
                                        Thông báo mới
                                    </a>
                                </li>
                                <li>
                                    <a className='dropdown-item' href='#'>
                                        Tất cả thông báo
                                    </a>
                                </li>
                            </ul>
                        </div>
                    {/* <!-- Avatar --> */}
                        <div className='dropdown'>
                            <a
                                className='dropdown-toggle d-flex align-items-center hidden-arrow'
                                href='#'
                                id='navbarDropdownMenuAvatar'
                                role='button'
                                data-mdb-toggle='dropdown'
                                aria-expanded='false'
                            >
                                <Avatar
                                    style={{fontSize: "14px"}}            
                                    src={getAvatarByToken()}
                                    sx={{width: 30, height: 30}}
                                />
                            </a>
                            <ul
                                className='dropdown-menu dropdown-menu-end'
                                aria-labelledby='navbarDropdownMenuAvatar'
                            >
                                <li>
                                    <Link to={"/profile"} className='dropdown-item'>
                                        Thông tin cá nhân
                                    </Link>
                                </li>
                                <li>
                                    <Link
                                        className='dropdown-item'
                                        to='/my-favorite-books'
                                    >
                                        Sách yêu thích của tôi
                                    </Link>
                                </li>
                                {getRoleByToken() === "ADMIN" && (
                                    <li>
                                        <Link
                                            className='dropdown-item'
                                            to='/admin/dashboard'
                                        >
                                            Quản lý
                                        </Link>
                                    </li>
                                )}
                                <li>
                                    <a
                                        className='dropdown-item'
                                        style={{cursor: "pointer"}}
                                        onClick={() => {
                                            logout(navigate);
                                            setLoggedIn(false);
                                        }}
                                    >
                                        Đăng xuất
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </>
                )}

          </div>
        </div>

      </div>
    </nav>
  );
}
