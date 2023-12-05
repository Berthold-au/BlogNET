using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Le nom de l'article est trop long.")]
        [DisplayName("Titre de l'article: ")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Contenu de l'article: ")]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        [DisplayName("Auteur: ")]
        public int AuthorId { get; set; }

        //[ForeignKey("AuthorId")]
        //[ValidateNever]
        //public virtual User user { get; set; }

    }
}
