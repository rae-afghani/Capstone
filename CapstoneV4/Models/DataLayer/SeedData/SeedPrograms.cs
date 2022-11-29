
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapstoneV4.Models.DataLayer.SeedData
{
    public class SeedPrograms : IEntityTypeConfiguration<DomainModels.Program>

    {
        public void Configure(EntityTypeBuilder<DomainModels.Program> builder)
        {
            builder.HasData(
                new DomainModels.Program { ProgramID = 1, ProgramType = "Group Learning", ProgramDescription = "This is an in-person course led by an instructor. Our classroom ratios are 5:1. Classes meet once a week." },
                new DomainModels.Program { ProgramID = 2, ProgramType = "1-On-1", ProgramDescription = "The curriculum of our Academic Accelerators empowers students where their weak points are. Students enrolled in this program meet with an instructor once a week at our campus." },
                new DomainModels.Program { ProgramID = 3, ProgramType = "Virtual Course", ProgramDescription = "This is a virtual course led by an instructor over Zoom. Upon enrollment, Science Lab provides all the necessary materials to succeed in this program. Classes meet once a week." }

                );


        }
    }
}