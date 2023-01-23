using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Managesio.Core.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMapped : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "project_member");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "project_member",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    projectid = table.Column<Guid>(name: "project_id", type: "uuid", nullable: false),
                    userid = table.Column<Guid>(name: "user_id", type: "uuid", nullable: false),
                    isconfirmed = table.Column<bool>(name: "is_confirmed", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_project_member", x => x.id);
                    table.ForeignKey(
                        name: "fk_project_member_project_project_id",
                        column: x => x.projectid,
                        principalTable: "project",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_project_member_user_user_id",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_project_member_project_id",
                table: "project_member",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "ix_project_member_user_id",
                table: "project_member",
                column: "user_id");
        }
    }
}
