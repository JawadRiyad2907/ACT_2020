using ACT.Authentication;
using ACT.Controllers;
using ACT.Service;
using ACT.Service.Privelags;
using ACT.Utilities.Enum;
using ACT.ViewModel;
using ACT.ViewModel.Privelages;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACT.Areas.Privelags.Controllers
{
    public class ManageController : BaseController
    {
        private IMenuService _menuService;
        private IPrivelagsService _privelagsService;

        public ManageController(IMenuService menuService, IPrivelagsService privelagsService)
        {
            _menuService = menuService;
            _privelagsService = privelagsService;
        }

        #region PageBarFunction
        [NonAction]
        private List<PageBarViewModel> GetPageBar(string LocPageName)
        {
            return new List<PageBarViewModel>{
                new PageBarViewModel {Order=0,Description=Resources.PageTitle.Privelages,IsFirst=true },
                 new PageBarViewModel {Order=1,Description=LocPageName,IsLast=true },
            };
        }


        #endregion

        #region Category Actions
        [ActAuthorize(MenuEnum.ManageUserCategories)]
        public ActionResult Category(int Id)
        {
            ViewBag.CategoryId = Id;
            return View();
        }

        [ActAuthorize(MenuEnum.ManageUserCategories)]
        public ActionResult CategoryTree(int Id)
        {
            var nodes = _menuService.List(orderBy: o => o.OrderBy(x => x.Order), includeProperties: i => i.MenuPrivelags).Select(n => new { id = n.Id, parent = n.ParentId == null ? "#" : n.ParentId.ToString(), text = Resources.PageTitle.ResourceManager.GetString(n.ResourcesString), type = "default", state = new { selected = (n.MenuPrivelags.Where(x => x.CategoryId == Id).Count()) > 0 ? true : false } }).ToList();
            return Json(nodes, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ActAuthorize(MenuEnum.ManageUserCategories)]
        public JsonResult SaveCategory(int Id, int[] privelagesIds)
        {
            List<MenuPrivelagesViewModel> privelages = new List<MenuPrivelagesViewModel>();
            _privelagsService.Delete(cond => cond.CategoryId.Value == Id);
            
            if (privelagesIds != null)
            {

                foreach (var item in privelagesIds)
                {
                    privelages.Add(new MenuPrivelagesViewModel
                    {
                        CategoryId = Id,
                        MenuId = item,
                        CreatedDate = DateTime.Now,
                        CretaedBy = CurrentUser.Id
                    });
                }
                var mappedEntity = Mapper.Map<List<Models.MenuPrivelag>>(privelages);
                _privelagsService.AddRange(mappedEntity);

            }
            
            return Json(new { data = "", success = true }, JsonRequestBehavior.AllowGet);
        }


        [ActAuthorize(MenuEnum.ManageUserCategories)]
        public ActionResult CategoryTreeReadOnly(int Id)
        {
            var nodes = _menuService.List(orderBy: o => o.OrderBy(x => x.Order), includeProperties: i => i.MenuPrivelags).Select(n => new { id = n.Id, parent = n.ParentId == null ? "#" : n.ParentId.ToString(), text = Resources.PageTitle.ResourceManager.GetString(n.ResourcesString), type = "default", state = new { selected = (n.MenuPrivelags.Where(x => x.CategoryId == Id).Count()) > 0 ? true : false, disabled = true } }).ToList();
            return Json(nodes, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region JobTitle Actions
        [ActAuthorize(MenuEnum.JobTitleManagement)]
        public ActionResult JobTitle(int Id)
        {
            ViewBag.JobTitle = Id;
            return View();
        }

        [ActAuthorize(MenuEnum.JobTitleManagement)]
        public ActionResult JobTitleTree(int Id)
        {
            var nodes = _menuService.List(orderBy: o => o.OrderBy(x => x.Order), includeProperties: i => i.MenuPrivelags).Select(n => new { id = n.Id, parent = n.ParentId == null ? "#" : n.ParentId.ToString(), text = Resources.PageTitle.ResourceManager.GetString(n.ResourcesString), type = "default", state = new { selected = (n.MenuPrivelags.Where(x => x.JobTitleId == Id).Count()) > 0 ? true : false } }).ToList();
            return Json(nodes, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ActAuthorize(MenuEnum.JobTitleManagement)]
        public JsonResult SaveJobTitle(int Id, int[] privelagesIds)
        {
            List<MenuPrivelagesViewModel> privelages = new List<MenuPrivelagesViewModel>();
            _privelagsService.Delete(cond => cond.JobTitleId.Value == Id);
            if (privelagesIds != null)
            {

                foreach (var item in privelagesIds)
                {
                    privelages.Add(new MenuPrivelagesViewModel
                    {
                        JobTitleId = Id,
                        MenuId = item,
                        CreatedDate = DateTime.Now,
                        CretaedBy = CurrentUser.Id
                    });
                }
                var mappedEntity = Mapper.Map<List<Models.MenuPrivelag>>(privelages);
                _privelagsService.AddRange(mappedEntity);

            }
            return Json(new { data = "", success = true }, JsonRequestBehavior.AllowGet);
        }


        [ActAuthorize(MenuEnum.JobTitleManagement)]
        public ActionResult JobTitleTreeReadOnly(int Id)
        {
            var nodes = _menuService.List(orderBy: o => o.OrderBy(x => x.Order), includeProperties: i => i.MenuPrivelags).Select(n => new { id = n.Id, parent = n.ParentId == null ? "#" : n.ParentId.ToString(), text = Resources.PageTitle.ResourceManager.GetString(n.ResourcesString), type = "default", state = new { selected = (n.MenuPrivelags.Where(x => x.JobTitleId == Id).Count()) > 0 ? true : false, disabled = true } }).ToList();
            return Json(nodes, JsonRequestBehavior.AllowGet);
        }


        #endregion





    }
}