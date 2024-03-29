using CinemaApp.Data.Context;
using CinemaApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CinemaApp.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : MovieEntity
    {
        private readonly CinemaAppContext _db;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(CinemaAppContext db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();

            // _dbSet yerine _db.Users / _db.Products / _db.Categories gelecek.
        }
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            _dbSet.Update(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            Delete(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate is null ? _dbSet : _dbSet.Where(predicate);
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _db.SaveChanges();
        }
    }
}