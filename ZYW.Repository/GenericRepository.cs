// ***********************************************************************
// Assembly         : ZYW.Repository
// Author           : hebidu
// Created          : 03-11-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-18-2013
// ***********************************************************************
// <copyright file="GenericRepository.cs" company="XXX">
//     Copyright (c) XXX. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ZYW.Repository
{
    #region 引用包

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using ZYW.Infrastructure;

    #endregion

    /// <summary>
    /// 泛型基本数据库访问类
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region 字段

        /// <summary>
        /// The _context
        /// </summary>
        private BaseDBContext _context;
        /// <summary>
        /// The db set
        /// </summary>
        protected DbSet<TEntity> dbSet;

        #endregion

        #region 属性

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>The context.</value>
        public virtual BaseDBContext Context
        {
            get { return _context; }
            set { _context = value; }
        }
        #endregion

        #region 方法

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{TEntity}" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <exception cref="System.ArgumentNullException">不能为null.</exception>
        /// <exception cref="System.ArgumentException">IUnitOfWork类型接口必须为可以转换为BaseDBContext类型的对象</exception>
        public GenericRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("不能为null.");
            }

            _context = unitOfWork as BaseDBContext;
            if (_context == null)
            {
                throw new ArgumentException("IUnitOfWork类型接口必须为可以转换为BaseDBContext类型的对象");
            }

            this.dbSet = _context.Set<TEntity>();
        }

        #endregion

        #region IUnitOfWork 成员

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public virtual void Save()
        {
            this._context.Save();
        }

        #endregion

        #region IRepository<TEntity> 成员

        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <returns>IEnumerable{`0}.</returns>
        public virtual IEnumerable<TEntity> List()
        {
            //return _context.Set<TEntity>().ToList();
            return this.dbSet.ToList();
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entityToInsert">The entity to insert.</param>
        public virtual void Insert(TEntity entityToInsert)
        {
            //_context.Set<TEntity>().Add(entityToInsert);
            this.dbSet.Add(entityToInsert);
        }

        /// <summary>
        /// Deletes the specified entity to delete.
        /// </summary>
        /// <param name="entityToDelete">The entity to delete.</param>
        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        /// <summary>
        /// Updates the specified entity to update.
        /// </summary>
        /// <param name="entityToUpdate">The entity to update.</param>
        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }


        /// <summary>
        /// Gets the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>IEnumerable{`0}.</returns>
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        /// <summary>
        /// Singles the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>`0.</returns>
        public virtual TEntity GetSingle(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            TEntity entity;
            try
            {
                if (orderBy != null)
                {
                    entity = orderBy(query).Single<TEntity>();
                }
                else
                {
                    entity = query.Single<TEntity>();
                }
            }
            catch (Exception)
            {
                entity = null;
            }

            return entity;

        }

        /// <summary>
        /// Gets the specified page size.
        /// </summary>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="total">The total.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>IEnumerable{`0}.</returns>
        public virtual IEnumerable<TEntity> Get(int pageSize, int pageNumber, ref int total, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
            pageSize = pageSize < 0 ? 1 : pageSize;
            pageNumber = pageNumber < 1 ? 1 : pageNumber; 
            int skipCnt = (pageNumber - 1) * pageSize;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            total = (int)query.LongCount();
            return orderBy(query).Skip(skipCnt).Take(pageSize).ToList();
            
        }

        #endregion

    }
}
