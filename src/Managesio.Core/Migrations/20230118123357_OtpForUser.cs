using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Managesio.Core.Migrations
{
    /// <inheritdoc />
    public partial class OtpForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "otp",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "otp",
                table: "user");
        }
    }
}
