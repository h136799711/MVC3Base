// ***********************************************************************
// Assembly         : ZYW.DBContexts
// Author           : hebidu
// Created          : 03-14-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-18-2013
// ***********************************************************************
// <copyright file="SystemDBContext.cs" company="XXX">
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
    /// Class SystemDBContext
    /// </summary>
    public class SystemDBContext : BaseDBContext
    {
        #region 属性

        /// <summary>
        /// Gets or sets 系统编码集合
        /// </summary>
        /// <value>The sys X codes.</value>
        public DbSet<SysXCode> SysXCodes
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或者设置操作信息集合
        /// </summary>
        /// <value>The op informations.</value>
        public DbSet<OperationInformation> OpInformations
        {
            get;
            set;
        }

        #endregion

        #region 构造函数

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemDBContext" /> class.
        /// </summary>
        public SystemDBContext()
            : base()
        {
            Database.SetInitializer<SystemDBContext>(new DropCreateDatabaseIfModelChanges<SystemDBContext>());
        }

        /// <summary>
        /// Constructs a new context instance using the given string as the name or connection string for the
        /// database to which a connection will be made.
        /// See the class remarks for how this is used to create a connection.
        /// </summary>
        /// <param name="nameOrConnectionString">Either the database name or a connection string.</param>
        public SystemDBContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer<SystemDBContext>(new DropCreateDatabaseIfModelChanges<SystemDBContext>());
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
            // SysXCode
            OnSysXCodeModelCreating(modelBuilder);

            // OperationInformation
            OnOperationInformationModelCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region 方法

        /// <summary>
        /// Called when [sys X code model creating].
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected virtual void OnSysXCodeModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysXCode>().ToTable("tbSysXCode");

            modelBuilder.Entity<SysXCode>().HasKey(s => s.XID);
            modelBuilder.Entity<SysXCode>().Property(s => s.XID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<SysXCode>().Property(s => s.XCode).IsRequired();
            modelBuilder.Entity<SysXCode>().Property(s => s.XCode).HasMaxLength(126);

            modelBuilder.Entity<SysXCode>().Property(s => s.XName).IsRequired();
            modelBuilder.Entity<SysXCode>().Property(s => s.XName).HasMaxLength(126);

            modelBuilder.Entity<SysXCode>().Property(s => s.XSource).IsRequired();
            modelBuilder.Entity<SysXCode>().Property(s => s.XSource).HasMaxLength(1024);


            modelBuilder.Entity<SysXCode>().Property(s => s.XDepth).IsRequired();
            modelBuilder.Entity<SysXCode>().Property(s => s.XDepth).HasMaxLength(512);
            modelBuilder.Entity<SysXCode>().Property(s => s.XRemark).HasMaxLength(512);
            modelBuilder.Entity<SysXCode>().Property(s => s.XParentID).IsRequired();
            modelBuilder.Entity<SysXCode>().Property(s => s.XFlag).IsRequired();

            modelBuilder.Entity<SysXCode>().HasMany<OperationInformation>(op => op.opInformation);

        }

        /// <summary>
        /// Called when [operation information model creating].
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected virtual void OnOperationInformationModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OperationInformation>().ToTable("tbOperationInfor");
            modelBuilder.Entity<OperationInformation>().HasKey(op => op.OpID);
            modelBuilder.Entity<OperationInformation>().Property(op => op.OpID).IsRequired()
                            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<OperationInformation>().Property(op => op.OpStartTime).IsRequired();
            modelBuilder.Entity<OperationInformation>().Property(op => op.OpEndTime).IsRequired();
            modelBuilder.Entity<OperationInformation>().Property(op => op.OpObjectID).IsRequired();
            modelBuilder.Entity<OperationInformation>().Property(op => op.OpResult).IsRequired();
            modelBuilder.Entity<OperationInformation>().Property(op => op.OpType).IsRequired();
        }

        #endregion        
    }
}
