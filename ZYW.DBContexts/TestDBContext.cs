// ***********************************************************************
// Assembly         : ZYW.DBContexts
// Author           : hebidu
// Created          : 03-11-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-18-2013
// ***********************************************************************
// <copyright file="TestDBContext.cs" company="XXX">
//     Copyright (c) XXX. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ZYW.DBContexts
{
    #region 引用包

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using ZYW.Infrastructure;
    using ZYW.Model;

    #endregion

    /// <summary>
    /// TestModel类的数据库访问类
    /// </summary>
    public class TestDBContext:BaseDBContext
    {
        #region 属性

        /// <summary>
        /// 获取TestModel的集合
        /// </summary>
        /// <value>The tests.</value>
        public DbSet<TestModel> Tests
        {
            get
            {
                return this.Set<TestModel>();
            }
        }        

        #endregion

        #region 构造函数


        /// <summary>
        /// Initializes a new instance of the <see cref="TestDBContext" /> class.
        /// </summary>
        public TestDBContext()
            : base()
        {
            //Database.SetInitializer<TestDBContext>(new MigrateDatabaseToLatestVersion<TestDBContext, Configuration>());
            Database.SetInitializer<TestDBContext>(new DropCreateDatabaseIfModelChanges<TestDBContext>());
        }

        #endregion

        #region 重载方法

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.</remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // TestModel
            OnTestModelCreating(modelBuilder);
            
            //sysxcode
            //OnSysXCodeModelCreating(modelBuilder);

            //operationinformation
            //OnOperationInformationModelCreating(modelBuilder);
            //去除复数形式的表名
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region 方法

        /// <summary>
        /// Called when [TestModel Creating].
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected virtual void OnTestModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestModel>().ToTable("tbTest");
            modelBuilder.Entity<TestModel>().HasKey(T => T.testID);
            modelBuilder.Entity<TestModel>().Property(T => T.testID)
                         .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<TestModel>().Property(T => T.testName).IsRequired();
          //  modelBuilder.Entity<TestModel>().Property(T => T.testName).HasMaxLength(32);
            modelBuilder.Entity<TestModel>().Property(T => T.testName).IsRequired();
         //   modelBuilder.Entity<TestModel>().Property(T => T.testDesc).HasMaxLength(256);

        }

        #endregion
    }
}
