using CapstoneV4.Models.DomainModels;

namespace CapstoneV4.Models.DTOs
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public Dictionary<int, string> Authors { get; set; }
        
        public void Load(Book book)
        {
            BookId = book.BookId;
            Title = book.Title;
            Price = book.Price;
            Authors = new Dictionary<int, string>();

            foreach(BookAuthor ba in book.BookAuthor)
            {
                Authors.Add(ba.AuthorId, ba.Author.FullName);
            }
        }
    }
}
