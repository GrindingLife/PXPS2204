using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PXPS2204.Data.Migrations
{
    public partial class PXPS2204 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HealthDataEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NEET = table.Column<int>(type: "int", nullable: false),
                    Selfharm = table.Column<int>(type: "int", nullable: false),
                    Psychosis = table.Column<int>(type: "int", nullable: false),
                    Medical = table.Column<int>(type: "int", nullable: false),
                    ChildDx = table.Column<int>(type: "int", nullable: false),
                    Circadian = table.Column<int>(type: "int", nullable: false),
                    Tripartite = table.Column<int>(type: "int", nullable: false),
                    ClinicalStage = table.Column<int>(type: "int", nullable: false),
                    Sofas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthDataEntries", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthDataEntries");
        }
    }
}
