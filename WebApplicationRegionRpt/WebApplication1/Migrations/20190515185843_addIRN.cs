using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FEDPAY.Migrations
{
    public partial class addIRN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoice_Return_Notice",
                schema: "fedpay",
                columns: table => new
                {
                    IRN_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IRN_INVOICE_NO = table.Column<string>(nullable: true),
                    IRN_PO_NO = table.Column<string>(nullable: true),
                    IRN_VENDOR_NO = table.Column<string>(nullable: true),
                    IRN_VENDOR_ALT_KEY = table.Column<string>(nullable: true),
                    IRN_INVOICE_RETURN_CODE1 = table.Column<string>(nullable: true),
                    IRN_INVOICE_RETURN_CODE2 = table.Column<string>(nullable: true),
                    IRN_INVOICE_RETURN_CODE3 = table.Column<string>(nullable: true),
                    IRN_INVOICE_RETURN_CODE4 = table.Column<string>(nullable: true),
                    IRN_INVOICE_RETURN_CODE5 = table.Column<string>(nullable: true),
                    IRN_RETURN_AMT = table.Column<decimal>(nullable: false),
                    IRN_DATE_OF_RETURN = table.Column<DateTime>(nullable: false),
                    IRN_DATE_RECEIVED = table.Column<DateTime>(nullable: false),
                    IRN_FSS_PO_NO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice_Return_Notice", x => x.IRN_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice_Return_Notice",
                schema: "fedpay");
        }
    }
}
