# 🌳 HỆ THỐNG QUẢN LÝ GIA PHẢ DÒNG HỌ

## 📦 Cài đặt

```bash
npm install react-bootstrap-icons
npm install react-router-dom
npm install @mui/material @mui/icons-material @emotion/react @emotion/styled
npm create vite@latest . -- --template react-ts
npm install jwt-decode
npm install react-toastify
npm install react-flow-renderer  # Vẽ cây gia phả
npm install xlsx  # Xuất Excel
npm install html2canvas jspdf  # Xuất PDF/Image
```

---

## 👥 PHÂN QUYỀN HỆ THỐNG

Hệ thống có 3 cấp độ quản trị:
- **ADMIN**: Quản trị viên cao nhất - Toàn quyền quản lý
- **USER**: Thành viên - Xem và đóng góp thông tin

---

## 🔵 CHỨC NĂNG CHI TIẾT

### **MODULE 1: QUẢN LÝ PHẢ ĐỒ** 🌳

#### 1.1. Thêm đời đầu (Tổ tiên)
- Thêm thành viên đời đầu (không có cha mẹ)
- Nhập thông tin cơ bản: Họ tên, Ngày sinh
- Đặt làm gốc cây gia phả

#### 1.2. Thêm thành viên mới
- **Con cái:**
  - Thêm con cho thành viên
  - Chọn con cả, con thứ (thứ tự hiển thị)
  - Số thứ tự: 1, 2, 3... (số càng cao càng ưu tiên)

- **Vợ/Chồng:**
  - Thêm vợ cả, vợ hai, vợ ba...
  - Thêm chồng cả, chồng hai...
  - Ghi chú loại hôn nhân

- **Bố/Mẹ:**
  - Liên kết với bố/mẹ
  - Hỗ trợ nhiều mẹ (mẹ đẻ, mẹ kế...)

#### 1.3. Chỉnh sửa thành viên
- Cập nhật mọi thông tin
- Đổi vị trí thành viên trong cây
- Thay đổi số thứ tự (con cả → con thứ)

#### 1.4. Xóa thành viên
- Xóa thành viên không có con
- Xác nhận trước khi xóa
- Xóa cascade các quan hệ

#### 1.5. Hiển thị đường nối hôn phối
- Đường nối từ vợ 1 → con của vợ 1
- Đường nối từ vợ 2 → con của vợ 2
- Màu sắc phân biệt (vợ cả: xanh, vợ lẽ: đỏ...)

#### 1.6. Sắp xếp thứ tự
- Kéo thả thay đổi vị trí
- Nhập số thứ tự trực tiếp
- Số thứ tự cao → đứng đầu

---

### **MODULE 2: THÔNG TIN THÀNH VIÊN** 👤

#### 2.1. Thông tin cơ bản
- Họ tên đầy đủ
- Giới tính (Nam/Nữ/Khác)
- Ngày tháng năm sinh (ngày âm lịch + dương lịch)
- Nơi sinh (Tỉnh/Thành phố, Quận/Huyện, Xã/Phường)
- Địa chỉ hiện tại
- Email, Số điện thoại, Zalo, Facebook

#### 2.2. Tên gọi khác
- Tên thật
- Tên gọi ở nhà (tên thân mật)
- Tên tự
- Tên hiệu
- Tên pháp danh (nếu tu hành)

#### 2.3. Ảnh thành viên
- Upload ảnh đại diện
- Upload nhiều ảnh (album cá nhân)
- Ảnh chứng minh nhân dân/CCCD
- Ảnh gia đình
- Ảnh thời trẻ/hiện tại

#### 2.4. Tiểu sử
- Trình soạn thảo văn bản rich text
- Hỗ trợ định dạng: Bold, Italic, Underline
- Chèn hình ảnh, video
- Phân đoạn: Tuổi thơ, Học vấn, Sự nghiệp, Gia đình

#### 2.5. Thông tin mất (nếu có)
- Ngày mất (âm lịch + dương lịch)
- Nơi mất
- Nơi an táng
- Tọa độ mộ (Google Maps)

#### 2.6. Thông tin khác
- Nghề nghiệp
- Học vấn (Bằng cấp cao nhất)
- Tôn giáo
- Đảng phái
- Thành tích, giải thưởng

---

### **MODULE 3: HIỂN THỊ PHẢ ĐỒ** 📊

