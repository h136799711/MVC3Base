// ***********************************************************************
// Assembly         : ZYW.DBContexts
// Author           : hebidu
// Created          : 03-14-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-15-2013
// ***********************************************************************
// <copyright file="BookDBContext.cs" company="XXX">
//     Copyright (c) XXX. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ZYW.DBContexts
{
    #region 引用包

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ZYW.Infrastructure;

    #endregion

    /// <summary>
    /// Class BookDBContext
    /// </summary>
    public class BookDBContext:SystemDBContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookDBContext" /> class.
        /// </summary>
        public BookDBContext()
            : base()
        {
        }

        /// <summary>
        /// Constructs a new context instance using the given string as the name or connection string for the
        /// database to which a connection will be made.
        /// See the class remarks for how this is used to create a connection.
        /// </summary>
        /// <param name="nameOrConnectionString">Either the database name or a connection string.</param>
        public BookDBContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }
    }
}
