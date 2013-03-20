// ***********************************************************************
// Assembly         : ZYW.Test.RepositoryTest
// Author           : hebidu
// Created          : 03-11-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-15-2013
// ***********************************************************************
// <copyright file="TestRepositoryTest.cs" company="XXX">
//     Copyright (c) XXX. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ZYW.Test.RepositoryTest
{
    #region 引用包

    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ZYW.DBContexts;
    using ZYW.Infrastructure;
    using ZYW.Model;
    using ZYW.Repository;

    #endregion

    /// <summary>
    /// 这是 TestRepositoryTest 的测试类，旨在
    /// 包含所有 TestRepositoryTest 单元测试
    /// </summary>
    /// <remarks>测试最好在数据库联通下测试，才算完整</remarks>
    [TestClass()]
    public class TestRepositoryTest
    {
        #region 字段与属性

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

        #region 测试主体

        /// <summary>
        /// TestRepository 构造函数 的测试
        /// </summary>
        [TestMethod()]
        public void TestRepositoryConstructorTest()
        {
            //1.准备工作
            IUnitOfWork unitOfWork = new TestDBContext(); // TODO: 初始化为适当的值
            TestRepository target = new TestRepository(unitOfWork);
            
            //
            bool isTrue = target.Context is TestDBContext;
            Assert.IsTrue(isTrue, "给定对象不能转换为指定的TestDBContext类型");
            isTrue = target.Context is BaseDBContext;
            Assert.IsTrue(isTrue, "给定对象不能转换为指定的BaseDBContext类型");
            TestModel test = new TestModel();
            target.Insert(test);
            TestDBContext testDBC = target.Context as TestDBContext;
            Assert.AreEqual(testDBC, target.Context);
            Assert.IsNotNull(testDBC.Tests.Find(test.testID));
            Assert.IsNull(testDBC.Tests.Find(0));
            BaseDBContext baseDBC = target.Context as BaseDBContext;
            Assert.IsNotNull(baseDBC.Set<TestModel>().Find(test.testID));
            Assert.IsNull(baseDBC.Set<TestModel>().Find(0));
            Assert.AreEqual(testDBC, target.Context);
        }

        /// <summary>
        /// List 的测试
        /// </summary>
        [TestMethod()]
        public void ListTest()
        {
            IUnitOfWork unitOfWork = new TestDBContext(); // TODO: 初始化为适当的值
            TestRepository target = new TestRepository(unitOfWork); // TODO: 初始化为适当的值
            TestModel expected = null; // TODO: 初始化为适当的值
            IEnumerable<TestModel> actual;
            target.DeleteAll();
            target.Save();
            actual = target.List();
            Assert.AreEqual((actual as List<TestModel>).Count,0);
            expected = new TestModel();
            expected.testName = "123Name";
            expected.testDesc = "123Desc";
            target.Insert(expected);
            expected = new TestModel();
            expected.testName = "123Name";
            expected.testDesc = "123Desc";
            target.Insert(expected);
            target.Save();
            actual = target.List();
            Assert.AreEqual((actual as List<TestModel>).Count, 2);

        }

        /// <summary>
        /// GetEntityByID 的测试
        /// </summary>
        [TestMethod()]
        public void GetEntityByIDTest()
        {
            IUnitOfWork unitOfWork = new TestDBContext(); // TODO: 初始化为适当的值
            TestRepository target = new TestRepository(unitOfWork); // TODO: 初始化为适当的值

            TestModel actual = new TestModel();
            actual.testName = "name";
            actual.testDesc = "1223";
            target.Insert(actual);
            target.Save();
            TestModel expected = target.GetEntityByID(actual.testID);
            Assert.AreEqual(expected.testID, actual.testID,"新插入数据ID用来获取，其结果ID不一致");
        }

        #endregion
    }
}
