using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEntryModel.EF
{
    [Table("ChiTietPhieuMuons")]
    public class ChiTietPhieuMuon
    {
        [Key]
        [Required]
        public Guid Id { get; set; } = new Guid();

        public Guid SachId { get; set; }
        public Guid PhieuMuonId { get; set; }

        [Required]
        public DateTime NgayTra { get; set; }

        [ForeignKey(nameof(SachId))]
        public Sach? Sach { get; set; }

        [ForeignKey(nameof(PhieuMuonId))]
        public PhieuMuon? PhieuMuon { get; set; }
    }
}