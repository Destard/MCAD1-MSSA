using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvoidScurvyMVCApplication.Migrations
{
    public partial class AddedDiscontinuedField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDiscontinued",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDiscontinued",
                table: "Products");
        }
    }
}
