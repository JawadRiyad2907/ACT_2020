using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACT.Service;
using ACT.ViewModel;
using System.Resources;
using ACT.Authentication;
using ACT.Utilities.Enum;

namespace ACT.Controllers
{
    [ActAuthorize(MenuEnum.MyInfo)]
    public class MyInfoController : BaseController
    {

        #region Variable
        IUserService _userService;
        #endregion

        #region Const
        public MyInfoController(IUserService userService)
        {
            this._userService = userService;
        }

        #endregion

        #region PageBarFunction
        [NonAction]
        private List<PageBarViewModel> GetPageBar(string LocPageName)
        {
            return new List<PageBarViewModel>{
                 new PageBarViewModel {Order=2,Description=LocPageName,IsFirst=true ,IsLast=true },
            };
        }


        #endregion




        public ActionResult Index()
        {
            ViewBag.Title = Resources.PageTitle.MyInfo_Index;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.MyInfo_Index);
            return View();
        }
    }
}