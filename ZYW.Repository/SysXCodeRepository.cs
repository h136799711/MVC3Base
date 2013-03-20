// ***********************************************************************
// Assembly         : ZYW.Repository
// Author           : hebidu
// Created          : 03-15-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-18-2013
// ***********************************************************************
// <copyright file="SysXCodeRepository.cs" company="XXX">
//     Copyright (c) XXX. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ZYW.Repository
{
    #region 引用包

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ZYW.DBContexts;
    using ZYW.Infrastructure;
    using ZYW.IRepositorys;
    using ZYW.Model;
    using System.Linq.Expressions;
    using System.Collections;

    #endregion

    /// <summary>
    /// Class SysXCodeRepository
    /// </summary>
    public class SysXCodeRepository:GenericRepository<SysXCode>,ISysXCodeRepository
    {
        #region 属性

        public static readonly int SplitBits = 5;

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>The context.</value>
        /// <exception cref="System.InvalidCastException">必须为SystemDBContext类型</exception>
        public override BaseDBContext Context
        {
            get
            {
                return base.Context;
            }
            set
            {
                try
                {
                    base.Context = value as SystemDBContext;
                }
                catch (InvalidCastException)
                {
                    throw new InvalidCastException("必须为SystemDBContext类型");
                }
            }
        }

        #endregion

        #region 构造函数


        /// <summary>
        /// Initializes a new instance of the <see cref="SysXCodeRepository" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public SysXCodeRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region IRepository<SysXCode> 成员

        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <returns>IEnumerable{SysXCode}.</returns>
        public override IEnumerable<SysXCode> List()
        {
            return (this.Context as SystemDBContext).SysXCodes.ToList();
        }

        #endregion

        #region ISysXCodeRepository 成员

        /// <summary>
        /// 返回一级目录
        /// </summary>
        /// <returns>IList.</returns>
        public System.Collections.IEnumerable PrimaryNav()
        {
            Expression<Func<SysXCode, bool>> filter = s=>s.XParentID == 0;
            Func<IQueryable<SysXCode>, IOrderedQueryable<SysXCode>> orderBy = t=>t.OrderBy(s=>s.XOrderNumber);
            IEnumerable list = from nav in this.Get(filter, orderBy).ToList() select new { nav.XName, nav.XCode };

            return list;
        }

        #endregion

        #region ISysXCodeRepository 成员


        /// <summary>
        /// Seconds the nav.
        /// </summary>
        /// <param name="XCode">The X code.</param>
        /// <returns>IEnumerable.</returns>
        public IEnumerable SecondNav(string XCode)
        {            
            return Nav(XCode,2);
        }

        /// <summary>
        /// Seconds the nav.
        /// </summary>
        /// <param name="XCode">The X code.</param>
        /// <returns>IEnumerable.</returns>
        public IEnumerable ThirdNav(string XCode)
        {
            return Nav(XCode, 3);
        }

        /// <summary>
        /// Navs the specified X code.
        /// </summary>
        /// <param name="XCode">The X code.</param>
        /// <param name="depth">The depth.</param>
        /// <returns>IEnumerable.</returns>
        private IEnumerable Nav(string XCode, int depth)
        {

            Expression<Func<SysXCode, bool>> filter = s => s.XCode.Length == depth * SplitBits && s.XCode.Substring(0, 5*(depth-1)) == XCode;
            Func<IQueryable<SysXCode>, IOrderedQueryable<SysXCode>> orderBy = t => t.OrderBy(s => s.XOrderNumber);
            IEnumerable list = from nav in this.Get(filter, orderBy).ToList() select new { nav.XName, nav.XSource,nav.XCode };

            return list;
        }
        
        #endregion
    }
}
