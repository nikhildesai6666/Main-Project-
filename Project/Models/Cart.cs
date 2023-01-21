using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Project.Models
{
    [Table("cart")]
    public class Cart
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Cartid { get; set; }

        [Required(ErrorMessage = "productid is required")]

        public int Pid { get; set; }

        [Required(ErrorMessage = "userid is required")]

        public int Userid { get; set; }


    }
}
