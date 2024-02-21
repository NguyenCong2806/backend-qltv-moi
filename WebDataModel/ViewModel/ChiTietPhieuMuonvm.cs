using System.ComponentModel.DataAnnotations;

namespace WebDataModel.ViewModel
{
    public class ChiTietPhieuMuonvm
    {
        public Guid Id { get; set; } = new Guid();

        public Guid SachId { get; set; }
        public Guid PhieuMuonId { get; set; }

        [Required]
        public DateTime NgayTra { get; set; }

        public Sachvm? Sach { get; set; }
    }
}