using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPiNet6Ver2.Data
{
    [Table("User")]
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(250)]
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }   
    }
}
