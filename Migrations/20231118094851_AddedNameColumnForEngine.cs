using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APS.NET_MVC.Migrations
{
    /// <inheritdoc />
    public partial class AddedNameColumnForEngine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Engine",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Engine");
        }
    }
}
