using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SuaNhaMVC.Migrations
{
    /// <inheritdoc />
    public partial class FixSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WebsiteContents",
                columns: new[] { "Id", "Content", "CreatedAt", "ImageUrl", "IsActive", "Key", "Link", "Order", "Title", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { "content-1", "Chúng tôi cung cấp dịch vụ sửa chữa nhà cửa toàn diện với đội ngũ thợ lành nghề, giá cả hợp lý", new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, true, "hero-title", null, 1, "Dịch Vụ Sửa Nhà Cửa Chuyên Nghiệp", 6, new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { "content-2", "Với hơn 10 năm kinh nghiệm trong lĩnh vực sửa chữa nhà cửa, chúng tôi cam kết mang đến dịch vụ chất lượng cao nhất cho khách hàng.", new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, true, "about-title", null, 1, "Về Chúng Tôi", 1, new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { "content-3", "0123.456.789", new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, true, "contact-phone", null, 1, "Hotline", 4, new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WebsiteContents",
                keyColumn: "Id",
                keyValue: "content-1");

            migrationBuilder.DeleteData(
                table: "WebsiteContents",
                keyColumn: "Id",
                keyValue: "content-2");

            migrationBuilder.DeleteData(
                table: "WebsiteContents",
                keyColumn: "Id",
                keyValue: "content-3");
        }
    }
}
