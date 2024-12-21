using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autokauppa_DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SellerInfo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SellerId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ProductionYear = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    EngineSize = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Transmission = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SafetyFeatures = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    OtherFeatures = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ListedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SellerInfoId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_SellerInfo_SellerInfoId",
                        column: x => x.SellerInfoId,
                        principalTable: "SellerInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_SellerInfoId",
                table: "Cars",
                column: "SellerInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "SellerInfo");
        }
    }
}