#### 3.1. Các chế độ hiển thị đường nối
- **Nằm ngang**: Cây ngang từ trái sang phải
- **Đường cong**: Nối bằng đường cong mềm mại
- **Đường thẳng**: Nối bằng đường thẳng góc

#### 3.2. Tùy chỉnh hiển thị
- Zoom in/out (50% - 200%)
- Hiển thị/Ẩn ảnh đại diện
- Hiển thị/Ẩn ngày sinh/mất
- Chế độ toàn màn hình

#### 3.3. Xem quan hệ xưng hô
- Chọn 2 thành viên bất kỳ
- Hệ thống tính toán: "A là [con trai] của B"
- Hiển thị đường đi trên cây
- Ví dụ: Cháu nội, Cháu ngoại, Cô, Dì, Bác, Chú...

#### 3.4. Tìm thành viên trên phả đồ
- Gõ tên → highlight thành viên
- Auto scroll đến vị trí thành viên
- Hiển thị đường đi từ gốc đến thành viên đó

---

### **MODULE 4: BẢO MẬT & CHIA SẺ** 🔒

#### 4.1. Tạo mã bảo mật
- Bật chế độ riêng tư cho phả đồ
- Tạo mã bảo mật (6-8 ký tự)
- Chỉ người có mã mới xem được

#### 4.2. Phân quyền xem
- **Public**: Ai cũng xem được
- **Private**: Chỉ thành viên gia tộc
- **Password**: Yêu cầu nhập mật khẩu

#### 4.3. Chia sẻ phả đồ
- Copy link chia sẻ: `https://giaphadonhong.vn/phadao/nguyen-chi-ho-1`
- Chia sẻ qua Facebook, Zalo
- Gửi email mời xem
- Tạo QR code

#### 4.4. Nhúng phả đồ
- Tạo iframe code
- Nhúng vào website khác
- Tùy chỉnh kích thước

---

### **MODULE 5: DANH SÁCH THÀNH VIÊN** 📋

#### 5.1. Xem danh sách
- Hiển thị dạng bảng
- Thông tin: STT, Ảnh, Họ tên, Ngày sinh, Đời thứ, Chi họ
- Sắp xếp theo: Tên, Ngày sinh, Đời thứ
- Phân trang: 20/50/100 thành viên/trang

#### 5.2. Tìm kiếm nâng cao
- Tìm theo tên (hỗ trợ tiếng Việt có dấu/không dấu)
- Lọc theo: Giới tính, Đời thứ, Độ tuổi, Còn sống/Đã mất
- Lọc theo địa danh
- Lọc theo nghề nghiệp

#### 5.3. Xem chi tiết
- Click vào thành viên → xem profile đầy đủ
- Các tab: Thông tin, Quan hệ, Ảnh, Tiểu sử, Sự kiện

#### 5.4. Liên kết đến sơ đồ
- Button "Xem trên phả đồ"
- Tự động highlight thành viên trong cây
- Hiển thị đường đi từ tổ tiên

#### 5.5. Xuất file Excel
- Xuất toàn bộ danh sách
- Xuất theo bộ lọc
- Format: STT, Họ tên, Ngày sinh, Nơi sinh, Đời thứ, Bố, Mẹ, Vợ/Chồng

---

### **MODULE 6: CẤU HÌNH WEBSITE** ⚙️

#### 6.1. Tạo Phả ký
- Trình soạn thảo văn bản
- Nội dung: Lịch sử dòng họ, Nguồn gốc, Phong tục, Truyền thống
- Hỗ trợ markdown
- Chèn ảnh, video, tài liệu

#### 6.2. Tùy chỉnh giao diện
- **Tên gia phả**: Họ Nguyễn, Chi Họ Bình Định...
- **Logo**: Upload logo (PNG, SVG)
- **Banner**: Ảnh bìa trang chủ (tối đa 2MB)
- **Màu chủ đạo**: Chọn màu theme

#### 6.3. Vị trí Nhà thờ Tộc
- Nhúng Google Maps iframe
- Hiển thị địa chỉ
- Chỉ đường từ vị trí hiện tại

#### 6.4. Thông tin liên hệ
- Số điện thoại hotline
- Email gia tộc
- Facebook fanpage
- Zalo group
- Địa chỉ văn phòng/nhà thờ

#### 6.5. Tên miền riêng
- Chuyển đổi từ `giaphadonhong.vn/nguyen` → `honguyen.vn`
- Hướng dẫn cấu hình DNS
- Cài đặt SSL certificate

