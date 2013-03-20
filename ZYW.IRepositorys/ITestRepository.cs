// ***********************************************************************
// Assembly         : ZYW.IRepositorys
// Author           : hebidu
// Created          : 03-11-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-12-2013
// ***********************************************************************
// <copyright file="ITestRepository.cs" company="XXX">
//     Copyright (c) XXX. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ZYW.IRepositorys
{
    #region 引用包

    using ZYW.Model;
    using ZYW.Infrastructure;
    #endregion

    /// <summary>
    /// Test的数据库访问接口
    /// </summary>
    /// <remark></remark>
    public interface ITestRepository : IRepository<TestModel> 
    {
        /// <summary>
        /// Gets the entity by ID.
        /// </summary>
        /// <param name="ID">The ID.</param>
        /// <returns>TestModel.</returns>
        TestModel GetEntityByID(long ID);
        /// <summary>
        /// Deletes all.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        bool DeleteAll();
    }
}
