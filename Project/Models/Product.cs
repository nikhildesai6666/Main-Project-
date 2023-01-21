using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Project.Models

{
     
    [Table("product")]
    public class Role
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "name is required")]
        public string? Pname { get; set; }
         
        [Required(ErrorMessage = "price is required")]

        public int price { get; set; }

        [Required(ErrorMessage = "cartid is required")]

        public int Cartid { get; set; } 


    }
}