using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto_sistetmas.API.Migrations
{
    /// <inheritdoc />
    public partial class Edit_total : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Toal",
                table: "Products",
                newName: "Total");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Products",
                newName: "Toal");
        }
    }
}
