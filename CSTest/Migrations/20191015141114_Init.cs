using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSTest.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dateTemps",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    daysNumber = table.Column<int>(nullable: false),
                    dateTime = table.Column<DateTime>(nullable: false),
                    temperature = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dateTemps", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "houseNames",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_houseNames", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "plantNames",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plantNames", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "houseDetails",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    daysNumber = table.Column<int>(nullable: false),
                    houseNameid = table.Column<int>(nullable: true),
                    consumptionHouse = table.Column<double>(nullable: false),
                    localDateTemp = table.Column<DateTime>(nullable: false),
                    userName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_houseDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_houseDetails_houseNames_houseNameid",
                        column: x => x.houseNameid,
                        principalTable: "houseNames",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "plantDetails",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    daysNumber = table.Column<int>(nullable: false),
                    plantNameid = table.Column<int>(nullable: true),
                    price = table.Column<double>(nullable: false),
                    consumptionPlant = table.Column<double>(nullable: false),
                    localDateTemp = table.Column<DateTime>(nullable: false),
                    userName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plantDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_plantDetails_plantNames_plantNameid",
                        column: x => x.plantNameid,
                        principalTable: "plantNames",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_houseDetails_houseNameid",
                table: "houseDetails",
                column: "houseNameid");

            migrationBuilder.CreateIndex(
                name: "IX_plantDetails_plantNameid",
                table: "plantDetails",
                column: "plantNameid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dateTemps");

            migrationBuilder.DropTable(
                name: "houseDetails");

            migrationBuilder.DropTable(
                name: "plantDetails");

            migrationBuilder.DropTable(
                name: "houseNames");

            migrationBuilder.DropTable(
                name: "plantNames");
        }
    }
}
