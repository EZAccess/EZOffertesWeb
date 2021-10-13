using Microsoft.EntityFrameworkCore.Migrations;

namespace EZOffertes.Api.Migrations
{
    public partial class InitialNavigations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RelationPhoneNumbers_RelationId",
                table: "RelationPhoneNumbers",
                column: "RelationId");

            migrationBuilder.CreateIndex(
                name: "IX_RelationNotes_RelationId",
                table: "RelationNotes",
                column: "RelationId");

            migrationBuilder.CreateIndex(
                name: "IX_RelationEmailAddresses_RelationId",
                table: "RelationEmailAddresses",
                column: "RelationId");

            migrationBuilder.CreateIndex(
                name: "IX_RelationAddresses_RelationId",
                table: "RelationAddresses",
                column: "RelationId");

            migrationBuilder.CreateIndex(
                name: "IX_QuickProductSetItems_ProductId",
                table: "QuickProductSetItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperties_ProductId",
                table: "ProductProperties",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_InvoiceId",
                table: "Payments",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_InvoiceId",
                table: "OrderDetails",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_OrderId",
                table: "Invoices",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Orders_OrderId",
                table: "Invoices",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Invoices_InvoiceId",
                table: "OrderDetails",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Invoices_InvoiceId",
                table: "Payments",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Orders_OrderId",
                table: "Payments",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProperties_Products_ProductId",
                table: "ProductProperties",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuickProductSetItems_Products_ProductId",
                table: "QuickProductSetItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuickProductSetItems_QuickProductSets_QuickProductSetId",
                table: "QuickProductSetItems",
                column: "QuickProductSetId",
                principalTable: "QuickProductSets",
                principalColumn: "QuickProductSetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RelationAddresses_Relations_RelationId",
                table: "RelationAddresses",
                column: "RelationId",
                principalTable: "Relations",
                principalColumn: "RelationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RelationEmailAddresses_Relations_RelationId",
                table: "RelationEmailAddresses",
                column: "RelationId",
                principalTable: "Relations",
                principalColumn: "RelationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RelationNotes_Relations_RelationId",
                table: "RelationNotes",
                column: "RelationId",
                principalTable: "Relations",
                principalColumn: "RelationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RelationPhoneNumbers_Relations_RelationId",
                table: "RelationPhoneNumbers",
                column: "RelationId",
                principalTable: "Relations",
                principalColumn: "RelationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Orders_OrderId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Invoices_InvoiceId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Invoices_InvoiceId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Orders_OrderId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProperties_Products_ProductId",
                table: "ProductProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_QuickProductSetItems_Products_ProductId",
                table: "QuickProductSetItems");

            migrationBuilder.DropForeignKey(
                name: "FK_QuickProductSetItems_QuickProductSets_QuickProductSetId",
                table: "QuickProductSetItems");

            migrationBuilder.DropForeignKey(
                name: "FK_RelationAddresses_Relations_RelationId",
                table: "RelationAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_RelationEmailAddresses_Relations_RelationId",
                table: "RelationEmailAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_RelationNotes_Relations_RelationId",
                table: "RelationNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_RelationPhoneNumbers_Relations_RelationId",
                table: "RelationPhoneNumbers");

            migrationBuilder.DropIndex(
                name: "IX_RelationPhoneNumbers_RelationId",
                table: "RelationPhoneNumbers");

            migrationBuilder.DropIndex(
                name: "IX_RelationNotes_RelationId",
                table: "RelationNotes");

            migrationBuilder.DropIndex(
                name: "IX_RelationEmailAddresses_RelationId",
                table: "RelationEmailAddresses");

            migrationBuilder.DropIndex(
                name: "IX_RelationAddresses_RelationId",
                table: "RelationAddresses");

            migrationBuilder.DropIndex(
                name: "IX_QuickProductSetItems_ProductId",
                table: "QuickProductSetItems");

            migrationBuilder.DropIndex(
                name: "IX_ProductProperties_ProductId",
                table: "ProductProperties");

            migrationBuilder.DropIndex(
                name: "IX_Payments_InvoiceId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_OrderId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_InvoiceId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_OrderId",
                table: "Invoices");
        }
    }
}
