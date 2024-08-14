using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyNhanSu.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitTeam3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_AccountId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "Account",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_EmployeeID",
                table: "Account",
                column: "EmployeeID",
                unique: true,
                filter: "[EmployeeID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee",
                table: "Account",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_EmployeeID",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Account");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AccountId",
                table: "Employee",
                column: "AccountId",
                unique: true,
                filter: "[AccountId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Account",
                table: "Employee",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "AccountId");
        }
    }
}
