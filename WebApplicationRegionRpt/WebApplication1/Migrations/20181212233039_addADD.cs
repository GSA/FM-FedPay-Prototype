using Microsoft.EntityFrameworkCore.Migrations;

namespace FEDPAY.Migrations
{
    public partial class addADD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ADD_PO_UCP",
                schema: "fedpay",
                table: "Admin_Diff",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "ADD_PO_QTY",
                schema: "fedpay",
                table: "Admin_Diff",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "ADD_BILLED_UCP",
                schema: "fedpay",
                table: "Admin_Diff",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "ADD_BILLED_QTY",
                schema: "fedpay",
                table: "Admin_Diff",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ADD_PO_UCP",
                schema: "fedpay",
                table: "Admin_Diff",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ADD_PO_QTY",
                schema: "fedpay",
                table: "Admin_Diff",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ADD_BILLED_UCP",
                schema: "fedpay",
                table: "Admin_Diff",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ADD_BILLED_QTY",
                schema: "fedpay",
                table: "Admin_Diff",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
