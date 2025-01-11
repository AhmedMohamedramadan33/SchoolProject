using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using School.Infrastructure.Abstract;
using School.Infrastructure.Data;
using System.Linq.Expressions;

namespace School.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task AddRangeAsync(ICollection<T> entities)
        {
            await _dbContext.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }

        public async void Commit()
        {
            await _dbContext.Database.CommitTransactionAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(ICollection<T> entities)
        {
            _dbContext.RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<T> GetTableAsTracking()
        {
            return _dbSet.AsTracking().AsQueryable<T>();
        }

        public IQueryable<T> GetTableNoTracking()
        {
            return _dbSet.AsNoTracking().AsQueryable<T>();
        }

        public IQueryable<T> OrderBy(IQueryable<T> query, Expression<Func<T, object>> orderBy, bool? isDescending = false)
        {
            return isDescending == true ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);
        }

        public void RollBack()
        {
            _dbContext.Database.RollbackTransaction();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<T> SearchAsync(Expression<Func<T, bool>> predicate)
        {
            return GetTableNoTracking().Where(predicate);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(ICollection<T> entities)
        {
            _dbContext.UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }


    }
}
