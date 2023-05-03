using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DhiaGabtni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exemples");

            migrationBuilder.CreateTable(
                name: "livreurs",
                columns: table => new
                {
                    IdLivreur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_livreurs", x => x.IdLivreur);
                });

            migrationBuilder.CreateTable(
                name: "menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateMenu = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "plats",
                columns: table => new
                {
                    IdPlat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypePlat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prix = table.Column<double>(type: "float", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plats", x => x.IdPlat);
                });

            migrationBuilder.CreateTable(
                name: "commandes",
                columns: table => new
                {
                    NumCmd = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCmd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    livree = table.Column<bool>(type: "bit", nullable: false),
                    livreurIdLivreur = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commandes", x => x.NumCmd);
                    table.ForeignKey(
                        name: "FK_commandes_livreurs_livreurIdLivreur",
                        column: x => x.livreurIdLivreur,
                        principalTable: "livreurs",
                        principalColumn: "IdLivreur",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuPlat",
                columns: table => new
                {
                    PlatsIdPlat = table.Column<int>(type: "int", nullable: false),
                    menusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuPlat", x => new { x.PlatsIdPlat, x.menusId });
                    table.ForeignKey(
                        name: "FK_MenuPlat_menus_menusId",
                        column: x => x.menusId,
                        principalTable: "menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuPlat_plats_PlatsIdPlat",
                        column: x => x.PlatsIdPlat,
                        principalTable: "plats",
                        principalColumn: "IdPlat",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ligneCommandes",
                columns: table => new
                {
                    CommandeFk = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlatFk = table.Column<int>(type: "int", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    PlatIdPlat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ligneCommandes", x => new { x.CommandeFk, x.PlatFk });
                    table.ForeignKey(
                        name: "FK_ligneCommandes_commandes_CommandeFk",
                        column: x => x.CommandeFk,
                        principalTable: "commandes",
                        principalColumn: "NumCmd",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ligneCommandes_plats_PlatIdPlat",
                        column: x => x.PlatIdPlat,
                        principalTable: "plats",
                        principalColumn: "IdPlat",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_commandes_livreurIdLivreur",
                table: "commandes",
                column: "livreurIdLivreur");

            migrationBuilder.CreateIndex(
                name: "IX_ligneCommandes_PlatIdPlat",
                table: "ligneCommandes",
                column: "PlatIdPlat");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPlat_menusId",
                table: "MenuPlat",
                column: "menusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ligneCommandes");

            migrationBuilder.DropTable(
                name: "MenuPlat");

            migrationBuilder.DropTable(
                name: "commandes");

            migrationBuilder.DropTable(
                name: "menus");

            migrationBuilder.DropTable(
                name: "plats");

            migrationBuilder.DropTable(
                name: "livreurs");

            migrationBuilder.CreateTable(
                name: "exemples",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exemples", x => x.id);
                });
        }
    }
}
