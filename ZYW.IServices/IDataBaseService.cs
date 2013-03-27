// ***********************************************************************
// Assembly         : ZYW.IServices
// Author           : hebidu
// Created          : 03-11-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-13-2013
// ***********************************************************************
// <copyright file="IDataBaseService.cs" company="XXX">
//     Copyright (c) XXX. All rights reserved.
// </copyright>
// <summary>基本与IRepository中定义接口相同</summary>
// ***********************************************************************
namespace ZYW.IServices
{
    #region 引用包

    using System.Collections.Generic;
    using ZYW.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System;
    #endregion

    /// <summary>
    /// 数据库访问服务接口
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IDataBaseService<TEntity>:IUnitOfWork
    {
        #region 属性

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get;  }

        #endregion

        #region 服务声明
        
        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <returns>IEnumerable{`0}.</returns>
        IEnumerable<TEntity> List();
        
        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Insert(TEntity entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Gets the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>IEnumerable{`0}.</returns>
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        /// <summary>
        /// Gets the specified page size.
        /// </summary>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="total">The total.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>IEnumerable{`0}.</returns>
        IEnumerable<TEntity> Get(
            int pageSize, 
            int pageNumber, 
            ref int total,         
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, 
            Expression<Func<TEntity, bool>> filter = null, 
            string includeProperties = "");

        /// <summary>
        /// Gets the single entity .
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>一个实体对象或者null.</returns>
        TEntity GetSingle(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        #endregion
    }
}
