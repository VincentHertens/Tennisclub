using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Tennisclub_DAL.Repositories
{
    public abstract class GenericRepository<TEntity, TReadDto, TCreateDto, TUpdateDto, TIdType> : IGenericRepository<TEntity, TReadDto, TCreateDto, TUpdateDto, TIdType>
        where TEntity : class
        where TReadDto : class
        where TCreateDto : class
        where TUpdateDto : class
        where TIdType : struct
    {
        protected readonly TennisclubContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly IMapper _mapper;

        public GenericRepository(TennisclubContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
            _mapper = mapper;
        }

        public TReadDto GetById(TIdType id)
        {
            return _mapper.Map<TReadDto>(_dbSet.Find(id));
        }

        public IEnumerable<TReadDto> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includeProperties) //, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
        {
            IQueryable<TEntity> query = _dbSet.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return _mapper.Map<IEnumerable<TReadDto>>(query.AsNoTracking().ToList());
        }

        public virtual TReadDto Add(TCreateDto createDto)
        {
            TEntity entity = _dbSet.Add(_mapper.Map<TEntity>(createDto)).Entity;
            SaveChanges();

            return _mapper.Map<TReadDto>(entity);
        }

        public virtual TReadDto Update(TUpdateDto updateDto)
        {
            var entity = _mapper.Map<TEntity>(updateDto);
            _context.Entry(entity).CurrentValues.SetValues(updateDto);
            _dbSet.Update(entity);
            SaveChanges();

            return _mapper.Map<TReadDto>(entity);
        }

        public virtual void Delete(TIdType id)
        {
            _dbSet.Remove(_mapper.Map<TEntity>(_dbSet.Find(id)));
            SaveChanges();            
        }
      
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
