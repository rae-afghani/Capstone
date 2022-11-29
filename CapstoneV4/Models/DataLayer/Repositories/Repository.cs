using Microsoft.EntityFrameworkCore;

namespace CapstoneV4.Models.DataLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private CapstoneDB database { get; set; }
        private DbSet<T> dbSet { get; set; }
        public Repository(CapstoneDB db)
        {

            database = db;
            dbSet = database.Set<T>();

        }

        //here, i am getting the number of entities that are being pulled, using a private field when filtering because there may be instances where the COUNT is less than DBSET.COUNT()
        private int? count;
        public int Count => count ?? dbSet.Count();


        //virtual is added in the case of an override
        public virtual void Delete(T entity) => dbSet.Remove(entity);

        public virtual T Get(QueryOptions<T> options)
        {
            IQueryable<T> query = BuildQuery(options);
            return query.FirstOrDefault();
        }

        //will find the record with the specified id
        public virtual T Get(int id) => dbSet.Find(id);

        public virtual T Get(string id) => dbSet.Find(id);

        public virtual void Insert(T entity) => dbSet.Add(entity);


        public virtual IEnumerable<T> List(QueryOptions<T> options)
        {
            IQueryable<T> query = BuildQuery(options);
            return query.ToList();
        }

        public virtual void Save(T entity) => database.SaveChanges();

        public virtual void Update(T entity) => dbSet.Update(entity);



        //private helper method to build query 
        private IQueryable<T> BuildQuery(QueryOptions<T> options)
        {
            IQueryable<T> query = dbSet;
            foreach (string include in options.GetIncludes())
            {
                query = query.Include(include);
            }

            if (options.HasWhere)
            {
                foreach (var clause in options.WhereClauses)
                {
                    query = query.Where(clause);
                }
                count = query.Count(); //a filtered count
            }

            if (options.HasOrderBy)
            {    //ascending order sort
                if (options.OrderByDirection == "asc")
                {
                    query = query.OrderBy(options.OrderBy);
                }
                else
                {
                    query = query.OrderByDescending(options.OrderBy);
                }



            }


            if (options.HasPaging)
            {
                query = query.PageBy(options.PageNumber, options.PageSize);
            }

            return query;
        }
    }
}
