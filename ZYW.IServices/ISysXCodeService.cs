// ***********************************************************************
// Assembly         : ZYW.IServices
// Author           : hebidu
// Created          : 03-15-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-18-2013
// ***********************************************************************
// <copyright file="ISysXCodeService.cs" company="XXX">
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
    /// Interface ISysXCodeService
    /// </summary>
    public interface ISysXCodeService:IDataBaseService<SysXCode>
    {
        SysXCode GetByID(long ID);
    }
}
