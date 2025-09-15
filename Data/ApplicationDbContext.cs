using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuaNhaMVC.Models;

namespace SuaNhaMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Service> Services { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<WebsiteContent> WebsiteContents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure Service
            builder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            });

            // Configure Booking
            builder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.User)
                      .WithMany(u => u.Bookings)
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
                      
                entity.HasOne(e => e.Service)
                      .WithMany(s => s.Bookings)
                      .HasForeignKey(e => e.ServiceId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure WebsiteContent
            builder.Entity<WebsiteContent>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Key).IsUnique();
            });

            // Seed data
            SeedData(builder);
        }

        private void SeedData(ModelBuilder builder)
        {
            // Seed Services
            var services = new[]
            {
                new Service
                {
                    Id = "1",
                    Name = "Sửa chữa điện nước",
                    Description = "Dịch vụ sửa chữa hệ thống điện và nước trong nhà, bảo trì định kỳ",
                    Price = 500000,
                    ImageUrl = "https://images.pexels.com/photos/1345139/pexels-photo-1345139.jpeg",
                    Category = "Điện nước",
                    CreatedAt = new DateTime(2025, 9, 15)
                },
                new Service
                {
                    Id = "2",
                    Name = "Sơn nhà, tường",
                    Description = "Dịch vụ sơn nhà chuyên nghiệp, màu sắc đa dạng, bền đẹp",
                    Price = 800000,
                    ImageUrl = "https://images.pexels.com/photos/1669799/pexels-photo-1669799.jpeg",
                    Category = "Sơn",
                    CreatedAt = new DateTime(2025, 9, 15)
                },
                new Service
                {
                    Id = "3",
                    Name = "Lát gạch, đá",
                    Description = "Thi công lát gạch men, gạch granite, đá tự nhiên chất lượng cao",
                    Price = 1200000,
                    ImageUrl = "https://images.pexels.com/photos/1080721/pexels-photo-1080721.jpeg",
                    Category = "Gạch",
                    CreatedAt = new DateTime(2025, 9, 15)
                },
                new Service
                {
                    Id = "4",
                    Name = "Sửa chữa mái nhà",
                    Description = "Sửa chữa, thay thế ngói, chống dột mái nhà hiệu quả",
                    Price = 1500000,
                    ImageUrl = "https://images.pexels.com/photos/186077/pexels-photo-186077.jpeg",
                    Category = "Mái",
                    CreatedAt = new DateTime(2025, 9, 15)
                },
                new Service
                {
                    Id = "5",
                    Name = "Làm trần thạch cao",
                    Description = "Thi công trần thạch cao đẹp, chống ẩm, cách nhiệt tốt",
                    Price = 900000,
                    ImageUrl = "https://images.pexels.com/photos/1571460/pexels-photo-1571460.jpeg",
                    Category = "Trần",
                    CreatedAt = new DateTime(2025, 9, 15)
                },
                new Service
                {
                    Id = "6",
                    Name = "Sửa cửa, khóa",
                    Description = "Sửa chữa, thay thế cửa ra vào, khóa cửa an toàn",
                    Price = 300000,
                    ImageUrl = "https://images.pexels.com/photos/277559/pexels-photo-277559.jpeg",
                    Category = "Cửa",
                    CreatedAt = new DateTime(2025, 9, 15)
                }
            };

            builder.Entity<Service>().HasData(services);

            // Seed WebsiteContents
            var contents = new[]
            {
                new WebsiteContent
                {
                    Id = "content-1",
                    Key = "hero-title",
                    Title = "Dịch Vụ Sửa Nhà Cửa Chuyên Nghiệp",
                    Content = "Chúng tôi cung cấp dịch vụ sửa chữa nhà cửa toàn diện với đội ngũ thợ lành nghề, giá cả hợp lý",
                    Type = ContentType.Hero,
                    Order = 1,
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 9, 15, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2025, 9, 15, 0, 0, 0, DateTimeKind.Utc)
                },
                new WebsiteContent
                {
                    Id = "content-2",
                    Key = "about-title",
                    Title = "Về Chúng Tôi",
                    Content = "Với hơn 10 năm kinh nghiệm trong lĩnh vực sửa chữa nhà cửa, chúng tôi cam kết mang đến dịch vụ chất lượng cao nhất cho khách hàng.",
                    Type = ContentType.AboutUs,
                    Order = 1,
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 9, 15, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2025, 9, 15, 0, 0, 0, DateTimeKind.Utc)
                },
                new WebsiteContent
                {
                    Id = "content-3",
                    Key = "contact-phone",
                    Title = "Hotline",
                    Content = "0123.456.789",
                    Type = ContentType.Contact,
                    Order = 1,
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 9, 15, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2025, 9, 15, 0, 0, 0, DateTimeKind.Utc)
                }
            };

            builder.Entity<WebsiteContent>().HasData(contents);
        }
    }
}