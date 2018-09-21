using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FEDPAY.Migrations
{
    public partial class fedpay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Region",
                schema: "fedpay",
                table: "Region");

            migrationBuilder.AlterColumn<string>(
                name: "REG_PO_SUFFIX",
                schema: "fedpay",
                table: "Region",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "id",
                schema: "fedpay",
                table: "Region",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Region",
                schema: "fedpay",
                table: "Region",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Region",
                schema: "fedpay",
                table: "Region");

            migrationBuilder.DropColumn(
                name: "id",
                schema: "fedpay",
                table: "Region");

            migrationBuilder.AlterColumn<string>(
                name: "REG_PO_SUFFIX",
                schema: "fedpay",
                table: "Region",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Region",
                schema: "fedpay",
                table: "Region",
                column: "REG_PO_SUFFIX");
        }
    }
}
