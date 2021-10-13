using EZOffertes.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EZOffertes.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        //public DbSet<InvoiceStatus> InvoiceStatusEnum { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PersonTitle> PersonTitles { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<QuickProductSetItem> QuickProductSetItems { get; set; }
        public DbSet<QuickProductSet> QuickProductSets { get; set; }
        public DbSet<RelationAddress> RelationAddresses { get; set; }
        public DbSet<RelationEmailAddress> RelationEmailAddresses { get; set; }
        public DbSet<RelationNote> RelationNotes { get; set; }
        public DbSet<RelationPhoneNumber> RelationPhoneNumbers { get; set; }
        public DbSet<Relation> Relations { get; set; }
        public DbSet<ShippingMethod> ShippingMethods { get; set; }
        public DbSet<UnitOfMeasure> UnitsOfMeasure { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity("EZOffertes.Models.Employee", b =>
            {
                b.Property<DateTime?>("TsCreated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");

                b.Property<DateTime?>("TsUpdated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");

            });

            modelBuilder.Entity("EZOffertes.Models.Invoice", b =>
            {
                b.HasOne("EZOffertes.Models.Order", null)
                    .WithMany("Invoices")
                    .HasForeignKey("OrderId")
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                b.Property<DateTime?>("TsCreated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");

                b.Property<DateTime?>("TsUpdated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");

            });

            modelBuilder.Entity("EZOffertes.Models.Order", b =>
            {
                ////b.HasOne("EZOffertes.Models.Relation", "Relation")
                ////    .WithMany()
                ////    .HasForeignKey("CustomerId")
                ////    .OnDelete(DeleteBehavior.Restrict)
                ////    .IsRequired();

                //b.HasOne("EZOffertes.Models.Employee", "Employee")
                //    .WithMany()
                //    .HasForeignKey("EmployeeId")
                //    .OnDelete(DeleteBehavior.Restrict)
                //    .IsRequired();

                //b.HasOne("EZOffertes.Models.ShippingMethod", "ShippingMethod")
                //    .WithMany()
                //    .HasForeignKey("ShippingMethodId")
                //    .OnDelete(DeleteBehavior.Restrict)
                //    .IsRequired();

                b.Property<DateTime?>("TsCreated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");

                b.Property<DateTime?>("TsUpdated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");

                //b.Navigation("Employee");

                ////b.Navigation("Relation");

                //b.Navigation("ShippingMethod");

                //b.HasKey("OrderId");

                //b.HasIndex("CustomerId");

                //b.HasIndex("EmployeeId");

                //b.HasIndex("ShippingMethodId");

                //b.ToTable("Orders");
            });

            modelBuilder.Entity("EZOffertes.Models.OrderDetail", b =>
            {
                b.HasOne("EZOffertes.Models.Invoice", null)
                    .WithMany("OrderDetails")
                    .HasForeignKey("InvoiceId")
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne("EZOffertes.Models.Order", null)
                    .WithMany("OrderDetails")
                    .HasForeignKey("OrderId")
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                //b.HasOne("EZOffertes.Models.Product", "Product")
                //    .WithMany()
                //    .HasForeignKey("ProductId")
                //    .OnDelete(DeleteBehavior.Restrict)
                //    .IsRequired();

                b.Property<DateTime?>("TsCreated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");

                b.Property<DateTime?>("TsUpdated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity("EZOffertes.Models.Payment", b =>
            {
                //b.HasOne("EZOffertes.Models.Employee", "Employee")
                //    .WithMany()
                //    .HasForeignKey("EmployeeId")
                //    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne("EZOffertes.Models.Invoice", null)
                    .WithMany("Payments")
                    .HasForeignKey("InvoiceId")
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                b.HasOne("EZOffertes.Models.Order", null)
                    .WithMany("Payments")
                    .HasForeignKey("OrderId")
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                b.Property<DateTime?>("TsCreated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");

                b.Property<DateTime?>("TsUpdated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity("EZOffertes.Models.PersonTitle", b =>
            {
                b.Property<DateTime?>("TsCreated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");

                b.Property<DateTime?>("TsUpdated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");

            });

            modelBuilder.Entity("EZOffertes.Models.Product", b =>
            {
                b.Property<DateTime?>("TsCreated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");

                b.Property<DateTime?>("TsUpdated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");

            });

            modelBuilder.Entity("EZOffertes.Models.ProductCategory", b => 
            {
                b.Property<DateTime?>("TsCreated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");

                b.Property<DateTime?>("TsUpdated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");

            });

            modelBuilder.Entity("EZOffertes.Models.ProductProperty", b =>
            {
                //b.HasOne("EZOffertes.Models.Product", null)
                //    .WithMany("ProductProperties")
                //    .HasForeignKey("ProductId")
                //    .OnDelete(DeleteBehavior.Cascade)
                //    .IsRequired();

                b.Property<DateTime?>("TsCreated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");

                b.Property<DateTime?>("TsUpdated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity("EZOffertes.Models.QuickProductSet", b =>
            {
                b.Property<DateTime?>("TsCreated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");

                b.Property<DateTime?>("TsUpdated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity("EZOffertes.Models.QuickProductSetItem", b =>
            {
                b.HasOne("EZOffertes.Models.Product", "Product")
                    .WithMany()
                    .HasForeignKey("ProductId")
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                ////b.HasOne("EZOffertes.Models.QuickProductSet", "QuickProductSet")
                ////    .WithMany("Items")
                ////    .HasForeignKey("QuickCode")
                ////    .OnDelete(DeleteBehavior.Cascade)
                ////    .IsRequired();

                b.Property<DateTime?>("TsCreated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");

                b.Property<DateTime?>("TsUpdated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");

            });

            modelBuilder.Entity("EZOffertes.Models.Relation", b =>
            {
                b.Property<DateTime?>("TsCreated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");

                b.Property<DateTime?>("TsUpdated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity("EZOffertes.Models.RelationAddress", b =>
            {
                //b.HasOne("EZOffertes.Models.Relation", null)
                //    .WithMany("Addresses")
                //    .HasForeignKey("RelationId")
                //    .OnDelete(DeleteBehavior.Cascade)
                //    .IsRequired();

                b.Property<DateTime?>("TsCreated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");

                b.Property<DateTime?>("TsUpdated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");

            });

            modelBuilder.Entity("EZOffertes.Models.RelationNote", b =>
            {
                //b.HasOne("EZOffertes.Models.Relation", null)
                //    .WithMany("Notes")
                //    .HasForeignKey("RelationId")
                //    .OnDelete(DeleteBehavior.Cascade)
                //    .IsRequired();

                b.Property<DateTime?>("TsCreated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");

                b.Property<DateTime?>("TsUpdated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");

            });

            modelBuilder.Entity("EZOffertes.Models.RelationPhoneNumber", b =>
            {
                //b.HasOne("EZOffertes.Models.Relation", null)
                //    .WithMany("PhoneNumbers")
                //    .HasForeignKey("RelationId")
                //    .OnDelete(DeleteBehavior.Cascade)
                //    .IsRequired();

                b.Property<DateTime?>("TsCreated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");

                b.Property<DateTime?>("TsUpdated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");

            });

            modelBuilder.Entity("EZOffertes.Models.ShippingMethod", b =>
            {
                b.Property<DateTime?>("TsCreated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");

                b.Property<DateTime?>("TsUpdated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity("EZOffertes.Models.UnitOfMeasure", b =>
            {
                b.Property<DateTime?>("TsCreated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");

                b.Property<DateTime?>("TsUpdated")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()");
            });

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UnitOfMeasure>().HasData(new UnitOfMeasure { UnitOfMeasureId = 1, Unit = "stuks", TsCreated = null, TsUpdated = null });
            modelBuilder.Entity<UnitOfMeasure>().HasData(new UnitOfMeasure { UnitOfMeasureId = 2, Unit = "sets", TsCreated = null, TsUpdated = null });
            modelBuilder.Entity<UnitOfMeasure>().HasData(new UnitOfMeasure { UnitOfMeasureId = 3, Unit = "m", TsCreated = null, TsUpdated = null });
            modelBuilder.Entity<UnitOfMeasure>().HasData(new UnitOfMeasure { UnitOfMeasureId = 4, Unit = "m2", TsCreated = null, TsUpdated = null });
            modelBuilder.Entity<UnitOfMeasure>().HasData(new UnitOfMeasure { UnitOfMeasureId = 5, Unit = "cm", TsCreated = null, TsUpdated = null });
            modelBuilder.Entity<UnitOfMeasure>().HasData(new UnitOfMeasure { UnitOfMeasureId = 6, Unit = "cm2", TsCreated = null, TsUpdated = null });
            modelBuilder.Entity<UnitOfMeasure>().HasData(new UnitOfMeasure { UnitOfMeasureId = 7, Unit = "mm", TsCreated = null, TsUpdated = null });
            modelBuilder.Entity<UnitOfMeasure>().HasData(new UnitOfMeasure { UnitOfMeasureId = 8, Unit = "mm2", TsCreated = null, TsUpdated = null });

            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory { ProductCategoryId = 1, ProductCategoryName = "No name", TsCreated = null, TsUpdated = null });

            modelBuilder.Entity<PersonTitle>().HasData(new PersonTitle { PersonTitleId = 1, Title = "Dhr", TsCreated = null, TsUpdated = null });
            modelBuilder.Entity<PersonTitle>().HasData(new PersonTitle { PersonTitleId = 2, Title = "Mvr", TsCreated = null, TsUpdated = null });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FamilyName = "Maat",
                FamilyNamePrefix = "ter",
                FirstName = "Gideon",
                Title = "Dhr",
                Initials = "GtM",
                Username = "gideon@ezaccess.nl",
                EmailAddress = "gideon@ezaccess.nl",
                FunctionName = "Director",
                Active = true,
                Clearance = 9,
                TsCreated = null,
                TsUpdated = null
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                FamilyName = "Chien",
                FamilyNamePrefix = null,
                FirstName = "Jaimie",
                Title = "Mvr",
                Initials = "JC",
                Username = "jaimie@ezaccess.nl",
                EmailAddress = "jaimie@ezaccess.nl",
                FunctionName = "Boss",
                Active = true,
                Clearance = 7,
                TsCreated = null,
                TsUpdated = null
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 3,
                FamilyName = "Maat",
                FamilyNamePrefix = "ter",
                FirstName = "Jedidja",
                Title = null,
                Initials = "JtM",
                Username = "jedidja@ezaccess.nl",
                EmailAddress = "jedidja@ezaccess.nl",
                FunctionName = "Child",
                Active = true,
                Clearance = 1,
                TsCreated = null,
                TsUpdated = null
            });

            modelBuilder.Entity<Relation>().HasData(new Relation
            {
                RelationId = 1,
                IsCustomer = true,
                IsSupplier = false,
                IsConsumer = false,
                RelationName = "EZAccess",
                CompanyName = "EZAccess",
                CompanyNamePrefix = null,
                FamilyName = null,
                FamilyNamePrefix = null,
                FirstName = null,
                Title = null,
                FirstPhoneNumberId = null,
                DefaultEmailAddressId = null,
                InvoiceEmailAddressId = null,
                OrderEmailAddressId = null,
                OrderMethod = 0,
                TsCreated = null,
                TsUpdated = null
            });

            modelBuilder.Entity<ShippingMethod>().HasData(new ShippingMethod { ShippingMethodId = 1, ShippingMethodName = "Take away", TsCreated = null, TsUpdated = null });
            modelBuilder.Entity<ShippingMethod>().HasData(new ShippingMethod { ShippingMethodId = 2, ShippingMethodName = "By truck", TsCreated = null, TsUpdated = null });
            modelBuilder.Entity<ShippingMethod>().HasData(new ShippingMethod { ShippingMethodId = 3, ShippingMethodName = "By mail", TsCreated = null, TsUpdated = null });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 100000,
                CustomerId = 1,
                EmployeeId = 1,
                OrderStatus = 0,
                OfferDate = DateTime.Parse("2021-01-01"),
                OrderDate = DateTime.Parse("2021-01-01"),
                IsInvoiced = true,
                CustomerReference = "InitialEntry",
                ShippingMethodId = null,
                ShippingDate = null,
                ShippingName = null,
                ShippingAddressLine1 = null,
                ShippingAddressLine2 = null,
                ShippingPostalCode = null,
                ShippingCity = null,
                ShippingState = null,
                ShippingCountry = null,
                ShippingPhoneNumber = null,
                ShippingComments = null,
                VATTariff = 0,
                DiscountPerc = 0,
                PackingList = null,
                PackingDate = null,
                Notes = null,
                Calc_SumAmount = 0,
                Calc_TotalOffer = 0,
                Calc_TotalOrder = 0,
                Calc_TotalPaid = 0,
                Calc_TotalInvoiced = 0,
                RecordStatus = 0,
                TsCreated = null,
                TsUpdated = null
            });

            modelBuilder.Entity<Invoice>().HasData(new Invoice
            {
                InvoiceId = 100000,
                CustomerId = 1,
                OrderId = 100000,
                InvoiceNumber = 20210000,
                InvoiceDate = DateTime.Parse("2021-01-01"),
                InvoiceStatus = 0,
                DateReminder = null,
                DateWarning = null,
                VATTariff = 0,
                DiscountPerc = 0,
                Calc_AmountGrossIncl = 0,
                Calc_AmountGrossExcl = 0,
                Calc_AmountDiscountIncl = 0,
                Calc_AmountDiscountExcl = 0,
                Calc_AmountVAT = 0,
                Calc_AmountIncl = 0,
                Calc_AmountExcl = 0,
                TsCreated = null,
                TsUpdated = null
            });
        }
    }
}
