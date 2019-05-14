using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace game_cell.Data.Migrations
{
    public partial class AddSomethingToModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Platformss",
                columns: table => new
                {
                    PlatformsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platformss", x => x.PlatformsId);
                });

            migrationBuilder.CreateTable(
                name: "GAMEs",
                columns: table => new
                {
                    GAMEId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GAMEName = table.Column<string>(nullable: true),
                    PlatformsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GAMEs", x => x.GAMEId);
                    table.ForeignKey(
                        name: "FK_GAMEs_Platformss_PlatformsId",
                        column: x => x.PlatformsId,
                        principalTable: "Platformss",
                        principalColumn: "PlatformsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GAMEs_PlatformsId",
                table: "GAMEs",
                column: "PlatformsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GAMEs");

            migrationBuilder.DropTable(
                name: "Platformss");
        }
    }
}
