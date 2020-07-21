using ACT.Authentication;
using ACT.Controllers;
using ACT.Models;
using ACT.Service;
using ACT.Utilities.Enum;
using ACT.Utilities.Extensions;
using ACT.ViewModel;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;


namespace ACT.Areas.WorkPlanning.Controllers
{
    [ActAuthorize(MenuEnum.MainIndicatorsPanel, OptionalAccessEnum.IsDirectResponsible)]
    public class MainIndicatorsController : BaseController
    {
        #region Variable
        private readonly ISectorService _sectorService;
        private readonly IUserCategoryService _userCategoryService;
        #endregion

        #region ctor
        public MainIndicatorsController(ISectorService sectorService, IUserCategoryService userCategoryService)
        {
            _sectorService = sectorService;
            _userCategoryService = userCategoryService;
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
            ViewBag.Title = Resources.PageTitle.MainIndicators_Index;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.MainIndicators_Index);
            return View();
        }

        public ActionResult ItemTable()
        {
            decimal? SearchUserCategory = Request.QueryString["UserCategoryId"].ToNullableDecimal();
            decimal? SearchJobTitle = Request.QueryString["JobTitleId"].ToNullableDecimal();
            decimal? SearchUser = Request.QueryString["UserId"].ToNullableDecimal();

            if (!SearchUserCategory.HasValue)
            {
                return PartialView();
            }

            var data = _sectorService.SectorsItems(SearchUserCategory.Value);
            var uerCategory = Mapper.Map<UserCategoryViewModel>(_userCategoryService.GetById(SearchUserCategory));
            ViewBag.UerCategory = uerCategory;
            return PartialView(data);
        }
        #endregion




    }
}