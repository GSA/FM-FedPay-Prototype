using Microsoft.EntityFrameworkCore.Migrations;

namespace FEDPAY.Migrations
{
    public partial class addNMC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Non_Merchandise_Code",
                schema: "fedpay",
                columns: table => new
                {
                    NMC_CODE = table.Column<string>(maxLength: 2, nullable: false),
                    NMC_MEANING = table.Column<string>(maxLength: 40, nullable: true),
                    NMC_INVOICE_ACTION = table.Column<string>(maxLength: 1, nullable: true),
                    NMC_ADMIN_DIFF_IND = table.Column<string>(maxLength: 1, nullable: true),
                    NMC_PO_TD_CODE = table.Column<string>(maxLength: 2, nullable: true),
                    NMC_BILLING_LIT = table.Column<string>(maxLength: 15, nullable: true),
                    NMC_TRANSACTION_ID = table.Column<string>(maxLength: 4, nullable: true),
                    NMC_ADJUSTMENT_IND = table.Column<string>(maxLength: 1, nullable: true),
                    NMC_SYS_CODE = table.Column<string>(maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Non_Merchandise_Code", x => x.NMC_CODE);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Non_Merchandise_Code",
                schema: "fedpay");
        }
    }
}
