using System.ComponentModel.DataAnnotations;

namespace WebDataModel.ViewModel
{
    public class NhaXuatBanvm
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}