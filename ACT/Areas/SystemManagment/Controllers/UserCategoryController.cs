using ACT.Controllers;
using ACT.Models;
using ACT.Service;
using ACT.ViewModel;
using System.Web.Mvc;
using AutoMapper;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using System.Linq;
using ACT.Utilities.Extensions;
using ACT.Utilities.Enum;
using ACT.Authentication;

namespace ACT.Areas.SystemManagment.Controllers
{
    public class UserCategoryController : BaseController
    {
        #region Variable
        ILevel1Service _Level1Service;
        ILevel2Service _Level2Service;
        ILevel3Service _Level3Service;
        ILevel4Service _Level4Service;
        IUserCategoryService _UserCategoryService;
        #endregion

        #region PageBarFunction
        [NonAction]
        private List<PageBarViewModel> GetPageBar(string LocPageName)
        {
            return new List<PageBarViewModel>{
                new PageBarViewModel {Order=0,Description=Resources.PageTitle.SystemAdministration,IsFirst=true },
                 new PageBarViewModel {Order=1,Description=LocPageName,IsLast=true },
            };
        }


        #endregion

        #region Const
        public UserCategoryController(
            IUserCategoryService UserCategoryService,
             ILevel1Service Level1Service,
            ILevel2Service Level2Service,
            ILevel3Service Level3Service,
            ILevel4Service Level4Service)
        {
            _UserCategoryService = UserCategoryService;
            _Level2Service = Level2Service;
            _Level1Service = Level1Service;
            _Level3Service = Level3Service;
            _Level4Service = Level4Service;
        }

        #endregion

        #region Main
        [ActAuthorize(MenuEnum.ManageUserCategories)]
        public ActionResult Index()
        {
            ViewBag.Title = Resources.PageTitle.UserCategory_Index;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.UserCategory_Index);
            ViewBag.Description = "";
            return View();
        }

