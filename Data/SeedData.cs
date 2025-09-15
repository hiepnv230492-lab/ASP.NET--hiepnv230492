using Microsoft.AspNetCore.Identity;
using SuaNhaMVC.Models;

namespace SuaNhaMVC.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            
            // Tạo tài khoản admin
            var adminEmail = "admin@admin.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            
            if (adminUser == null)
            {
                adminUser = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FullName = "Administrator",
                    Phone = "0901234567",
                    IsAdmin = true,
                    CreatedAt = new DateTime(2025, 9, 15)
                };
                
                await userManager.CreateAsync(adminUser, "admin@123");
            }

            // Tạo sample users và bookings
            await CreateSampleBookings(userManager, context);
        }

        private static async Task CreateSampleBookings(UserManager<User> userManager, ApplicationDbContext context)
        {
            // Kiểm tra nếu đã có booking thì không tạo nữa
            if (context.Bookings.Any()) return;

            var services = context.Services.ToList();
            if (!services.Any()) return;

            // Tạo sample users
            var sampleUsers = new[]
            {
                new { Email = "nguyenvan.a@gmail.com", Name = "Nguyễn Văn A", Phone = "0901111111" },
                new { Email = "tranthib@gmail.com", Name = "Trần Thị B", Phone = "0902222222" },
                new { Email = "levanc@gmail.com", Name = "Lê Văn C", Phone = "0903333333" },
                new { Email = "phamthid@gmail.com", Name = "Phạm Thị D", Phone = "0904444444" },
                new { Email = "hoangvane@gmail.com", Name = "Hoàng Văn E", Phone = "0905555555" }
            };

            var users = new List<User>();
            foreach (var userData in sampleUsers)
            {
                var existingUser = await userManager.FindByEmailAsync(userData.Email);
                if (existingUser == null)
                {
                    var user = new User
                    {
                        UserName = userData.Email,
                        Email = userData.Email,
                        FullName = userData.Name,
                        Phone = userData.Phone,
                        IsAdmin = false,
                        CreatedAt = DateTime.UtcNow.AddDays(-new Random().Next(1, 30))
                    };
                    
                    await userManager.CreateAsync(user, "User@123");
                    users.Add(user);
                }
                else
                {
                    users.Add(existingUser);
                }
            }

            // Tạo sample bookings
            var random = new Random();
            var bookings = new List<Booking>();
            var statuses = new[] { BookingStatus.Pending, BookingStatus.Confirmed, BookingStatus.InProgress, BookingStatus.Completed, BookingStatus.Cancelled };

            for (int i = 0; i < 15; i++)
            {
                var user = users[random.Next(users.Count)];
                var service = services[random.Next(services.Count)];
                var createdDate = DateTime.UtcNow.AddDays(-random.Next(1, 30));
                var bookingDate = createdDate.AddDays(random.Next(1, 14));

                var booking = new Booking
                {
                    Id = Guid.NewGuid().ToString(),
                    UserId = user.Id,
                    ServiceId = service.Id,
                    CustomerName = user.FullName,
                    CustomerPhone = user.Phone,
                    CustomerAddress = $"{random.Next(1, 999)} Đường {(char)('A' + random.Next(0, 26))}, Quận {random.Next(1, 12)}, TP.HCM",
                    BookingDate = bookingDate,
                    BookingTime = $"{random.Next(8, 17):00}:00",
                    Notes = i % 3 == 0 ? "Cần sửa gấp, liên hệ trước khi đến" : 
                           i % 2 == 0 ? "Nhà có người già, vui lòng chú ý" : null,
                    Status = statuses[random.Next(statuses.Length)],
                    CreatedAt = createdDate
                };

                bookings.Add(booking);
            }

            context.Bookings.AddRange(bookings);
            await context.SaveChangesAsync();
        }
    }
}