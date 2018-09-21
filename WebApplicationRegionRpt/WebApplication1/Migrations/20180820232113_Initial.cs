using Microsoft.EntityFrameworkCore.Migrations;

namespace FEDPAY.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "REG_ROUTING_ID",
                schema: "fedpay",
                table: "Region",
                nullable: true,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "REG_ROUTING_ID",
                schema: "fedpay",
                table: "Region",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
