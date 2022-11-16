

//the purpose of this class is to create a Unit of Work pattern.
//because of the CRUD operations implemented in REPOSITORY.CS and
//IREPOSITORY.CS (update, save, delete, insert),
//this UoW will group those operations into a single transaction.
//in the case that one of the operations fail, then **ALL** the
//database operations will ROLLBACK

using CapstoneV4.Models.DomainModels;
using CapstoneV4.Models.DataLayer.Repositories;
using System;


namespace CapstoneV4.Models.DataLayer.Repositories
{
    public interface IStoreUoW
    {
        Repository<Book> Books { get; }
        Repository<Author> Authors { get; }
        Repository<BookAuthor> BookAuthors { get; }
        Repository<Genre> Genres { get; }

        void DeleteCurrentBookAuthors(Book book);
        void AddNewBookAuthors(Book book, int[] authorids);
        void Save();



    }
}
