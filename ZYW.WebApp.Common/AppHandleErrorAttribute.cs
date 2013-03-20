// ***********************************************************************
// Assembly         : ZYW.WebApp.Common
// Author           : hebidu
// Created          : 03-11-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-11-2013
// ***********************************************************************
// <copyright file="AppHandleErrorAttribute.cs" company="XXX">
//     Copyright (c) XXX. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ZYW.WebApp.Common
{
    #region 引用包

    using System;
    using System.Reflection;
    using System.Web.Mvc;
    using System.Web.Routing;
    using log4net;
    #endregion
    /// <summary>
    /// 应用程序最外围的异常处理
    /// </summary>
    public class AppHandleErrorAttribute : HandleErrorAttribute
    {
        /// <summary>
        /// Called when an exception occurs.
        /// </summary>
        /// <param name="filterContext">The action-filter context.</param>
        public override void OnException(ExceptionContext filterContext)
        {
            ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            Exception ex = filterContext.Exception;
            if (ex is WebException)
            {
                log.Error("自定义异常（WebException）", ex);
                filterContext.ExceptionHandled = true;
                RouteValueDictionary routeValue = new RouteValueDictionary();
                routeValue.Add("controller", "Error");
                routeValue.Add("action", "Unknown");
                routeValue.Add("message", ex.Message);
                filterContext.Result = new RedirectToRouteResult("Default", routeValue);
            }
            else
            {
                log.Error("系统异常", ex);
                filterContext.ExceptionHandled = true;
                filterContext.Result = new RedirectResult("~/Error/Unknown");
         
            }

        }
    }

}
