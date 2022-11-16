using Microsoft.EntityFrameworkCore;
using CapstoneV4.Models.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapstoneV4.Models.DataLayer.SeedData
{
    public class SeedBooks : IEntityTypeConfiguration<Book>

    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { BookId = 1, Title = "Book1", GenreId = "history", Price = 199.00 },
                new Book { BookId = 2, Title = "Book2", GenreId = "scifi", Price = 249.00 },
                new Book { BookId = 3, Title = "Book3", GenreId = "history", Price = 199.00 },
                new Book { BookId = 4, Title = "Book4", GenreId = "scifi", Price = 249.00 }
                );
        }
    }
}
