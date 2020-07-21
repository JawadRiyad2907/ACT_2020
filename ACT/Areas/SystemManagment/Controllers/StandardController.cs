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

    public class StandardController : BaseController
    {

        #region Variable
        IStandardService _standardService;
        IUserCategoryService _userCategoryService;
        IItemService _itemService;
        #endregion
        #region Const
        public StandardController(IStandardService standardService, IUserCategoryService userCategoryService, IItemService itemService)
        {
            _standardService = standardService;
            _userCategoryService = userCategoryService;
            _itemService = itemService;
        }

        #endregion
        #region PageBarFunction
        [NonAction]
        private List<PageBarViewModel> GetPageBar(string LocPageName)
        {
            return new List<PageBarViewModel>{
                new PageBarViewModel {Order=0,Description=Resources.PageTitle.SystemAdministration,IsFirst=true },
                new PageBarViewModel {Order=1,Description=Resources.PageTitle.Item_Index  },
                 new PageBarViewModel {Order=2,Description=LocPageName,IsLast=true },
            };
        }


        #endregion



        #region Main
        [ActAuthorize(MenuEnum.Item)]
        public ActionResult Index(decimal ItemId, decimal CategoryId)
        {
            ViewBag.Title = Resources.PageTitle.Standard_Index;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.Standard_Index);
            ViewBag.Description = "";
            ViewBag.ItemId = ItemId;
            ViewBag.CategoryId = CategoryId;
            return View();
        }

        [HttpGet]
        [ActAuthorize(MenuEnum.Item)]
        public JsonResult GetStandardList(DataTableViewModel dataTableViewModel)
        {

            string SearchName = Request.QueryString["SearchName"];
            string SearchItemIdStr = Request.QueryString["SearchItemId"];
            int? SearchItemId = !string.IsNullOrEmpty(SearchItemIdStr) ? int.Parse(SearchItemIdStr) as int? : null;
            string SearchCategoryIdstr = Request.QueryString["SearchCategoryId"];
            int? SearchCategoryId = !string.IsNullOrEmpty(SearchCategoryIdstr) ? int.Parse(SearchCategoryIdstr) as int? : null;

            var data = _standardService.ListWithPaging(filter: x => x.Name.Contains(SearchName) && x.ItemId == SearchItemId && x.CategoryId == SearchCategoryId,
                orderBy: o => o.DisplayOrder,
                pageSize: dataTableViewModel.length,
                page: dataTableViewModel.start,
                includeProperties: i => i.Evidences);

            var model = Mapper.Map<IList<StandardViewModel>>(data.EntityData);
            return Json(new { data = model, recordsTotal = data.Count, recordsFiltered = data.Count }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Add
        [HttpGet]
        [ActAuthorize(MenuEnum.Item)]
        public ActionResult Add(decimal ItemId, decimal CategoryId)
        {
            ViewBag.Title = Resources.PageTitle.Standard_Add;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.Standard_Add);
            ViewBag.Description = "";
            var model = new StandardViewModel();
            model.Publish = true;
            model.ItemId = ItemId;
            model.CategoryId = CategoryId;
            return View(model);
        }
        [HttpPost]
        [ActAuthorize(MenuEnum.Item)]
        public JsonResult Add(StandardViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_standardService.IsStanderdWeightSumGreaterItem(model.CategoryId, model.ItemId, model.Id, model.Weight))
                {
                    return Json(new { data = model, success = false, ErrorsList = new string[] { Resources.LocalizedText.IsStanderdWeightSumGreaterItem } }, JsonRequestBehavior.AllowGet);
                }
                var EntityMapped = Mapper.Map<Standard>(model);
                EntityMapped.CreatedById = CurrentUser.Id;
                EntityMapped.CreatedDate = DateTime.Now;
                _standardService.Add(EntityMapped);
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
            var StandardEntity = _standardService.GetById(Id);
            if (StandardEntity != null)
            {
                _standardService.Delete(StandardEntity);
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
            ViewBag.Title = Resources.PageTitle.Standard_Edit;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.Standard_Edit);
            ViewBag.Description = "";
            //Get Entity Edited
            var StandardEntity = _standardService.GetById(Id);
            StandardEntity.LastModifiedById = CurrentUser.Id;
            StandardEntity.LastModifiedDate = DateTime.Now;
            var modelMapped = Mapper.Map<StandardViewModel>(StandardEntity);
            return View(modelMapped);
        }
        [HttpPost]
        [ActAuthorize(MenuEnum.Item)]
        public JsonResult Edit(StandardViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_standardService.IsStanderdWeightSumGreaterItem(model.CategoryId, model.ItemId, model.Id, model.Weight))
                {
                    return Json(new { data = model, success = false, ErrorsList = new string[] { Resources.LocalizedText.IsStanderdWeightSumGreaterItem } }, JsonRequestBehavior.AllowGet);
                }
                var StandardEntity = _standardService.GetById(model.Id);
                StandardEntity = Mapper.Map(model, StandardEntity);
                _standardService.Edit(StandardEntity);
                return Json(new { data = model, success = true }, JsonRequestBehavior.AllowGet);
            }
            var errors = ModelState.GetDistinctModelErrors();
            return Json(new { data = model, success = false, ErrorsList = errors }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Actions

        public ActionResult ViewCategoryAndItem(decimal ItemId, decimal CategoryId)
        {
            var model = new ViewCategoryAndItemViewModel();
            model.CategoryName = _userCategoryService.GetById(CategoryId).Name;
            model.ItemName = _itemService.GetById(ItemId).Name;
            return PartialView(model);
        }

        #endregion
    }
}