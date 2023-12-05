using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class User
    {
        [Key]
        public  int Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Le nom d'utilisateur est trop grand.")]
        [DisplayName("Nom d'utilisateur: ")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Mot de passe: ")]
        public string Password { get; set; }

        public string Role { get; set; }

        //public string ProfileImg { get; set; }
    }
}
