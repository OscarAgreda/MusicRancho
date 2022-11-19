using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicRancho_RanchoAPI.Migrations
{
    public partial class InitialApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ranchos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Sqft = table.Column<int>(type: "int", nullable: false),
                    Occupancy = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amenity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranchos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RanchoNumbers",
                columns: table => new
                {
                    RanchoNo = table.Column<int>(type: "int", nullable: false),
                    RanchoID = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RanchoNumbers", x => x.RanchoNo);
                    table.ForeignKey(
                        name: "FK_RanchoNumbers_Ranchos_RanchoID",
                        column: x => x.RanchoID,
                        principalTable: "Ranchos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ranchos",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2022, 11, 20, 17, 26, 16, 700, DateTimeKind.Local).AddTicks(2524), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://someWebSite.com/blueranchoimages/rancho3.jpg", "Royal Rancho", 4, 200.0, 550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "", new DateTime(2022, 11, 20, 17, 26, 16, 700, DateTimeKind.Local).AddTicks(2538), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://someWebSite.com/blueranchoimages/rancho1.jpg", "Premium Pool Rancho", 4, 300.0, 550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "", new DateTime(2022, 11, 20, 17, 26, 16, 700, DateTimeKind.Local).AddTicks(2539), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://someWebSite.com/blueranchoimages/rancho4.jpg", "Luxury Pool Rancho", 4, 400.0, 750, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "", new DateTime(2022, 11, 20, 17, 26, 16, 700, DateTimeKind.Local).AddTicks(2540), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://someWebSite.com/blueranchoimages/rancho5.jpg", "Diamond Rancho", 4, 550.0, 900, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "", new DateTime(2022, 11, 20, 17, 26, 16, 700, DateTimeKind.Local).AddTicks(2541), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://someWebSite.com/blueranchoimages/rancho2.jpg", "Diamond Pool Rancho", 4, 600.0, 1100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RanchoNumbers_RanchoID",
                table: "RanchoNumbers",
                column: "RanchoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RanchoNumbers");

            migrationBuilder.DropTable(
                name: "Ranchos");
        }
    }
}