---

### **MODULE 7: QUẢN TRỊ GIA PHẢ** 👨‍💼

#### 7.1. Thêm quản trị viên
- **Quản trị toàn bộ**: Quản lý tất cả
- **Quản trị nhánh**: Chỉ quản lý 1 nhánh (từ 1 tổ tiên xuống)
- Gửi email mời làm quản trị

#### 7.2. Phân quyền chi tiết
- **Quyền xem**: Xem phả đồ, Xem thành viên
- **Quyền sửa**: Sửa thông tin thành viên
- **Quyền thêm**: Thêm thành viên mới
- **Quyền xóa**: Xóa thành viên (không thể xóa gia phả)
- **Quyền đăng bài**: Đăng tin tức, sự kiện
- **Quyền duyệt**: Duyệt thành viên/bài viết trước khi công khai

#### 7.3. Theo dõi hoạt động
- Lịch sử thao tác của từng quản trị viên
- Ai làm gì, khi nào
- Xem thay đổi trước/sau
- Export log audit

#### 7.4. Xóa quyền quản trị
- Thu hồi quyền
- Gửi thông báo
- Backup dữ liệu trước khi thu hồi

---

### **MODULE 8: TIN TỨC & SỰ KIỆN** 📰

#### 8.1. Quản lý bài viết
- **Tạo bài viết mới:**
  - Tiêu đề
  - Nội dung (Rich text editor)
  - Ảnh đại diện
  - Chuyên mục
  - Trạng thái: Nháp/Công khai

- **Chỉnh sửa bài viết:**
  - Sửa nội dung
  - Thay đổi chuyên mục
  - Đăng/Hạ tin

#### 8.2. Chuyên mục
- Tin tức gia tộc
- Sự kiện - Lễ hội
- Nhân vật tiêu biểu
- Phong tục - Truyền thống
- Tạo chuyên mục mới

#### 8.3. Tạo sự kiện nhắc nhở
- **Loại sự kiện:**
  - Lễ giỗ tổ tiên
  - Lễ giỗ thành viên
  - Đại hội dòng họ
  - Họp mặt chi họ
  - Sinh nhật thành viên
  - Ngày cưới

- **Cài đặt nhắc nhở:**
  - Nhắc trước: 7 ngày, 3 ngày, 1 ngày
  - Gửi email thông báo
  - Gửi notification trên web

#### 8.4. Bật/Tắt hiển thị
- Bật/Tắt từng chuyên mục
- Bật/Tắt sự kiện trên trang chủ
- Bật/Tắt countdown sự kiện

#### 8.5. Đăng ký nhận thông báo
- Thành viên đăng ký email
- Tự động gửi email khi có sự kiện
- Tùy chọn loại sự kiện muốn nhận

#### 8.6. Chia sẻ bài viết
- Chia sẻ lên Facebook, Zalo
- Copy link bài viết
- Gửi email cho thành viên

---

### **MODULE 9: XUẤT FILE** 💾

#### 9.1. Xuất Excel
- **Xuất danh sách thành viên:**
  - Toàn bộ thành viên
  - Theo bộ lọc
  - Format: STT, Họ tên, Ngày sinh, Bố, Mẹ, Vợ/Chồng, Con cái

- **Xuất phả đồ Excel:**
  - Dạng bảng phả hệ
  - Phân cấp theo đời
  - Màu sắc phân biệt giới tính

#### 9.2. Xuất hình ảnh phả đồ
- Format: PNG, JPG
- Phông nền trắng (để in)
- Phông nền màu (để xem online)
- Chất lượng: HD, Full HD, 4K

#### 9.3. Xuất file in phả đồ
- **Template có sẵn:**
  - Mẫu 1: Phả đồ ngang
  - Mẫu 2: Phả đồ dọc
  - Mẫu 3: Phả đồ vòng tròn
  - Mẫu 4: Phả đồ hiện đại

- **Tùy chỉnh in:**
  - Khổ giấy: A4, A3, A2, A1, A0
  - Hướng: Ngang/Dọc
  - Margin
  - Header/Footer tùy chỉnh

#### 9.4. Xuất PDF
- Xuất toàn bộ phả đồ
- Xuất phả ký (lịch sử dòng họ)
- Xuất danh sách thành viên
- Hỗ trợ bookmark navigation

---

### **MODULE 10: THỐNG KÊ & BÁO CÁO** 📊

