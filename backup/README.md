# Database Backup

## Thông tin backup
- **Ngày tạo**: 15/09/2025
- **Phiên bản**: v1.0.0
- **Database**: SQLite

## Nội dung database
- Bảng Users (với admin account)
- Bảng Services (6 dịch vụ mẫu)
- Bảng Bookings (sẽ có sample data khi chạy app)
- Bảng WebsiteContents (3 nội dung mẫu)

## Cách khôi phục
1. Dừng ứng dụng
2. Copy file `SuaNhaMVC_backup.db` thành `SuaNhaMVC.db`
3. Chạy lại ứng dụng

## Thông tin đăng nhập Admin
- **Email**: admin@admin.com
- **Password**: admin@123

## Cấu trúc dữ liệu hiện tại
- Services: 6 dịch vụ (điện nước, sơn nhà, lát gạch, sửa mái, trần thạch cao, sửa cửa)
- WebsiteContents: 3 nội dung (hero-title, about-title, contact-phone)
- Migrations: AddWebsiteContent, FixSeedData