// ***********************************************************************
// Assembly         : ZYW.Repository
// Author           : hebidu
// Created          : 03-11-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-12-2013
// ***********************************************************************
// <copyright file="TestRepository.cs" company="XXX">
//     Copyright (c) XXX. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ZYW.Repository
{
    #region 引用包

    using System.Collections.Generic;
    using System.Linq;
    using ZYW.DBContexts;
    using ZYW.Infrastructure;
    using ZYW.IRepositorys;
    using ZYW.Model;

    #endregion

    /// <summary>
    /// Test的数据库访问实现类
    /// </summary>
    public class TestRepository : GenericRepository<TestModel>, ITestRepository
    {
        #region 属性
        
        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>The context.</value>
        public override BaseDBContext Context
        {
            get
            {
                return base.Context;
            }
            set
            {
                base.Context = value as TestDBContext;
            }
        }

        #endregion

        #region 构造函数

        /// <summary>
        /// Initializes a new instance of the <see cref="TestRepository" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public TestRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region 方法
        
        /// <summary>
        /// 获取Test的数据集
        /// </summary>
        /// <returns>Test的数据集</returns>
        public new IEnumerable<TestModel> List()
        {
            return (this.Context as TestDBContext).Tests.ToList();
        }
        
        #endregion

        #region ITestRepository 成员

        /// <summary>
        /// Gets the entity by ID.
        /// </summary>
        /// <param name="ID">The ID.</param>
        /// <returns>Test实体</returns>
        public TestModel GetEntityByID(long ID)
        {
            return (this.Context as TestDBContext).Tests.Find(ID);
        }

        /// <summary>
        /// 从数据库删除所有数据,假设数据库中已有数据
        /// </summary>
        /// <returns><c>true</c> 如果正确删除所有数据, <c>false</c> otherwise</returns>
        public bool DeleteAll()
        {
            string sql = "delete from tbTest";
            return this.Context.Database.ExecuteSqlCommand(sql) == 0;
        }

        #endregion
    }
}
