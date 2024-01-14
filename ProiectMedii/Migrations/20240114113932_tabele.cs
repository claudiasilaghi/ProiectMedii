using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectMedii.Migrations
{
    public partial class tabele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Strada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numar = table.Column<int>(type: "int", nullable: true),
                    Oras = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Judet = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresa", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Membru",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membru", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    AdresaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Restaurant_Adresa_AdresaID",
                        column: x => x.AdresaID,
                        principalTable: "Adresa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recenzie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parere = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdresaID = table.Column<int>(type: "int", nullable: true),
                    RestaurantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzie", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Recenzie_Adresa_AdresaID",
                        column: x => x.AdresaID,
                        principalTable: "Adresa",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Recenzie_Restaurant_RestaurantID",
                        column: x => x.RestaurantID,
                        principalTable: "Restaurant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Persoane = table.Column<int>(type: "int", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RestaurantID = table.Column<int>(type: "int", nullable: false),
                    AdresaID = table.Column<int>(type: "int", nullable: true),
                    MembruID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervare", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rezervare_Adresa_AdresaID",
                        column: x => x.AdresaID,
                        principalTable: "Adresa",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Rezervare_Membru_MembruID",
                        column: x => x.MembruID,
                        principalTable: "Membru",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervare_Restaurant_RestaurantID",
                        column: x => x.RestaurantID,
                        principalTable: "Restaurant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recenzie_AdresaID",
                table: "Recenzie",
                column: "AdresaID");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzie_RestaurantID",
                table: "Recenzie",
                column: "RestaurantID");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_AdresaID",
                table: "Restaurant",
                column: "AdresaID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervare_AdresaID",
                table: "Rezervare",
                column: "AdresaID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervare_MembruID",
                table: "Rezervare",
                column: "MembruID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervare_RestaurantID",
                table: "Rezervare",
                column: "RestaurantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recenzie");

            migrationBuilder.DropTable(
                name: "Rezervare");

            migrationBuilder.DropTable(
                name: "Membru");

            migrationBuilder.DropTable(
                name: "Restaurant");

            migrationBuilder.DropTable(
                name: "Adresa");
        }
    }
}
