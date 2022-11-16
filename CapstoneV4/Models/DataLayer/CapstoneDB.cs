using CapstoneV4.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace CapstoneV4.Models.DataLayer
{
    public class CapstoneDB : DbContext
    {
        public CapstoneDB(DbContextOptions<CapstoneDB> options)
            : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }
        public DbSet<Genre> Genres { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   

            //creating primary keys
            modelBuilder.Entity<BookAuthor>().HasKey(ba => new {ba.BookId, ba.AuthorId});


            //foreign keys
            modelBuilder.Entity<BookAuthor>().HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthor)
                .HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<BookAuthor>().HasOne(ba => ba.Author)
                .WithMany(b => b.BookAuthor)
                .HasForeignKey(ba => ba.AuthorId);


            //removing cascading delete w/ genre
            modelBuilder.Entity<Book>().HasOne(b => b.Genre)
                .WithMany(g => g.Books)
                .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.ApplyConfiguration(new SeedGenres());
            modelBuilder.ApplyConfiguration(new SeedBooks());
            modelBuilder.ApplyConfiguration(new SeedAuthors());
            modelBuilder.ApplyConfiguration(new SeedBookAuthors());


        }
    }


}
