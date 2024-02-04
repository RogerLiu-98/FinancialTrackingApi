using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinancialTrackingApi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultValueForCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Rent, mortgage, property taxes, repairs", "Housing" },
                    { 2, "Electricity, water, gas, internet", "Utilities" },
                    { 3, "Food, household supplies", "Groceries" },
                    { 4, "Fuel, public transit, parking fees, vehicle maintenance", "Transportation" },
                    { 5, "Restaurants, coffee shops", "Dining Out" },
                    { 6, "Movies, games, events", "Entertainment" },
                    { 7, "Medical appointments, prescriptions, health insurance", "Healthcare" },
                    { 8, "Savings account contributions, stocks, bonds", "Savings & Investments" },
                    { 9, "Clothes, hobbies, gifts", "Personal Spending" },
                    { 10, "Salary, bonuses, other earnings", "Income" },
                    { 11, "Any other expenses", "Other" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11);
        }
    }
}
