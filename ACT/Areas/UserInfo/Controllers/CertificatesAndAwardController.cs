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
    public class CertificatesAndAwardController : BaseController
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
        ICertificatesAndAwardService _CertificatesAndAwardService;
        #endregion

        #region Const
        public CertificatesAndAwardController(ICertificatesAndAwardService CertificatesAndAwardService)
        {
            _CertificatesAndAwardService = CertificatesAndAwardService;
        }

        #endregion

        #region Main
        public ActionResult Index()
        {
            ViewBag.Title = Resources.PageTitle.CertificatesAndAward_Index;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.CertificatesAndAward_Index);
            ViewBag.Description = "";
            return View();
        }

        [HttpGet]
        public JsonResult GetCertificatesAndAwardList(DataTableViewModel dataTableViewModel)
        {
            var data = _CertificatesAndAwardService.ListWithPaging(
                filter: x => x.UserId == CurrentUser.Id,
                orderBy: o => o.CreateDate,
                pageSize: dataTableViewModel.length,
                page: dataTableViewModel.start);

            //fix serilaize json >>
            var dataMapped = Mapper.Map<List<CertificatesAndAwardViewModel>>(data.EntityData);
            return Json(new { data = dataMapped, recordsTotal = data.Count, recordsFiltered = data.Count }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Add
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Title = Resources.PageTitle.CertificatesAndAward_Add;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.CertificatesAndAward_Add);
            ViewBag.Description = "";
            var model = new CertificatesAndAwardViewModel();
            return View(model);
        }
        [HttpPost]
        public JsonResult Add(CertificatesAndAwardViewModel model)
        {
            if (ModelState.IsValid)
            {
                var EntityMapped = Mapper.Map<CertificatesAndAward>(model);
                EntityMapped.UserId = CurrentUser.Id;
                EntityMapped.CreateDate = DateTime.Now;
                _CertificatesAndAwardService.Add(EntityMapped);
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
            var CertificatesAndAwardEntity = _CertificatesAndAwardService.GetBy(x => x.Id == Id && x.UserId == CurrentUser.Id);
            if (CertificatesAndAwardEntity != null)
            {
                _CertificatesAndAwardService.Delete(CertificatesAndAwardEntity);
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
            ViewBag.Title = Resources.PageTitle.CertificatesAndAward_Edit;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.CertificatesAndAward_Edit);
            ViewBag.Description = "";
            //Get Entity Edited
            var CertificatesAndAwardEntity = _CertificatesAndAwardService.GetBy(x => x.Id == Id && x.UserId == CurrentUser.Id);
            var modelMapped = Mapper.Map<CertificatesAndAwardViewModel>(CertificatesAndAwardEntity);
            return View(modelMapped);
        }
        [HttpPost]
        public JsonResult Edit(CertificatesAndAwardViewModel model)
        {
            if (ModelState.IsValid)
            {
                var CertificatesAndAwardEntity = _CertificatesAndAwardService.GetBy(x => x.Id == model.Id && x.UserId == CurrentUser.Id);
                CertificatesAndAwardEntity = Mapper.Map(model, CertificatesAndAwardEntity);
                CertificatesAndAwardEntity.UpdateDate = DateTime.Now;
                _CertificatesAndAwardService.Edit(CertificatesAndAwardEntity);
                return Json(new { data = model, success = true }, JsonRequestBehavior.AllowGet);
            }
            var errors = ModelState.GetDistinctModelErrors();
            return Json(new { data = model, success = false, ErrorsList = errors }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}