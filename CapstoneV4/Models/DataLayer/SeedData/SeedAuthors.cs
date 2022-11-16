using Microsoft.EntityFrameworkCore;
using CapstoneV4.Models.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


//seeding
namespace CapstoneV4.Models.DataLayer.SeedData
{
    public class SeedAuthors : IEntityTypeConfiguration<Author>

    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasData(
                new Author { AuthorID = 1, FirstName = "FName1", LastName = "LName1" },
                new Author { AuthorID = 2, FirstName = "FName2", LastName = "LName2" },
                new Author { AuthorID = 3, FirstName = "FName3", LastName = "LName3"},
                new Author { AuthorID = 4, FirstName = "FName4", LastName = "LName4"}

                );
        }
    }
}
