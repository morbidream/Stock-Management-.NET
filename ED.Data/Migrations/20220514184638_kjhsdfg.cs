using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ED.Data.Migrations
{
    public partial class kjhsdfg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    CIN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.CIN);
                });

            migrationBuilder.CreateTable(
                name: "MyCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MyName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MyName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DateProd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductKey);
                    table.ForeignKey(
                        name: "FK_Products_MyCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "MyCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Biologicals",
                columns: table => new
                {
                    ProductKey = table.Column<int>(type: "int", nullable: false),
                    Herbs = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biologicals", x => x.ProductKey);
                    table.ForeignKey(
                        name: "FK_Biologicals_Products_ProductKey",
                        column: x => x.ProductKey,
                        principalTable: "Products",
                        principalColumn: "ProductKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chemicals",
                columns: table => new
                {
                    ProductKey = table.Column<int>(type: "int", nullable: false),
                    LabName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MyCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MyStreet = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chemicals", x => x.ProductKey);
                    table.ForeignKey(
                        name: "FK_Chemicals_Products_ProductKey",
                        column: x => x.ProductKey,
                        principalTable: "Products",
                        principalColumn: "ProductKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Factures",
                columns: table => new
                {
                    ProductFk = table.Column<int>(type: "int", nullable: false),
                    ClientFk = table.Column<int>(type: "int", nullable: false),
                    DateAchat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Prix = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factures", x => new { x.ClientFk, x.ProductFk, x.DateAchat });
                    table.ForeignKey(
                        name: "FK_Factures_Clients_ClientFk",
                        column: x => x.ClientFk,
                        principalTable: "Clients",
                        principalColumn: "CIN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Factures_Products_ProductFk",
                        column: x => x.ProductFk,
                        principalTable: "Products",
                        principalColumn: "ProductKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Providings",
                columns: table => new
                {
                    ProductsProductKey = table.Column<int>(type: "int", nullable: false),
                    ProvidersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providings", x => new { x.ProductsProductKey, x.ProvidersId });
                    table.ForeignKey(
                        name: "FK_Providings_Products_ProductsProductKey",
                        column: x => x.ProductsProductKey,
                        principalTable: "Products",
                        principalColumn: "ProductKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Providings_Providers_ProvidersId",
                        column: x => x.ProvidersId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Factures_ProductFk",
                table: "Factures",
                column: "ProductFk");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Providings_ProvidersId",
                table: "Providings",
                column: "ProvidersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Biologicals");

            migrationBuilder.DropTable(
                name: "Chemicals");

            migrationBuilder.DropTable(
                name: "Factures");

            migrationBuilder.DropTable(
                name: "Providings");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "MyCategories");
        }
    }
}
