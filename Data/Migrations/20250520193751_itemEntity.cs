using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SklepHkr2025.Migrations
{
    /// <inheritdoc />
    public partial class itemEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriceGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceMarkUpA = table.Column<int>(type: "int", nullable: true),
                    PriceMarkUpB = table.Column<int>(type: "int", nullable: true),
                    PriceMarkUpC = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProducentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    incomId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    logoFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProducentDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResponsiblePersonProducent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    incomId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    logoFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProducentDetailId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsiblePersonProducent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponsiblePersonProducent_ProducentDetails_ProducentDetailId",
                        column: x => x.ProducentDetailId,
                        principalTable: "ProducentDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopCategoryId = table.Column<int>(type: "int", nullable: true),
                    PriceGroupId = table.Column<int>(type: "int", nullable: true),
                    VatRate = table.Column<int>(type: "int", nullable: false),
                    EanCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProducentId = table.Column<int>(type: "int", nullable: true),
                    Lenght = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Width = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ResponsiblePersonProducentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_PriceGroups_PriceGroupId",
                        column: x => x.PriceGroupId,
                        principalTable: "PriceGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_ProducentDetails_ProducentId",
                        column: x => x.ProducentId,
                        principalTable: "ProducentDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_ResponsiblePersonProducent_ResponsiblePersonProducentId",
                        column: x => x.ResponsiblePersonProducentId,
                        principalTable: "ResponsiblePersonProducent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_ShopCategories_ShopCategoryId",
                        column: x => x.ShopCategoryId,
                        principalTable: "ShopCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemImages_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemImages_ItemId",
                table: "ItemImages",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_PriceGroupId",
                table: "Items",
                column: "PriceGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ProducentId",
                table: "Items",
                column: "ProducentId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ResponsiblePersonProducentId",
                table: "Items",
                column: "ResponsiblePersonProducentId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ShopCategoryId",
                table: "Items",
                column: "ShopCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsiblePersonProducent_ProducentDetailId",
                table: "ResponsiblePersonProducent",
                column: "ProducentDetailId",
                unique: true,
                filter: "[ProducentDetailId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemImages");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "PriceGroups");

            migrationBuilder.DropTable(
                name: "ResponsiblePersonProducent");

            migrationBuilder.DropTable(
                name: "ProducentDetails");
        }
    }
}
