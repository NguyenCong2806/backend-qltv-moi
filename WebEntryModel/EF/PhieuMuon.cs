using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEntryModel.EF
{
    [Table("PhieuMuons")]
    public class PhieuMuon
    {
        [Key]
        public Guid Id { get; set; }

        public Guid MaDG { get; set; }
        [Required]
        public DateTime NgayMuon { get; set; }

        [ForeignKey(nameof(MaDG))]
        public DocGia? DocGia { get; set; }

    }
}