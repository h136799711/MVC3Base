// ***********************************************************************
// Assembly         : ZYW.WebApp
// Author           : hebidu
// Created          : 03-11-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-13-2013
// ***********************************************************************
// <copyright file="ErrorController.cs" company="XXX">
//     Copyright (c) XXX. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ZYW.WebApp.Controllers
{

    #region 引用包

    using System.Web.Mvc;
    using System;
    using System.Reflection;
    #endregion

    /// <summary>
    /// Class ErrorController
    /// </summary>
    public class ErrorController : Controller
    {
        #region 方法

        /// <summary>
        /// 为被处理的异常发生时应转到此
        /// </summary>
        /// <param name="message">异常相关信息.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Unknown(string message = "请求出错，请联系网站管理员")
        {
            if (Request.IsAjaxRequest())
            {
                return Json(new { code = -1024, message = message },
                    JsonRequestBehavior.AllowGet);
            }
            ViewData["message"] = message;
            return View();
        }

        /// <summary>
        /// 404错误时,没有找到页面
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult _404()
        {
            if (Request.IsAjaxRequest())
            {
                return Json(new { code = -404, message = "未找到(NotFound)" },
                    JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        /// <summary>
        /// 403错误时，禁止页面
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult _403()
        {
            if (Request.IsAjaxRequest())
            {
                return Json(new { code = -403, message = "禁止(Forbidden)" },
                    JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        
        /// <summary>
        /// 400错误时，错误请求
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult _400()
        {
            if (Request.IsAjaxRequest())
            {
                return Json(new { code = -400, message = "错误请求(Bad Request)" },
                    JsonRequestBehavior.AllowGet);
            }
            return View();
        }
         
        /// <summary>
        /// 401错误时，未认证
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult _401()
        {
            if (Request.IsAjaxRequest())
            {
                return Json(new { code = -401, message = "未认证" },
                    JsonRequestBehavior.AllowGet);
            }
            return View();
        }
                  
        /// <summary>
        /// 408错误时，未认证
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult _408()
        {
            if (Request.IsAjaxRequest())
            {
                return Json(new { code = -408, message = "请求超时" },
                    JsonRequestBehavior.AllowGet);
            }
            return View();
        }
                  
        /// <summary>
        /// 409错误时，未认证
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult _409()
        {
            if (Request.IsAjaxRequest())
            {
                return Json(new { code = -409, message = "冲突" },
                    JsonRequestBehavior.AllowGet);
            }
            return View();
        }
                  
        /// <summary>
        /// 413错误时，请求实体太大
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult _413()
        {
            if (Request.IsAjaxRequest())
            {
                return Json(new { code = -413, message = "请求实体太大" },
                    JsonRequestBehavior.AllowGet);
            }
            return View();
        }
                   
        /// <summary>
        /// 414错误时，请求URI太长
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult _414()
        {
            if (Request.IsAjaxRequest())
            {
                return Json(new { code = -414, message = "请求URI太长" },
                    JsonRequestBehavior.AllowGet);
            }
            return View();
        }      
     
        /// <summary>
        /// 415错误时，不支持媒体类型
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult _415()
        {
            if (Request.IsAjaxRequest())
            {
                return Json(new { code = -415, message = "不支持媒体类型" },
                    JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        
        /// <summary>
        /// 500错误时，服务器内部错误
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult _500()
        {
            if (Request.IsAjaxRequest())
            {
                return Json(new { code = -500, message = "服务器内部错误" },
                    JsonRequestBehavior.AllowGet);
            }

            return View();
        }
        
        /// <summary>
        /// 501错误时，未实现（Not Implemented）
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult _501()
        {
            if (Request.IsAjaxRequest())
            {
                return Json(new { code = -501, message = "未实现（Not Implemented）" },
                    JsonRequestBehavior.AllowGet);
            }
            return View();
        }
　 
        /// <summary>
        /// 502错误时，网关失败
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult _502()
        {
            if (Request.IsAjaxRequest())
            {
                return Json(new { code = -502, message = "网关失败" },
                    JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        /// <summary>
        /// 504错误时，网关超时
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult _504()
        {
            if (Request.IsAjaxRequest())
            {
                return Json(new { code = -504, message = "网关超时" },
                    JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        
        /// <summary>
        /// 505错误时，HTTP版本不支持
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult _505()
        {
            if (Request.IsAjaxRequest())
            {
                return Json(new { code = -505, message = "HTTP版本不支持" },
                    JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        /// <summary>
        /// 多路选择
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult _300()
        {
            if (Request.IsAjaxRequest())
            {
                return Json(new { code = -300, message = "多路选择" },
                    JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        /// <summary>
        /// 永久转移
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult _301()
        {
            if (Request.IsAjaxRequest())
            {
                return Json(new { code = -301, message = "永久转移" },
                    JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        
        /// <summary>
        /// 暂时转移
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult _302()
        {
            if (Request.IsAjaxRequest())
            {
                return Json(new { code = -302, message = "暂时转移" },
                    JsonRequestBehavior.AllowGet);
            }
            return View();
        }
          
        /// <summary>
        /// 参见其它
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult _303()
        {
            if (Request.IsAjaxRequest())
            {
                return Json(new { code = -303, message = "参见其它" },
                    JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        #endregion
    }
}
