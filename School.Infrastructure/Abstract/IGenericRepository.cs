using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace School.Infrastructure.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        Task DeleteRangeAsync(ICollection<T> entities);
        Task<T> GetByIdAsync(int id);
        Task SaveChangesAsync();
        IDbContextTransaction BeginTransaction();
        IQueryable<T> SearchAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> OrderBy(IQueryable<T> query, Expression<Func<T, object>> orderBy, bool? isDescending = false);
        void Commit();
        void RollBack();
        Task<IReadOnlyList<T>> GetAll();
        IQueryable<T> GetTableNoTracking();
        IQueryable<T> GetTableAsTracking();
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);
        Task DeleteAsync(T entity);
    }
}
