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
using System;

namespace ACT.Areas.UserInfo.Controllers
{
    [ActAuthorize(MenuEnum.MyInfo)]
    public class CourseController : BaseController
    {
        #region PageBarFunction
        [NonAction]
        private List<PageBarViewModel> GetPageBar(string LocPageName)
        {
            return new List<PageBarViewModel>{
                new PageBarViewModel {Order=0,Description=Resources.PageTitle.UserInfo,IsFirst=true },
                 new PageBarViewModel {Order=2,Description=LocPageName,IsLast=true },
            };
        }


        #endregion


        #region Variable
        ICourseService _courseService;
        #endregion

        #region Const
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        #endregion

        #region Main
        public ActionResult Index()
        {
            ViewBag.Title = Resources.PageTitle.Course_Index;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.Course_Index);
            ViewBag.Description = "";
            return View();
        }

        [HttpGet]
        public JsonResult GetCourseList(DataTableViewModel dataTableViewModel)
        {
            var data = _courseService.ListWithPaging(
                filter: x => x.UserId == CurrentUser.Id,
                orderBy: o => o.CreatedDate,
                pageSize: dataTableViewModel.length,
                page: dataTableViewModel.start);

            //fix serilaize json >>
            var dataMapped = Mapper.Map<List<CourseViewModel>>(data.EntityData);
            return Json(new { data = dataMapped, recordsTotal = data.Count, recordsFiltered = data.Count }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Add
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Title = Resources.PageTitle.Course_Add;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.Course_Add);
            ViewBag.Description = "";
            var model = new CourseViewModel();
            return View(model);
        }
        [HttpPost]
        public JsonResult Add(CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var EntityMapped = Mapper.Map<Course>(model);
                EntityMapped.UserId = CurrentUser.Id;
                EntityMapped.CreatedDate = DateTime.Now;
                _courseService.Add(EntityMapped);
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
            var CourseEntity = _courseService.GetBy(x => x.Id == Id && x.UserId == CurrentUser.Id);
            if (CourseEntity != null)
            {
                _courseService.Delete(CourseEntity);
                return Json(new { data = Id, success = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { data = Id, success = false, ErrorsList = Resources.LocalizedText.DeletedItemNotFound }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Edit
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            //ViewBags Info
            ViewBag.Title = Resources.PageTitle.Course_Edit;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.Course_Edit);
            ViewBag.Description = "";
            //Get Entity Edited
            var CourseEntity = _courseService.GetBy(x => x.Id == Id && x.UserId == CurrentUser.Id);
            var modelMapped = Mapper.Map<CourseViewModel>(CourseEntity);
            return View(modelMapped);
        }
        [HttpPost]
        public JsonResult Edit(CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var CourseEntity = _courseService.GetBy(x => x.Id == model.Id && x.UserId == CurrentUser.Id);
                CourseEntity = Mapper.Map(model, CourseEntity);
                CourseEntity.UpdateDate = DateTime.Now;
                _courseService.Edit(CourseEntity);
                return Json(new { data = model, success = true }, JsonRequestBehavior.AllowGet);
            }
            var errors = ModelState.GetDistinctModelErrors();
            return Json(new { data = model, success = false, ErrorsList = errors }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}