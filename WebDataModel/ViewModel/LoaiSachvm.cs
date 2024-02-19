using System.ComponentModel.DataAnnotations;

namespace WebDataModel.ViewModel
{
    public class LoaiSachvm
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}