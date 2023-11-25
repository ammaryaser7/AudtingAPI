using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudtingAPI.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmentModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeModels_DepartmentModels_DepartmentModelId",
                        column: x => x.DepartmentModelId,
                        principalTable: "DepartmentModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditModels_EmployeeModels_EmployeeModelId",
                        column: x => x.EmployeeModelId,
                        principalTable: "EmployeeModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuditModels_UserModels_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "UserModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditModels_EmployeeModelId",
                table: "AuditModels",
                column: "EmployeeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditModels_UserModelId",
                table: "AuditModels",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeModels_DepartmentModelId",
                table: "EmployeeModels",
                column: "DepartmentModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditModels");

            migrationBuilder.DropTable(
                name: "EmployeeModels");

            migrationBuilder.DropTable(
                name: "UserModels");

            migrationBuilder.DropTable(
                name: "DepartmentModels");
        }
    }
}
