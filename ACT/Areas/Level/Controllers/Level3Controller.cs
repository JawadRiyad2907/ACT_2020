using ACT.Controllers;

using ACT.Service;
using ACT.ViewModel;
using System.Web.Mvc;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;
using ACT.Utilities.Extensions;
using ACT.Models;
using ACT.Authentication;
using ACT.Utilities.Enum;

namespace ACT.Areas.Level.Controllers
{
    public class Level3Controller : BaseController
    {

        #region Variable
        ILevel3Service _Level3Service;
        ILevel1Service _Level1Service;
        ILevel2Service _Level2Service;
        #endregion

        #region Const
        public Level3Controller(ILevel1Service Level1Service, ILevel2Service Level2Service, ILevel3Service Level3Service)
        {
            _Level3Service = Level3Service;
            _Level2Service = Level2Service;
            _Level1Service = Level1Service;
        }

        #endregion

        #region PageBarFunction
        [NonAction]
        private List<PageBarViewModel> GetPageBar(string LocPageName)
        {
            return new List<PageBarViewModel>{
                new PageBarViewModel {Order=0,Description=Resources.PageTitle.SystemAdministration,IsFirst=true },
                new PageBarViewModel {Order=1,Description=Resources.PageTitle.OrganizationsManagement  },
                 new PageBarViewModel {Order=2,Description=LocPageName,IsLast=true },
            };
        }


        #endregion

        #region Main
        [ActAuthorize(MenuEnum.ManageLevel3)]
        public ActionResult Index()
        {
            ViewBag.Title = Resources.PageTitle.Level3_Index;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.Level3_Index);
            ViewBag.Description = "";
            return View();
        }

        [ActAuthorize(MenuEnum.ManageLevel3)]
        [HttpGet]
        public JsonResult GetLevel3List(DataTableViewModel dataTableViewModel)
        {
            //check if not null
            string SearchLevel1Str = Request.QueryString["SearchLevel1"];
            int? SearchLevel1 = !string.IsNullOrEmpty(SearchLevel1Str) ? int.Parse(SearchLevel1Str) as int? : null;

            string SearchLevel2Str = Request.QueryString["SearchLevel2"];
            int? SearchLevel2 = !string.IsNullOrEmpty(SearchLevel2Str) ? int.Parse(SearchLevel2Str) as int? : null;

            string SearchName = Request.QueryString["SearchName"];

            var includeMultiProperties = new Expression<Func<Level3, object>>[] { x => x.Level2, y => y.Level1 };

            var data = _Level3Service.ListWithPaging(
                filter: x => (SearchLevel1 == null || x.Level1Id == SearchLevel1) && (SearchLevel2 == null || x.Level2Id == SearchLevel2) && x.Name.Contains(SearchName),
                includeProperties: includeMultiProperties,
                orderBy: o => o.DisplayOrder,
                pageSize: dataTableViewModel.length,
                page: dataTableViewModel.start);

            //fix serilaize json >>
            var dataMapped = Mapper.Map<List<Level3ViewModel>>(data.EntityData);
            return Json(new { data = dataMapped, recordsTotal = data.Count, recordsFiltered = data.Count }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Add
        [HttpGet]
        [ActAuthorize(MenuEnum.ManageLevel3)]
        public ActionResult Add()
        {
            ViewBag.Title = Resources.PageTitle.Level3_Add;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.Level3_Add);
            ViewBag.Description = "";
            var model = new Level3ViewModel();
            model.Published = true;
            return View(model);
        }
        [HttpPost]
        [ActAuthorize(MenuEnum.ManageLevel3)]
        public JsonResult Add(Level3ViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.IsDefault)
                {
                    _Level3Service.UpdateDefaultFalse();
                }
                var EntityMapped = Mapper.Map<Level3>(model);
                _Level3Service.Add(EntityMapped);
                return Json(new { data = model, success = true }, JsonRequestBehavior.AllowGet);
            }
            var errors = ModelState.GetDistinctModelErrors();
            return Json(new { data = model, success = false, ErrorsList = errors }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Delete
        [HttpPost]
        [ActAuthorize(MenuEnum.ManageLevel3)]
        public JsonResult Delete(int Id)
        {
            var Level3Entity = _Level3Service.GetById(Id);
            if (Level3Entity != null)
            {
                _Level3Service.Delete(Level3Entity);
                return Json(new { data = Id, success = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { data = Id, success = false, ErrorsList = Resources.LocalizedText.DeletedItemNotFound }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Edit
        [HttpGet]
        [ActAuthorize(MenuEnum.ManageLevel3)]
        public ActionResult Edit(int Id)
        {
            //ViewBags Info
            ViewBag.Title = Resources.PageTitle.Level3_Edit;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.Level3_Edit);
            ViewBag.Description = "";
            //Get Entity Edited
            var Level3Entity = _Level3Service.GetById(Id);
            var modelMapped = Mapper.Map<Level3ViewModel>(Level3Entity);
            return View(modelMapped);
        }
        [HttpPost]
        [ActAuthorize(MenuEnum.ManageLevel3)]
        public JsonResult Edit(Level3ViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.IsDefault)
                {
                    _Level3Service.UpdateDefaultFalse();
                }
                var Level3Entity = _Level3Service.GetById(model.Id);
                Level3Entity = Mapper.Map(model, Level3Entity);
                _Level3Service.Edit(Level3Entity);
                return Json(new { data = model, success = true }, JsonRequestBehavior.AllowGet);
            }
            var errors = ModelState.GetDistinctModelErrors();
            return Json(new { data = model, success = false, ErrorsList = errors }, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region Fill Action
        [ActAuthorize(MenuEnum.CommonAction)]
        public JsonResult FillLevel3(decimal Level2Id)
        {
            var data = _Level3Service.List(x => x.Published == true && x.Level2Id == Level2Id, orderBy: x => x.OrderBy(o => o.DisplayOrder))
            .Select(x => new { id = x.Id, text = string.Format("{0}", x.Name) });
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        #endregion

    }
}