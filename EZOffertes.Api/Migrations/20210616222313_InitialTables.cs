using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EZOffertes.Api.Migrations
{
    public partial class InitialTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamilyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FamilyNamePrefix = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Initials = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FunctionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Clearance = table.Column<int>(type: "int", nullable: false),
                    TsCreated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    TsUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    InvoiceNumber = table.Column<int>(type: "int", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceStatus = table.Column<int>(type: "int", nullable: false),
                    DateReminder = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateWarning = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VATTariff = table.Column<double>(type: "float", nullable: false),
                    DiscountPerc = table.Column<double>(type: "float", nullable: false),
                    Calc_AmountGrossIncl = table.Column<double>(type: "float", nullable: false),
                    Calc_AmountGrossExcl = table.Column<double>(type: "float", nullable: false),
                    Calc_AmountDiscountIncl = table.Column<double>(type: "float", nullable: false),
                    Calc_AmountDiscountExcl = table.Column<double>(type: "float", nullable: false),
                    Calc_AmountVAT = table.Column<double>(type: "float", nullable: false),
                    Calc_AmountIncl = table.Column<double>(type: "float", nullable: false),
                    Calc_AmountExcl = table.Column<double>(type: "float", nullable: false),
                    TsCreated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    TsUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TextOffer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TextOrder = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Calc_DetailAmount = table.Column<double>(type: "float", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    SupplierStatus = table.Column<int>(type: "int", nullable: false),
                    SupplierArticleNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SupplierProductDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SupplierComment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SupplierOrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SupplierOrderReference = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SupplierConfirmDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SupplierDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShippingStatus = table.Column<int>(type: "int", nullable: false),
                    PackListId = table.Column<int>(type: "int", nullable: true),
                    ParentOrderDetailId = table.Column<int>(type: "int", nullable: true),
                    IsInternalComment = table.Column<bool>(type: "bit", nullable: false),
                    ActionSelect = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    TsCreated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    TsUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    OfferDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsInvoiced = table.Column<bool>(type: "bit", nullable: false),
                    CustomerReference = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ShippingMethodId = table.Column<int>(type: "int", nullable: false),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShippingName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ShippingAddressLine1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ShippingAddressLine2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ShippingPostalCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShippingCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShippingState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShippingCountry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShippingPhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShippingComments = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    VATTariff = table.Column<double>(type: "float", nullable: false),
                    DiscountPerc = table.Column<double>(type: "float", nullable: false),
                    PackingList = table.Column<int>(type: "int", nullable: true),
                    PackingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calc_SumAmount = table.Column<double>(type: "float", nullable: false),
                    Calc_TotalOffer = table.Column<double>(type: "float", nullable: false),
                    Calc_TotalOrder = table.Column<double>(type: "float", nullable: false),
                    Calc_TotalPaid = table.Column<double>(type: "float", nullable: false),
                    Calc_TotalInvoiced = table.Column<double>(type: "float", nullable: false),
                    RecordStatus = table.Column<int>(type: "int", nullable: false),
                    TsCreated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    TsUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    TsCreated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    TsUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "PersonTitles",
                columns: table => new
                {
                    PersonTitleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TsCreated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    TsUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTitles", x => x.PersonTitleId);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TsCreated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    TsUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.ProductCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ProductProperties",
                columns: table => new
                {
                    ProductPropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PropertyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PropertyValue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TsCreated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    TsUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProperties", x => x.ProductPropertyId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TextOffer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TextOrder = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    SupplierArticleNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SupplierProductDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TsCreated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    TsUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "QuickProductSetItems",
                columns: table => new
                {
                    QuickProductSetItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuickProductSetId = table.Column<int>(type: "int", nullable: false),
                    QuickOption = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    OptionDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TsCreated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    TsUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuickProductSetItems", x => x.QuickProductSetItemId);
                });

            migrationBuilder.CreateTable(
                name: "QuickProductSets",
                columns: table => new
                {
                    QuickProductSetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuickCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TsCreated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    TsUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuickProductSets", x => x.QuickProductSetId);
                });

            migrationBuilder.CreateTable(
                name: "RelationAddresses",
                columns: table => new
                {
                    RelationAddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelationId = table.Column<int>(type: "int", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddressType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TsCreated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    TsUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationAddresses", x => x.RelationAddressId);
                });

            migrationBuilder.CreateTable(
                name: "RelationEmailAddresses",
                columns: table => new
                {
                    RelationEmailAddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelationId = table.Column<int>(type: "int", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TsCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TsUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationEmailAddresses", x => x.RelationEmailAddressId);
                });

            migrationBuilder.CreateTable(
                name: "RelationNotes",
                columns: table => new
                {
                    RelationNoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelationId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    TsCreated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    TsUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationNotes", x => x.RelationNoteId);
                });

            migrationBuilder.CreateTable(
                name: "RelationPhoneNumbers",
                columns: table => new
                {
                    RelationPhoneNumberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelationId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumberType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsFirstPhoneNumber = table.Column<bool>(type: "bit", nullable: false),
                    TsCreated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    TsUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationPhoneNumbers", x => x.RelationPhoneNumberId);
                });

            migrationBuilder.CreateTable(
                name: "Relations",
                columns: table => new
                {
                    RelationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsCustomer = table.Column<bool>(type: "bit", nullable: false),
                    IsSupplier = table.Column<bool>(type: "bit", nullable: false),
                    IsConsumer = table.Column<bool>(type: "bit", nullable: false),
                    RelationName = table.Column<string>(type: "nvarchar(510)", maxLength: 510, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CompanyNamePrefix = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FamilyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FamilyNamePrefix = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FirstPhoneNumberId = table.Column<int>(type: "int", nullable: false),
                    DefaultEmailAddressId = table.Column<int>(type: "int", nullable: false),
                    InvoiceEmailAddressId = table.Column<int>(type: "int", nullable: false),
                    OrderEmailAddressId = table.Column<int>(type: "int", nullable: false),
                    OrderMethod = table.Column<int>(type: "int", nullable: false),
                    TsCreated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    TsUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relations", x => x.RelationId);
                });

            migrationBuilder.CreateTable(
                name: "ShippingMethods",
                columns: table => new
                {
                    ShippingMethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingMethodName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TsCreated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    TsUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingMethods", x => x.ShippingMethodId);
                });

            migrationBuilder.CreateTable(
                name: "UnitsOfMeasure",
                columns: table => new
                {
                    UnitOfMeasureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TsCreated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    TsUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitsOfMeasure", x => x.UnitOfMeasureId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonTitles_Title",
                table: "PersonTitles",
                column: "Title",
                unique: true,
                filter: "[Title] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductCategoryName",
                table: "ProductCategories",
                column: "ProductCategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuickProductSetItems_QuickProductSetId_QuickOption",
                table: "QuickProductSetItems",
                columns: new[] { "QuickProductSetId", "QuickOption" },
                unique: true,
                filter: "[QuickOption] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_QuickProductSets_QuickCode",
                table: "QuickProductSets",
                column: "QuickCode",
                unique: true,
                filter: "[QuickCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UnitsOfMeasure_Unit",
                table: "UnitsOfMeasure",
                column: "Unit",
                unique: true,
                filter: "[Unit] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PersonTitles");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductProperties");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "QuickProductSetItems");

            migrationBuilder.DropTable(
                name: "QuickProductSets");

            migrationBuilder.DropTable(
                name: "RelationAddresses");

            migrationBuilder.DropTable(
                name: "RelationEmailAddresses");

            migrationBuilder.DropTable(
                name: "RelationNotes");

            migrationBuilder.DropTable(
                name: "RelationPhoneNumbers");

            migrationBuilder.DropTable(
                name: "Relations");

            migrationBuilder.DropTable(
                name: "ShippingMethods");

            migrationBuilder.DropTable(
                name: "UnitsOfMeasure");
        }
    }
}
