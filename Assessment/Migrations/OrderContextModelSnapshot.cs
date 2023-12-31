﻿// <auto-generated />
using System;
using Assessment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Assessment.Migrations
{
    [DbContext(typeof(OrderContext))]
    partial class OrderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Assessment.Models.AppUsers", b =>
                {
                    b.Property<int>("AppUsersID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConfirmEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRoleID")
                        .HasColumnType("int");

                    b.HasKey("AppUsersID");

                    b.HasIndex("UserRoleID");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("Assessment.Models.OrderLine", b =>
                {
                    b.Property<int>("OrderLineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DeleteStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LineNumber")
                        .HasColumnType("int");

                    b.Property<int>("OrdersID")
                        .HasColumnType("int");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ProductCostPrice")
                        .HasColumnType("float");

                    b.Property<double>("ProductSalePrice")
                        .HasColumnType("float");

                    b.Property<int>("ProductTypeID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderLineID");

                    b.HasIndex("OrdersID");

                    b.HasIndex("ProductTypeID");

                    b.ToTable("orderLines");
                });

            modelBuilder.Entity("Assessment.Models.OrderStatus", b =>
                {
                    b.Property<int>("OrderStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderStatusID");

                    b.ToTable("orderStatuses");

                    b.HasData(
                        new
                        {
                            OrderStatusID = 1,
                            StatusDescription = "New"
                        },
                        new
                        {
                            OrderStatusID = 2,
                            StatusDescription = "Processing"
                        },
                        new
                        {
                            OrderStatusID = 3,
                            StatusDescription = "Complete"
                        });
                });

            modelBuilder.Entity("Assessment.Models.OrderType", b =>
                {
                    b.Property<int>("OrderTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderTypeID");

                    b.ToTable("orderTypes");

                    b.HasData(
                        new
                        {
                            OrderTypeID = 1,
                            TypeDescription = "Normal"
                        },
                        new
                        {
                            OrderTypeID = 2,
                            TypeDescription = "Staff"
                        },
                        new
                        {
                            OrderTypeID = 3,
                            TypeDescription = "Mechanical"
                        },
                        new
                        {
                            OrderTypeID = 4,
                            TypeDescription = "Perishable"
                        });
                });

            modelBuilder.Entity("Assessment.Models.Orders", b =>
                {
                    b.Property<int>("OrdersID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeleteStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<int>("OrderStatusID")
                        .HasColumnType("int");

                    b.Property<int>("OrderTypeID")
                        .HasColumnType("int");

                    b.HasKey("OrdersID");

                    b.HasIndex("OrderStatusID");

                    b.HasIndex("OrderTypeID");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("Assessment.Models.ProductType", b =>
                {
                    b.Property<int>("ProductTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProductTypeDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductTypeID");

                    b.ToTable("productTypes");

                    b.HasData(
                        new
                        {
                            ProductTypeID = 1,
                            ProductTypeDescription = "Apparel"
                        },
                        new
                        {
                            ProductTypeID = 2,
                            ProductTypeDescription = "Parts"
                        },
                        new
                        {
                            ProductTypeID = 3,
                            ProductTypeDescription = "Equipment"
                        },
                        new
                        {
                            ProductTypeID = 4,
                            ProductTypeDescription = "Motor"
                        });
                });

            modelBuilder.Entity("Assessment.Models.UserRole", b =>
                {
                    b.Property<int>("UserRoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserRoleDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserRoleID");

                    b.ToTable("userRoles");

                    b.HasData(
                        new
                        {
                            UserRoleID = 1,
                            UserRoleDescription = "Admin"
                        },
                        new
                        {
                            UserRoleID = 2,
                            UserRoleDescription = "Guest"
                        });
                });

            modelBuilder.Entity("Assessment.Models.AppUsers", b =>
                {
                    b.HasOne("Assessment.Models.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Assessment.Models.OrderLine", b =>
                {
                    b.HasOne("Assessment.Models.Orders", "Orders")
                        .WithMany()
                        .HasForeignKey("OrdersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assessment.Models.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Assessment.Models.Orders", b =>
                {
                    b.HasOne("Assessment.Models.OrderStatus", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assessment.Models.OrderType", "OrderType")
                        .WithMany()
                        .HasForeignKey("OrderTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
