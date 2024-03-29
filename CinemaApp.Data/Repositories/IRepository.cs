using System.Linq.Expressions;

namespace CinemaApp.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
        void Update(TEntity entity);
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);

        // ^ Bir SQL Sorgusunu parametre olarak göndereceksek

        // = null diyerek, bir parametre verilmesi zorunluluğunu ortadan kaldırıyorum.

        TEntity Get(Expression<Func<TEntity, bool>> predicate);

    }
}
