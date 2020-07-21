using ACT.Authentication;
using ACT.Controllers;
using ACT.Service;
using ACT.Utilities.Enum;
using ACT.Utilities.Extensions;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using AutoMapper;
using System.Web.Mvc;
using ACT.Models;
using Newtonsoft.Json;
using System.Net;

namespace ACT.Areas.WorkPlanning.Controllers
{

    [ActAuthorize(MenuEnum.SubIndicatorsPanel, OptionalAccessEnum.IsDirectResponsible)]
    public class SubIndicatorsController : BaseController
    {

        #region Variable
        private readonly ISubIndicatorsService _subIndicatorsService;
        private readonly IUserCategoryService _userCategoryService;
        private readonly IStandardService _standardService;
        #endregion

        #region ctor
        public SubIndicatorsController(
            ISubIndicatorsService subIndicatorsService,
            IUserCategoryService userCategoryService,
            IStandardService standardService
            )
        {
            _subIndicatorsService = subIndicatorsService;
            _userCategoryService = userCategoryService;
            _standardService = standardService;
        }
        #endregion

        #region PageBarFunction
        [NonAction]
        private List<PageBarViewModel> GetPageBar(string LocPageName)
        {
            return new List<PageBarViewModel>{
                new PageBarViewModel {Order=0,Description=Resources.PageTitle.WorkPlanning,IsFirst=true },
                 new PageBarViewModel {Order=0,Description=Resources.PageTitle.IndicatorsPanel },
                 new PageBarViewModel {Order=1,Description=LocPageName,IsLast=true },
            };
        }
        #endregion


        #region Actinos
        public ActionResult Index(decimal? SearchSelectedCategoryId)
        {
            ViewBag.Title = Resources.PageTitle.SubIndicatorsPanel_Index;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.SubIndicatorsPanel_Index);
            return View();
        }

        public ActionResult ItemTable()
        {
            decimal? SearchUserCategory = Request.QueryString["UserCategoryId"].ToNullableDecimal();
            decimal? SearchJobTitle = Request.QueryString["JobTitleId"].ToNullableDecimal();
            decimal? SearchUser = Request.QueryString["UserId"].ToNullableDecimal();
            decimal? SearchItemId = Request.QueryString["ItemId"].ToNullableDecimal();
            if (SearchUserCategory.HasValue)
            {
                var model = _subIndicatorsService.GetSubIndicators(CurrentUser.LevelResponsibleForMe.Level1Id, CurrentUser.LevelResponsibleForMe.Level2Id, CurrentUser.LevelResponsibleForMe.Level3Id, CurrentUser.LevelResponsibleForMe.Level4Id, SearchUserCategory.Value, SearchItemId);
                return PartialView(model);
            }
            else
            {
                return PartialView();
            }

        }

        [HttpPost]
        public ActionResult AddQuantity()
        {
            //get form data
            string ValueJson = Request.Form["value[ValueJson]"];
            bool IsContinuous = bool.Parse(Request.Form["value[IsContinuous]"]);
            string Quantity = Request.Form["value[Quantity]"];
            decimal TargetCategory = decimal.Parse(Request.Form["value[TargetCategory]"]);

            //set model value from from data
            var model = JsonConvert.DeserializeObject<SubIndicatorsCategoryQuantityViewModel>(ValueJson);
            model.IsContinuous = IsContinuous;
            model.Quantity = IsContinuous ? "" : Quantity;
            model.TargetCategory = TargetCategory;
            //chack if my category
            if (!IfMyCategory(TargetCategory))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }
            if (_subIndicatorsService.IsItemNa(model.ItemId, model.TargetCategory))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }


            //Mapper and insert
            var entity = Mapper.Map<SubIndicatorsCategory>(model);
            _subIndicatorsService.Add(entity);
            return Content("");
        }
        [HttpPost]
        public ActionResult EditEditQuantity()
        {
            //get form data
            string ValueJson = Request.Form["value[ValueJson]"];
            bool IsContinuous = bool.Parse(Request.Form["value[IsContinuous]"]);
            string Quantity = Request.Form["value[Quantity]"];
            decimal TargetCategory = decimal.Parse(Request.Form["value[TargetCategory]"]);
            decimal Id = decimal.Parse(Request.Form["pk"]);
            //set model value from from data
            var model = JsonConvert.DeserializeObject<SubIndicatorsCategoryQuantityViewModel>(ValueJson);
            model.IsContinuous = IsContinuous;
            model.Quantity = IsContinuous ? "" : Quantity;
            model.Id = Id;
            model.TargetCategory = TargetCategory;
            var entity = _subIndicatorsService.GetById(model.Id);
            //chack if my category
            if (!IfMyCategory(TargetCategory))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }
            if (_subIndicatorsService.IsItemNa(model.ItemId, model.TargetCategory))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }
            //Mapper and edit
            entity = Mapper.Map(model, entity);
            _subIndicatorsService.Edit(entity);
            return Content("");
        }




        [HttpPost]
        public ActionResult EditStandardWeight()
        {
            //get form data
            decimal Weight = decimal.Parse(Request.Form["value"]);
            decimal TargetCategory = decimal.Parse(Request.QueryString["TargetCategory"]);
            decimal StandardId = decimal.Parse(Request.QueryString["StandardId"]);
            var entity = _standardService.GetById(StandardId);
            if (!IfMyCategory(TargetCategory) || entity.CategoryId != TargetCategory)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }
            if (_standardService.IsStanderdWeightSumGreaterItem(TargetCategory, entity.ItemId,StandardId, Weight))
            {
                return Content(Resources.LocalizedText.IsStanderdWeightSumGreaterItem);
            }
            entity.Weight = Weight;
            _standardService.Edit(entity);
            return Content("");
        }



        #endregion


        #region Functions

        [NonAction]
        private bool IfMyCategory(decimal CategoryId)
        {
            var data = _userCategoryService.GetBy(x =>
             x.Level1Id == CurrentUser.LevelResponsibleForMe.Level1Id &&
             x.Level2Id == CurrentUser.LevelResponsibleForMe.Level2Id &&
             x.Level3Id == CurrentUser.LevelResponsibleForMe.Level3Id &&
             x.Level4Id == CurrentUser.LevelResponsibleForMe.Level4Id &&
             x.Id == CategoryId);

            return data != null;
        }

        #endregion



    }
}