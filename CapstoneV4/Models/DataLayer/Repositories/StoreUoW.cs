using CapstoneV4.Models.DomainModels;
using CapstoneV4.Models.DataLayer.Repositories;
using FluentAssertions;
using System;


namespace CapstoneV4.Models.DataLayer.Repositories
{
    public class StoreUoW : IStoreUoW
    {
        private CapstoneDB database;
        public StoreUoW(CapstoneDB db)
        {
            database = db;
        }

        private Repository<Book> bookData;
        public Repository<Book> Books
        {
            get
            {
                if (bookData == null)
                {
                    bookData = new Repository<Book>(database);
                }
                return bookData;
            }
        }


        private Repository<Author> authorData;
        public Repository<Author> Authors
        {
            get
            {
                if (authorData == null)
                {
                    authorData = new Repository<Author>(database);
                }
                return authorData;
            }
        }


        private Repository<BookAuthor> bookAuthorData;
        public Repository<BookAuthor> BookAuthor
        {
            get
            {
                if (bookAuthorData == null)
                {
                    bookAuthorData = new Repository<BookAuthor>(database);
                }
                return bookAuthorData;
            }
        }


        private Repository<Genre> genreData;
        public Repository<Genre> Genres
        {
            get
            {
                if (genreData == null)
                {
                    genreData = new Repository<Genre>(database);
                }
                return genreData;
            }
        }

        public Repository<BookAuthor> BookAuthors => throw new NotImplementedException();

        public void AddNewBookAuthors(Book book, int[] authorids)
        {
            book.BookAuthor = authorids.Select(i => new BookAuthor { Book = book, AuthorId = i}).ToList();
        }

        public void DeleteCurrentBookAuthors(Book book)
        {
            var currentAuthors = BookAuthor.List(new QueryOptions<BookAuthor> {
                Where = ba => ba.BookId == book.BookId
            });

            foreach(BookAuthor ba in currentAuthors) {
                BookAuthor.Delete(ba);
            }
        }

        public void Save() => database.SaveChanges();

    }
}
