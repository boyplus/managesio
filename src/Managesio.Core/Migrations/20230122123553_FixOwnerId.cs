using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Managesio.Core.Migrations
{
    /// <inheritdoc />
    public partial class FixOwnerId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_project_user_user_id",
                table: "project");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "project",
                newName: "owner_id");

            migrationBuilder.RenameIndex(
                name: "ix_project_user_id",
                table: "project",
                newName: "ix_project_owner_id");

            migrationBuilder.AddForeignKey(
                name: "fk_project_user_owner_id",
                table: "project",
                column: "owner_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_project_user_owner_id",
                table: "project");

            migrationBuilder.RenameColumn(
                name: "owner_id",
                table: "project",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "ix_project_owner_id",
                table: "project",
                newName: "ix_project_user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_project_user_user_id",
                table: "project",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
