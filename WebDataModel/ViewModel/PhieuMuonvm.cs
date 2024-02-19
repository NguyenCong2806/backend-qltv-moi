using System.ComponentModel.DataAnnotations;

namespace WebDataModel.ViewModel
{
    public class PhieuMuonvm
    {
        public Guid Id { get; set; }

        public Guid MaDG { get; set; }
        [Required]
        public DateTime NgayMuon { get; set; }

        public DocGiavm? DocGia { get; set; }
    }
}