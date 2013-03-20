// ***********************************************************************
// Assembly         : ZYW.Model
// Author           : hebidu
// Created          : 03-11-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-12-2013
// ***********************************************************************
// <copyright file="TestModel.cs" company="XXX">
//     Copyright (c) XXX. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ZYW.Model
{
    #region 引用包

    using System;

    #endregion

    /// <summary>
    /// TestModel的模型类
    /// </summary>
    [Serializable]
    public class TestModel
    {
        #region 属性

        /// <summary>
        /// Gets or sets the test ID.
        /// </summary>
        /// <value>The test ID.</value>
        public long testID { get; set; }

        /// <summary>
        /// Gets or sets the name of the test.
        /// </summary>
        /// <value>The name of the test.</value>
        public string testName { get; set; }

        /// <summary>
        /// Gets or sets the test desc.
        /// </summary>
        /// <value>The test desc.</value>
        public string testDesc { get; set; }
        #endregion
    }
}
