using ACT.Authentication;
using ACT.Controllers;
using ACT.Models;
using ACT.Service;
using ACT.Utilities.Enum;
using ACT.Utilities.Extensions;
using ACT.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace ACT.Areas.WorkPlanning.Controllers
{
    [ActAuthorize(MenuEnum.EducationalUnits, OptionalAccessEnum.IsDirectResponsible)]
    public class EducationalUnitsController : BaseController
    {
        #region Variable
        IEnterpriseUnitService _enterpriseUnitService;
        #endregion

        #region Const
        public EducationalUnitsController(IEnterpriseUnitService enterpriseUnitService)
        {
            _enterpriseUnitService = enterpriseUnitService;
        }

        #endregion

        #region PageBarFunction
        [NonAction]
        private List<PageBarViewModel> GetPageBar(string LocPageName)
        {
            return new List<PageBarViewModel>{
                new PageBarViewModel {Order=0,Description=Resources.PageTitle.WorkPlanning,IsFirst=true },
                new PageBarViewModel {Order=1,Description=Resources.PageTitle.EnterpriseUnits  },
                 new PageBarViewModel {Order=2,Description=LocPageName,IsLast=true },
            };
        }


        #endregion


        #region Main



        public ActionResult Index()
        {
            ViewBag.Title = Resources.PageTitle.EducationalUnits_Index;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.EducationalUnits_Index);
            ViewBag.Description = "";
            return View();
        }


        public ActionResult TreeListUnits()
        {

            string SearchName = Request.QueryString["SearchName"];
            var data = _enterpriseUnitService.ListWithPaging(
                filter: x => x.EnterpriseUnitsType == (short)EnterpriseUnitsTypeEnum.Educational && (x.Level1Id == CurrentUser.LevelResponsibleForMe.Level1Id) && (x.Level2Id == CurrentUser.LevelResponsibleForMe.Level2Id) && (x.Level3Id == CurrentUser.LevelResponsibleForMe.Level3Id) && (x.Level4Id == CurrentUser.LevelResponsibleForMe.Level4Id) && x.Name.Contains(SearchName),
                orderBy: o => o.DisplayOrder,
                 includeProperties: x => x.UnitUsers.Select(u => u.User));
            //fix serilaize json 
            var dataMapped = Mapper.Map<List<EducationalUnitsViewModel>>(data.EntityData);
            dataMapped = dataMapped.Where(x => x.Parent == null).ToList();
            return Json(new { data = dataMapped, recordsTotal = data.Count, recordsFiltered = data.Count }, JsonRequestBehavior.AllowGet);
        }



        #endregion


        #region Add
        [HttpGet]

        public ActionResult Add(decimal? ParentId)
        {
            ViewBag.Title = Resources.PageTitle.UserCategory_Add;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.EducationalUnits_Add);
            ViewBag.Description = "";
            var model = new EducationalUnitsViewModel();
            if (ParentId.HasValue)
            {
                model.Parent = ParentId;
                model.ParentName = _enterpriseUnitService.GetById(ParentId).Name;
            }
            return View(model);
        }
        [HttpPost]

        public JsonResult Add(EducationalUnitsViewModel model)
        {
            if (ModelState.IsValid)
            {

                var EntityMapped = Mapper.Map<EnterpriseUnit>(model);
                EntityMapped.Level1Id = CurrentUser.LevelResponsibleForMe.Level1Id;
                EntityMapped.Level2Id = CurrentUser.LevelResponsibleForMe.Level2Id;
                EntityMapped.Level3Id = CurrentUser.LevelResponsibleForMe.Level3Id;
                EntityMapped.Level4Id = CurrentUser.LevelResponsibleForMe.Level4Id;
                EntityMapped.EnterpriseUnitsType = (int)EnterpriseUnitsTypeEnum.Educational;
                EntityMapped.CreatedDate = DateTime.Now;
                EntityMapped.CreatedById = CurrentUser.Id;
                _enterpriseUnitService.Add(EntityMapped);
                return Json(new { data = model, success = true }, JsonRequestBehavior.AllowGet);
            }
            var errors = ModelState.GetDistinctModelErrors();
            return Json(new { data = model, success = false, ErrorsList = errors }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Edit
        [HttpGet]

        public ActionResult Edit(int Id)
        {
            //ViewBags Info
            ViewBag.Title = Resources.PageTitle.EducationalUnits_Edit;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.EducationalUnits_Edit);
            ViewBag.Description = "";
            //Get Entity Edited
            var EducationalUnitsEntity = _enterpriseUnitService.GetBy(x => x.Id == Id, false, x => x.EnterpriseUnit1);
            var modelMapped = Mapper.Map<EducationalUnitsViewModel>(EducationalUnitsEntity);
            return View(modelMapped);
        }
        [HttpPost]

        public JsonResult Edit(EducationalUnitsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var EducationalUnitsEntity = _enterpriseUnitService.GetById(model.Id);
                EducationalUnitsEntity = Mapper.Map(model, EducationalUnitsEntity);
                _enterpriseUnitService.Edit(EducationalUnitsEntity);
                return Json(new { data = model, success = true }, JsonRequestBehavior.AllowGet);
            }
            var errors = ModelState.GetDistinctModelErrors();
            return Json(new { data = model, success = false, ErrorsList = errors }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Delete
        [HttpPost]

        public JsonResult Delete(int Id)
        {
            var UserEntity = _enterpriseUnitService.GetById(Id);
            if (UserEntity != null)
            {
                _enterpriseUnitService.Delete(UserEntity);
                return Json(new { data = Id, success = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { data = Id, success = false, ErrorsList = Resources.LocalizedText.DeletedItemNotFound }, JsonRequestBehavior.AllowGet);
        }
        #endregion


    }
}