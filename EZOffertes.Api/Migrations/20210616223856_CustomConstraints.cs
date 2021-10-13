using Microsoft.EntityFrameworkCore.Migrations;

namespace EZOffertes.Api.Migrations
{
    public partial class CustomConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey("FK_Orders_Relations", "Orders", "CustomerId",
                "Relations", null, null, "RelationId", ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey("FK_Orders_Employees", "Orders", "EmployeeId",
                "Employees", null, null, "EmployeeId", ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey("FK_Orders_ShippingMethods", "Orders", "ShippingMethodId",
                "ShippingMethods", null, null, "ShippingMethodId", ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey("FK_Invoices_Relations", "Invoices", "CustomerId",
                "Relations", null, null, "RelationId", ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey("FK_Payments_Employees", "Payments", "EmployeeId",
                "Employees", null, null, "EmployeeId", ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey("FK_Relations_RelationPhoneNumbers", "Relations", "FirstPhoneNumberId",
                "RelationPhoneNumbers", null, null, "RelationPhoneNumberId", ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey("FK_Relations_RelationEmailAddresses_1", "Relations", "DefaultEmailAddressId",
                "RelationEmailAddresses", null, null, "RelationEmailAddressId", ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey("FK_Relations_RelationEmailAddresses_2", "Relations", "InvoiceEmailAddressId",
                "RelationEmailAddresses", null, null, "RelationEmailAddressId", ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey("FK_Relations_RelationEmailAddresses_3", "Relations", "OrderEmailAddressId",
                "RelationEmailAddresses", null, null, "RelationEmailAddressId", ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey("FK_OrderDetails_Products", "OrderDetails", "ProductId",
                "Products", null, null, "ProductId", ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey("FK_OrderDetails_Relations", "OrderDetails", "SupplierId",
                "Relations", null, null, "RelationId", ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey("FK_Products_Relations", "Products", "SupplierId",
                "Relations", null, null, "RelationId", ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("FK_Orders_Relations", "Orders");

            migrationBuilder.DropForeignKey("FK_Orders_Employees", "Orders");

            migrationBuilder.DropForeignKey("FK_Orders_ShippingMethods", "Orders");

            migrationBuilder.DropForeignKey("FK_Invoices_Relations", "Invoices");

            migrationBuilder.DropForeignKey("FK_Payments_Employees", "Payments");

            migrationBuilder.DropForeignKey("FK_Relations_RelationPhoneNumbers", "Relations");

            migrationBuilder.DropForeignKey("FK_Relations_RelationEmailAddresses_1", "Relations");

            migrationBuilder.DropForeignKey("FK_Relations_RelationEmailAddresses_2", "Relations");

            migrationBuilder.DropForeignKey("FK_Relations_RelationEmailAddresses_3", "Relations");

            migrationBuilder.DropForeignKey("FK_OrderDetails_Products", "OrderDetails");

            migrationBuilder.DropForeignKey("FK_OrderDetails_Relations", "OrderDetails");

            migrationBuilder.DropForeignKey("FK_Products_Relations", "Products");
        }
    }
}
