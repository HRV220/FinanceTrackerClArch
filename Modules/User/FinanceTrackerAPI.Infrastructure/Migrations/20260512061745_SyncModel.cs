using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceTrackerAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SyncModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Units_ShortName",
                table: "Units");

            migrationBuilder.CreateIndex(
                name: "IX_Units_ShortName",
                table: "Units",
                column: "ShortName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Units_ShortName",
                table: "Units");

            migrationBuilder.CreateIndex(
                name: "IX_Units_ShortName",
                table: "Units",
                column: "ShortName",
                unique: true);
        }
    }
}
