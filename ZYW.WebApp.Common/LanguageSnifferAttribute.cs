// ***********************************************************************
// Assembly         : ZYW.WebApp.Common
// Author           : hebidu
// Created          : 03-19-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-19-2013
// ***********************************************************************
// <copyright file="LanguageSnifferAttribute.cs" company="XXX">
//     Copyright (c) XXX. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ZYW.WebApp.Common
{
    #region 引用包

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using System.Globalization;
    using ZYW.WebApp.Common.Const;

    #endregion

    /// <summary>
    /// Class LanguageSnifferAttribute
    /// </summary>
    public class LanguageSnifferAttribute : FilterAttribute, IActionFilter
    {
        /// <summary>
        /// 站点支持的语言列表
        /// </summary>
        public static readonly List<string> AvailableCultures = new List<string>
        {
            "en-US","zh-CN"
        };

        /// <summary>
        /// 在执行操作方法之前调用。
        /// </summary>
        /// <param name="filterContext">筛选器上下文。</param>
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string cultureCode=null;

            if (filterContext.HttpContext.Session[SessionKey.Language] != null)
            {
                string tmp = filterContext.HttpContext.Session[SessionKey.Language].ToString();
                tmp = tmp.Replace("_", "-");
                if (AvailableCultures.Any(o => o.Equals(tmp, StringComparison.OrdinalIgnoreCase)))
                {
                    cultureCode = tmp;
                }

            }
            else
            {
                cultureCode = GetBrowserCulture(filterContext);
            }
            
            try
            {
                CultureInfo culture = new CultureInfo(cultureCode);
                System.Threading.Thread.CurrentThread.CurrentCulture = culture;
                System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 获取浏览器的语言设置
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        /// <returns>System.String.</returns>
        private string GetBrowserCulture(ActionExecutingContext filterContext)
        {

            var browerCulture = filterContext.HttpContext.Request.UserLanguages;
            if (browerCulture == null)
            {
                return null;
            }
            foreach (var item in browerCulture)
            {
                if (AvailableCultures.Any(o => o.Equals(item,StringComparison.OrdinalIgnoreCase)))
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// 在执行操作方法后调用。
        /// </summary>
        /// <param name="filterContext">筛选器上下文。</param>
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }
    }
}
