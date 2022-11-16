using System.ComponentModel.DataAnnotations;

namespace CapstoneV4.Models.DomainModels
{
    public class Author
    {

        public int AuthorID { get; set; }

        [Required(ErrorMessage = "Please enter a first name")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name")]
        [MaxLength(60)]
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public ICollection<BookAuthors> BookAuthors { get; set; }





    }
}
