using Microsoft.EntityFrameworkCore;
using SerilogDemo.Data.DBContexts;

namespace SerilogDemo.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        internal DbSet<T> dbSet;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            this.dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task CreateAsync(T entity)
        {
           await dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
             dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        //protected readonly List<T> _entities = new();

        //public IEnumerable<T> GetAll() => _entities;
        //public T GetById(Guid id) => _entities.Find(e => ((dynamic)e).Id == id);
        //public void Add(T entity) { ((dynamic)entity).Id = Guid.NewGuid(); _entities.Add(entity); }
        //public void Update(T entity)
        //{
        //    var existing = GetById(((dynamic)entity).Id);
        //    if (existing != null)
        //    {
        //        _entities.Remove(existing);
        //        _entities.Add(entity);
        //    }
        //}
        //public void Delete(Guid id) => _entities.RemoveAll(e => ((dynamic)e).Id == id);
    }
}
