// ***********************************************************************
// Assembly         : ZYW.WebApp
// Author           : hebidu
// Created          : 03-11-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-11-2013
// ***********************************************************************
// <copyright file="Global.asax.cs" company="XXX">
//     Copyright (c) XXX. All rights reserved.
// </copyright>
// <summary>
// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
// visit http://go.microsoft.com/?LinkId=9394801
// </summary>
// ***********************************************************************
namespace ZYW.WebApp
{
    #region 引用包

    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Autofac;
    using Autofac.Configuration;
    using Autofac.Integration.Mvc;
    using ZYW.WebApp.Common;
    using System;
    using System.Web;
    using System.Globalization;
    using System.Threading;
    using ZYW.WebApp.Common.Const;
    using System.Collections.Generic;
    #endregion

    /// <summary>
    /// Class MvcApplication
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        public static readonly List<string> AvailableCultures = new List<string>
        {
            "en-US","zh-CN"
        };

        #region 方法

        /// <summary>
        /// Registers the global filters.
        /// </summary>
        /// <param name="filters">The filters.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //  filters.Add(new HandleErrorAttribute());
            //filters.Add(new LanguageSnifferAttribute());
            filters.Add(new AppHandleErrorAttribute());
        }

        /// <summary>
        /// Registers the routes.
        /// </summary>
        /// <param name="routes">The routes.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //此路由请求最常用的页面cshtml，由AjaxHtml控制器
            routes.MapRoute(
                "DefaultAjaxHtml", // Route name
                "{htmlname}", // URL with parameters
                new { controller = "AjaxHtml", action = "Get", htmlname = UrlParameter.Optional }, // Parameter defaults
                new { htmlName = @"\b\w+.html$" }
            );

            //controller表示模块，此路由请求此模块的页面cshtml
            routes.MapRoute(
                "AjaxHtml", // Route name
                "{controller}/{htmlname}", // URL with parameters
                new { controller = "AjaxHtml", action = "Get", htmlname = UrlParameter.Optional }, // Parameter defaults
                new { htmlName = @"\b\w+.html$" }
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{message}", // URL with parameters
                new { controller = "Home", action = "Index", message = UrlParameter.Optional } // Parameter defaults
            );

        }

        /// <summary>
        /// 注册需要注入的类型
        /// </summary>
        protected void RegisterTypes()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ConfigurationSettingsReader("autofac"));
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }

        /// <summary>
        /// Application_s the start.
        /// </summary>
        protected void Application_Start()
        {
            this.RegisterTypes();

            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

        }

        /// <summary>
        /// Handles the AcquireRequestState event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session != null)
            {
                string cultureCode = null;

                if (this.Session[SessionKey.Language] != null)
                {
                    string tmp = this.Session[SessionKey.Language].ToString();
                    tmp = tmp.Replace("_", "-");
                    if (AvailableCultures.Any(o => o.Equals(tmp, StringComparison.OrdinalIgnoreCase)))
                    {
                        cultureCode = tmp;
                    }

                }
                else
                {
                    cultureCode = GetBrowserCulture();
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
        }
        
        /// <summary>
        /// 获取浏览器的语言设置
        /// </summary>
        /// <returns>System.String.</returns>
        private string GetBrowserCulture()
        {

            var browerCulture = this.Request.UserLanguages;
            if (browerCulture == null)
            {
                return null;
            }
            foreach (var item in browerCulture)
            {
                if (AvailableCultures.Any(o => o.Equals(item, StringComparison.OrdinalIgnoreCase)))
                {
                    return item;
                }
            }
            return null;
        }
        
        #endregion
    }
}