#### 10.1. Thống kê lượt xem
- Tổng số lượt xem website
- Lượt xem theo ngày/tuần/tháng
- Lượt xem phả đồ
- Lượt xem từng thành viên
- Biểu đồ tăng trưởng

#### 10.2. Thống kê thành viên
- Tổng số thành viên
- Phân bố theo giới tính (Biểu đồ tròn)
- Phân bố theo độ tuổi (Biểu đồ cột)
- Phân bố theo địa danh (Bản đồ)
- Số lượng theo đời thứ

#### 10.3. Thống kê hoạt động
- Số lượng thành viên mới thêm (theo tháng)
- Số bài viết đăng
- Số sự kiện tổ chức
- Thành viên hoạt động nhiều nhất

---

### **MODULE 11: AFFILIATE (TIẾP THỊ LIÊN KẾT)** 💰

#### 11.1. Đăng ký Affiliate
- Tạo tài khoản affiliate
- Nhận mã giới thiệu riêng
- Link giới thiệu: `giaphadonhong.vn/ref/ABC123`

#### 11.2. Dashboard Affiliate
- Số lượng người đăng ký qua link
- Số gói nâng cấp bán được
- Doanh thu hoa hồng
- Lịch sử giao dịch

#### 11.3. Hoa hồng
- 10% cho đăng ký gói PRO
- 15% cho đăng ký gói PREMIUM
- 20% cho đăng ký gói ENTERPRISE
- Thanh toán qua: Banking, Momo, Paypal

#### 11.4. Tài liệu Marketing
- Banner quảng cáo
- Video giới thiệu
- Nội dung mẫu cho Facebook
- Email template

---

## 🔐 PHÂN QUYỀN CHI TIẾT

### **ADMIN (Quản trị viên cao nhất)**

| Chức năng | Quyền |
|-----------|-------|
| Tạo/Sửa/Xóa Họ | ✅ |
| Tạo/Sửa/Xóa Chi Họ | ✅ |
| Quản lý tất cả thành viên | ✅ |
| Phân quyền quản trị | ✅ |
| Cấu hình website | ✅ |
| Tạo phả ký | ✅ |
| Đăng tin tức/sự kiện | ✅ |
| Xuất file | ✅ |
| Xem thống kê | ✅ |
| Backup/Restore | ✅ |
| Quản lý Affiliate | ✅ |

### **CHI_HO_ADMIN (Quản trị nhánh)**

| Chức năng | Quyền |
|-----------|-------|
| Quản lý thành viên nhánh mình | ✅ |
| Xem thành viên nhánh khác | ✅ (chỉ xem) |
| Đăng tin tức | ✅ (cần duyệt) |
| Tạo sự kiện | ✅ |
| Xuất file nhánh mình | ✅ |
| Xem thống kê nhánh | ✅ |
| Cấu hình website | ❌ |
| Phân quyền | ❌ |

### **USER (Thành viên)**

| Chức năng | Quyền |
|-----------|-------|
| Xem phả đồ | ✅ |
| Đề xuất thêm thành viên | ✅ (cần duyệt) |
| Cập nhật thông tin bản thân | ✅ |
| Bình luận | ✅ |
| Xem tin tức | ✅ |
| Đăng ký sự kiện | ✅ |
| Xuất file | ❌ |

---

## 🎯 ROADMAP PHÁT TRIỂN

### **Phase 1: Core Features** (Tháng 1-2)
- ✅ Authentication & Authorization
- ✅ Quản lý Họ & Chi Họ
- ✅ Quản lý thành viên cơ bản
- ✅ Notification system
- ⏳ Vẽ cây gia phả (đang làm)

### **Phase 2: Phả đồ nâng cao** (Tháng 3-4)
- Quan hệ nhiều vợ/chồng
- Sắp xếp thứ tự thành viên
- Xem quan hệ xưng hô
- Các chế độ hiển thị đường nối
- Bảo mật & chia sẻ

### **Phase 3: Content Management** (Tháng 5-6)
- Tin tức & Sự kiện
- Album ảnh
- Upload files
- Phả ký
- Nhà thờ tộc

### **Phase 4: Export & Print** (Tháng 7)
- Xuất Excel
- Xuất hình ảnh
- Template in ấn
- Xuất PDF

### **Phase 5: Analytics & Monetization** (Tháng 8-9)
- Dashboard thống kê
- Báo cáo chi tiết
- Affiliate system
- Payment gateway

