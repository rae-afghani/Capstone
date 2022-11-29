

//the purpose of this class is to create a Unit of Work pattern.
//because of the CRUD operations implemented in REPOSITORY.CS and
//IREPOSITORY.CS (update, save, delete, insert),
//this UoW will group those operations into a single transaction.
//in the case that one of the operations fail, then **ALL** the
//database operations will ROLLBACK

using CapstoneV4.Models.DomainModels;


namespace CapstoneV4.Models.DataLayer.Repositories
{
    public interface IStoreUoW
    {
        Repository<Courses> Courses { get; }
        Repository<DomainModels.Program> Programs { get; }
        Repository<CourseProgram> CourseProgram { get; }
        Repository<Topics> Topics { get; }

        void DeleteCurrentCoursePrograms(Courses course);
        void AddNewCoursePrograms(Courses course, int[] programids);
        void Save();



    }
}
