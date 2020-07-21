using ACT.Controllers;
using ACT.Models;
using ACT.Service;
using ACT.ViewModel;
using System.Web.Mvc;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System;
using ACT.Utilities.Extensions;
using ACT.Authentication;
using ACT.Utilities.Enum;

namespace ACT.Areas.Level.Controllers
{
    public class Level2Controller : BaseController
    {

        #region Variable
        ILevel2Service _Level2Service;
        ILevel1Service _Level1Service;
        #endregion

        #region Const
        public Level2Controller(ILevel1Service Level1Service, ILevel2Service Level2Service)
        {
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
        [ActAuthorize(MenuEnum.ManageLevel2)]
        public ActionResult Index()
        {
            ViewBag.Title = Resources.PageTitle.Level2_Index;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.Level2_Index);
            ViewBag.Description = "";
            return View();
        }


        [HttpGet]
        [ActAuthorize(MenuEnum.ManageLevel2)]
        public JsonResult GetLevel2List(DataTableViewModel dataTableViewModel)
        {
            //check if not null
            string SearchLevel1Str = Request.QueryString["SearchLevel1"];
            int? SearchLevel1 = !string.IsNullOrEmpty(SearchLevel1Str) ? int.Parse(SearchLevel1Str) as int? : null;

            string SearchName = Request.QueryString["SearchName"];


            var data = _Level2Service.ListWithPaging(
                filter: x => (SearchLevel1 == null || x.Level1Id == SearchLevel1) && x.Name.Contains(SearchName),
                includeProperties: x => x.Level1,
                orderBy: o => o.DisplayOrder,
                pageSize: dataTableViewModel.length,
                page: dataTableViewModel.start);

            //fix serilaize json >>
            var dataMapped = Mapper.Map<List<Level2ViewModel>>(data.EntityData);
            return Json(new { data = dataMapped, recordsTotal = data.Count, recordsFiltered = data.Count }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Add
        [HttpGet]
        [ActAuthorize(MenuEnum.ManageLevel2)]
        public ActionResult Add()
        {
            ViewBag.Title = Resources.PageTitle.Level2_Add;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.Level2_Add);
            ViewBag.Description = "";
            var model = new Level2ViewModel();
            model.Published = true;
            return View(model);
        }
        [HttpPost]
        [ActAuthorize(MenuEnum.ManageLevel2)]
        public JsonResult Add(Level2ViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.IsDefault)
                {
                    _Level2Service.UpdateDefaultFalse();
                }
                var EntityMapped = Mapper.Map<Level2>(model);
                _Level2Service.Add(EntityMapped);
                return Json(new { data = model, success = true }, JsonRequestBehavior.AllowGet);
            }
            var errors = ModelState.GetDistinctModelErrors();
            return Json(new { data = model, success = false, ErrorsList = errors }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Delete
        [HttpPost]
        [ActAuthorize(MenuEnum.ManageLevel2)]
        public JsonResult Delete(int Id)
        {
            var Level2Entity = _Level2Service.GetById(Id);
            if (Level2Entity != null)
            {
                _Level2Service.Delete(Level2Entity);
                return Json(new { data = Id, success = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { data = Id, success = false, ErrorsList = Resources.LocalizedText.DeletedItemNotFound }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Edit
        [HttpGet]
        [ActAuthorize(MenuEnum.ManageLevel2)]
        public ActionResult Edit(int Id)
        {
            //ViewBags Info
            ViewBag.Title = Resources.PageTitle.Level2_Edit;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.Level2_Edit);
            ViewBag.Description = "";
            //Get Entity Edited
            var Level2Entity = _Level2Service.GetById(Id);
            var modelMapped = Mapper.Map<Level2ViewModel>(Level2Entity);
            return View(modelMapped);
        }
        [HttpPost]
        [ActAuthorize(MenuEnum.ManageLevel2)]
        public JsonResult Edit(Level2ViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.IsDefault)
                {
                    _Level2Service.UpdateDefaultFalse();
                }
                var Level2Entity = _Level2Service.GetById(model.Id);
                Level2Entity = Mapper.Map(model, Level2Entity);
                _Level2Service.Edit(Level2Entity);
                return Json(new { data = model, success = true }, JsonRequestBehavior.AllowGet);
            }
            var errors = ModelState.GetDistinctModelErrors();
            return Json(new { data = model, success = false, ErrorsList = errors }, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region Fill Action
        [HttpGet]
        [ActAuthorize(MenuEnum.CommonAction)]
        public JsonResult FillLevel2(decimal level1Id)
        {
            var data = _Level2Service.List(x => x.Published == true && x.Level1Id == level1Id, orderBy: x => x.OrderBy(o => o.DisplayOrder))
                  .Select(x => new { id = x.Id, text = string.Format("{0}", x.Name) });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}