        [HttpGet]
        [ActAuthorize(MenuEnum.ManageUserCategories)]
        public JsonResult GetUserCategoryList(DataTableViewModel dataTableViewModel)
        {
            string SearchLevel1Str = Request.QueryString["SearchLevel1"];
            int? SearchLevel1 = !string.IsNullOrEmpty(SearchLevel1Str) ? int.Parse(SearchLevel1Str) as int? : null;

            string SearchLevel2Str = Request.QueryString["SearchLevel2"];
            int? SearchLevel2 = !string.IsNullOrEmpty(SearchLevel2Str) ? int.Parse(SearchLevel2Str) as int? : null;

            string SearchLevel3Str = Request.QueryString["SearchLevel3"];
            int? SearchLevel3 = !string.IsNullOrEmpty(SearchLevel3Str) ? int.Parse(SearchLevel3Str) as int? : null;

            string SearchLevel4Str = Request.QueryString["SearchLevel4"];
            int? SearchLevel4 = !string.IsNullOrEmpty(SearchLevel4Str) ? int.Parse(SearchLevel4Str) as int? : null;

            string SearchName = Request.QueryString["SearchName"];

            var includeMultiProperties = new Expression<Func<ACT.Models.UserCategory, object>>[] { x => x.Level2, y => y.Level1, z => z.Level3, t => t.Level4 };

            var data = _UserCategoryService.ListWithPaging(
                filter: x => (SearchLevel1 == null || x.Level1Id == SearchLevel1) && (SearchLevel2 == null || x.Level2Id == SearchLevel2) && (SearchLevel3 == null || x.Level3Id == SearchLevel3) && (SearchLevel4 == null || x.Level4Id == SearchLevel4) && x.Name.Contains(SearchName),
                includeProperties: includeMultiProperties,
                orderBy: o => o.DisplayOrder,
                pageSize: dataTableViewModel.length,
                page: dataTableViewModel.start);

            //fix serilaize json >>
            var dataMapped = Mapper.Map<List<UserCategoryViewModel>>(data.EntityData);
            return Json(new { data = dataMapped, recordsTotal = data.Count, recordsFiltered = data.Count }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Add
        [HttpGet]
        [ActAuthorize(MenuEnum.ManageUserCategories)]
        public ActionResult Add()
        {
            ViewBag.Title = Resources.PageTitle.UserCategory_Add;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.UserCategory_Add);
            ViewBag.Description = "";
            var model = new UserCategoryViewModel();
            model.TypeList.AddRange(UserCategoryTypeEnum.Administrative.ToSelectList());
            model.Active = true;
            return View(model);
        }
        [HttpPost]
        [ActAuthorize(MenuEnum.ManageUserCategories)]
        public JsonResult Add(UserCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var EntityMapped = Mapper.Map<UserCategory>(model);
                _UserCategoryService.Add(EntityMapped);
                return Json(new { data = model, success = true }, JsonRequestBehavior.AllowGet);
            }
            var errors = ModelState.GetDistinctModelErrors();
            return Json(new { data = model, success = false, ErrorsList = errors }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Delete
        [HttpPost]
        [ActAuthorize(MenuEnum.ManageUserCategories)]
        public JsonResult Delete(int Id)
        {
            var UserCategoryEntity = _UserCategoryService.GetById(Id);
            if (UserCategoryEntity != null)
            {
                if (UserCategoryEntity.IsSystemAdmin == true)
                {
                    return Json(new { data = Id, success = false, ErrorsList = Resources.LocalizedText.UserCategory_Validation_IsSystemAdmin }, JsonRequestBehavior.AllowGet);
                }
                _UserCategoryService.Delete(UserCategoryEntity);
                return Json(new { data = Id, success = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { data = Id, success = false, ErrorsList = Resources.LocalizedText.DeletedItemNotFound }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Edit
        [HttpGet]
        [ActAuthorize(MenuEnum.ManageUserCategories)]
        public ActionResult Edit(int Id)
        {
            //ViewBags Info
            ViewBag.Title = Resources.PageTitle.UserCategory_Edit;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.UserCategory_Edit);
            ViewBag.Description = "";
            //Get Entity Edited
            var UserCategoryEntity = _UserCategoryService.GetById(Id);
            var modelMapped = Mapper.Map<UserCategoryViewModel>(UserCategoryEntity);
            modelMapped.TypeList.AddRange(UserCategoryTypeEnum.Administrative.ToSelectList());
            return View(modelMapped);
        }
        [HttpPost]
        [ActAuthorize(MenuEnum.ManageUserCategories)]
        public JsonResult Edit(UserCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var UserCategoryEntity = _UserCategoryService.GetById(model.Id);
                UserCategoryEntity = Mapper.Map(model, UserCategoryEntity);
                _UserCategoryService.Edit(UserCategoryEntity);
                return Json(new { data = model, success = true }, JsonRequestBehavior.AllowGet);
            }
            var errors = ModelState.GetDistinctModelErrors();
            return Json(new { data = model, success = false, ErrorsList = errors }, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region Fill Action
        [HttpGet]
        [ActAuthorize(MenuEnum.CommonAction)]
        public JsonResult FillUserCategory(decimal? level1Id, decimal? level2Id, decimal? level3Id, decimal? level4Id)
        {
            var data = _UserCategoryService.GetUserCategoryLevels(level1Id, level2Id, level3Id, level4Id).Select(x => new { id = x.Id, text = string.Format("{0}", x.Name) });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [ActAuthorize(MenuEnum.CommonAction, OptionalAccessEnum.IsDirectResponsible)]
        public JsonResult FillUserCategoryForUserDirectResponsable()
        {
            var data = _UserCategoryService.GetUserCategoryLevels(CurrentUser.LevelResponsibleForMe.Level1Id, CurrentUser.LevelResponsibleForMe.Level2Id, CurrentUser.LevelResponsibleForMe.Level3Id, CurrentUser.LevelResponsibleForMe.Level4Id).Select(x => new { id = x.Id, text = string.Format("{0}", x.Name) });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}