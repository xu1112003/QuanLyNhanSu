using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyNhanSu.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    ConfirmPassword = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Role = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Account__349DA5A6E899A3D1", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "PhucLoi",
                columns: table => new
                {
                    PhucLoiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhucLoiType = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Money = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PhucLoi__E041D7C45D45EFCF", x => x.PhucLoiId);
                });

            migrationBuilder.CreateTable(
                name: "Salary",
                columns: table => new
                {
                    SalaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryType = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Money = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Salary__4BE204572E084E79", x => x.SalaryId);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    PositionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    HeSo = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PhucLoiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Position__60BB9A79B67833A8", x => x.PositionId);
                    table.ForeignKey(
                        name: "FK_PhucLoi",
                        column: x => x.PhucLoiId,
                        principalTable: "PhucLoi",
                        principalColumn: "PhucLoiId");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Gender = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Role = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    PositionId = table.Column<int>(type: "int", nullable: true),
                    SalaryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__7AD04F113C020FB1", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId");
                    table.ForeignKey(
                        name: "FK_Position",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "PositionId");
                    table.ForeignKey(
                        name: "FK_Salary",
                        column: x => x.SalaryId,
                        principalTable: "Salary",
                        principalColumn: "SalaryId");
                });

            migrationBuilder.CreateTable(
                name: "Cong",
                columns: table => new
                {
                    CongId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayCham = table.Column<DateTime>(type: "date", nullable: false),
                    CheckIn = table.Column<TimeSpan>(type: "time", nullable: false),
                    CheckOut = table.Column<TimeSpan>(type: "time", nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cong__BE52BA818D8BFB08", x => x.CongId);
                    table.ForeignKey(
                        name: "FK_EmployeeAttendance",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkingDate = table.Column<DateTime>(type: "date", nullable: false),
                    MorningActivity = table.Column<string>(type: "text", nullable: true),
                    AfternoonActivity = table.Column<string>(type: "text", nullable: true),
                    EveningActivity = table.Column<string>(type: "text", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Schedule__9C8A5B4926A8D27B", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_EmployeeSchedule",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cong_EmployeeId",
                table: "Cong",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AccountId",
                table: "Employee",
                column: "AccountId",
                unique: true,
                filter: "[AccountId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PositionId",
                table: "Employee",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_SalaryId",
                table: "Employee",
                column: "SalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Position_PhucLoiId",
                table: "Position",
                column: "PhucLoiId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_EmployeeId",
                table: "Schedule",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cong");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Salary");

            migrationBuilder.DropTable(
                name: "PhucLoi");
        }
    }
}
