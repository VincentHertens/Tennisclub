using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.OldRepositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void SaveChanges();
        IEnumerable<TEntity> GetAll();      
        TEntity GetById(object id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);       
    }
}
