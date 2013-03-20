// ***********************************************************************
// Assembly         : ZYW.Model
// Author           : hebidu
// Created          : 03-11-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-12-2013
// ***********************************************************************
// <copyright file="OperationInformation.cs" company="XXX">
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
    /// 系统中重要操作的一些信息
    /// </summary>
    /// <remarks>操作对象还需要进一步设计，暂定为用户ID</remarks>
    public class OperationInformation
    {
        #region 属性

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        /// <value>The ID.</value>
        public long OpID{get;set;}

        /// <summary>
        /// 获取或设置操作开始时间。
        /// </summary>
        /// <value>操作开始时间。</value>
        public DateTime OpStartTime{get;set;}

        /// <summary>
        /// 获取或设置操作类型
        /// </summary>
        /// <value>操作类型</value>
        public string OpType {get;set;}

        /// <summary>
        /// 获取或设置操作结束时间
        /// </summary>
        /// <value>操作结束时间</value>
        public DateTime OpEndTime{get;set;}

        /// <summary>
        /// 获取或设置操作结果
        /// </summary>
        /// <value>操作结果</value>
        public int OpResult { get; set; }

        /// <summary>
        /// 获取或设置进行此操作的对象，通常此代表操作的对象，比如用户ID
        /// </summary>
        /// <value>进行此操作的对象</value>
        public long OpObjectID { get; set; }

        /// <summary>
        /// 获取或设置系统编码的ID，通常此代表被操作的对象，比如页面
        /// </summary>
        /// <value>系统编码的ID</value>
        public long XCodeID { get; set; }

        /// <summary>
        /// Gets or sets the sys X code.
        /// </summary>
        /// <value>The sys X code.</value>
        public virtual SysXCode SysXCode { get; set; }
        #endregion
    }
}
