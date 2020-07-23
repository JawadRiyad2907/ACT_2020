using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACT.Models;
using ACT.Service;
using AutoMapper;
using ACT.ViewModel;
using ACT.Utilities.Helper;
using ACT.Authentication;
using ACT.Utilities.Enum;

namespace ACT.Controllers
{


    [ActAuthorize(MenuEnum.CommonAction)]
    public class MenuController : BaseController
    {

        #region InstanceServices
        readonly IMenuService _menuService;
        readonly ILanguageService languageService;
        #endregion

        #region Constraints 
        public MenuController(IMenuService menuService, ILanguageService languageService)
        {
            this._menuService = menuService;
            this.languageService = languageService;
        }
        #endregion

        #region Actions
        public PartialViewResult GetMenu()
        {
            var list = _menuService.GetMenuByPermission(CurrentUser.MenuIdsPermission);
            return PartialView("_MenuLayout", list);
        }

        public PartialViewResult GetMenuSidebar()
        {
            var list = _menuService.GetMenuByPermission(CurrentUser.MenuIdsPermission);
            return PartialView("_SidebarLayout", list);
        }
        [AllowAnonymous]
        public PartialViewResult RightMenu()
        {
            var list = languageService.List(filter: x => x.Published, orderBy: q => q.OrderBy(e => e.DisplayOrder));
            var menuList = Mapper.Map<List<LanguageMenuViewModel>>(list);
           
            var CurrentLang = menuList.Where(x => x.LanguageCulture == CultureHelper.GetCurrentCulture() || x.LanguageCulture.Split('-')[0] == CultureHelper.GetCurrentCulture()).FirstOrDefault();
            menuList.Remove(CurrentLang);
            var model = new LanguageMenuBaseViewModel
            {
                Currnet = CurrentLang,
                Menu = menuList
            };
            return PartialView("_RightMenu", model);
        }


        #endregion



    }
}