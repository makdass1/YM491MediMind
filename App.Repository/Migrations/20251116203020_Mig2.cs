using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Allergies",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "Kakao" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
