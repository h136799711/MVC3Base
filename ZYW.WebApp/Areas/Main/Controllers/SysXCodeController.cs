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

            ViewBag.XCode = ModelDisplayName.XCode;
            ViewBag.XName = ModelDisplayName.Name;
            ViewBag.XOrderNumber = ModelDisplayName.XOrderNumber;
            ViewBag.XParentID = ModelDisplayName.XParentID;
            ViewBag.XDepth = ModelDisplayName.XDepth;
            ViewBag.XSource = ModelDisplayName.XSource;
            ViewBag.XFlag = ModelDisplayName.XFlag;
            ViewBag.XRemark = ModelDisplayName.Remark;

            ViewBag.Create = ViewBagMessage.Create;
            ViewBag.BackToList = ViewBagMessage.BackToList;
            ViewBag.NoData = ViewBagMessage.NoData;
            ViewBag.Edit = ViewBagMessage.Edit;
            ViewBag.Delete = ViewBagMessage.Delete;
            ViewBag.Details = ViewBagMessage.Details;

            ViewBag.Title = ViewBagMessage.List;
            ViewBag.SysXCode = ViewBagMessage.SysXCode;

            #endregion

            IEnumerable list = from sysxcode in this._sysXCodeService.List()
                                         select new { sysxcode.XCode, sysxcode.XDepth,sysxcode.XFlag,
                                             sysxcode.XID,sysxcode.XName,sysxcode.XOrderNumber,
                                             sysxcode.XParentID,sysxcode.XRemark,sysxcode.XSource};
            if (Request.IsAjaxRequest())
            {
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return View(list);
        }

        /// <summary>
        /// Detailses the specified ID.
        /// GET: /Main/SysXCode/Details/5 .
        /// </summary>
        /// <param name="ID">The ID.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Details(long ID)
        {
            #region ViewBag

            ViewBag.Title = Resources.ViewBagMessage.Details;
            ViewBag.Create = Resources.ViewBagMessage.Create;
            ViewBag.Edit = Resources.ViewBagMessage.Edit;
            ViewBag.BackToList = Resources.ViewBagMessage.BackToList;
            ViewBag.SysXCode = ViewBagMessage.SysXCode;

            #endregion

            return View(this._sysXCodeService.GetByID(ID));
        }

        /// <summary>
        /// Creates this instance.
        /// GET: /Main/SysXCode/Create .
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Create()
        {
            #region ViewBag

            ViewBag.Title = Resources.ViewBagMessage.Create;
            ViewBag.Create = Resources.ViewBagMessage.Create;
            ViewBag.BackToList = Resources.ViewBagMessage.BackToList;
            ViewBag.SysXCode = ViewBagMessage.SysXCode;

            #endregion

            return View();
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
            if (ModelState.IsValid)
            {
                this._sysXCodeService.Insert(sysXCode);
                this._sysXCodeService.Save();
                return RedirectToAction("Index");
            }

            return View();
        }

        /// <summary>
        /// Edits the specified ID.
        /// GET: /Main/SysXCode/Edit/5.
        /// </summary>
        /// <param name="ID">The ID.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Edit(long ID)
        {
            #region ViewBag

            ViewBag.Save = Resources.ViewBagMessage.Save;
            ViewBag.Title = Resources.ViewBagMessage.Edit;
            ViewBag.BackToList = Resources.ViewBagMessage.BackToList;
            ViewBag.SysXCode = ViewBagMessage.SysXCode;

            #endregion

            return View(this._sysXCodeService.GetByID(ID));
        }

        /// <summary>
        /// Edits the specified id.
        /// POST: /Main/SysXCode/Edit/5.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="collection">The collection.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Edit(SysXCode sysXCode)
        {
            if (ModelState.IsValid)
            {
                this._sysXCodeService.Update(sysXCode);
                this._sysXCodeService.Save();
                return RedirectToAction("Index");
            }
            return View(sysXCode);
        }

        /// <summary>
        /// Deletes the specified ID.
        /// GET: /Main/SysXCode/Delete/5.
        /// </summary>
        /// <param name="ID">The ID.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Delete(long ID)
        {
            #region ViewBag

            ViewBag.Title = ViewBagMessage.Delete;
            ViewBag.Delete = ViewBagMessage.Delete;
            ViewBag.BackToList = ViewBagMessage.BackToList;
            ViewBag.SysXCode = ViewBagMessage.SysXCode;

            #endregion

            return View(this._sysXCodeService.GetByID(ID));
        }

        /// <summary>
        /// Deletes the specified SysXCode.
        /// POST: /Main/SysXCode/Delete/5.
        /// </summary>
        /// <param name="sysXCode">The SysXCode.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Delete(long ID,SysXCode sysXCode)
        {
            sysXCode = this._sysXCodeService.GetByID(ID);
            this._sysXCodeService.Delete(sysXCode);
            this._sysXCodeService.Save();

            return RedirectToAction("Index");
        }

        #endregion
    }
}
