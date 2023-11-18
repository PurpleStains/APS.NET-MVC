using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APS.NET_MVC.Migrations
{
    /// <inheritdoc />
    public partial class AddedCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Production = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EngineID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Car_Engine_EngineID",
                        column: x => x.EngineID,
                        principalTable: "Engine",
                        principalColumn: "EngineId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_EngineID",
                table: "Car",
                column: "EngineID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");
        }
    }
}
