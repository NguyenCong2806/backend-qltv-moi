using System.ComponentModel.DataAnnotations;

namespace WebDataModel.ViewModel
{
    public class Sachvm
    {
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
        public LoaiSachvm? LoaiSach { get; set; }
        public NhaXuatBanvm? NhaXuatBan { get; set; }
    }
}