---

## 🛠️ TECH STACK

### **Frontend**
- React 19 + TypeScript + Vite
- Material-UI + Bootstrap 5
- React Flow Renderer (Vẽ cây gia phả)
- XLSX (Xuất Excel)
- html2canvas + jsPDF (Xuất PDF/Image)
- React Toastify (Notifications)

### **Backend**
- .NET 8.0 + EF Core
- MySQL Database
- JWT Authentication
- MediatR (CQRS Pattern)
- Clean Architecture

### **DevOps**
- Docker
- CI/CD (GitHub Actions)
- Nginx
- SSL Certificate

---

## 📝 LƯU Ý QUAN TRỌNG

1. **Quan hệ phức tạp**: Hỗ trợ đa thê (nhiều vợ/chồng) theo phong tục Việt Nam
2. **Số thứ tự**: Con cả = số lớn, con út = số nhỏ
3. **Bảo mật**: Mã hóa thông tin nhạy cảm (CCCD, địa chỉ...)
4. **Audit Log**: Ghi lại mọi thay đổi, ai làm gì khi nào
5. **Backup tự động**: Hàng ngày lúc 2h sáng
6. **Tên miền riêng**: Hỗ trợ custom domain cho khách VIP

---

Developed with ❤️ for Vietnamese family trees | © 2026 Gia Phả Dòng Họ

---

## 🔵 CHỨC NĂNG USER (Người dùng)

### **1. XÁC THỰC & TÀI KHOẢN**

#### 1.1. Đăng ký tài khoản
- Nhập thông tin: Tên đăng nhập, Email, Mật khẩu, Giới tính
- Hệ thống gửi mã xác thực 6 số qua email
- Nhập mã để kích hoạt tài khoản

#### 1.2. Đăng nhập
- Đăng nhập bằng email/username và mật khẩu
- Hệ thống cấp JWT token (access token + refresh token)
- Tự động lưu trạng thái đăng nhập

#### 1.3. Quản lý profile
- Xem thông tin cá nhân
- Cập nhật: Tên, Avatar, Email, Giới tính
- Đổi mật khẩu
- Link tài khoản với thành viên trong gia phả

#### 1.4. Quên mật khẩu
- Nhập email đã đăng ký
- Nhận mật khẩu mới qua email
- Đăng nhập và đổi lại mật khẩu

---

### **2. QUẢN LÝ THÀNH VIÊN GIA PHẢ**

#### 2.1. Thêm thành viên mới
- **Thông tin cơ bản:**
  - Họ tên
  - Giới tính (Nam/Nữ/Khác)
  - Ngày sinh, Nơi sinh
  - Email
  - Ảnh đại diện
  
- **Thông tin chi tiết:**
  - Đời thứ (đời 1, 2, 3...)
  - Chi họ (thuộc chi họ nào)
  - Tiểu sử
  - Ngày mất, Nơi mất (nếu có)

- **Tự động:**
  - Hệ thống gửi thông báo đến tất cả thành viên cùng chi họ
  - Gửi thông báo cho cả dòng họ đó

#### 2.2. Xem danh sách thành viên
- Xem tất cả thành viên trong chi họ của mình
- Hiển thị dạng lưới/danh sách
- Thông tin hiển thị: Ảnh, Họ tên, Ngày sinh, Đời thứ
- Sắp xếp theo: Tên, Ngày sinh, Đời thứ

#### 2.3. Xem chi tiết thành viên
- **Tab Thông tin:**
  - Thông tin cá nhân đầy đủ
  - Tiểu sử
  - Ảnh đại diện
  
- **Tab Quan hệ:**
  - Cha/Mẹ
  - Vợ/Chồng
  - Con cái
  - Anh chị em

- **Tab Sự kiện:**
  - Các sự kiện liên quan
  - Sinh nhật, Giỗ, Họp mặt...

- **Tab Album:**
  - Ảnh của thành viên này
  - Ảnh được tag

- **Tab Thành tựu:**
  - Học vấn
  - Sự nghiệp
  - Giải thưởng

#### 2.4. Chỉnh sửa thông tin
- Chỉ sửa được thành viên do mình tạo
- Cập nhật mọi thông tin
- Lịch sử thay đổi được lưu lại

#### 2.5. Xóa thành viên
- Chỉ xóa được thành viên do mình tạo
- Xác nhận trước khi xóa
- Xóa mềm (có thể khôi phục)

