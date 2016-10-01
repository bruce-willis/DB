using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DB.Data;

namespace DB.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20161001115036_UpdateCustomer")]
    partial class UpdateCustomer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DB.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Age");

                    b.Property<string>("Email");

                    b.Property<decimal?>("Height");

                    b.Property<string>("Middlename");

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.Property<string>("Telephone");

                    b.Property<decimal?>("Weight");

                    b.HasKey("CustomerID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("DB.Models.Dealer", b =>
                {
                    b.Property<int>("DealerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Promocode");

                    b.HasKey("DealerID");

                    b.ToTable("Dealer");
                });

            modelBuilder.Entity("DB.Models.Good", b =>
                {
                    b.Property<int>("GoodID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("Carbohydrate");

                    b.Property<int?>("Category");

                    b.Property<string>("Description");

                    b.Property<decimal?>("Fat");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<decimal?>("Protein");

                    b.Property<int?>("PurchaseID");

                    b.HasKey("GoodID");

                    b.HasIndex("PurchaseID");

                    b.ToTable("Good");
                });

            modelBuilder.Entity("DB.Models.Purchase", b =>
                {
                    b.Property<int>("PurchaseID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int?>("CustomerID");

                    b.Property<int?>("DealerID");

                    b.Property<DateTime>("Time");

                    b.Property<decimal>("TotalPrice");

                    b.HasKey("PurchaseID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("DealerID");

                    b.ToTable("Purchase");
                });

            modelBuilder.Entity("DB.Models.Good", b =>
                {
                    b.HasOne("DB.Models.Purchase")
                        .WithMany("Goods")
                        .HasForeignKey("PurchaseID");
                });

            modelBuilder.Entity("DB.Models.Purchase", b =>
                {
                    b.HasOne("DB.Models.Customer")
                        .WithMany("Purchases")
                        .HasForeignKey("CustomerID");

                    b.HasOne("DB.Models.Dealer")
                        .WithMany("Sold")
                        .HasForeignKey("DealerID");
                });
        }
    }
}
