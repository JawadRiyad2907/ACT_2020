using ACT.Controllers;
using ACT.Authentication;
using ACT.Service;
using ACT.Utilities.Enum;
using ACT.Utilities.Extensions;
using ACT.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace ACT.Areas.WorkPlanning.Controllers
{
    public class MyPerformanceController : BaseController
    {

        #region Variable
        private readonly IItemService _itemService;
        #endregion

        #region constructor
        public MyPerformanceController(IItemService itemService)
        {
            _itemService = itemService;
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

        #region Actions

        [ActAuthorize(MenuEnum.MyPerformance)]
        public ActionResult Index()
        {
            ViewBag.Title = Resources.PageTitle.MyPerformance_Index;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.MyPerformance_Index);
            return View();
        }



        public ActionResult PerformanceTable(decimal? SearchMyItem)
        {
            if (!SearchMyItem.HasValue)
            {
                return PartialView();
            }

            var item = _itemService.GetItem(SearchMyItem.Value, CurrentUser.UserCategoryId);
            return PartialView(item);
        }


        #endregion


    }
}