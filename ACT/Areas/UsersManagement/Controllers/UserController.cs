using ACT.Controllers;
using ACT.Models;
using ACT.Service;
using ACT.ViewModel;
using System.Web.Mvc;
using AutoMapper;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using System.Linq;
using ACT.Utilities.Extensions;
using ACT.Utilities.Enum;
using ACT.Authentication;

namespace ACT.Areas.UsersManagement.Controllers
{
    public class UserController : BaseController
    {
        #region Variable
        ILevel1Service _Level1Service;
        ILevel2Service _Level2Service;
        ILevel3Service _Level3Service;
        ILevel4Service _Level4Service;
        IUserService _UserService;
        ISystemSettingService _systemSettingService;
        #endregion

        #region Const
        public UserController(
            IUserService UserService,
             ILevel1Service Level1Service,
            ILevel2Service Level2Service,
            ILevel3Service Level3Service,
            ILevel4Service Level4Service,
             ISystemSettingService systemSettingService)
        {
            _UserService = UserService;
            _Level2Service = Level2Service;
            _Level1Service = Level1Service;
            _Level3Service = Level3Service;
            _Level4Service = Level4Service;
            _systemSettingService = systemSettingService;
        }

        #endregion

        #region PageBarFunction
        [NonAction]
        private List<PageBarViewModel> GetPageBar(string LocPageName)
        {
            return new List<PageBarViewModel>{
                new PageBarViewModel {Order=0,Description=Resources.PageTitle.UserManagment,IsFirst=true },
                 new PageBarViewModel {Order=1,Description=LocPageName,IsLast=true },
            };
        }


        #endregion


        #region Main
        [ActAuthorize(MenuEnum.Users)]
        public ActionResult Index()
        {
            ViewBag.Title = Resources.PageTitle.User_Index;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.User_Index);
            ViewBag.Description = "";
            return View();
        }

        [HttpGet]
        [ActAuthorize(MenuEnum.Users)]
        public JsonResult GetUserList(DataTableViewModel dataTableViewModel)
        {

            //query string filter
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

            string SearchJobTitleStr = Request.QueryString["SearchJobTitle"];
            decimal? SearchJobTitle = !string.IsNullOrEmpty(SearchJobTitleStr) ? decimal.Parse(SearchJobTitleStr) as decimal? : null;

            string SearchFirstName = Request.QueryString["SearchFirstName"];
            string SearchLastName = Request.QueryString["SearchLastName"];
            string SearchEmail = Request.QueryString["SearchEmail"];


            //include multi properties with data
            var includeMultiProperties = new Expression<Func<ACT.Models.User, object>>[] { x => x.UserCategory, y => y.JobTitle, };
            var data = _UserService.ListWithPaging(
                //filter
                filter: x =>
                (SearchLevel1 == null || x.Level1Id == SearchLevel1) &&
                (SearchLevel2 == null || x.Level2Id == SearchLevel2) &&
                (SearchLevel3 == null || x.Level3Id == SearchLevel3) &&
                (SearchLevel4 == null || x.Level4Id == SearchLevel4) &&
                (SearchUserCategory == null || x.UserCategoryId == SearchUserCategory) &&
                (SearchJobTitle == null || x.JobTitleId == SearchJobTitle) &&
                 x.FirstName.Contains(SearchFirstName) &&
                x.LastName.Contains(SearchLastName) &&
                 x.Email.Contains(SearchEmail),
                //includeProperties
                includeProperties: includeMultiProperties,
                orderBy: o => o.Id,
                pageSize: dataTableViewModel.length,
                page: dataTableViewModel.start);

            //fix serilaize json >>
            var dataMapped = Mapper.Map<List<UserViewModel>>(data.EntityData);
            return Json(new { data = dataMapped, recordsTotal = data.Count, recordsFiltered = data.Count }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Add
        [HttpGet]
        [ActAuthorize(MenuEnum.Users)]
        public ActionResult Add()
        {
            ViewBag.Title = Resources.PageTitle.User_Add;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.User_Add);
            ViewBag.Description = "";
            var model = new UserViewModel();
            model.AlvailableGenderList.AddRange(GenderEnum.Male.ToSelectList());
            model.Active = true;
            return View(model);
        }
        [HttpPost]
        [ActAuthorize(MenuEnum.Users)]
        public JsonResult Add(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                //if password null set defualt value
                if (string.IsNullOrEmpty(model.Password))
                {
                    var defualtPassword = _systemSettingService.GetById((int)SystemSettingEnum.DefualtPassword).Value;
                    model.Password = defualtPassword;
                }
                var EntityMapped = Mapper.Map<User>(model);
                EntityMapped.CreatedDate = DateTime.Now;

                _UserService.Add(EntityMapped);
                return Json(new { data = model, success = true }, JsonRequestBehavior.AllowGet);
            }
            var errors = ModelState.GetDistinctModelErrors();
            return Json(new { data = model, success = false, ErrorsList = errors }, JsonRequestBehavior.AllowGet);
        }



