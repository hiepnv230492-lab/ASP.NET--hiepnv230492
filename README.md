# WEBSITE DỊCH VỤ SỬA NHÀ CỬA

## THÔNG TIN SINH VIÊN
- **Họ tên:** Nguyễn Văn Hiệp
- **Ngày sinh:** 23/04/1992
- **Email:** hiepnv230492@sv-onuni.edu.vn
- **Số điện thoại:** 0398125356
- **Tài khoản:** hiepnv230492
- **Lớp:** DK23TTK11
- **Mã sinh viên:** 170123427

## TỔNG QUAN DỰ ÁN
Website quản lý dịch vụ sửa nhà cửa được xây dựng bằng ASP.NET Core MVC với hệ thống quản trị hoàn chỉnh.

## CÔNG NGHỆ SỬ DỤNG
- **Framework:** ASP.NET Core MVC 9.0
- **Database:** SQLite + Entity Framework Core
- **Authentication:** ASP.NET Core Identity
- **Frontend:** Bootstrap 5, FontAwesome, Custom CSS
- **IDE:** Visual Studio Code / Visual Studio

## CÁC BƯỚC THỰC HIỆN

### Bước 1: Khởi tạo dự án (15/09/2025)
- [x] Tạo project ASP.NET Core MVC
- [x] Cấu hình Entity Framework với SQLite
- [x] Setup ASP.NET Core Identity

### Bước 2: Thiết kế Database (15/09/2025)
- [x] Tạo model User, Service, Booking
- [x] Cấu hình relationships trong ApplicationDbContext
- [x] Tạo migration InitialCreate
- [x] Seed data mẫu cho Services

### Bước 3: Xây dựng Controllers (15/09/2025)
- [x] HomeController - Trang chủ
- [x] ServicesController - Quản lý dịch vụ
- [x] BookingController - Đặt dịch vụ
- [x] AccountController - Đăng nhập/đăng ký
- [x] AdminController - Quản trị hệ thống

### Bước 4: Thiết kế Views (15/09/2025)
- [x] Layout chính với Bootstrap 5
- [x] Trang chủ responsive
- [x] Danh sách dịch vụ
- [x] Form đặt dịch vụ
- [x] Trang đăng nhập/đăng ký

### Bước 5: Hệ thống quản trị (15/09/2025)
- [x] Dashboard admin với thống kê
- [x] Quản lý dịch vụ (CRUD)
- [x] Quản lý đơn hàng
- [x] Cập nhật trạng thái đơn hàng

### Bước 6: Quản lý nội dung động (15/09/2025)
- [x] Tạo model WebsiteContent
- [x] Migration AddWebsiteContent
- [x] Trang quản lý nội dung website
- [x] CRUD operations cho nội dung
- [x] Filter theo loại nội dung

### Bước 7: Cài đặt hệ thống (15/09/2025)
- [x] Trang Settings với form cấu hình
- [x] Quản lý thông tin website
- [x] Cài đặt liên hệ và mạng xã hội
- [x] Trạng thái hệ thống

### Bước 8: Tối ưu giao diện (15/09/2025)
- [x] Thiết kế admin panel hiện đại
- [x] Gradient colors và animations
- [x] Responsive design
- [x] Icons và visual effects

### Bước 9: Seed Data và Testing (15/09/2025)
- [x] Tạo SeedData cho sample bookings
- [x] Tạo sample users và đơn hàng
- [x] Test các chức năng chính
- [x] Backup database

## TÍNH NĂNG CHÍNH

### Người dùng
- Xem danh sách dịch vụ
- Đặt lịch sử dụng dịch vụ
- Xem lịch sử đơn hàng
- Đăng ký/đăng nhập tài khoản

### Quản trị viên
- Dashboard với thống kê tổng quan
- Quản lý dịch vụ (thêm/sửa/xóa)
- Quản lý đơn hàng và cập nhật trạng thái
- Quản lý nội dung website động
- Cài đặt thông tin hệ thống

## CẤU TRÚC DATABASE

### Bảng Users
- Thông tin người dùng và admin
- Tích hợp ASP.NET Core Identity

### Bảng Services
- 6 dịch vụ: Điện nước, Sơn nhà, Lát gạch, Sửa mái, Trần thạch cao, Sửa cửa
- Thông tin giá, mô tả, hình ảnh

### Bảng Bookings
- Đơn đặt dịch vụ từ khách hàng
- Trạng thái: Pending, Confirmed, InProgress, Completed, Cancelled

### Bảng WebsiteContents
- Nội dung động cho website
- Loại: Hero, AboutUs, Service, Testimonial, Contact, Footer

## HƯỚNG DẪN CHẠY DỰ ÁN

### Yêu cầu hệ thống
- .NET 9.0 SDK
- Visual Studio Code hoặc Visual Studio

### Các bước chạy
1. Clone/Download source code
2. Mở terminal tại thư mục dự án
3. Chạy lệnh: `dotnet restore`
4. Chạy lệnh: `dotnet ef database update`
5. Chạy lệnh: `dotnet run`
6. Truy cập: `http://localhost:5011`

### Tài khoản mặc định
- **Admin:** admin@admin.com / admin@123
- **User:** Tự đăng ký hoặc sử dụng sample users

## BACKUP & RESTORE
- **Backup location:** `/backup/SuaNhaMVC_backup.db`
- **Restore:** Chạy `backup/restore.bat`

## TIẾN ĐỘ HOÀN THÀNH
- [x] **100%** - Dự án hoàn thành đầy đủ tính năng
- [x] **Frontend:** Giao diện responsive, hiện đại
- [x] **Backend:** Logic xử lý hoàn chỉnh
- [x] **Database:** Cấu trúc tối ưu với sample data
- [x] **Admin Panel:** Hệ thống quản trị chuyên nghiệp
- [x] **Testing:** Đã test các chức năng chính

## GHI CHÚ
- Dự án được phát triển trong 1 ngày (15/09/2025)
- Sử dụng SQLite để dễ dàng deploy và demo
- Code được tổ chức theo mô hình MVC chuẩn
- Responsive design tương thích mobile và desktop
- Có thể mở rộng thêm tính năng thanh toán, chat, notification

---
**Ngày hoàn thành:** 15/09/2025  
**Sinh viên thực hiện:** Nguyễn Văn Hiệp - 170123427