﻿// <auto-generated />
using System;
using DAl;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace api_movil.Migrations
{
    [DbContext(typeof(PulpFreshContext))]
    [Migration("20210627070206_FixTypeOfProp1")]
    partial class FixTypeOfProp1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CategoryPresentation", b =>
                {
                    b.Property<int>("PresentationsCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("PresentationsPresentationId")
                        .HasColumnType("int");

                    b.HasKey("PresentationsCategoryId", "PresentationsPresentationId");

                    b.HasIndex("PresentationsPresentationId");

                    b.ToTable("CategoryPresentation");
                });

            modelBuilder.Entity("Entidad.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Entidad.Client", b =>
                {
                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(130)");

                    b.Property<string>("Neighborhood")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ClientId");

                    b.HasIndex("UserName");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Entidad.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("IdClient")
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalIva")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("InvoiceId");

                    b.HasIndex("ClientId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Entidad.InvoiceDetail", b =>
                {
                    b.Property<int>("IdDetail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<int?>("IdInvoice")
                        .HasColumnType("int");

                    b.Property<int>("IdProduct")
                        .HasColumnType("int");

                    b.Property<int>("QuantityProduct")
                        .HasColumnType("int");

                    b.Property<decimal>("TolalDetail")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UnitValue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdDetail");

                    b.HasIndex("IdInvoice");

                    b.ToTable("InvoiceDetails");
                });

            modelBuilder.Entity("Entidad.Presentation", b =>
                {
                    b.Property<int>("PresentationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Measure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PresentationId");

                    b.ToTable("Presentations");
                });

            modelBuilder.Entity("Entidad.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Iva")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantityStock")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Unit_Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Entidad.User", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("UserName");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PresentationProduct", b =>
                {
                    b.Property<int>("PresentationsPresentationId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsProductId")
                        .HasColumnType("int");

                    b.HasKey("PresentationsPresentationId", "ProductsProductId");

                    b.HasIndex("ProductsProductId");

                    b.ToTable("PresentationProduct");
                });

            modelBuilder.Entity("CategoryPresentation", b =>
                {
                    b.HasOne("Entidad.Category", null)
                        .WithMany()
                        .HasForeignKey("PresentationsCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidad.Presentation", null)
                        .WithMany()
                        .HasForeignKey("PresentationsPresentationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entidad.Client", b =>
                {
                    b.HasOne("Entidad.User", "User")
                        .WithMany()
                        .HasForeignKey("UserName");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entidad.Invoice", b =>
                {
                    b.HasOne("Entidad.Client", null)
                        .WithMany("Presentations")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("Entidad.InvoiceDetail", b =>
                {
                    b.HasOne("Entidad.Invoice", null)
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("IdInvoice");
                });

            modelBuilder.Entity("Entidad.Product", b =>
                {
                    b.HasOne("Entidad.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PresentationProduct", b =>
                {
                    b.HasOne("Entidad.Presentation", null)
                        .WithMany()
                        .HasForeignKey("PresentationsPresentationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidad.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entidad.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entidad.Client", b =>
                {
                    b.Navigation("Presentations");
                });

            modelBuilder.Entity("Entidad.Invoice", b =>
                {
                    b.Navigation("InvoiceDetails");
                });
#pragma warning restore 612, 618
        }
    }
}