#### 2.6. Tìm kiếm thành viên
- Tìm theo tên
- Lọc theo: Giới tính, Đời thứ, Độ tuổi
- Tìm kiếm nâng cao

---

### **3. QUẢN LÝ QUAN HỆ GIA PHẢ**

#### 3.1. Thêm quan hệ Cha-Con
- Chọn người cha
- Chọn con (có thể chọn nhiều)
- Hệ thống tự động cập nhật cây gia phả

#### 3.2. Thêm quan hệ Hôn nhân
- Chọn vợ/chồng
- Ngày cưới
- Tình trạng hôn nhân

#### 3.3. Xem cây gia phả
- Hiển thị dạng cây phả đồ
- Zoom in/out
- Click vào thành viên để xem chi tiết
- Hiển thị quan hệ bằng màu sắc/đường nối

#### 3.4. Tìm quan hệ giữa 2 người
- Chọn 2 thành viên
- Hệ thống tính toán quan hệ
- Hiển thị: "A là cháu nội của B", "A là cô của B"...

---

### **4. QUẢN LÝ SỰ KIỆN**

#### 4.1. Tạo sự kiện mới
- **Loại sự kiện:**
  - Sinh nhật
  - Giỗ
  - Họp mặt gia đình
  - Lễ cưới
  - Lễ đầy tháng
  - Khác...

- **Thông tin:**
  - Tên sự kiện
  - Ngày giờ
  - Địa điểm
  - Mô tả
  - Danh sách tham gia

#### 4.2. Xem danh sách sự kiện
- Hiển thị dạng lịch (Calendar)
- Sự kiện sắp tới
- Sự kiện đã qua
- Lọc theo loại sự kiện

#### 4.3. Đăng ký tham gia sự kiện
- Click "Tham gia"
- Xác nhận tham dự
- Nhận thông báo nhắc nhở

#### 4.4. Chỉnh sửa/Xóa sự kiện
- Chỉ sửa được sự kiện do mình tạo
- Cập nhật thông tin
- Xóa sự kiện

---

### **5. QUẢN LÝ ALBUM & ẢNH**

#### 5.1. Tạo album mới
- Tên album
- Mô tả
- Quyền xem (Chi họ/Dòng họ/Riêng tư)

#### 5.2. Upload ảnh
- Upload nhiều ảnh cùng lúc
- Kéo thả file
- Hỗ trợ: JPG, PNG, GIF
- Tự động nén ảnh

#### 5.3. Xem album
- Hiển thị dạng lưới
- Slideshow
- Zoom ảnh
- Chia sẻ

#### 5.4. Tag thành viên trong ảnh
- Click vào ảnh
- Chọn vị trí trên ảnh
- Chọn thành viên để tag
- Hiển thị tên khi hover

#### 5.5. Tải về ảnh
- Tải ảnh gốc
- Tải album (ZIP)

---

### **6. QUẢN LÝ TỆP TIN**

#### 6.1. Upload tài liệu
- **Loại file:**
  - Giấy khai sinh
  - Giấy chứng tử
  - Sổ đỏ
  - Bằng cấp
  - Giấy tờ khác

- Upload file PDF, DOC, DOCX, XLS
- Tối đa 10MB/file

#### 6.2. Xem danh sách file
- Phân loại theo loại
- Tìm kiếm file
- Preview file online

#### 6.3. Tải về file
- Tải từng file
- Tải nhiều file (ZIP)

---

### **7. TƯƠNG TÁC XÃ HỘI**

#### 7.1. Bình luận (Comment)
- Comment trên profile thành viên
- Comment trên sự kiện
- Comment trên ảnh
- Trả lời comment
- React (Like, Love...)

#### 7.2. Thành tựu
- Thêm thành tựu cho thành viên
- Loại: Học vấn, Sự nghiệp, Giải thưởng, Khác
- Năm đạt được
- Mô tả chi tiết

---

### **8. THÔNG BÁO**

#### 8.1. Xem thông báo
- **Phân loại tự động:**
  - 🌍 Toàn hệ thống (badge vàng)
  - 🏠 Dòng họ (badge xanh lá)
  - 👥 Chi họ (badge xanh dương)
  - 👤 Cá nhân

- **Tab lọc:**
  - Tất cả
  - Tin mới (chưa đọc)
  - Đã đọc

