using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InvoiceRelationToCartorinvoicedetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDisable",
                table: "Address");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "CartOrInvoiceDtails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartOrInvoiceDtails_InvoiceId",
                table: "CartOrInvoiceDtails",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartOrInvoiceDtails_Invoices_InvoiceId",
                table: "CartOrInvoiceDtails",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartOrInvoiceDtails_Invoices_InvoiceId",
                table: "CartOrInvoiceDtails");

            migrationBuilder.DropIndex(
                name: "IX_CartOrInvoiceDtails_InvoiceId",
                table: "CartOrInvoiceDtails");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "CartOrInvoiceDtails");

            migrationBuilder.AddColumn<bool>(
                name: "IsDisable",
                table: "Address",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
