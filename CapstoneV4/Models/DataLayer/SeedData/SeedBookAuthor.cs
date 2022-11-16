using Microsoft.EntityFrameworkCore;
using CapstoneV4.Models.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapstoneV4.Models.DataLayer.SeedData
{
    public class SeedBookAuthor : IEntityTypeConfiguration<BookAuthor>

    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.HasData(
                new BookAuthor { BookId = 1, AuthorId = 3 },
                new BookAuthor { BookId = 2, AuthorId = 2 },
                new BookAuthor { BookId = 3, AuthorId = 3 },
                new BookAuthor { BookId = 4, AuthorId = 4 }
                );
        }
    }
}
