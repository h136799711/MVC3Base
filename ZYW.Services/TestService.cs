// ***********************************************************************
// Assembly         : ZYW.Services
// Author           : hebidu
// Created          : 03-11-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-11-2013
// ***********************************************************************
// <copyright file="TestService.cs" company="XXX">
//     Copyright (c) XXX. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ZYW.Services
{
    #region 引用包

    using System;
    using System.Collections.Generic;
    using ZYW.IServices;
    using ZYW.IRepositorys;
using System.Linq;
using System.Linq.Expressions;
using ZYW.Model;

    #endregion

    /// <summary>
    /// Test的数据库访问服务类
    /// </summary>
    public class TestService:ITestService
    {
        #region 字段

        /// <summary>
        /// The _test repository
        /// </summary>
        private ITestRepository _testRepository;

        #endregion

        #region 构造函数

        /// <summary>
        /// Initializes a new instance of the <see cref="TestService"/> class.
        /// </summary>
        /// <param name="testRepository">The test repository.</param>
        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }
        
        #endregion

        #region ITestService 成员

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <exception cref="System.NotImplementedException"></exception>
        public string Name
        {
            get
            {
                return "TestService";
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets the entity by ID.
        /// </summary>
        /// <param name="ID">The ID.</param>
        /// <returns>TestModel.</returns>
        public Model.TestModel GetEntityByID(long ID)
        {
            return this._testRepository.GetEntityByID(ID);
        }

        #endregion

        #region IDataBaseService<TestModel> 成员

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns>Test的数据集</returns>
        public IEnumerable<TestModel> List()
        {
            return this._testRepository.List();
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Insert(TestModel entity)
        {
            this._testRepository.Insert(entity);
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(TestModel entity)
        {
            this._testRepository.Delete(entity);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(TestModel entity)
        {
            this._testRepository.Update(entity);
        }

        /// <summary>
        /// 保存更改到数据库
        /// </summary>
        public void Save()
        {
            this._testRepository.Save();
        }

        /// <summary>
        /// Gets the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>IEnumerable{TestModel}.</returns>
        public IEnumerable<TestModel> Get(Expression<Func<TestModel, bool>> filter = null, Func<IQueryable<TestModel>, IOrderedQueryable<TestModel>> orderBy = null, string includeProperties = "")
        {
            return this._testRepository.Get(filter, orderBy, includeProperties);
        }

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>TestModel.</returns>
        public TestModel GetSingle(Expression<Func<TestModel, bool>> filter = null, Func<IQueryable<TestModel>, IOrderedQueryable<TestModel>> orderBy = null, string includeProperties = "")
        {
            return this._testRepository.GetSingle(filter, orderBy, includeProperties);
        }

        #endregion
        

        #region IDataBaseService<TestModel> 成员


        public IEnumerable<TestModel> Get(int pageSize, int pageNumber, ref int total, Func<IQueryable<TestModel>, IOrderedQueryable<TestModel>> orderBy, Expression<Func<TestModel, bool>> filter = null, string includeProperties = "")
        {
            return null;
        }

        #endregion

        #region IDataBaseService<TestModel> 成员


        public IEnumerable<TestModel> PagingGet(int pageSize, int pageNumber, ref int total, Func<IQueryable<TestModel>, IOrderedQueryable<TestModel>> orderBy, Expression<Func<TestModel, bool>> filter = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
