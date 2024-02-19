using System.ComponentModel.DataAnnotations;

namespace WebDataModel.ViewModel
{
    public class DocGiavm
    {
        public Guid Id { get; set; } = new Guid();

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string DiaChi { get; set; }

        public DateTime? NgaySinh { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        public DateTime HanSuDung { get; set; } = DateTime.Now.AddYears(1);
    }
}