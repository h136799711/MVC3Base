// ***********************************************************************
// Assembly         : ZYW.WebApp
// Author           : hebidu
// Created          : 03-19-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-19-2013
// ***********************************************************************
// <copyright file="LanguageController.cs" company="XXX">
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
    using ZYW.WebApp.Common.Const;

    #endregion

    /// <summary>
    /// 网站语言控制器
    /// </summary>
    public class LanguageController : Controller
    {
        /// <summary>
        /// 网站语言设为美式英文
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult English(string returnUrl)
        {
            this.Session[SessionKey.Language] = LangEnum.EN_US;
            if (!String.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            System.Web.Routing.RouteValueDictionary rvd = new System.Web.Routing.RouteValueDictionary();
            rvd.Add("controller", "Home");
            rvd.Add("action", "Index");
            return RedirectToRoute("Default", rvd);
        }

        /// <summary>
        /// 网站语言设为中文
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Chinese(string returnUrl)
        {
            this.Session[SessionKey.Language] = LangEnum.ZH_CN;
            if (!String.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            System.Web.Routing.RouteValueDictionary rvd = new System.Web.Routing.RouteValueDictionary();
            rvd.Add("controller", "Home");
            rvd.Add("action", "Index");
            return RedirectToRoute("Default", rvd);
        }
    }
}
