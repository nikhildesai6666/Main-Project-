using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Project.Models
{
    [Table("category")]
    public class Category
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Catid { get; set; }

        [Required(ErrorMessage = "categoryname is required")]
        public string? Catname { get; set; }

    }
}
