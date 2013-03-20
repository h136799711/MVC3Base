// ***********************************************************************
// Assembly         : ZYW.WebApp
// Author           : hebidu
// Created          : 03-11-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-13-2013
// ***********************************************************************
// <copyright file="TestController.cs" company="XXX">
//     Copyright (c) XXX. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ZYW.WebApp.Areas.Main.Controllers
{
    #region 引用包

    using System.Collections;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using ZYW.IServices;
    using ZYW.Model;
    using ZYW.WebApp.Common.Const;

    #endregion

    /// <summary>
    /// 用于示例的控制器,未实现 编辑功能
    /// </summary>
    public class TestController : Controller
    {
        #region 成员

        /// <summary>
        /// The _test service
        /// </summary>
        private ITestService _testService;

        #endregion

        #region 方法

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="testService">test的服务接口实现类</param>
        public TestController(ITestService testService)
        {
            this._testService = testService;
        }

        //
        // GET: /Main/Test/

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            return View(this._testService.List());
        }
        //
        // GET: /Main/Test/Details/5

        /// <summary>
        /// Detailses the specified ID.
        /// </summary>
        /// <param name="ID">The ID.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Details(int ID)
        {
            TestModel test = this._testService.GetEntityByID(ID);
            IEnumerator<TestModel> enumerator = this._testService.Get(t => t.testID == ID).GetEnumerator();
            enumerator.MoveNext();
            test = enumerator.Current;
            if (Request.IsAjaxRequest())
            {
                return Json(test);
            }
            return View(test);
        }

        //
        // GET: /Main/Test/Create

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Main/Test/Create

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Create(TestModel entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this._testService.Insert(entity);
                    this._testService.Save();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Create");

            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Main/Test/Edit/5

        /// <summary>
        /// Edits the specified ID.
        /// </summary>
        /// <param name="ID">The ID.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Edit(int ID)
        {
            return View(this._testService.GetEntityByID(ID));
        }


        /// <summary>
        /// Edits the specified TestModel.
        /// POST: /Main/Test/Edit/5
        /// </summary>
        /// <param name="test">The test.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Edit(TestModel test)
        {
            if (ModelState.IsValid)
            {
                this._testService.Update(test);
                this._testService.Save();
            }
            return RedirectToAction("Index");

        }

        /// <summary>
        /// Deletes the specified ID.
        /// </summary>
        /// <param name="ID">The ID.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Delete(int ID)
        {
            this._testService.Delete(new TestModel() { testID = ID});
            this._testService.Save();
            return RedirectToAction("Index");
        }

        #endregion
    }
}
