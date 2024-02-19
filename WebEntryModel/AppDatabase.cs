using Microsoft.EntityFrameworkCore;
using WebEntryModel.EF;

namespace WebEntryModel
{
    public class AppDatabase : DbContext
    {
        public AppDatabase(DbContextOptions<AppDatabase> options) : base(options)
        {
        }

        public DbSet<Userview> Userviews { get; set; }
        public DbSet<LoaiSach> LoaiSaches { get; set; }
        public DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public DbSet<Sach> Saches { get; set; }
        public DbSet<ChiTietPhieuMuon> ChiTietPhieuMuons { get; set; }
        public DbSet<DocGia> DocGias { get; set; }
        public DbSet<PhieuMuon> PhieuMuons { get; set; }
        public DbSet<PhieuTra> PhieuTras { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}