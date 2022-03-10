using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Prestadores.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        int Count();
        int Count(Expression<Func<TEntity, bool>> filterExpression);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filterExpression);
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> filterExpression);
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(Expression<Func<TEntity, bool>> filterExpression);
    }
}
