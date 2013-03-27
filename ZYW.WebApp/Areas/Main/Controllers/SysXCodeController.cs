// ***********************************************************************
// Assembly         : ZYW.WebApp
// Author           : hebidu
// Created          : 03-18-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-18-2013
// ***********************************************************************
// <copyright file="SysXCodeController.cs" company="XXX">
//     Copyright (c) XXX. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ZYW.WebApp.Areas.Main.Controllers
{
    #region 引用包

    using System.Web.Mvc;
    using Resources;
    using ZYW.IServices;
    using ZYW.Model;
    using ZYW.Model.Resources;
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections;
    using System;
    using ZYW.WebApp.ViewModel;
    using ZYW.WebApp.Common.Const;

    #endregion

    /// <summary>
    /// Class SysXCodeController
    /// </summary>
    public class SysXCodeController : Controller
    {
        #region 字段

        protected ISysXCodeService _sysXCodeService;

        #endregion

        #region 构造函数

        /// <summary>
        /// Initializes a new instance of the <see cref="SysXCodeController"/> class.
        /// </summary>
        /// <param name="sysXCodeService">The sys X code service.</param>
        public SysXCodeController(ISysXCodeService sysXCodeService)
        {
            this._sysXCodeService = sysXCodeService;
        }

        #endregion

        #region Action方法

        /// <summary>
        /// 
        /// GET: /Main/SysXCode/
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            #region ViewBag

            ViewBag.Title = ViewBagMessage.List;
            ViewBag.XID = ModelDisplayName.ID;
            ViewBag.Name = ModelDisplayName.Name;
            ViewBag.XCode = ModelDisplayName.XCode;
            ViewBag.XDepth = ModelDisplayName.XDepth;
            ViewBag.XFlag = ModelDisplayName.XFlag;
            ViewBag.XOrderNumber = ModelDisplayName.XOrderNumber;
            ViewBag.XParentID = ModelDisplayName.XParentID;
            ViewBag.Remark = ModelDisplayName.Remark;
            ViewBag.XSource = ModelDisplayName.XSource;

            #endregion

            return View();
        }

        /// <summary>
        /// 
        /// GET: /Main/SysXCode/List
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult List()
        {
            if (Request.IsAjaxRequest())
            {
                var result = from code in this._sysXCodeService.List()
                             select new
                             {
                                 code.XCode,
                                 code.XDepth,
                                 code.XFlag,
                                 code.XID,
                                 code.XName,
                                 code.XOrderNumber,
                                 code.XParentID,
                                 code.XRemark,
                                 code.XSource
                             };
                return Json(new { total = result.Count(), rows = result }, JsonRequestBehavior.AllowGet);
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Pagings the list.
        /// </summary>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult PagingList(int pageSize,int pageNumber)
        {
            if (Request.IsAjaxRequest())
            {
                int total = 0;
                var result = from code in this._sysXCodeService.Get(pageSize, pageNumber, ref total, s => s.OrderBy(code => code.XID))
                             select new
                             {
                                 code.XCode,
                                 code.XDepth,
                                 code.XFlag,
                                 code.XID,
                                 code.XName,
                                 code.XOrderNumber,
                                 code.XParentID,
                                 code.XRemark,
                                 code.XSource
                             };
                return Json(new { total = total, rows = result }, JsonRequestBehavior.AllowGet);
            }
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Detailses the specified ID.
        /// GET: /Main/SysXCode/Details/5 .
        /// </summary>
        /// <param name="ID">The ID.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Details(long ID)
        {
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Creates this instance.
        /// GET: /Main/SysXCode/Create .
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Create()
        {
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Creates the specified SysXCode.
        /// POST: /Main/SysXCode/Create.
        /// </summary>
        /// <param name="sysXCode">The SysXCode.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Create(SysXCode sysXCode)
        {
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Edits the specified ID.
        /// GET: /Main/SysXCode/Edit/5.
        /// </summary>
        /// <param name="ID">The ID.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Edit(long ID)
        {
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Edits the specified id.
        /// POST: /Main/SysXCode/Edit/5.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Edit(SysXCode sysXCode)
        {
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Deletes the specified ID.
        /// GET: /Main/SysXCode/Delete/5.
        /// </summary>
        /// <param name="ID">The ID.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Delete(long ID)
        {
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Deletes the specified SysXCode.
        /// POST: /Main/SysXCode/Delete/5.
        /// </summary>
        /// <param name="sysXCode">The SysXCode.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Delete(long ID, SysXCode sysXCode)
        {
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 返回一级导航
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult AdminNav()
        {
            if (Request.IsAjaxRequest())
            {
                return Json(this._sysXCodeService.AdminNav(), JsonRequestBehavior.AllowGet);
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 返回子导航
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult SubNavOf(long? ID)
        {
            if (!String.IsNullOrEmpty(Request.Form["ID"]))
            {
                ID = long.Parse(Request.Form["ID"]);
            }
            if (!ID.HasValue)
            {
                ID = long.MinValue;
            }

            if (Request.IsAjaxRequest())
            {
                return Json(this._sysXCodeService.SubNavOf(ID.Value), JsonRequestBehavior.AllowGet);
            }
            return RedirectToAction("Index");
        }

        #endregion
    }
}
