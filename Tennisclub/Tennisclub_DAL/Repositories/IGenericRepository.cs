using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Tennisclub_DAL.Repositories
{
    public interface IGenericRepository<TEntity, TReadDto, TCreateDto, TUpdateDto, TIdType>
        where TEntity : class
        where TReadDto : class
        where TCreateDto : class
        where TUpdateDto : class
        where TIdType : struct
    {
        public TReadDto GetById(TIdType id);
        public IEnumerable<TReadDto> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includeProperties); //, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
        public TReadDto Add(TCreateDto createDto);
        public void Delete(TIdType id);
        public TReadDto Update(TUpdateDto updateDto);
        public void SaveChanges();
    }
}
