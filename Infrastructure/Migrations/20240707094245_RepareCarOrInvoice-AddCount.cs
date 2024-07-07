using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RepareCarOrInvoiceAddCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CartOrInvoiceDtails_InvoiceId",
                table: "CartOrInvoiceDtails");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "CartOrInvoiceDtails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CartOrInvoiceDtails_InvoiceId",
                table: "CartOrInvoiceDtails",
                column: "InvoiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CartOrInvoiceDtails_InvoiceId",
                table: "CartOrInvoiceDtails");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "CartOrInvoiceDtails");

            migrationBuilder.CreateIndex(
                name: "IX_CartOrInvoiceDtails_InvoiceId",
                table: "CartOrInvoiceDtails",
                column: "InvoiceId",
                unique: true,
                filter: "[InvoiceId] IS NOT NULL");
        }
    }
}
