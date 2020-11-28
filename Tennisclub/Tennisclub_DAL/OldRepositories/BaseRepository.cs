using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Tennisclub_DAL.OldRepositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly TennisclubContext _context;

        public BaseRepository(TennisclubContext context)
        {
            _context = context;
        }        

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById(object id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
      
        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }       

        public void SaveChanges()
        {
            _context.SaveChanges();
        }            
    }
}
