using ACT.Controllers;
using ACT.Models;
using ACT.Service;
using ACT.ViewModel;
using System.Web.Mvc;
using AutoMapper;
using ACT.Utilities.Extensions;
using System.Collections.Generic;
using System.Linq;
using ACT.Authentication;
using ACT.Utilities.Enum;

namespace ACT.Areas.Level.Controllers
{

    public class Level1Controller : BaseController
    {

        #region Variable
        ILevel1Service _level1Service;
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

        #region Const
        public Level1Controller(ILevel1Service level1Service)
        {
            _level1Service = level1Service;
        }

        #endregion

        #region Main
        [ActAuthorize(MenuEnum.ManageLevel1)]
        public ActionResult Index()
        {
            ViewBag.Title = Resources.PageTitle.Level1_Index;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.Level1_Index);
            ViewBag.Description = "";
            return View();
        }

        [HttpGet]
        [ActAuthorize(MenuEnum.ManageLevel1)]
        public JsonResult GetLevel1List(DataTableViewModel dataTableViewModel)
        {

            string SearchName = Request.QueryString["SearchName"];

            var data = _level1Service.ListWithPaging(filter: x => x.Name.Contains(SearchName),
                orderBy: o => o.DisplayOrder,
                pageSize: dataTableViewModel.length,
                page: dataTableViewModel.start);

            return Json(new { data = data.EntityData, recordsTotal = data.Count, recordsFiltered = data.Count }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Add
        [HttpGet]
        [ActAuthorize(MenuEnum.ManageLevel1)]
        public ActionResult Add()
        {
            ViewBag.Title = Resources.PageTitle.Level1_Add;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.Level1_Add);
            ViewBag.Description = "";
            var model = new Level1ViewModel();
            model.Published = true;
            return View(model);
        }
        [HttpPost]
        [ActAuthorize(MenuEnum.ManageLevel1)]
        public JsonResult Add(Level1ViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.IsDefault)
                {
                    _level1Service.UpdateDefaultFalse();
                }
                var EntityMapped = Mapper.Map<Level1>(model);
                _level1Service.Add(EntityMapped);
                return Json(new { data = model, success = true }, JsonRequestBehavior.AllowGet);
            }
            var errors = ModelState.GetDistinctModelErrors();
            return Json(new { data = model, success = false, ErrorsList = errors }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Delete
        [HttpPost]
        [ActAuthorize(MenuEnum.ManageLevel1)]
        public JsonResult Delete(int Id)
        {
            var Level1Entity = _level1Service.GetById(Id);
            if (Level1Entity != null)
            {
                _level1Service.Delete(Level1Entity);
                return Json(new { data = Id, success = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { data = Id, success = false, ErrorsList = Resources.LocalizedText.DeletedItemNotFound }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Edit
        [HttpGet]
        [ActAuthorize(MenuEnum.ManageLevel1)]
        public ActionResult Edit(int Id)
        {
            //ViewBags Info
            ViewBag.Title = Resources.PageTitle.Level1_Edit;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.Level1_Edit);
            ViewBag.Description = "";
            //Get Entity Edited
            var Level1Entity = _level1Service.GetById(Id);
            var modelMapped = Mapper.Map<Level1ViewModel>(Level1Entity);
            return View(modelMapped);
        }
        [HttpPost]
        [ActAuthorize(MenuEnum.ManageLevel1)]
        public JsonResult Edit(Level1ViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.IsDefault)
                {
                    _level1Service.UpdateDefaultFalse();
                }
                var Level1Entity = _level1Service.GetById(model.Id);
                Level1Entity = Mapper.Map(model, Level1Entity);
                _level1Service.Edit(Level1Entity);
                return Json(new { data = model, success = true }, JsonRequestBehavior.AllowGet);
            }
            var errors = ModelState.GetDistinctModelErrors();
            return Json(new { data = model, success = false, ErrorsList = errors }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Fill
        [HttpGet]
        [ActAuthorize(MenuEnum.CommonAction)]
        public JsonResult FillLevel1()
        {
            var data = _level1Service.List(x => x.Published, orderBy: x => x.OrderBy(o => o.DisplayOrder))
            .Select(x => new { id = x.Id, text = string.Format("{0}", x.Name) });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion


    }
}