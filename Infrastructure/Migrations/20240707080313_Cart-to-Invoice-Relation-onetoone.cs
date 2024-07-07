using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CarttoInvoiceRelationonetoone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CartOrInvoiceDtails_InvoiceId",
                table: "CartOrInvoiceDtails");

            migrationBuilder.CreateIndex(
                name: "IX_CartOrInvoiceDtails_InvoiceId",
                table: "CartOrInvoiceDtails",
                column: "InvoiceId",
                unique: true,
                filter: "[InvoiceId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CartOrInvoiceDtails_InvoiceId",
                table: "CartOrInvoiceDtails");

            migrationBuilder.CreateIndex(
                name: "IX_CartOrInvoiceDtails_InvoiceId",
                table: "CartOrInvoiceDtails",
                column: "InvoiceId");
        }
    }
}