#### 8.2. Tự động cập nhật
- Refresh mỗi 30 giây
- Badge hiển thị số thông báo chưa đọc
- Sound notification (tùy chọn)

#### 8.3. Đánh dấu đã đọc
- Click vào thông báo → tự động đánh dấu đã đọc
- Button "Đánh dấu tất cả đã đọc"

#### 8.4. Loại thông báo nhận được:
- Thành viên mới được thêm vào chi họ
- Sự kiện sắp diễn ra
- Ai đó comment trên profile
- Được tag trong ảnh
- Thông báo từ admin

---

## 🔴 CHỨC NĂNG ADMIN (Quản trị viên)

Admin có **TẤT CẢ** quyền của USER + các quyền mở rộng:

### **1. QUẢN LÝ DÒNG HỌ (HỌ)**

#### 1.1. Tạo dòng họ mới
- Tên họ (VD: Họ Nguyễn, Họ Trần...)
- Mô tả về dòng họ
- Lịch sử nguồn gốc
- Ảnh đại diện họ

#### 1.2. Xem danh sách họ
- Tất cả các dòng họ trong hệ thống
- Số lượng chi họ
- Số lượng thành viên
- Thống kê

#### 1.3. Chỉnh sửa thông tin họ
- Cập nhật tên, mô tả
- Thay đổi ảnh
- Chỉnh sửa lịch sử

#### 1.4. Xóa họ
- Xóa dòng họ (cẩn thận!)
- Xác nhận nhiều lần
- Xóa cascade (xóa cả chi họ, thành viên)

---

### **2. QUẢN LÝ CHI HỌ**

#### 2.1. Tạo chi họ mới
- Thuộc dòng họ nào
- Tên chi họ
- Mô tả
- Chỉ định trưởng chi

#### 2.2. Xem tất cả chi họ
- Của tất cả các dòng họ
- Số lượng thành viên
- Trưởng chi là ai

#### 2.3. Chỉ định trưởng chi
- Chọn thành viên trong chi họ
- Trưởng chi có quyền phê duyệt thành viên mới
- Quản lý sự kiện chi họ

#### 2.4. Sửa/Xóa chi họ
- Cập nhật thông tin
- Xóa chi họ (cascade)

---

### **3. QUẢN LÝ TÀI KHOẢN NGƯỜI DÙNG**

#### 3.1. Xem tất cả tài khoản
- Danh sách user
- Thông tin: Email, Role, Ngày đăng ký, Trạng thái
- Tìm kiếm user

#### 3.2. Phân quyền
- Nâng user lên ADMIN
- Hạ ADMIN xuống USER
- Ghi log thay đổi

#### 3.3. Gán chi họ cho user
- Chọn user
- Gán vào chi họ cụ thể
- User sẽ thấy thông báo của chi họ đó

#### 3.4. Link user với thành viên
- Liên kết tài khoản với thành viên trong gia phả
- 1 user chỉ link 1 thành viên
- Dùng để xác định quan hệ

#### 3.5. Kích hoạt/Khóa tài khoản
- Khóa tài khoản vi phạm
- Mở khóa tài khoản
- Xóa tài khoản

#### 3.6. Xem lịch sử hoạt động
- Audit log của từng user
- Xem user đã làm gì
- Thời gian, hành động

---

### **4. QUẢN LÝ THÔNG BÁO NÂNG CAO**

#### 4.1. Gửi thông báo toàn hệ thống
- Tất cả user đều nhận
- Dùng cho bảo trì, cập nhật tính năng

#### 4.2. Gửi thông báo cho dòng họ
- Chọn 1 dòng họ
- Tất cả chi họ thuộc dòng họ đó nhận

#### 4.3. Gửi thông báo cho chi họ
- Chọn 1 chi họ cụ thể
- Chỉ thành viên chi họ đó nhận

#### 4.4. Gửi thông báo cá nhân
- Chọn 1 user
- Gửi tin nhắn riêng

#### 4.5. Xem tất cả thông báo
- Admin thấy mọi thông báo trong hệ thống
- Lọc theo loại
- Xóa thông báo

---

### **5. QUẢN LÝ DỮ LIỆU TOÀN CỤC**

#### 5.1. Duyệt thành viên mới
- Xem thành viên user vừa thêm
- Phê duyệt/Từ chối
- Gửi lý do từ chối

#### 5.2. Xóa thành viên bất kỳ
- Xóa thành viên của bất kỳ user nào
- Xóa thành viên trùng lặp
- Merge thành viên

