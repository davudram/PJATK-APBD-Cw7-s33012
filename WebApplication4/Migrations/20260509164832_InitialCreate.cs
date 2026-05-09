using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication4.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComponentManufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abbreviation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FoundationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentManufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComponentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abbreviation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PCs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Weight = table.Column<float>(type: "float(5)", nullable: false),
                    Warranty = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(10)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComponentManufacturersId = table.Column<int>(type: "int", nullable: false),
                    ComponentTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Components_ComponentManufacturers_ComponentManufacturersId",
                        column: x => x.ComponentManufacturersId,
                        principalTable: "ComponentManufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Components_ComponentTypes_ComponentTypesId",
                        column: x => x.ComponentTypesId,
                        principalTable: "ComponentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PCComponents",
                columns: table => new
                {
                    PcId = table.Column<int>(type: "int", nullable: false),
                    ComponentCode = table.Column<string>(type: "char(10)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCComponents", x => new { x.PcId, x.ComponentCode });
                    table.ForeignKey(
                        name: "FK_PCComponents_Components_ComponentCode",
                        column: x => x.ComponentCode,
                        principalTable: "Components",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PCComponents_PCs_PcId",
                        column: x => x.PcId,
                        principalTable: "PCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ComponentManufacturers",
                columns: new[] { "Id", "Abbreviation", "FoundationDate", "FullName" },
                values: new object[,]
                {
                    { 1, "C1", new DateTime(2021, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Component Manufacture 1" },
                    { 2, "C2", new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Component Manufacture 2" },
                    { 3, "C3", new DateTime(2011, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Component Manufacture 3" }
                });

            migrationBuilder.InsertData(
                table: "ComponentTypes",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[,]
                {
                    { 1, "CT1", "Component Type 1" },
                    { 2, "CT2", "Component Type 2" },
                    { 3, "CT3", "Component Type 3" }
                });

            migrationBuilder.InsertData(
                table: "PCs",
                columns: new[] { "Id", "CreatedAt", "Name", "Stock", "Warranty", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pc 1", 1, 5, 5.69f },
                    { 2, new DateTime(2026, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pc 2", 3, 3, 4.5f },
                    { 3, new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pc 3", 22, 2, 45.619f }
                });

            migrationBuilder.InsertData(
                table: "Components",
                columns: new[] { "Code", "ComponentManufacturersId", "ComponentTypesId", "Description", "Name" },
                values: new object[,]
                {
                    { "Code1", 1, 1, "Description 1", "Component 1" },
                    { "Code2", 2, 2, "Description 2", "Component 2" },
                    { "Code3", 3, 3, "Description 3", "Component 3" }
                });

            migrationBuilder.InsertData(
                table: "PCComponents",
                columns: new[] { "ComponentCode", "PcId", "Amount" },
                values: new object[,]
                {
                    { "Code1", 1, 5 },
                    { "Code2", 2, 44 },
                    { "Code3", 3, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Components_ComponentManufacturersId",
                table: "Components",
                column: "ComponentManufacturersId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_ComponentTypesId",
                table: "Components",
                column: "ComponentTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_PCComponents_ComponentCode",
                table: "PCComponents",
                column: "ComponentCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PCComponents");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "PCs");

            migrationBuilder.DropTable(
                name: "ComponentManufacturers");

            migrationBuilder.DropTable(
                name: "ComponentTypes");
        }
    }
}
