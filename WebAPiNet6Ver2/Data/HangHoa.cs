using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPiNet6Ver2.Data
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public Guid MaHh { get; set; }
        [Required]
        [MaxLength(255)]
        public string TenHh { get; set; }
        public string MoTa { get; set; }
        [Range(0,double.MaxValue)]
        public double DonGia { get; set; }
        public byte GiamGia { get; set; }
        public int? MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Category category { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public HangHoa()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
    }
}
