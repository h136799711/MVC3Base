// ***********************************************************************
// Assembly         : ZYW.WebApp.Common
// Author           : hebidu
// Created          : 03-11-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-11-2013
// ***********************************************************************
// <copyright file="WebException.cs" company="XXX">
//     Copyright (c) XXX. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ZYW.WebApp.Common
{

    #region 引用包

    using System;
    using System.Runtime.Serialization;

    #endregion

    /// <summary>
    /// 自定义Web程序异常，通常程序中用户抛出的异常应该为此异常或其子类
    /// </summary>
    [Serializable]
    public class WebException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebException"/> class.
        /// </summary>
        public WebException() { }

        /// <summary>
        /// 使用指定错误消息初始化 <see cref="T:System.ApplicationException" /> 类的新实例。
        /// </summary>
        /// <param name="message">描述错误的消息。</param>
        public WebException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.ApplicationException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">解释异常原因的错误信息。</param>
        /// <param name="innerException">导致当前异常的异常。如果 <paramref name="innerException" /> 参数不为空引用，则在处理内部异常的 catch 块中引发当前异常。</param>
        public WebException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.ApplicationException" /> class with serialized data.
        /// </summary>
        /// <param name="info">保存序列化对象数据的对象。</param>
        /// <param name="context">有关源或目标的上下文信息。</param>
        protected WebException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