        #endregion

        #region Delete
        [HttpPost]
        [ActAuthorize(MenuEnum.Users)]
        public JsonResult Delete(int Id)
        {
            var UserEntity = _UserService.GetById(Id);
            if (UserEntity != null)
            {
                _UserService.Delete(UserEntity);
                return Json(new { data = Id, success = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { data = Id, success = false, ErrorsList = Resources.LocalizedText.DeletedItemNotFound }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Edit
        [HttpGet]
        [ActAuthorize(MenuEnum.Users)]
        public ActionResult Edit(int Id)
        {
            //ViewBags Info
            ViewBag.Title = Resources.PageTitle.User_Edit;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.User_Edit);
            ViewBag.Description = "";
            //Get Entity Edited
            var UserEntity = _UserService.GetById(Id);
            var modelMapped = Mapper.Map<UserViewModel>(UserEntity);
            modelMapped.AlvailableGenderList.AddRange(GenderEnum.Male.ToSelectList());
            return View(modelMapped);
        }
        [HttpPost]
        [ActAuthorize(MenuEnum.Users)]
        public JsonResult Edit(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var UserEntity = _UserService.GetById(model.Id);
                UserEntity = Mapper.Map(model, UserEntity);
                _UserService.Edit(UserEntity);
                return Json(new { data = model, success = true }, JsonRequestBehavior.AllowGet);
            }
            var errors = ModelState.GetDistinctModelErrors();
            return Json(new { data = model, success = false, ErrorsList = errors }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Remote Validation
        [HttpPost]
        [ActAuthorize(MenuEnum.Users)]
        public JsonResult IsUserNameAvailable(string UserName, decimal? Id)
        {
            return Json(!_UserService.Any(u => u.UserName == UserName && u.Id != Id), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ActAuthorize(MenuEnum.Users)]
        public JsonResult IsEmailAvailable(string Email, decimal? Id)
        {
            return Json(!_UserService.Any(u => u.Email == Email && u.Id != Id), JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region GenerateUserName
        [HttpPost]
        [ActAuthorize(MenuEnum.Users)]
        public string GenerateUserName(string FirstName, string LastName, string UserNameEdited)
        {
            string newUserName = string.Empty;
            if (!string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName))
            {
                string FirstLetter = FirstName.Substring(0, 1);
                newUserName = FirstLetter + "." + LastName;
                int counter = 1;
                while (_UserService.GetBy(x => x.UserName == newUserName && UserNameEdited != newUserName) != null)
                {
                    newUserName = FirstLetter + "." + LastName + counter;
                    counter++;
                }
            }
            return newUserName;
        }
        #endregion

        #region Common Action
        [ActAuthorize(MenuEnum.CommonAction)]
        public ActionResult UserLevelInfo(bool ShowCategory = true, bool ShowJobTitle = true)
        {
            var includeMultiProperties = new Expression<Func<ACT.Models.User, object>>[] { l1 => l1.Level11, l2 => l2.Level21, l3 => l3.Level31, l4 => l4.Level41, x => x.UserCategory, y => y.JobTitle };
            var UserEntity = _UserService.GetBy(x => x.Id == CurrentUser.Id, false, includeMultiProperties);
            var ModelMapped = Mapper.Map<UserLevelInfoViewModel>(UserEntity);
            ModelMapped.ShowCategory = ShowCategory;
            ModelMapped.ShowJobTitle = ShowJobTitle;
            return PartialView("~/Views/Common/UserLevelInfo.cshtml", ModelMapped);
        }


        [ActAuthorize(MenuEnum.CommonAction, OptionalAccessEnum.IsDirectResponsible)]
        public JsonResult FillUsersForUserDirectResponsable(decimal? UserCategoryId, decimal? JobTitleId)
        {
            var data = _UserService.List(
            x => x.Active &&
             UserCategoryId.HasValue &&
             x.UserCategoryId == UserCategoryId &&
             (!JobTitleId.HasValue || x.JobTitleId == JobTitleId) &&
            x.Level1Id == CurrentUser.LevelResponsibleForMe.Level1Id &&
             x.Level2Id == CurrentUser.LevelResponsibleForMe.Level2Id &&
              x.Level3Id == CurrentUser.LevelResponsibleForMe.Level3Id &&
               x.Level4Id == CurrentUser.LevelResponsibleForMe.Level4Id
            , orderBy: x => x.OrderBy(o => o.Id))
            .Select(x => new { id = x.Id, text = string.Format("{0} {1} {2} {3}", x.FirstName, x.SecondName, x.ThirdName, x.LastName) });
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        #endregion


    }
}