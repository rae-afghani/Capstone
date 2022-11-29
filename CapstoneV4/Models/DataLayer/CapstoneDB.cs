using CapstoneV4.Models.DataLayer.SeedData;
using CapstoneV4.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace CapstoneV4.Models.DataLayer
{
    public class CapstoneDB : DbContext
    {
        public CapstoneDB(DbContextOptions<CapstoneDB> options)
            : base(options) { }

        public DbSet<DomainModels.Program> Programs { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<CourseProgram> CourseProgram { get; set; }
        public DbSet<Topics> Topics { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //creating primary keys
            modelBuilder.Entity<Courses>().HasKey(c => new { c.CourseID });
            modelBuilder.Entity<Topics>().HasKey(c => new { c.TopicID});
            modelBuilder.Entity<CourseProgram>().HasKey(prgm => new { prgm.CourseID, prgm.ProgramID });


            //foreign keys

            modelBuilder.Entity<CourseProgram>()
                        .HasOne(prgm => prgm.Course)
                        .WithMany(c => c.CourseProgram)
                        .HasForeignKey(prgm => prgm.CourseID);

            modelBuilder.Entity<CourseProgram>()
                .HasOne(prgm => prgm.Program)
                .WithMany(c => c.CourseProgram)
                .HasForeignKey(prgm => prgm.ProgramID);

            //prevent cascading delete w/ topic
            modelBuilder.Entity<Courses>()
                .HasOne(c => c.Topic)
                .WithMany(t => t.Courses)
                .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.ApplyConfiguration(new SeedTopics());
            modelBuilder.ApplyConfiguration(new SeedCourses());
            modelBuilder.ApplyConfiguration(new SeedPrograms());
            modelBuilder.ApplyConfiguration(new SeedCourseByProgram());


        }
    }


}
