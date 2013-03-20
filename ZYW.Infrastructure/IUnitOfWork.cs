// ***********************************************************************
// Assembly         : ZYW.Infrastructure
// Author           : hebidu
// Created          : 03-11-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-11-2013
// ***********************************************************************
// <copyright file="IUnitOfWork.cs" company="XXX">
//     Copyright (c) XXX. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ZYW.Infrastructure
{
    /// <summary>
    /// IUnitOfWork 接口 ，也可加入UnDo之类的
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Saves this instance.
        /// </summary>
        void Save();
    }
}
