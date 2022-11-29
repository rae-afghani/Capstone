using CapstoneV4.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapstoneV4.Models.DataLayer.SeedData
{
    public class SeedCourseByProgram : IEntityTypeConfiguration<CourseProgram>

    {
        public void Configure(EntityTypeBuilder<CourseProgram> builder)
        {
            builder.HasData(
                new CourseProgram { CourseID = 101, ProgramID = 1 },
                new CourseProgram { CourseID = 102, ProgramID = 1 },
                new CourseProgram { CourseID = 103, ProgramID = 1 },
                new CourseProgram { CourseID = 104, ProgramID = 1 },
                new CourseProgram { CourseID = 105, ProgramID = 1 },

                new CourseProgram { CourseID = 201, ProgramID = 2 },
                new CourseProgram { CourseID = 202, ProgramID = 2 },
                new CourseProgram { CourseID = 203, ProgramID = 2 },

                new CourseProgram { CourseID = 301, ProgramID = 3 },
                new CourseProgram { CourseID = 302, ProgramID = 3 },
                new CourseProgram { CourseID = 303, ProgramID = 3 }

                );
        }
    }
}
