using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PicnicMicroservice.Infrastructure.Persistence.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PicnicCollaborations",
                columns: table => new
                {
                    CollaborationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InviteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PicnicCollaborations", x => x.CollaborationId);
                });

            migrationBuilder.CreateTable(
                name: "PicnicInvites",
                columns: table => new
                {
                    InviteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PicnicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PicnicInvites", x => x.InviteId);
                });

            migrationBuilder.CreateTable(
                name: "Picnics",
                columns: table => new
                {
                    PicnicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LocationLat = table.Column<decimal>(type: "decimal(8,6)", nullable: false),
                    LocationLong = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    PicnicType = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picnics", x => x.PicnicId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PicnicCollaborations");

            migrationBuilder.DropTable(
                name: "PicnicInvites");

            migrationBuilder.DropTable(
                name: "Picnics");
        }
    }
}
