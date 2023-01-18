using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Managesio.Core.Migrations
{
    /// <inheritdoc />
    public partial class OtpForUserNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "otp",
                table: "user",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                defaultValue: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "otp",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: null,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
