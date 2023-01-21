using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Project.Models
{
    [Table("users")]
    public class Users
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Userid { get; set; }


        [Required(ErrorMessage = "email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "password is required")]

        public string? Password { get; set; }

        [Required(ErrorMessage = "roleid is required")]

        public int Roleid { get; set; }



    }
}
