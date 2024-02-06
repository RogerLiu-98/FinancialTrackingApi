using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialTrackingApi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTransactionNameField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                schema: "dbo",
                table: "Transactions");
        }
    }
}
