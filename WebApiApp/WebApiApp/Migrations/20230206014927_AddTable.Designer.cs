﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiApp.Data;

namespace WebApiApp.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230206014927_AddTable")]
    partial class AddTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WebApiApp.Data.DonHang", b =>
                {
                    b.Property<Guid>("MaDh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaChiGiao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayDat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime?>("NgayGiao")
                        .HasColumnType("datetime2");

                    b.Property<string>("NguoiNhan")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TinhTrang")
                        .HasColumnType("int");

                    b.HasKey("MaDh");

                    b.ToTable("DonHang");
                });

            modelBuilder.Entity("WebApiApp.Data.HangHoa", b =>
                {
                    b.Property<Guid>("MaHh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("DonGia")
                        .HasColumnType("float");

                    b.Property<byte>("GiamGia")
                        .HasColumnType("tinyint");

                    b.Property<int?>("MaLoai")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenHh")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaHh");

                    b.HasIndex("MaLoai");

                    b.ToTable("HangHoa");
                });

            modelBuilder.Entity("WebApiApp.Data.Loai", b =>
                {
                    b.Property<int>("MaLoai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaLoai");

                    b.ToTable("Loai");
                });

            modelBuilder.Entity("WebApiApp.Data.OrderDetail", b =>
                {
                    b.Property<Guid>("MaDh")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MaHh")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("DonGia")
                        .HasColumnType("float");

                    b.Property<byte>("GiamGia")
                        .HasColumnType("tinyint");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaDh", "MaHh");

                    b.HasIndex("MaHh");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("WebApiApp.DataDB.CategoryProduct", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryID");

                    b.ToTable("CategorysProduct");
                });

            modelBuilder.Entity("WebApiApp.DataDB.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("ProductPrice")
                        .HasColumnType("float");

                    b.Property<byte>("ProductSales")
                        .HasColumnType("tinyint");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("WebApiApp.Data.HangHoa", b =>
                {
                    b.HasOne("WebApiApp.Data.Loai", "Loai")
                        .WithMany("HangHoas")
                        .HasForeignKey("MaLoai");

                    b.Navigation("Loai");
                });

            modelBuilder.Entity("WebApiApp.Data.OrderDetail", b =>
                {
                    b.HasOne("WebApiApp.Data.DonHang", "DonHang")
                        .WithMany("OrderDetails")
                        .HasForeignKey("MaDh")
                        .HasConstraintName("FK_ORDERDETAIL_TO_DONHANG")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiApp.Data.HangHoa", "HangHoa")
                        .WithMany("OrderDetails")
                        .HasForeignKey("MaHh")
                        .HasConstraintName("FK_ORDERDETAIL_TO_HANGHOA")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonHang");

                    b.Navigation("HangHoa");
                });

            modelBuilder.Entity("WebApiApp.DataDB.Product", b =>
                {
                    b.HasOne("WebApiApp.DataDB.CategoryProduct", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .HasConstraintName("FK_PRODUCT_TO_CATEGORY");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("WebApiApp.Data.DonHang", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("WebApiApp.Data.HangHoa", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("WebApiApp.Data.Loai", b =>
                {
                    b.Navigation("HangHoas");
                });

            modelBuilder.Entity("WebApiApp.DataDB.CategoryProduct", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
