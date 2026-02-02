import {Link, NavLink, useLocation, useNavigate} from "react-router-dom";

import Button from "@mui/material/Button";
import Avatar from "@mui/material/Avatar";
import { useAuth } from "../../utils/AuthContext";
import { getAvatarByToken, getLastNameByToken, getRoleByToken, isToken, logout } from "../../utils/JwtService";
// interface NavbarProps {
//     tuKhoaTimKiem: string;
//     setTuKhoaTimKiem: (tuKhoa: string) => void;
// }
function Navbar() {

    const {setLoggedIn} = useAuth();
    const navigate = useNavigate();
  
    const location = useLocation();
    const adminEndpoint = ["/admin"];
    if(adminEndpoint.includes(location.pathname)){
        return null;
    }

    return(
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <div className="container-fluid">
                <a className="navbar-brand" href="#">Bookstore</a>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse"
                        data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent"
                        aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>

                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                        <li className="nav-item">
                            <NavLink className="nav-link active" aria-current="page" to="/">Trang chủ</NavLink>
                        </li>
                        <li className='nav-item'>
                            <NavLink className='nav-link' to='/about'>
                                Giới thiệu
                            </NavLink>
                        </li>
                        {/* <li className="nav-item dropdown">
                            <NavLink className="nav-link dropdown-toggle" to="#" id="navbarDropdown1" role="button"
                                     data-bs-toggle="dropdown" aria-expanded="false">
                                Thể loại sách
                            </NavLink>
                            <ul className="dropdown-menu" aria-labelledby="navbarDropdown1">
                                <li><NavLink className="dropdown-item" to="/30">Thể loại 1</NavLink></li>
                                <li><NavLink className="dropdown-item" to="/32">Thể loại 2</NavLink></li>
                                <li><NavLink className="dropdown-item" to="/36">Thể loại 3</NavLink></li>
                            </ul>
                        </li>*/}
                        <li className='nav-item dropdown dropdown-hover'>
                            <a
                                className='nav-link dropdown-toggle'
                                href='#'
                                role='button'
                                data-bs-toggle='dropdown'
                                aria-expanded='false'
                            >
                                Thể loại
                            </a>
                        </li>
                        <li className='nav-item'>
                            <Link className='nav-link' to={"/policy"}>
                                Chính sách
                            </Link>
                        </li>
                        {isToken() && (
                            <li className='nav-item'>
                                <NavLink className='nav-link' to={"/feedback"}>
                                    Feedback
                                </NavLink>
                            </li>
                        )}
                    </ul>
                </div>

               
               
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
                                    alt={getLastNameByToken()?.toUpperCase()}
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
</nav>
);
}

export default Navbar;