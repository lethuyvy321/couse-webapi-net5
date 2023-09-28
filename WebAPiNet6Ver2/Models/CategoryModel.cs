using System.ComponentModel.DataAnnotations;

namespace WebAPiNet6Ver2.Models
{
    public class CategoryModel
    {
        [Required]
        [MaxLength(25)]
        public string TenLoai { get; set; }
    }
}
