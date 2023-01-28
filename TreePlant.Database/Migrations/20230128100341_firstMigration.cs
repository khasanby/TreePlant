using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreePlant.Database.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TreeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TreeSorts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MatureHeight = table.Column<double>(type: "float", nullable: false),
                    MatureWidth = table.Column<double>(type: "float", nullable: false),
                    GrowthRateCm = table.Column<double>(type: "float", nullable: false),
                    HarvestTime = table.Column<int>(type: "int", nullable: false),
                    SoilType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SunExposure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BearingAge = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    TreeTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeSorts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreeSorts_TreeTypes_TreeTypeId",
                        column: x => x.TreeTypeId,
                        principalTable: "TreeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantedTrees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreeSortId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantedTrees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantedTrees_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantedTrees_TreeSorts_TreeSortId",
                        column: x => x.TreeSortId,
                        principalTable: "TreeSorts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantedTrees_AreaId",
                table: "PlantedTrees",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantedTrees_TreeSortId",
                table: "PlantedTrees",
                column: "TreeSortId");

            migrationBuilder.CreateIndex(
                name: "IX_TreeSorts_TreeTypeId",
                table: "TreeSorts",
                column: "TreeTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlantedTrees");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "TreeSorts");

            migrationBuilder.DropTable(
                name: "TreeTypes");
        }
    }
}
