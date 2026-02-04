import { useState } from 'react';
import { Routes, Route, useLocation } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';
import Navbar from './layout/header-footer/Navbar';
import Footer from './layout/footer/Footer';
import { Error404Page } from './page/Error/404Page';
import DangNhap from './layout/User/DangNhap';
import DangKyNguoiDung from './layout/User/DangKyNguoiDung';
import KichHoatTaiKhoan from './layout/User/KichHoatTaiKhoan';
import { ForgotPassword } from './layout/User/ForgotPassword';
import HomePage from './layout/homepage/Homepage';
import ChinhSach from './page/ChinhSach';
import TinTuc from './page/TinTuc';


const App = () => {
    const [reloadAvatar] = useState(0);
    const location = useLocation();
    const isAdminPath = location.pathname.startsWith("/admin");

    return (
        <>
            {/* Hiển thị Navbar và Footer cho trang khách hàng */}
            {!isAdminPath && (
                <>
                    <Navbar
                        key={reloadAvatar}
                    />
                </>
            )}
            {/* Customer Routes */}
            {!isAdminPath && (
                <Routes>
                    {/* Trang chủ */}
                    <Route path='/' element={<HomePage />} />
                    <Route path='dangnhap' element={<DangNhap />} />
                    <Route path='dangky' element={<DangKyNguoiDung />} />
                    <Route path='policy' element={<ChinhSach />} />
                    <Route path='/active/:code/:userId' element={<KichHoatTaiKhoan />} />
                    <Route path='/forgot-password' element={<ForgotPassword />} />
                    <Route path='tin-tuc' element={<TinTuc />} />
                    {/* Nếu không tìm thấy trang */}
                    <Route path='*' element={<Error404Page />} />
                </Routes>
            )}

            {/* Admin Routes */}
            {isAdminPath && (
                <div className='row overflow-hidden w-100'>
                    <div className='col-2 col-md-3 col-lg-2'>
                        {/* Sidebar Admin - thêm component sidebar ở đây */}
                    </div>
                    <div className='col-10 col-md-9 col-lg-10'>
                        <Routes>
                            {/* Dashboard Admin */}
                            <Route path='dashboard' element={<div className="container mt-5"><h1>Admin Dashboard</h1><p>Chào mừng Admin!</p></div>}/>
                            
                            {/* Catch-all cho admin routes không tồn tại */}
                            <Route path='*' element={<Error404Page/>}/>
                        </Routes>
                    </div>
                </div>
            )}
            {/* Hiển thị Footer cho trang khách hàng */}
            {!isAdminPath && <Footer />}
            {/* Toast thông báo */}
            <ToastContainer
                position="bottom-center"
                autoClose={3000}
            />
        </>
    );
};


export default App;