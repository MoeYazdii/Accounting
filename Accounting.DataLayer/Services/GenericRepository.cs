﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Services
{
    public class GenericRepository<TEntity>
    where TEntity : class
    {
        private Accounting_DBEntities _db;
        private DbSet<TEntity> _dbSet;
        public GenericRepository(Accounting_DBEntities db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }

        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where = null) //IEnumerable == all type of lists
        {
            IQueryable<TEntity> query = _dbSet; //Lazy Load
            if (where != null)
            {
                query = query.Where(where);
            }

            return query.ToList();
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(TEntity entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public virtual void Delete(object id)
        {
            var entity = GetById(id);
            Delete(entity);
        }
    }
}
