using ACT.Controllers;
using ACT.Service.UnitUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ACT.General.Json;
using ACT.ViewModel;
using ACT.Service;
using ACT.ViewModel.UnitUsers;
using ACT.Utilities.Enum;
using ACT.Authentication;
using ACT.Utilities.Extensions;

namespace ACT.Areas.WorkPlanning.Controllers
{
    public class UserUnitController : BaseController
    {
        #region Variables
        private IUnitUserService _unitUserService;
        private IEnterpriseUnitService _enterpriseUnitService;
        #endregion

        #region PageBarFunction
        [NonAction]
        private List<PageBarViewModel> GetPageBar(string LocPageName)
        {
            return new List<PageBarViewModel>{
                new PageBarViewModel {Order=0,Description=Resources.PageTitle.WorkPlanning,IsFirst=true },
                new PageBarViewModel {Order=1,Description=Resources.PageTitle.UserUnit,IsLast=true  }
            };
        }


        #endregion

        #region CTOR
        public UserUnitController(IUnitUserService unitUserService, IEnterpriseUnitService enterpriseUnitService)
        {
            _unitUserService = unitUserService;
            _enterpriseUnitService = enterpriseUnitService;
        }
        #endregion

        #region Actions
        //[ActAuthorize(MenuEnum.AdministrativeUnits)]
        public ActionResult Index(int unitId, EnterpriseUnitsTypeEnum type)
        {
            ViewBag.Title = Resources.PageTitle.UserUnit;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.UserUnit);
            var unitInfo = _enterpriseUnitService.GetById(unitId);

            var userNotAddedList = _unitUserService.GetNonUnitUser(unitId, CurrentUser.LevelResponsibleForMe, type)
                .Select(x => new SelectListItem()
                {
                    Text = x.FullName,
                    Value = x.UserId.ToString()
                });
            var userAddedList = _unitUserService.GetUnitUserAdded(unitId)
               .Select(x => new SelectListItem()
               {
                   Text = x.FullName,
                   Value = x.UserId.ToString()
               });
            var rsponsibleUserList = _unitUserService.GetResponsibleUser(unitId)
                 .Select(x => new SelectListItem()
                 {
                     Text = x.FullName,
                     Value = x.UserId.ToString()
                 });

            var model = new UnitUserViewModel();
            model.UnitId = unitInfo.Id;
            model.UnitName = unitInfo.Name;
            model.type = type;
            model.UserNotAddedList = userNotAddedList;
            model.UserAddedList = userAddedList;
            model.UserResponsibleList = rsponsibleUserList;
            return View(model);
        }


        [HttpPost]
        //[ActAuthorize(MenuEnum.AdministrativeUnits)]
        public JsonResult Index(UnitUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                //remove all
                _unitUserService.RemoveAllUserForUnit(model.UnitId);
                //added
                _unitUserService.AddUserToUnit(model.UnitId, model.UserAdded, model.UserResponsible);
                return Json(new { data = model, success = true }, JsonRequestBehavior.AllowGet);
            }
            var errors = ModelState.GetDistinctModelErrors();
            return Json(new { data = model, success = false, ErrorsList = errors }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult AllUserUnit(int unitId)
        {
            ViewBag.UserAddedList = _unitUserService.GetUnitUserAdded(unitId)
              .Select(x => new SelectListItem()
              {
                  Text = x.FullName,
                  Value = x.UserId.ToString()
              });
            ViewBag.RsponsibleUserList = _unitUserService.GetResponsibleUser(unitId)
                 .Select(x => new SelectListItem()
                 {
                     Text = x.FullName,
                     Value = x.UserId.ToString()
                 });
            return PartialView();

        }

        [HttpGet]
        public ActionResult GetCountUserForLevel(EnterpriseUnitsTypeEnum type)
        {
            var count = _unitUserService.GetCountUserForLevel(CurrentUser.LevelResponsibleForMe, type);
            return Content(count.ToString());
        }

        #endregion
    }
}