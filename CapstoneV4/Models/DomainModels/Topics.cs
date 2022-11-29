using System.ComponentModel.DataAnnotations;

namespace CapstoneV4.Models.DomainModels
{
    public class Topics
    {
        [MaxLength(10)]
        [Required(ErrorMessage = "Please enter a topic ID")]
        public string TopicID { get; set; }

        [StringLength(25)]
        [Required(ErrorMessage = "Please enter topic type")]
        public string Name { get; set; }

        public ICollection<Courses> Courses { get; set; }
    }
}
