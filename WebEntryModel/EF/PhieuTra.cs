using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEntryModel.EF
{
    [Table("Phieutras")]
    public class PhieuTra
    {
        [Key]
        [Required]
        public Guid Id { get; set; } = new Guid();

        public Guid PhieuMuonId { get; set; }

        public DateTime? NgayTra { get; set; } = DateTime.Now;

        [ForeignKey(nameof(PhieuMuonId))]
        public PhieuMuon? PhieuMuon { get; set; }
    }
}