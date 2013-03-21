// ***********************************************************************
// Assembly         : ZYW.Services
// Author           : hebidu
// Created          : 03-20-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-18-2013
// ***********************************************************************
// <copyright file="SysXCodeService.cs" company="XXX">
//     Copyright (c) XXX. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ZYW.Services
{
    #region 引用包

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ZYW.IServices;
    using ZYW.IRepositorys;

    #endregion

    /// <summary>
    /// Class SysXCodeService
    /// </summary>
    public class SysXCodeService:ISysXCodeService
    {
        #region 字段


        /// <summary>
        /// The _sys X code repository
        /// </summary>
        private ISysXCodeRepository _sysXCodeRepository;

        #endregion

        #region 构造函数

        /// <summary>
        /// Initializes a new instance of the <see cref="SysXCodeService" /> class.
        /// </summary>
        /// <param name="sysXCodeRepository">The sys X code repository.</param>
        public SysXCodeService(ISysXCodeRepository sysXCodeRepository)
        {
            this._sysXCodeRepository = sysXCodeRepository;
        }

        #endregion

        #region IDataBaseService<SysXCode> 成员

        #region 属性

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return "系统编码数据操作服务";
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <returns>IEnumerable{Model.SysXCode}.</returns>
        public IEnumerable<Model.SysXCode> List()
        {
            return this._sysXCodeRepository.List();
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Insert(Model.SysXCode entity)
        {
            this._sysXCodeRepository.Insert(entity);
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(Model.SysXCode entity)
        {
            this._sysXCodeRepository.Delete(entity);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(Model.SysXCode entity)
        {
            this._sysXCodeRepository.Update(entity);
        }

        /// <summary>
        /// Gets the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>IEnumerable{Model.SysXCode}.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<Model.SysXCode> Get(System.Linq.Expressions.Expression<Func<Model.SysXCode, bool>> filter = null, Func<IQueryable<Model.SysXCode>, IOrderedQueryable<Model.SysXCode>> orderBy = null, string includeProperties = "")
        {
            return this._sysXCodeRepository.Get(filter, orderBy, includeProperties);
        }

        #endregion

        #endregion

        #region IUnitOfWork 成员

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            this._sysXCodeRepository.Save();
        }

        #endregion

        #region ISysXCodeService 成员

        /// <summary>
        /// Gets the by ID.
        /// </summary>
        /// <param name="ID">The ID.</param>
        /// <returns>Model.SysXCode.</returns>
        public Model.SysXCode GetByID(long ID)
        {
            return this._sysXCodeRepository.GetSingle(t => t.XID == ID);
        }

        /// <summary>
        /// 返回一级导航
        /// </summary>
        /// <returns>IList.</returns>
        public System.Collections.IEnumerable AdminNav()
        {
            return this._sysXCodeRepository.AdminNav();
        }

        /// <summary>
        /// Seconds the nav.
        /// </summary>
        /// <returns>IEnumerable.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public System.Collections.IEnumerable SubNavOf(long ID)
        {
            return this._sysXCodeRepository.SubNavOf(ID);
        }

        #endregion

        #region IDataBaseService<SysXCode> 成员

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Model.SysXCode.</returns>
        public Model.SysXCode GetSingle(System.Linq.Expressions.Expression<Func<Model.SysXCode, bool>> filter = null, Func<IQueryable<Model.SysXCode>, IOrderedQueryable<Model.SysXCode>> orderBy = null, string includeProperties = "")
        {
            return this._sysXCodeRepository.GetSingle(filter, orderBy, includeProperties);
        }

        #endregion

    }
}
