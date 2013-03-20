// ***********************************************************************
// Assembly         : ZYW.DBContexts
// Author           : hebidu
// Created          : 03-11-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-11-2013
// ***********************************************************************
// <copyright file="UnitOfWork.cs" company="XXX">
//     Copyright (c) XXX. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ZYW.DBContexts
{
    #region 引用包

    using System;
    using ZYW.Infrastructure;

    #endregion

    /// <summary>
    /// UnitOfWork 作为统一调用Repository的类
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        #region 字段

        /// <summary>
        /// The _context
        /// </summary>
        private BaseDBContext _context = null;
        /// <summary>
        /// The _disposed
        /// </summary>
        private bool _disposed = false;
        #endregion

        #region 方法


        /// <summary>
        /// 初始化一个 <see cref="UnitOfWork" /> 类的新实例.
        /// </summary>
        public UnitOfWork()
        {
            _context = new BaseDBContext();
        }

        /// <summary>
        /// 初始化一个 <see cref="UnitOfWork" /> 类的新实例.
        /// </summary>
        /// <param name="context">The context.</param>
        public UnitOfWork(BaseDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 保存更改到数据库中
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }


        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed && disposing)
            {
                _context.Dispose();
            }
            this._disposed = true;
        }

        /// <summary>
        /// 执行与释放或重置非托管资源相关的应用程序定义的任务。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
