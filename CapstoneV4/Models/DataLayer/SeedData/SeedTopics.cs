using CapstoneV4.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapstoneV4.Models.DataLayer.SeedData
{
    public class SeedTopics : IEntityTypeConfiguration<Topics>

    {
        public void Configure(EntityTypeBuilder<Topics> builder)
        {
            builder.HasData(
                new Topics { TopicID = "cs", Name = "Compuer Science" },
                new Topics { TopicID = "math", Name = "Mathematics" },
                new Topics { TopicID = "chem", Name = "Chemistry" },
                new Topics { TopicID = "psych", Name = "Psychology" },
                new Topics { TopicID = "phys", Name = "Physics" },
                new Topics { TopicID = "biol", Name = "Biology" }

                );
        }
    }
}
