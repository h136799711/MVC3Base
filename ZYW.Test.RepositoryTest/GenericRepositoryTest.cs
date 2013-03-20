// ***********************************************************************
// Assembly         : ZYW.Test.RepositoryTest
// Author           : hebidu
// Created          : 03-13-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-15-2013
// ***********************************************************************
// <copyright file="GenericRepositoryTest.cs" company="XXX">
//     Copyright (c) XXX. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ZYW.Test.RepositoryTest
{
    #region 引用包

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ZYW.DBContexts;
    using ZYW.Infrastructure;
    using ZYW.Model;
    using ZYW.Repository;

    #endregion

    /// <summary>
    /// 这是 GenericRepositoryTest 的测试类，旨在
    /// 包含所有 GenericRepositoryTest 单元测试
    /// </summary>
    [TestClass()]
    public class GenericRepositoryTest
    {
        #region 字段 属性

        /// <summary>
        /// The test context instance
        /// </summary>
        private TestContext testContextInstance;

        /// <summary>
        /// 获取或设置测试上下文，上下文提供
        /// 有关当前测试运行及其功能的信息。
        /// </summary>
        /// <value>The test context.</value>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        
        #endregion

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        #region 测试方法

        /// <summary>
        /// GenericRepository`1 构造函数 的测试
        /// </summary>
        /// <typeparam name="TEntity">The type of the T entity.</typeparam>
        public void GenericRepositoryConstructorTestHelper<TEntity>()
            where TEntity : class
        {
            IUnitOfWork unitOfWork = new BaseDBContext(); // TODO: 初始化为适当的值

            GenericRepository<TEntity> target = new GenericRepository<TEntity>(unitOfWork);
            Assert.IsNotNull(target.Context);
            target = new GenericRepository<TEntity>(null);

        }

        /// <summary>
        /// Generics the repository constructor test.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void GenericRepositoryConstructorTest()
        {
            GenericRepositoryConstructorTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        /// Generics the repository constructor test2.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException))]
        public void GenericRepositoryConstructorTest2()
        {
            GenericRepository<GenericParameterHelper> helper = new GenericRepository<GenericParameterHelper>(new BaseDBContext());
            GenericRepository<GenericParameterHelper> target = new GenericRepository<GenericParameterHelper>(helper);
        }

        /// <summary>
        /// Delete 的测试
        /// </summary>
        [TestMethod()]
        public void DeleteTest1()
        {
            IUnitOfWork unitOfWork = new TestDBContext();
            GenericRepository<TestModel> target = new GenericRepository<TestModel>(unitOfWork); // TODO: 初始化为适当的值

            Expression<Func<TestModel, bool>> filter = t => t.testName == "forDelete";
            List<TestModel> list = target.Get(filter).ToList();
            TestModel entityToDelete = list.Count() == 0 ? null : list.First(); // TODO: 初始化为适当的值
            if (entityToDelete == null)
            {
                entityToDelete = new TestModel();
                entityToDelete.testName = "forDelete";
                target.Insert(entityToDelete);
                target.Save();
                entityToDelete = target.Get(filter).ToList().First();

            }
            Assert.IsNotNull(entityToDelete, String.Format("数据库中不存在主键为{0}的数据，请插入数据", 4));
            target.Delete(entityToDelete);
            target.Save();
            Assert.AreEqual(target.Get(t => t.testID == entityToDelete.testID).ToList().Count(), 0, "数据库中不应该存在主键为4的数据");

        }

        /// <summary>
        /// Get 的测试
        /// </summary>
        [TestMethod()]
        public void GetTest()
        {
            IUnitOfWork unitOfWork = new TestDBContext(); // TODO: 初始化为适当的值
            GenericRepository<TestModel> target = new GenericRepository<TestModel>(unitOfWork); // TODO: 初始化为适当的值
            Expression<Func<TestModel, bool>> filter = t => t.testName.Contains("hbd"); // TODO: 初始化为适当的值
            Func<IQueryable<TestModel>, IOrderedQueryable<TestModel>> orderBy = delegate(IQueryable<TestModel> tm) { return tm.OrderBy(t => t.testID).ThenByDescending(t => t.testDesc); }; // TODO: 初始化为适当的值
            string includedProperties = "";
            IEnumerable<TestModel> expected = null; // TODO: 初始化为适当的值
            IEnumerable<TestModel> actual;
            //向数据库插入测试数据
            TestModel tmp = new TestModel();
            tmp.testName = "hbd1";
            tmp.testDesc = "a";
            target.Insert(tmp);
            tmp = new TestModel();
            tmp.testName = "hbd2";
            tmp.testDesc = "b";
            target.Insert(tmp);
            tmp = new TestModel();
            tmp.testName = "hbd3";
            tmp.testDesc = "c";
            target.Insert(tmp);
            tmp = new TestModel();
            tmp.testName = "hbd";
            tmp.testDesc = "d";
            target.Insert(tmp);
            target.Save();

            // 调用测试方法Get
            actual = target.Get(filter, orderBy, includedProperties);
            expected = target.Get(filter, orderBy);
            Assert.AreEqual(actual.Count(), expected.Count(), "个数期望为相同，结果却不相同");

            expected = from t in actual where t.testName.Contains("hbd") select t;
            Assert.IsTrue(actual.Count() > 0, "返回数据不能为0个");
            Assert.IsNotNull(expected, "expected不能为NULL");
            Assert.AreEqual(expected.Count(), actual.Count());
            List<TestModel> list = actual.ToList();
            for (int i = 0; i < list.Count() - 1; i++)
            {
                if (list[i].testID == list[i + 1].testID)
                {
                    Assert.IsTrue(list[i].testDesc.CompareTo(list[i + 1].testDesc) == -1, "返回数据并没有序排序");
                }
                Assert.IsFalse(list[i].testID > list[i + 1].testID, "返回数据并没有升序排序");
            }

            expected = target.Get(filter);
            Assert.AreEqual(actual.Count(), expected.Count(), "个数期望为相同，结果却不相同");

            actual = target.List();
            expected = target.Get();
            Assert.AreEqual(actual.Count(), expected.Count(), "个数期望为相同，结果却不相同");
        }

        /// <summary>
        /// Update 的测试
        /// </summary>
        [TestMethod()]
        public void UpdateTest()
        {
            IUnitOfWork unitOfWork = new TestDBContext(); // TODO: 初始化为适当的值
            GenericRepository<TestModel> target = new GenericRepository<TestModel>(unitOfWork); // TODO: 初始化为适当的值
            TestModel entityToUpdate = null;
            entityToUpdate = new TestModel();
            entityToUpdate.testDesc = "test";
            entityToUpdate.testID = 3;
            entityToUpdate.testName = "test";
            target.Delete(entityToUpdate);
            target.Insert(entityToUpdate);
            target.Save();
            long id = entityToUpdate.testID;
            List<TestModel> list = target.Get(t => t.testID == id).ToList<TestModel>();
            entityToUpdate = list.Count() == 0 ? null : list.First(); ; // TODO: 初始化为适当的值
            Assert.IsNotNull(entityToUpdate, String.Format("数据库中不存在ID值为{0}的数据,请检查删除去插入方法是否有问题", id));
            entityToUpdate.testName = "HBD3";
            target.Update(entityToUpdate);
            target.Save();
            Assert.AreEqual(entityToUpdate.testName, target.GetSingle(t => t.testID == id).testName);
        }

        /// <summary>
        /// Context 的测试
        /// </summary>
        [TestMethod()]
        public void ContextTest()
        {
            IUnitOfWork unitOfWork = new TestDBContext(); // TODO: 初始化为适当的值
            GenericRepository<TestModel> target = new GenericRepository<TestModel>(unitOfWork); // TODO: 初始化为适当的值
            BaseDBContext expected = unitOfWork as BaseDBContext; // TODO: 初始化为适当的值
            BaseDBContext actual;
            Assert.AreEqual(expected, target.Context);
            target.Context = expected;
            actual = target.Context;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// List 的测试
        /// </summary>
        [TestMethod()]
        public void ListTest()
        {
            IUnitOfWork unitOfWork = new TestDBContext(); // TODO: 初始化为适当的值
            GenericRepository<TestModel> target = new GenericRepository<TestModel>(unitOfWork); // TODO: 初始化为适当的值
            IEnumerable<TestModel> list = target.List();
            int beforeInsertCount = list.Count();
            TestModel entityToInsert = new TestModel();
            entityToInsert.testName = "534";
            entityToInsert.testDesc = "ddt534";
            target.Insert(entityToInsert);
            target.Save();
            int afterInsertCount = target.List().Count();
            Assert.AreEqual(beforeInsertCount + 1, afterInsertCount);
        }

        #endregion
    }
}