#### 5.3. Sửa quan hệ
- Fix quan hệ sai
- Xóa quan hệ không hợp lệ

---

### **6. DASHBOARD & THỐNG KÊ**

#### 6.1. Dashboard tổng quan
- Tổng số họ
- Tổng số chi họ
- Tổng số thành viên
- Tổng số user
- Biểu đồ tăng trưởng

#### 6.2. Thống kê chi tiết
- **Theo dòng họ:**
  - Số lượng chi họ
  - Số lượng thành viên
  - Tỷ lệ nam/nữ
  - Độ tuổi trung bình

- **Theo chi họ:**
  - Thống kê từng chi họ
  - Đời thứ cao nhất
  - Số lượng thế hệ

- **Theo user:**
  - User hoạt động nhiều nhất
  - User thêm nhiều thành viên
  - User không hoạt động

#### 6.3. Biểu đồ
- Biểu đồ tăng trưởng thành viên
- Biểu đồ phân bố độ tuổi
- Biểu đồ giới tính
- Biểu đồ theo tỉnh thành

#### 6.4. Xuất báo cáo
- Xuất Excel
- Xuất PDF
- In ấn phả đồ

---

### **7. QUẢN LÝ HỆ THỐNG**

#### 7.1. Cấu hình hệ thống
- Tên website
- Logo
- Email hệ thống
- Cài đặt thông báo

#### 7.2. Quản lý file upload
- Dung lượng đã dùng
- Xóa file không dùng
- Giới hạn kích thước

#### 7.3. Backup & Restore
- Backup database
- Restore từ backup
- Lên lịch backup tự động

#### 7.4. Audit Log
- Xem tất cả log hệ thống
- Ai làm gì, khi nào
- Export log

---

## 📊 SO SÁNH QUYỀN HẠN

| Chức năng | USER | ADMIN |
|-----------|------|-------|
| Xem thành viên chi họ mình | ✅ | ✅ |
| Xem thành viên chi họ khác | ❌ | ✅ |
| Thêm thành viên | ✅ | ✅ |
| Sửa thành viên mình tạo | ✅ | ✅ |
| Sửa thành viên người khác tạo | ❌ | ✅ |
| Xóa thành viên | ✅ (của mình) | ✅ (bất kỳ) |
| Tạo chi họ | ❌ | ✅ |
| Tạo dòng họ | ❌ | ✅ |
| Gán chi họ cho user | ❌ | ✅ |
| Phân quyền | ❌ | ✅ |
| Gửi thông báo hệ thống | ❌ | ✅ |
| Xem thống kê toàn bộ | ❌ | ✅ |
| Xem audit log | ❌ | ✅ |
| Backup hệ thống | ❌ | ✅ |

---

## 🚀 CÁC TÍNH NĂNG NỔI BẬT

### ✨ Thông báo thông minh
- Phân loại tự động: Toàn hệ thống / Dòng họ / Chi họ / Cá nhân
- Auto-refresh mỗi 30 giây
- Badge hiển thị số thông báo chưa đọc
- Filter: Tất cả / Mới / Cũ

### 🌳 Cây gia phả interactive
- Hiển thị quan hệ trực quan
- Zoom in/out
- Tìm quan hệ giữa 2 người
- Export phả đồ PDF

### 📸 Quản lý ảnh & Album
- Upload nhiều ảnh
- Tag thành viên trong ảnh
- Slideshow
- Chia sẻ album

### 📅 Quản lý sự kiện
- Lịch sự kiện
- Nhắc nhở tự động
- Đăng ký tham dự

### 🔒 Bảo mật
- JWT Authentication
- Role-based Authorization
- Refresh token
- Audit log

---

## 🛠️ TECH STACK

- **Frontend**: React 19 + TypeScript + Vite
- **UI Library**: Material-UI + Bootstrap 5
- **State Management**: React Context API
- **Routing**: React Router DOM v7
- **HTTP Client**: Fetch API
- **Notifications**: React Toastify
- **Authentication**: JWT (jwt-decode)

---

## 📝 GHI CHÚ

- User chỉ xem được dữ liệu của chi họ mình
- Admin xem được toàn bộ hệ thống
- Thông báo được phân quyền tự động dựa vào ChiHoId và HoId
- Tất cả thay đổi đều được ghi log (AuditLog)

---

Developed with ❤️ for Vietnamese family trees