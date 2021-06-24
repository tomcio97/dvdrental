using System.Threading.Tasks;
using dvdrental.Domain.Interfaces.Repositories;
using dvdrental.Entities;

namespace dvdrental.Database.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
    {
        protected readonly DvdrentalContext context;

        public BaseRepository(DvdrentalContext context)
        {
            this.context = context;
        }
        public virtual async Task<bool> Add(T entity)
        {
            context.Add(entity);

            return await context.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> Delete(T entity)
        {
            context.Remove(entity);

            return await context.SaveChangesAsync() > 0;
        }
    }
}
