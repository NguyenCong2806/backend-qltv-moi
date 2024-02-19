using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEntryModel.EF
{
    [Table("Sachs")]
    public class Sach
    {
        [Key]
        public Guid Id { get; set; } = new Guid();

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Author { get; set; }
        [Required]
        [StringLength(255)]
        public string AnhBia { get; set; }

        public int LoaiSachId { get; set; }
        public int NhaXuanBanId { get; set; }
        public int? NamXB { get; set; }
        public int? SoLuong { get; set; }
        public float? GiaSach { get; set; }

        [ForeignKey("LoaiSachId")]
        public LoaiSach? LoaiSach { get; set; }

        [ForeignKey("NhaXuanBanId")]
        public NhaXuatBan? NhaXuatBan { get; set; }
    }
}