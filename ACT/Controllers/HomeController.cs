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
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "MyInfo", new { area = "UserInfo" });
        }
    }
}