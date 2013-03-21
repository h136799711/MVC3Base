// ***********************************************************************
// Assembly         : ZYW.IServices
// Author           : hebidu
// Created          : 03-20-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-20-2013
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
    using System.Collections;

    #endregion

    /// <summary>
    /// Interface ISysXCodeService
    /// </summary>
    public interface ISysXCodeService:IDataBaseService<SysXCode>
    {
        /// <summary>
        /// Gets the by ID.
        /// </summary>
        /// <param name="ID">The ID.</param>
        /// <returns>SysXCode.</returns>
        SysXCode GetByID(long ID);

        /// <summary>
        /// Primaries the nav.
        /// </summary>
        /// <returns>IList.</returns>
        IEnumerable AdminNav();

        /// <summary>
        /// Seconds the nav.
        /// </summary>
        /// <returns>IEnumerable.</returns>
        IEnumerable SubNavOf(long ID);
    }
}
