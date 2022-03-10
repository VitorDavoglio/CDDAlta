using Microsoft.EntityFrameworkCore;
using Prestadores.Domain.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infra_CodigoPenal.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DBContext _dbContext;

        public Repository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Count()
        {
            return _dbContext.Set<TEntity>().AsNoTracking().Count();
        }

        public int Count(Expression<Func<TEntity, bool>> filterExpression)
        {
            return _dbContext.Set<TEntity>().AsNoTracking().Count(filterExpression);
        }

        public async Task Create(TEntity entity)
        {
            try
            {
                await _dbContext.Set<TEntity>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Delete(Expression<Func<TEntity, bool>> filterExpression)
        {
            var entity = await FirstOrDefault(filterExpression);
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filterExpression)
        {
            var query = _dbContext.Set<TEntity>().AsNoTracking().Where(filterExpression);
            return query;
        }

        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> filterExpression)
        {
            return await _dbContext.Set<TEntity>()
               .AsNoTracking()
               .FirstOrDefaultAsync(filterExpression);
        }

        public async Task Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

    }
}
