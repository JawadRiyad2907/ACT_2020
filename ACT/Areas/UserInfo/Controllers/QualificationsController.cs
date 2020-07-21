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
    public class QualificationsController : BaseController
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
        IQualificationService _QualificationService;
        ICientificDegreeService _cientificDegreeService;
        #endregion

        #region Const
        public QualificationsController(IQualificationService QualificationService,
            ICientificDegreeService cientificDegreeService)
        {
            _QualificationService = QualificationService;
            _cientificDegreeService = cientificDegreeService;
        }

        #endregion

        #region Main
        public ActionResult Index()
        {
            ViewBag.Title = Resources.PageTitle.Qualification_Index;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.Qualification_Index);
            ViewBag.Description = "";
            return View();
        }

        [HttpGet]
        public JsonResult GetQualificationList(DataTableViewModel dataTableViewModel)
        {
            var data = _QualificationService.ListWithPaging(
                filter: x => x.UserId == CurrentUser.Id,
                includeProperties: x => x.CientificDegree,
                orderBy: o => o.Year,
                pageSize: dataTableViewModel.length,
                page: dataTableViewModel.start);

            //fix serilaize json >>
            var dataMapped = Mapper.Map<List<QualificationViewModel>>(data.EntityData);
            return Json(new { data = dataMapped, recordsTotal = data.Count, recordsFiltered = data.Count }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Add
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Title = Resources.PageTitle.Qualification_Add;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.Qualification_Add);
            ViewBag.Description = "";
            var model = new QualificationViewModel();
            model.AlvailableDegreeList = _cientificDegreeService.List().Select(x =>
                                  new SelectListItem()
                                  {
                                      Value = x.Id.ToString(),
                                      Text = x.Name.ToString()

                                  }).ToList();
            return View(model);
        }
        [HttpPost]
        public JsonResult Add(QualificationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var EntityMapped = Mapper.Map<Qualification>(model);
                EntityMapped.UserId = CurrentUser.Id;
                EntityMapped.CreatedDate = DateTime.Now;
                _QualificationService.Add(EntityMapped);
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
            var QualificationEntity = _QualificationService.GetBy(x => x.Id == Id && x.UserId == CurrentUser.Id);
            if (QualificationEntity != null)
            {
                _QualificationService.Delete(QualificationEntity);
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
            ViewBag.Title = Resources.PageTitle.Qualification_Edit;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.Qualification_Edit);
            ViewBag.Description = "";
            //Get Entity Edited
            var QualificationEntity = _QualificationService.GetBy(x => x.Id == Id && x.UserId == CurrentUser.Id);
            var modelMapped = Mapper.Map<QualificationViewModel>(QualificationEntity);
            modelMapped.AlvailableDegreeList = _cientificDegreeService.List().Select(x =>
                                new SelectListItem()
                                {
                                    Value = x.Id.ToString(),
                                    Text = x.Name.ToString()

                                }).ToList();
            return View(modelMapped);
        }
        [HttpPost]
        public JsonResult Edit(QualificationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var QualificationEntity = _QualificationService.GetBy(x => x.Id == model.Id && x.UserId == CurrentUser.Id);
                QualificationEntity = Mapper.Map(model, QualificationEntity);
                QualificationEntity.UpdateDate = DateTime.Now;
                _QualificationService.Edit(QualificationEntity);
                return Json(new { data = model, success = true }, JsonRequestBehavior.AllowGet);
            }
            var errors = ModelState.GetDistinctModelErrors();
            return Json(new { data = model, success = false, ErrorsList = errors }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}