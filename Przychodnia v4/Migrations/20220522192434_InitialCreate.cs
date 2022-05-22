using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Przychodnia_v4.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacjents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Imie = table.Column<string>(type: "TEXT", nullable: false),
                    Nazwisko = table.Column<string>(type: "TEXT", nullable: false),
                    Adres = table.Column<string>(type: "TEXT", nullable: false),
                    Pesel = table.Column<string>(type: "TEXT", nullable: false),
                    Plec = table.Column<string>(type: "TEXT", nullable: false),
                    DataUrodzenia = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacjents", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RodzajZabiegus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nazwa = table.Column<string>(type: "TEXT", nullable: false),
                    Numer = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodzajZabiegus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Wypiss",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rezultat = table.Column<string>(type: "TEXT", nullable: false),
                    DataWypisu = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataLeczeniaOd = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataLeczeniaDo = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PacjentID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wypiss", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Wypiss_Pacjents_PacjentID",
                        column: x => x.PacjentID,
                        principalTable: "Pacjents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rozpoznanies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nazwa = table.Column<string>(type: "TEXT", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RodzajZabieguID = table.Column<int>(type: "INTEGER", nullable: false),
                    PacjentID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rozpoznanies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rozpoznanies_Pacjents_PacjentID",
                        column: x => x.PacjentID,
                        principalTable: "Pacjents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rozpoznanies_RodzajZabiegus_RodzajZabieguID",
                        column: x => x.RodzajZabieguID,
                        principalTable: "RodzajZabiegus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rozpoznanies_PacjentID",
                table: "Rozpoznanies",
                column: "PacjentID");

            migrationBuilder.CreateIndex(
                name: "IX_Rozpoznanies_RodzajZabieguID",
                table: "Rozpoznanies",
                column: "RodzajZabieguID");

            migrationBuilder.CreateIndex(
                name: "IX_Wypiss_PacjentID",
                table: "Wypiss",
                column: "PacjentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rozpoznanies");

            migrationBuilder.DropTable(
                name: "Wypiss");

            migrationBuilder.DropTable(
                name: "RodzajZabiegus");

            migrationBuilder.DropTable(
                name: "Pacjents");
        }
    }
}
