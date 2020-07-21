using ACT.Authentication;
using ACT.Controllers;
using ACT.Service;
using ACT.Utilities.Enum;
using ACT.Utilities.Extensions;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACT.Areas.WorkPlanning.Controllers
{
    public class DirectResponsibleController : BaseController
    {



        #region Variable
        IDirectResponsibleService _directResponsibleService;
        IUserService _UserService;
        #endregion

        #region Const
        public DirectResponsibleController(IDirectResponsibleService directResponsibleService, IUserService UserService)
        {
            _directResponsibleService = directResponsibleService;
            _UserService = UserService;
        }
        #endregion

        #region PageBarFunction
        [NonAction]
        private List<PageBarViewModel> GetPageBar(string LocPageName)
        {
            return new List<PageBarViewModel>{
                new PageBarViewModel {Order=0,Description=Resources.PageTitle.WorkPlanning,IsFirst=true },
                 new PageBarViewModel {Order=2,Description=LocPageName,IsLast=true },
            };
        }


        #endregion


        #region Main

        [ActAuthorize(MenuEnum.DirectResponsible)]
        public ActionResult Index()
        {
            ViewBag.Title = Resources.PageTitle.DirectResponsible_Index;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.DirectResponsible_Index);
            ViewBag.Description = "";
            return View();
        }

        [HttpGet]
        [ActAuthorize(MenuEnum.DirectResponsible)]
        public JsonResult GetDirectResponsible(DataTableViewModel dataTableViewModel)
        {

            string SearchLevelName = Request.QueryString["SearchLevelName"];
            string SearchResponsibleName = Request.QueryString["SearchResponsibleName"];

            var EntityData = new List<DirectResponsibleViewModel>();
            int Count = 0;
            if (CurrentUser.MyLevelNumber == 0)
            {
                var data = _directResponsibleService.GetForlevel1(dataTableViewModel.length, dataTableViewModel.start, SearchLevelName, SearchResponsibleName);
                EntityData = data.EntityData;
                Count = data.Count;
            }
            else if (CurrentUser.MyLevelNumber == 1)
            {
                var data = _directResponsibleService.GetForlevel2(dataTableViewModel.length, dataTableViewModel.start, SearchLevelName, SearchResponsibleName);
                EntityData = data.EntityData;
                Count = data.Count;
            }
            else if (CurrentUser.MyLevelNumber == 2)
            {
                var data = _directResponsibleService.GetForlevel3(dataTableViewModel.length, dataTableViewModel.start, SearchLevelName, SearchResponsibleName);
                EntityData = data.EntityData;
                Count = data.Count;
            }
            else if (CurrentUser.MyLevelNumber == 3)
            {
                var data = _directResponsibleService.GetForlevel4(dataTableViewModel.length, dataTableViewModel.start, SearchLevelName, SearchResponsibleName);
                EntityData = data.EntityData;
                Count = data.Count;
            }
            return Json(new { data = EntityData, recordsTotal = Count, recordsFiltered = Count }, JsonRequestBehavior.AllowGet);
        }



        #endregion

        #region Edit
        [HttpGet]
        [ActAuthorize(MenuEnum.DirectResponsible)]
        public ActionResult Edit(decimal LevelId)
        {
            //ViewBags Info
            ViewBag.Title = Resources.PageTitle.DirectResponsible_Edit;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.DirectResponsible_Edit);
            ViewBag.Description = "";
            var model = _directResponsibleService.GetDirectResponsiblelevel(LevelId, CurrentUser.MyLevelNumber);
            model.AlvailableResponsibleList = _UserService.GetDirectResponsibleSameLevel(model.LevelNumber, LevelId)
             .Select(x => new SelectListItem
             {
                 Text = x.FirstName + " " + x.SecondName + " " + x.ThirdName + " " + x.LastName,
                 Value = x.Id.ToString()
             }).ToList();
            return View(model);
        }
        [HttpPost]
        [ActAuthorize(MenuEnum.DirectResponsible)]
        public JsonResult Edit(DirectResponsibleViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.LevelNumber = CurrentUser.MyLevelNumber;
                _directResponsibleService.UpdateDirectResponsiblelevel(model);
                return Json(new { data = model, success = true }, JsonRequestBehavior.AllowGet);
            }
            var errors = ModelState.GetDistinctModelErrors();
            return Json(new { data = model, success = false, ErrorsList = errors }, JsonRequestBehavior.AllowGet);
        }

        #endregion


    }
}