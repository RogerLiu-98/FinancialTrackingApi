using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialTrackingApi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SetIsActiveForCategoryDetaultToTrue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11,
                column: "IsActive",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11,
                column: "IsActive",
                value: false);
        }
    }
}
