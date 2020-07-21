
using ACT.Authentication;
using ACT.Controllers;
using ACT.Service.JobTitle;
using ACT.Utilities.Enum;
using ACT.Utilities.Extensions;
using ACT.ViewModel;
using ACT.ViewModel.JobTitle;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace ACT.Areas.SystemManagment.Controllers
{
    public class JobTitleController : BaseController
    {


        #region Variable
        private readonly IJobTitleService _jobTitleService;
        #endregion

        #region ctor
        public JobTitleController(IJobTitleService jobTitleService)
        {
            _jobTitleService = jobTitleService;
        }
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

        #region Actinos
        [ActAuthorize(MenuEnum.JobTitleManagement)]
        public ActionResult Index()
        {
            ViewBag.Title = Resources.PageTitle.JobTitle_Index;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.JobTitle_Index);
            ViewBag.Description = "";
            return View();
        }

        #endregion

        #region Add
        [HttpGet]
        [ActAuthorize(MenuEnum.JobTitleManagement)]
        public ActionResult Add()
        {
            ViewBag.Title = Resources.PageTitle.JobTitle_Add;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.JobTitle_Add);
            ViewBag.Description = "";
            var model = new JobTitleViewModel();
            model.Active = true;
            return View(model);
        }
        [HttpPost]
        [ActAuthorize(MenuEnum.JobTitleManagement)]
        public JsonResult Add(JobTitleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var EntityMapped = Mapper.Map<Models.JobTitle>(model);
                _jobTitleService.Add(EntityMapped);
                return Json(new { data = model, success = true }, JsonRequestBehavior.AllowGet);
            }
            var errors = ModelState.GetDistinctModelErrors();
            return Json(new { data = model, success = false, ErrorsList = errors }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Edit 
        [ActAuthorize(MenuEnum.JobTitleManagement)]
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.Title = Resources.PageTitle.JobTitle_Edit;
                ViewBag.PageBar = GetPageBar(Resources.PageTitle.JobTitle_Edit);
                ViewBag.Description = "";
                var jobTitleEntity = _jobTitleService.GetById(id);
                var modelMapped = Mapper.Map<JobTitleViewModel>(jobTitleEntity);
                return View(modelMapped);
            }
            catch (Exception ex)
            {

                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                throw;
            }

        }
        [HttpPost]
        [ActAuthorize(MenuEnum.JobTitleManagement)]
        public JsonResult Edit(JobTitleViewModel model)
        {

            if (ModelState.IsValid)
            {
                var EntityMapped = Mapper.Map<Models.JobTitle>(model);
                _jobTitleService.Edit(EntityMapped);
                return Json(new { data = model, success = true }, JsonRequestBehavior.AllowGet);
            }
            var errors = ModelState.GetDistinctModelErrors();
            return Json(new { data = model, success = false, ErrorsList = errors }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Delete
        [HttpPost]
        [ActAuthorize(MenuEnum.JobTitleManagement)]
        public JsonResult Delete(int Id)
        {
            var jobTitleEntity = _jobTitleService.GetById(Id);
            if (jobTitleEntity != null)
            {
                _jobTitleService.Delete(jobTitleEntity);
                return Json(new { data = Id, success = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { data = Id, success = false, ErrorsList = Resources.LocalizedText.DeletedItemNotFound }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Json
        [HttpGet]
        [ActAuthorize(MenuEnum.JobTitleManagement)]
        public JsonResult GetJobTitle(DataTableViewModel dataTableViewModel)
        {
            string SearchLevel1Str = Request.QueryString["SearchLevel1"];
            decimal? SearchLevel1 = !string.IsNullOrEmpty(SearchLevel1Str) ? decimal.Parse(SearchLevel1Str) as decimal? : null;

            string SearchLevel2Str = Request.QueryString["SearchLevel2"];
            decimal? SearchLevel2 = !string.IsNullOrEmpty(SearchLevel2Str) ? decimal.Parse(SearchLevel2Str) as decimal? : null;

            string SearchLevel3Str = Request.QueryString["SearchLevel3"];
            decimal? SearchLevel3 = !string.IsNullOrEmpty(SearchLevel3Str) ? decimal.Parse(SearchLevel3Str) as decimal? : null;

            string SearchLevel4Str = Request.QueryString["SearchLevel4"];
            decimal? SearchLevel4 = !string.IsNullOrEmpty(SearchLevel4Str) ? decimal.Parse(SearchLevel4Str) as decimal? : null;

            string SearchUserCategoryStr = Request.QueryString["SearchUserCategory"];
            decimal? SearchUserCategory = !string.IsNullOrEmpty(SearchUserCategoryStr) ? decimal.Parse(SearchUserCategoryStr) as decimal? : null;

            string SearchName = Request.QueryString["SearchName"];

            var includeMultiProperties = new Expression<Func<ACT.Models.JobTitle, object>>[] { x => x.UserCategory };
            var data = _jobTitleService.ListWithPaging(
                filter: x => (SearchLevel1 == null || x.Level1Id == SearchLevel1) && (SearchLevel2 == null || x.Level2Id == SearchLevel2) && (SearchLevel3 == null || x.Level3Id == SearchLevel3) && (SearchLevel4 == null || x.Level4Id == SearchLevel4) && (SearchUserCategory == null || x.UserCategoryId == SearchUserCategory) && x.JobName.Contains(SearchName),
                includeProperties: includeMultiProperties,
                orderBy: o => o.DisplayOrder,
                pageSize: dataTableViewModel.length,
                page: dataTableViewModel.start);

            //fix serilaize json >>
            var dataMapped = Mapper.Map<List<JobTitleViewModel>>(data.EntityData);
            return Json(new { data = dataMapped, recordsTotal = data.Count, recordsFiltered = data.Count }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Fill Action
        [ActAuthorize(MenuEnum.CommonAction)]
        public JsonResult FillJobTitle(decimal? UserCategoryId)
        {
            var data = _jobTitleService.List(x => x.Active && UserCategoryId.HasValue && x.UserCategoryId == UserCategoryId, orderBy: x => x.OrderBy(o => o.DisplayOrder))
            .Select(x => new { id = x.Id, text = string.Format("{0}", x.JobName) });
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [ActAuthorize(MenuEnum.CommonAction, OptionalAccessEnum.IsDirectResponsible)]
        public JsonResult FillJobTitleForUserDirectResponsable(decimal? UserCategoryId)
        {
            var data = _jobTitleService.List(
            x => x.Active &&
             UserCategoryId.HasValue && x.UserCategoryId == UserCategoryId &&
            x.Level1Id == CurrentUser.LevelResponsibleForMe.Level1Id &&
             x.Level2Id == CurrentUser.LevelResponsibleForMe.Level2Id &&
              x.Level3Id == CurrentUser.LevelResponsibleForMe.Level3Id &&
               x.Level4Id == CurrentUser.LevelResponsibleForMe.Level4Id 
            , orderBy: x => x.OrderBy(o => o.DisplayOrder))
            .Select(x => new { id = x.Id, text = string.Format("{0}", x.JobName) });
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
