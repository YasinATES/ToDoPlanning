using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ToDoPlanning.DataAccess.Abstract;

namespace ToDoPlanning.DataAccess.Concrete
{
    public class GenericDal<T, TContext> : IGenericRepository<T>
        where T : class
        where TContext : DbContext, new()
    {
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            using var context = new TContext();
            return filter == null ?
                await context.Set<T>().ToListAsync() :
                await context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            using var context = new TContext();
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null)
        {
            using var context = new TContext();
            return filter == null ?
                await context.Set<T>().CountAsync() :
                await context.Set<T>().Where(filter).CountAsync();
        }

        public async void Create(T entity)
        {
            using var context = new TContext();
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
        }

        public async void Update(T entity)
        {
            using var context = new TContext();
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async void Delete(T entity)
        {
            using var context = new TContext();
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}