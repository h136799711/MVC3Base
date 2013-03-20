// ***********************************************************************
// Assembly         : ZYW.Infrastructure
// Author           : hebidu
// Created          : 03-11-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-13-2013
// ***********************************************************************
// <copyright file="BaseDBContext.cs" company="XXX">
//     Copyright (c) XXX. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ZYW.Infrastructure
{
    #region 引用包

    using System.Data.Entity;

    #endregion

    /// <summary>
    /// BaseContext 基础的数据库操作上下文
    /// </summary>
    public class BaseDBContext : DbContext, IUnitOfWork
    {
        #region 方法

        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseDBContext()
        {
           
        }

        /// <summary>
        /// Constructs a new context instance using the given string as the name or connection string for the
        /// database to which a connection will be made.
        /// See the class remarks for how this is used to create a connection.
        /// </summary>
        /// <param name="nameOrConnectionString">Either the database name or a connection string.</param>
        public BaseDBContext(string nameOrConnectionString)
            :base(nameOrConnectionString)
        {
            Database.SetInitializer<BaseDBContext>(new DropCreateDatabaseIfModelChanges<BaseDBContext>());
        }

        /// <summary>
        /// 保存更改
        /// </summary>
        public void Save()
        {
            this.SaveChanges();
        }

        #endregion
    }
}
