using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Project.Models
{
    [Table("role")]
    public class Roles
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Roleid { get; set; }

        [Required(ErrorMessage = "name is required")]
        public string? Rolename { get; set; }


    }
}

    

