﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebEntryModel;

#nullable disable

namespace WebEntryModel.Migrations
{
    [DbContext(typeof(AppDatabase))]
    [Migration("20240217223730_UpdateAnhBia")]
    partial class UpdateAnhBia
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebEntryModel.EF.ChiTietPhieuMuon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("NgayTra")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PhieuMuonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SachId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PhieuMuonId");

                    b.HasIndex("SachId");

                    b.ToTable("ChiTietPhieuMuons");
                });

            modelBuilder.Entity("WebEntryModel.EF.DocGia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("HanSuDung")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("docgias");
                });

            modelBuilder.Entity("WebEntryModel.EF.LoaiSach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("LoaiSachs");
                });

            modelBuilder.Entity("WebEntryModel.EF.NhaXuatBan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("NhaXuatBans");
                });

            modelBuilder.Entity("WebEntryModel.EF.PhieuMuon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MaDG")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("NgayMuon")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MaDG");

                    b.ToTable("PhieuMuons");
                });

            modelBuilder.Entity("WebEntryModel.EF.PhieuTra", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("NgayTra")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PhieuMuonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PhieuMuonId");

                    b.ToTable("Phieutras");
                });

            modelBuilder.Entity("WebEntryModel.EF.Sach", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnhBia")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<float?>("GiaSach")
                        .HasColumnType("real");

                    b.Property<int>("LoaiSachId")
                        .HasColumnType("int");

                    b.Property<int?>("NamXB")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("NhaXuanBanId")
                        .HasColumnType("int");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoaiSachId");

                    b.HasIndex("NhaXuanBanId");

                    b.ToTable("Sachs");
                });

            modelBuilder.Entity("WebEntryModel.EF.Userview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool?>("Sex")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Userviews");
                });

            modelBuilder.Entity("WebEntryModel.EF.ChiTietPhieuMuon", b =>
                {
                    b.HasOne("WebEntryModel.EF.PhieuMuon", "PhieuMuon")
                        .WithMany()
                        .HasForeignKey("PhieuMuonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebEntryModel.EF.Sach", "Sach")
                        .WithMany()
                        .HasForeignKey("SachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhieuMuon");

                    b.Navigation("Sach");
                });

            modelBuilder.Entity("WebEntryModel.EF.PhieuMuon", b =>
                {
                    b.HasOne("WebEntryModel.EF.DocGia", "DocGia")
                        .WithMany()
                        .HasForeignKey("MaDG")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocGia");
                });

            modelBuilder.Entity("WebEntryModel.EF.PhieuTra", b =>
                {
                    b.HasOne("WebEntryModel.EF.PhieuMuon", "PhieuMuon")
                        .WithMany()
                        .HasForeignKey("PhieuMuonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhieuMuon");
                });

            modelBuilder.Entity("WebEntryModel.EF.Sach", b =>
                {
                    b.HasOne("WebEntryModel.EF.LoaiSach", "LoaiSach")
                        .WithMany()
                        .HasForeignKey("LoaiSachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebEntryModel.EF.NhaXuatBan", "NhaXuatBan")
                        .WithMany()
                        .HasForeignKey("NhaXuanBanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiSach");

                    b.Navigation("NhaXuatBan");
                });
#pragma warning restore 612, 618
        }
    }
}
