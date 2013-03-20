// ***********************************************************************
// Assembly         : ZYW.IRepositorys
// Author           : hebidu
// Created          : 03-20-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-20-2013
// ***********************************************************************
// <copyright file="ISysXCodeRepository.cs" company="XXX">
//     Copyright (c) XXX. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ZYW.IRepositorys
{
    #region 引用包

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ZYW.Model;
    using ZYW.Infrastructure;
    using System.Collections;

    #endregion

    /// <summary>
    /// Interface ISysXCodeRepository
    /// </summary>
    public interface ISysXCodeRepository:IRepository<SysXCode>
    {
        /// <summary>
        /// Primaries the nav.
        /// </summary>
        /// <returns>IList.</returns>
        IEnumerable PrimaryNav();

        /// <summary>
        /// Seconds the nav.
        /// </summary>
        /// <returns>IEnumerable.</returns>
        IEnumerable SecondNav(string XCode);
    }
}
