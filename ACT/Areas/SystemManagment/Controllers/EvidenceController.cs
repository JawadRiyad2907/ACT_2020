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

namespace ACT.Areas.SystemManagment.Controllers
{

    public class EvidenceController : BaseController
    {

        #region Variable
        IEvidenceService _evidenceService;
        IStandardService _standardService;
        #endregion
        #region Const
        public EvidenceController(IEvidenceService evidenceService, IStandardService standardService)
        {
            _evidenceService = evidenceService;
            _standardService = standardService;
        }

        #endregion

        #region PageBarFunction
        [NonAction]
        private List<PageBarViewModel> GetPageBar(string LocPageName)
        {
            return new List<PageBarViewModel>{
                new PageBarViewModel {Order=0,Description=Resources.PageTitle.SystemAdministration,IsFirst=true },
                new PageBarViewModel {Order=1,Description=Resources.PageTitle.Item_Index  },
                 new PageBarViewModel {Order=1,Description=Resources.PageTitle.Standard_Index  },
                 new PageBarViewModel {Order=2,Description=LocPageName,IsLast=true },
            };
        }


        #endregion

        #region Main
        [ActAuthorize(MenuEnum.Item)]
        public ActionResult Index(decimal StandardId)
        {
            ViewBag.Title = Resources.PageTitle.Evidence_Index;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.Evidence_Index);
            ViewBag.Standard = Mapper.Map<StandardViewModel>(_standardService.GetById(StandardId));
            return View();
        }

        [HttpGet]
        [ActAuthorize(MenuEnum.Item)]
        public JsonResult GetEvidenceList(DataTableViewModel dataTableViewModel)
        {

            string SearchName = Request.QueryString["SearchName"];
            decimal SearchStandardId = Request.QueryString["SearchStandardId"].ToNullableDecimal().Value;
            var data = _evidenceService.ListWithPaging(filter: x => x.EvidenceDescription.Contains(SearchName) && x.StandardId == SearchStandardId,
                orderBy: o => o.DisplayOrder,
                pageSize: dataTableViewModel.length,
                page: dataTableViewModel.start);

            return Json(new { data = data.EntityData, recordsTotal = data.Count, recordsFiltered = data.Count }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Add
        [HttpGet]
        [ActAuthorize(MenuEnum.Item)]
        public ActionResult Add(decimal StandardId)
        {
            ViewBag.Title = Resources.PageTitle.Evidence_Add;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.Evidence_Add);
            var model = new EvidenceViewModel();
            model.StandardId = StandardId;
            return View(model);
        }
        [HttpPost]
        [ActAuthorize(MenuEnum.Item)]
        public JsonResult Add(EvidenceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var EntityMapped = Mapper.Map<Evidence>(model);
                EntityMapped.CreatedById = CurrentUser.Id;
                EntityMapped.CreatedDate = DateTime.Now;
                _evidenceService.Add(EntityMapped);
                return Json(new { data = model, success = true }, JsonRequestBehavior.AllowGet);
            }
            var errors = ModelState.GetDistinctModelErrors();
            return Json(new { data = model, success = false, ErrorsList = errors }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Delete
        [HttpPost]
        [ActAuthorize(MenuEnum.Item)]
        public JsonResult Delete(int Id)
        {
            var EvidenceEntity = _evidenceService.GetById(Id);
            if (EvidenceEntity != null)
            {
                _evidenceService.Delete(EvidenceEntity);
                return Json(new { data = Id, success = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { data = Id, success = false, ErrorsList = Resources.LocalizedText.DeletedItemNotFound }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Edit
        [HttpGet]
        [ActAuthorize(MenuEnum.Item)]
        public ActionResult Edit(int Id)
        {
            //ViewBags Info
            ViewBag.Title = Resources.PageTitle.Evidence_Edit;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.Evidence_Edit);
            //Get Entity Edited
            var EvidenceEntity = _evidenceService.GetById(Id);
            var modelMapped = Mapper.Map<EvidenceViewModel>(EvidenceEntity);
            return View(modelMapped);
        }
        [HttpPost]
        [ActAuthorize(MenuEnum.Item)]
        public JsonResult Edit(EvidenceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var EvidenceEntity = _evidenceService.GetById(model.Id);
                EvidenceEntity = Mapper.Map(model, EvidenceEntity);
                _evidenceService.Edit(EvidenceEntity);
                return Json(new { data = model, success = true }, JsonRequestBehavior.AllowGet);
            }
            var errors = ModelState.GetDistinctModelErrors();
            return Json(new { data = model, success = false, ErrorsList = errors }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Actions
        public ActionResult ViewCategoryAndItemAndStandard(decimal StandardId)
        {
            var standardEntity = _standardService.GetBy(x => x.Id == StandardId, false, i => i.Item, i => i.UserCategory);
            var model = Mapper.Map<ViewCategoryAndItemStandardViewModel>(standardEntity);
            return PartialView(model);
        }

        #endregion
    }
}