using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Tennisclub_Data_Layer.Models;

namespace Tennisclub_Data_Layer.Repositories
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
