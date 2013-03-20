// ***********************************************************************
// Assembly         : ZYW.WebApp
// Author           : hebidu
// Created          : 03-11-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-08-2013
// ***********************************************************************
// <copyright file="MainAreaRegistration.cs" company="XXX">
//     Copyright (c) XXX. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ZYW.WebApp.Areas.Main
{
    #region 引用包

    using System.Web.Mvc;
    #endregion

    /// <summary>
    /// Class MainAreaRegistration
    /// </summary>
    public class MainAreaRegistration : AreaRegistration
    {
        /// <summary>
        /// 获取要注册的区域的名称。
        /// </summary>
        /// <value>The name of the area.</value>
        /// <returns>要注册的区域的名称。</returns>
        public override string AreaName
        {
            get
            {
                return "Main";
            }
        }

        /// <summary>
        /// 使用指定区域的上下文信息在 ASP.NET MVC 应用程序内注册某个区域。
        /// </summary>
        /// <param name="context">对注册区域所需的信息进行封装。</param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Main_default",
                "Main/{controller}/{action}/{id}",
                new { controller = "Test" ,action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
