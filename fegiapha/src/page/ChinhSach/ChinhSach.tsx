
import "./ChinhSach.css";
const ChinhSach = () => {
  return (
    <div className="container my-5">

      <div className="text-center mb-5">
        <h1 className="page-title">Chính Sách & Quy Định</h1>
        <p className="page-subtitle">
          Quy định sử dụng và nguyên tắc hoạt động của hệ thống gia phả dòng họ
        </p>
      </div>

      <div className="policy-box">

        <h4>1. Mục đích sử dụng</h4>
        <p>
          Website được xây dựng nhằm lưu trữ, quản lý và chia sẻ thông tin gia phả
          dòng họ một cách chính xác và minh bạch.
        </p>

        <h4>2. Quyền và nghĩa vụ của người dùng</h4>
        <ul>
          <li>Cung cấp thông tin đúng sự thật.</li>
          <li>Không đăng tải nội dung phản cảm.</li>
          <li>Tôn trọng các thành viên trong dòng họ.</li>
        </ul>

        <h4>3. Bảo mật thông tin</h4>
        <p>
          Mọi dữ liệu cá nhân được bảo mật và chỉ phục vụ cho mục đích quản lý
          gia phả.
        </p>

        <h4>4. Điều khoản thay đổi</h4>
        <p>
          Chính sách có thể được cập nhật theo từng giai đoạn mà không cần báo
          trước.
        </p>

      </div>

    </div>
  );
};

export default ChinhSach;
