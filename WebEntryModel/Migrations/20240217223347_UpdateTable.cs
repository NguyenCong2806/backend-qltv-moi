using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebEntryModel.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "docgias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HanSuDung = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_docgias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSachs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSachs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhaXuatBans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaXuatBans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhieuMuons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaDG = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayMuon = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuMuons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhieuMuons_docgias_MaDG",
                        column: x => x.MaDG,
                        principalTable: "docgias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sachs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LoaiSachId = table.Column<int>(type: "int", nullable: false),
                    NhaXuanBanId = table.Column<int>(type: "int", nullable: false),
                    NamXB = table.Column<int>(type: "int", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    GiaSach = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sachs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sachs_LoaiSachs_LoaiSachId",
                        column: x => x.LoaiSachId,
                        principalTable: "LoaiSachs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sachs_NhaXuatBans_NhaXuanBanId",
                        column: x => x.NhaXuanBanId,
                        principalTable: "NhaXuatBans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phieutras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhieuMuonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayTra = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phieutras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phieutras_PhieuMuons_PhieuMuonId",
                        column: x => x.PhieuMuonId,
                        principalTable: "PhieuMuons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuMuons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SachId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhieuMuonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayTra = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhieuMuons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuMuons_PhieuMuons_PhieuMuonId",
                        column: x => x.PhieuMuonId,
                        principalTable: "PhieuMuons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuMuons_Sachs_SachId",
                        column: x => x.SachId,
                        principalTable: "Sachs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuMuons_PhieuMuonId",
                table: "ChiTietPhieuMuons",
                column: "PhieuMuonId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuMuons_SachId",
                table: "ChiTietPhieuMuons",
                column: "SachId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuMuons_MaDG",
                table: "PhieuMuons",
                column: "MaDG");

            migrationBuilder.CreateIndex(
                name: "IX_Phieutras_PhieuMuonId",
                table: "Phieutras",
                column: "PhieuMuonId");

            migrationBuilder.CreateIndex(
                name: "IX_Sachs_LoaiSachId",
                table: "Sachs",
                column: "LoaiSachId");

            migrationBuilder.CreateIndex(
                name: "IX_Sachs_NhaXuanBanId",
                table: "Sachs",
                column: "NhaXuanBanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietPhieuMuons");

            migrationBuilder.DropTable(
                name: "Phieutras");

            migrationBuilder.DropTable(
                name: "Sachs");

            migrationBuilder.DropTable(
                name: "PhieuMuons");

            migrationBuilder.DropTable(
                name: "LoaiSachs");

            migrationBuilder.DropTable(
                name: "NhaXuatBans");

            migrationBuilder.DropTable(
                name: "docgias");
        }
    }
}
