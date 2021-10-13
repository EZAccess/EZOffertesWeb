using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EZOffertes.Api.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "ShippingMethods",
                columns: new[] { "ShippingMethodId", "Description", "ShippingMethodName" },
                values: new object[,]
                {
                    { 3, null, "By mail" },
                    { 2, null, "By truck" },
                    { 1, null, "Take away" }
                });

            migrationBuilder.InsertData(
                table: "UnitsOfMeasure",
                columns: new[] { "UnitOfMeasureId", "Unit" },
                values: new object[,]
                {
                    { 1, "stuks" },
                    { 2, "sets" },
                    { 3, "m" },
                    { 4, "m2" },
                    { 5, "cm" },
                    { 6, "cm2" },
                    { 7, "mm" },
                    { 8, "mm2" }
                });

            migrationBuilder.InsertData(
                table: "PersonTitles",
                columns: new[] { "PersonTitleId", "Title" },
                values: new object[,]
                {
                    { 1, "Dhr" },
                    { 2, "Mvr" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "ProductCategoryId", "ProductCategoryName" },
                values: new object[] { 1, "No name" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Active", "Clearance", "EmailAddress", "FamilyName", "FamilyNamePrefix", "FirstName", "FunctionName", "Initials", "Title", "Username" },
                values: new object[,]
                {
                    { 1, true, 9, "gideon@ezaccess.nl", "Maat", "ter", "Gideon", "Director", "GtM", "Dhr", "gideon@ezaccess.nl" },
                    { 2, true, 7, "jaimie@ezaccess.nl", "Chien", null, "Jaimie", "Boss", "JC", "Mvr", "jaimie@ezaccess.nl" },
                    { 3, true, 1, "jedidja@ezaccess.nl", "Maat", "ter", "Jedidja", "Child", "JtM", null, "jedidja@ezaccess.nl" }
                });

            migrationBuilder.InsertData(
                table: "Relations",
                columns: new[] { "RelationId", "CompanyName", "CompanyNamePrefix", "DefaultEmailAddressId", "FamilyName", "FamilyNamePrefix", "FirstName", "FirstPhoneNumberId", "InvoiceEmailAddressId", "IsConsumer", "IsCustomer", "IsSupplier", "OrderEmailAddressId", "OrderMethod", "RelationName", "Title" },
                values: new object[] { 1, "EZAccess", null, null, null, null, null, null, null, false, true, false, null, 0, "EZAccess", null });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "Calc_SumAmount", "Calc_TotalInvoiced", "Calc_TotalOffer", "Calc_TotalOrder", "Calc_TotalPaid", "CustomerId", "CustomerReference", "DiscountPerc", "EmployeeId", "IsInvoiced", "Notes", "OfferDate", "OrderDate", "OrderStatus", "PackingDate", "PackingList", "RecordStatus", "ShippingAddressLine1", "ShippingAddressLine2", "ShippingCity", "ShippingComments", "ShippingCountry", "ShippingDate", "ShippingMethodId", "ShippingName", "ShippingPhoneNumber", "ShippingPostalCode", "ShippingState", "VATTariff" },
                values: new object[] { 100000, 0.0, 0.0, 0.0, 0.0, 0.0, 1, "InitialEntry", 0.0, 1, true, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, 0, null, null, null, null, null, null, null, null, null, null, null, 0.0 });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceId", "Calc_AmountDiscountExcl", "Calc_AmountDiscountIncl", "Calc_AmountExcl", "Calc_AmountGrossExcl", "Calc_AmountGrossIncl", "Calc_AmountIncl", "Calc_AmountVAT", "CustomerId", "DateReminder", "DateWarning", "DiscountPerc", "InvoiceDate", "InvoiceNumber", "InvoiceStatus", "OrderId", "VATTariff" },
                values: new object[] { 100000, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 1, null, null, 0.0, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20210000, 0, 100000, 0.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 100000);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 100000);

            migrationBuilder.DeleteData(
                table: "Relations",
                keyColumn: "RelationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PersonTitles",
                keyColumn: "PersonTitleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PersonTitles",
                keyColumn: "PersonTitleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "ProductCategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UnitsOfMeasure",
                keyColumn: "UnitOfMeasureId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UnitsOfMeasure",
                keyColumn: "UnitOfMeasureId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UnitsOfMeasure",
                keyColumn: "UnitOfMeasureId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UnitsOfMeasure",
                keyColumn: "UnitOfMeasureId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UnitsOfMeasure",
                keyColumn: "UnitOfMeasureId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UnitsOfMeasure",
                keyColumn: "UnitOfMeasureId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UnitsOfMeasure",
                keyColumn: "UnitOfMeasureId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UnitsOfMeasure",
                keyColumn: "UnitOfMeasureId",
                keyValue: 8);

        }
    }
}
