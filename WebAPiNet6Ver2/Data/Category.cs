using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPiNet6Ver2.Data
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int MaLoai { get; set; }
        [Required]
        [MaxLength(25)]
        public string TenLoai { get; set; }
        public virtual ICollection<HangHoa> HangHoas { get; set; }
    }
}
