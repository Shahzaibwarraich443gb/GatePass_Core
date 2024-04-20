using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GatePass_Migrations.Migrations
{
    public partial class CompanyAddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyKey = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.CompanyId);
                });

            migrationBuilder.InsertData(
                table: "company",
                columns: new[] { "CompanyId", "CompanyKey", "CompanyName" },
                values: new object[] { 1, "468C8C57A591B", "Barakha Flour Mills" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "company");
        }
    }
}
