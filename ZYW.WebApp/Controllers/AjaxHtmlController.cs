// ***********************************************************************
// Assembly         : ZYW.WebApp
// Author           : hebidu
// Created          : 03-11-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-13-2013
// ***********************************************************************
// <copyright file="AjaxHtmlController.cs" company="XXX">
//     Copyright (c) XXX. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ZYW.WebApp.Controllers
{
    #region 引用包

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    #endregion

    /// <summary>
    /// Class AjaxHtmlController用于获取指定视图页面
    /// </summary>
    public class AjaxHtmlController : Controller
    {
        /// <summary>
        /// 获取指定名称的视图页面
        /// </summary>
        /// <param name="htmlname">The htmlname.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Get(string htmlname="Index.html")
        {
            return View(htmlname);
        }

    }
}
