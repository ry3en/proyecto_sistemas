using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto_sistetmas.API.Migrations
{
    /// <inheritdoc />
    public partial class updates_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_brands_Name",
                table: "brands",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_brands_Name",
                table: "brands");
        }
    }
}
