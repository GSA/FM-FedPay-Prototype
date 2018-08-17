using Microsoft.EntityFrameworkCore.Migrations;

namespace FEDPAY.Migrations
{
    public partial class fedpay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "fedpay");

            migrationBuilder.CreateTable(
                name: "Region",
                schema: "fedpay",
                columns: table => new
                {
                    REG_PO_SUFFIX = table.Column<string>(nullable: false),
                    REG_FSS_REGION_CODE = table.Column<string>(nullable: true),
                    REG_FAIM_FB_REGION_CODE = table.Column<string>(nullable: true),
                    REG_FEDPAY_REGION_CODE = table.Column<string>(nullable: true),
                    REG_ROUTING_ID = table.Column<decimal>(nullable: false),
                    REG_INFONET_REGION_CODE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.REG_PO_SUFFIX);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Region",
                schema: "fedpay");
        }
    }
}
