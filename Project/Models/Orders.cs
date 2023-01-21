using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Project.Models
{
    [Table("orders")]
    public class Orders
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Oid { get; set; }


        [Required(ErrorMessage = "userid is required")]

        public int Userid { get; set; }

        [Required(ErrorMessage = "quantity is required")]

        public int Quantity { get; set; }



    }
}
