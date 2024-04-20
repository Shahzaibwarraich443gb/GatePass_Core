using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GatePass_Migrations.Migrations
{
    public partial class dispatchitemname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "itemName",
                table: "dispatchItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "itemName",
                table: "dispatchItems");
        }
    }
}
