using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QTCoffeeSlotMachine.Logic.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "App");

            migrationBuilder.CreateTable(
                name: "SlotMachines",
                schema: "App",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    DepoteCoin5 = table.Column<int>(type: "int", nullable: false),
                    DepoteCoin10 = table.Column<int>(type: "int", nullable: false),
                    DepoteCoin20 = table.Column<int>(type: "int", nullable: false),
                    DepoteCoin50 = table.Column<int>(type: "int", nullable: false),
                    DepoteCoin100 = table.Column<int>(type: "int", nullable: false),
                    DepoteCoin200 = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlotMachines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "App",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlotMachineId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_SlotMachines_SlotMachineId",
                        column: x => x.SlotMachineId,
                        principalSchema: "App",
                        principalTable: "SlotMachines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_SlotMachineId",
                schema: "App",
                table: "Products",
                column: "SlotMachineId");

            migrationBuilder.CreateIndex(
                name: "IX_SlotMachines_Location",
                schema: "App",
                table: "SlotMachines",
                column: "Location",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products",
                schema: "App");

            migrationBuilder.DropTable(
                name: "SlotMachines",
                schema: "App");
        }
    }
}
