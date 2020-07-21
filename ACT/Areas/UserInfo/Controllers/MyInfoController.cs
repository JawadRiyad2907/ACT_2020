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

namespace ACT.Areas.UserInfo.Controllers
{
    [ActAuthorize(MenuEnum.MyInfo)]
    public class MyInfoController : BaseController
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
        IUserService _userService;
        #endregion

        #region Const
        public MyInfoController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Main
        public ActionResult Index()
        {
            ViewBag.Title = Resources.PageTitle.MyInfo_Index;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.MyInfo_Index);
            ViewBag.Description = "";
            var UserEntity = _userService.GetById(CurrentUser.Id);
            var model = Mapper.Map<MyInfoReadOnlyViewModel>(UserEntity);
            return View(model);
        }



        #endregion


        #region Edit
        [HttpGet]
        public ActionResult Edit()
        {
            //ViewBags Info
            ViewBag.Title = Resources.PageTitle.MyInfo_Edit;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.MyInfo_Edit);
            ViewBag.Description = "";
            //Get Entity Edited
            var UserEntity = _userService.GetById(CurrentUser.Id);
            var model = Mapper.Map<MyInfoViewModel>(UserEntity);
            return View(model);
        }
        [HttpPost]
        public JsonResult Edit(MyInfoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var UserEntity = _userService.GetById(CurrentUser.Id);
                UserEntity = Mapper.Map(model, UserEntity);
                _userService.Edit(UserEntity);
                return Json(new { data = model, success = true }, JsonRequestBehavior.AllowGet);
            }
            var errors = ModelState.GetDistinctModelErrors();
            return Json(new { data = model, success = false, ErrorsList = errors }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}