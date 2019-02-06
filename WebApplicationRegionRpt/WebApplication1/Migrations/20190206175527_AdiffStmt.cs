using Microsoft.EntityFrameworkCore.Migrations;

namespace FEDPAY.Migrations
{
    public partial class AdiffStmt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FEM_AD_IRN_CODE",
                schema: "fedpay",
                table: "Fedpay_Err_MES",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FEM_IRN_CODE",
                schema: "fedpay",
                table: "Fedpay_Err_MES",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FEM_SYS_CODE",
                schema: "fedpay",
                table: "Fedpay_Err_MES",
                maxLength: 2,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FEM_AD_IRN_CODE",
                schema: "fedpay",
                table: "Fedpay_Err_MES");

            migrationBuilder.DropColumn(
                name: "FEM_IRN_CODE",
                schema: "fedpay",
                table: "Fedpay_Err_MES");

            migrationBuilder.DropColumn(
                name: "FEM_SYS_CODE",
                schema: "fedpay",
                table: "Fedpay_Err_MES");
        }
    }
}
