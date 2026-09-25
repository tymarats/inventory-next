using Microsoft.EntityFrameworkCore.Migrations;

namespace Codaxy.Inventory.Persistence.Migrations
{
    public partial class AddCurrencyColumnInLicenseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(name: "Currency", table: "License", nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Currency", table: "License");
        }
    }
}
