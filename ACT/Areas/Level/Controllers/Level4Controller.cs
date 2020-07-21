using ACT.Controllers;
using ACT.Models;
using ACT.Service;
using ACT.ViewModel;
using System.Web.Mvc;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;
using ACT.Utilities.Extensions;
using ACT.Authentication;
using ACT.Utilities.Enum;

namespace ACT.Areas.Level.Controllers
{
    public class Level4Controller : BaseController
    {

        #region Variable
        ILevel1Service _Level1Service;
        ILevel2Service _Level2Service;
        ILevel3Service _Level3Service;
        ILevel4Service _Level4Service;
        ITypeEducationService _typeEducationService;
        ISchoolTypeService _SchoolTypeService;
        #endregion

        #region Const
        public Level4Controller(
            ILevel1Service Level1Service,
            ILevel2Service Level2Service,
            ILevel3Service Level3Service,
            ILevel4Service Level4Service,
            ITypeEducationService typeEducationService,
            ISchoolTypeService schoolTypeService)
        {

            _Level2Service = Level2Service;
            _Level1Service = Level1Service;
            _Level3Service = Level3Service;
            _Level4Service = Level4Service;
            _typeEducationService = typeEducationService;
            _SchoolTypeService = schoolTypeService;
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
        [ActAuthorize(MenuEnum.ManageLevel4)]
        public ActionResult Index()
        {
            ViewBag.Title = Resources.PageTitle.Level4_Index;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.Level4_Index);
            ViewBag.Description = "";
            return View();
        }


        [HttpGet]
        [ActAuthorize(MenuEnum.ManageLevel4)]
        public JsonResult GetLevel4List(DataTableViewModel dataTableViewModel)
        {
            //check if not null
            string SearchLevel1Str = Request.QueryString["SearchLevel1"];
            int? SearchLevel1 = !string.IsNullOrEmpty(SearchLevel1Str) ? int.Parse(SearchLevel1Str) as int? : null;

            string SearchLevel2Str = Request.QueryString["SearchLevel2"];
            int? SearchLevel2 = !string.IsNullOrEmpty(SearchLevel2Str) ? int.Parse(SearchLevel2Str) as int? : null;

            string SearchLevel3Str = Request.QueryString["SearchLevel3"];
            int? SearchLevel3 = !string.IsNullOrEmpty(SearchLevel3Str) ? int.Parse(SearchLevel3Str) as int? : null;

            string SearchName = Request.QueryString["SearchName"];


            var includeMultiProperties = new Expression<Func<Level4, object>>[] { x => x.Level2, y => y.Level1, z => z.Level3, t => t.TypeEducation, s => s.SchoolType };

            var data = _Level4Service.ListWithPaging(
                filter: x => (SearchLevel1 == null || x.Level1Id == SearchLevel1) && (SearchLevel2 == null || x.Level2Id == SearchLevel2) && (SearchLevel3 == null || x.Level3Id == SearchLevel3) && x.Name.Contains(SearchName),
                includeProperties: includeMultiProperties,
                orderBy: o => o.DisplayOrder,
                pageSize: dataTableViewModel.length,
                page: dataTableViewModel.start);

            //fix serilaize json >>
            var dataMapped = Mapper.Map<List<Level4ViewModel>>(data.EntityData);
            return Json(new { data = dataMapped, recordsTotal = data.Count, recordsFiltered = data.Count }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Add
        [HttpGet]
        [ActAuthorize(MenuEnum.ManageLevel4)]
        public ActionResult Add()
        {
            ViewBag.Title = Resources.PageTitle.Level4_Add;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.Level4_Add);
            ViewBag.Description = "";
            var model = new Level4ViewModel();
            model.Published = true;
            return View(model);
        }
        [HttpPost]
        [ActAuthorize(MenuEnum.ManageLevel4)]
        public JsonResult Add(Level4ViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.IsDefault)
                {
                    _Level4Service.UpdateDefaultFalse();
                }
                var EntityMapped = Mapper.Map<Level4>(model);
                _Level4Service.Add(EntityMapped);
                return Json(new { data = model, success = true }, JsonRequestBehavior.AllowGet);
            }
            var errors = ModelState.GetDistinctModelErrors();
            return Json(new { data = model, success = false, ErrorsList = errors }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Delete
        [HttpPost]
        [ActAuthorize(MenuEnum.ManageLevel4)]
        public JsonResult Delete(int Id)
        {
            var Level4Entity = _Level4Service.GetById(Id);
            if (Level4Entity != null)
            {
                _Level4Service.Delete(Level4Entity);
                return Json(new { data = Id, success = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { data = Id, success = false, ErrorsList = Resources.LocalizedText.DeletedItemNotFound }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Edit
        [HttpGet]
        [ActAuthorize(MenuEnum.ManageLevel4)]
        public ActionResult Edit(int Id)
        {
            //ViewBags Info
            ViewBag.Title = Resources.PageTitle.Level4_Edit;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.Level4_Edit);
            ViewBag.Description = "";
            //Get Entity Edited
            var Level4Entity = _Level4Service.GetById(Id);
            var modelMapped = Mapper.Map<Level4ViewModel>(Level4Entity);
            return View(modelMapped);
        }
        [HttpPost]
        [ActAuthorize(MenuEnum.ManageLevel4)]
        public JsonResult Edit(Level4ViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.IsDefault)
                {
                    _Level4Service.UpdateDefaultFalse();
                }
                var Level4Entity = _Level4Service.GetById(model.Id);
                Level4Entity = Mapper.Map(model, Level4Entity);
                _Level4Service.Edit(Level4Entity);
                return Json(new { data = model, success = true }, JsonRequestBehavior.AllowGet);
            }
            var errors = ModelState.GetDistinctModelErrors();
            return Json(new { data = model, success = false, ErrorsList = errors }, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region Fill Action
        [ActAuthorize(MenuEnum.CommonAction)]
        public JsonResult FillLevel4(decimal Level3Id)
        {
            var data = _Level4Service.List(x => x.Published == true && x.Level3Id == Level3Id, orderBy: x => x.OrderBy(o => o.DisplayOrder))
            .Select(x => new { id = x.Id, text = string.Format("{0}", x.Name) });
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        [ActAuthorize(MenuEnum.CommonAction)]
        public JsonResult FillTypeEducation()
        {
            var data = _typeEducationService.List()
            .Select(x => new { id = x.Id, text = string.Format("{0}", x.TypeName) });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [ActAuthorize(MenuEnum.CommonAction)]
        public JsonResult FillSchoolType()
        {
            var data = _SchoolTypeService.List()
            .Select(x => new { id = x.Id, text = string.Format("{0}", x.TypeName) });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}