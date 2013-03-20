// ***********************************************************************
// Assembly         : ZYW.IServices
// Author           : hebidu
// Created          : 03-11-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-13-2013
// ***********************************************************************
// <copyright file="ITestService.cs" company="XXX">
//     Copyright (c) XXX. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ZYW.IServices
{
    #region 引用包

    using ZYW.Model;
    #endregion

    /// <summary>
    /// Test的数据库访问服务接口
    /// </summary>
    public interface ITestService :IDataBaseService<TestModel>
    {
        /// <summary>
        /// Gets the entity by ID.
        /// </summary>
        /// <param name="ID">The ID.</param>
        /// <returns>TestModel.</returns>
        TestModel GetEntityByID(long ID);
    }
}
