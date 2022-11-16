namespace CapstoneV4.Models.DataLayer.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> List(QueryOptions<T> options);
        int Count { get; }

        //overload get method
        T Get(QueryOptions<T> options);
        T Get(int id);
        T Get(string id);



        //do not return anything, but outline CRUD operations
        //CRUD=create, read, update, delete
        //essential for software/web applications
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save(T entity);
    }
}
