using Microsoft.EntityFrameworkCore;
using CapstoneV4.Models.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapstoneV4.Models.DataLayer.SeedData
{
    public class SeedGenres : IEntityTypeConfiguration<Genre>

    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(
                new Genre { GenreId = "novel", Name = "Novel"},
                new Genre { GenreId = "memoir", Name = "Memoir" },
                new Genre { GenreId = "mystery", Name = "Mystery" },
                new Genre { GenreId = "scifi", Name = "SciFi" },
                new Genre { GenreId = "history", Name = "History" }

                );
        }
    }
}
