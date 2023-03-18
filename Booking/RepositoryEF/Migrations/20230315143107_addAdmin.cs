using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryEF.Migrations
{
    /// <inheritdoc />
    public partial class addAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "ImageId", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NID", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Street", "TwoFactorEnabled", "UserName", "gender" },
                values: new object[] { "4b0d06ca-1541-499b-9bf5-97e577cce0d7", 0, null, "314b168e-0f1d-41ff-a508-f51fb6d8babf", null, "shagon288@gmail.com", false, null, false, false, null, null, null, null, "Y10002000#", null, false, "8e448129-704f-4619-ae09-867db34359bc", null, false, "Youstina", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4b0d06ca-1541-499b-9bf5-97e577cce0d7");
        }
    }
}
