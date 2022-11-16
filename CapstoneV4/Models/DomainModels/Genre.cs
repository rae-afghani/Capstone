using System.ComponentModel.DataAnnotations;

namespace CapstoneV4.Models.DomainModels
{
    public class Genre
    {
        [MaxLength(10)]
        [Required(ErrorMessage = "Please enter a genre ID")]
        public string GenreId { get; set; }

        [StringLength(25)]
        [Required(ErrorMessage = "Please enter genre type")]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
