using ACT.Service;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ACT.Models;

namespace ACT.Controllers
{
    public class LanguageController : BaseController
    {
        readonly ILanguageService languageService;
        public LanguageController(ILanguageService languageService)
        {
            this.languageService = languageService;
        }


        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "ادارة اللغات والمفردات";
            ViewBag.Description = "";
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Title = "اضافة لغة جديدة";
            ViewBag.Description = "";
            return View();
        }
        [HttpPost]
        public ActionResult Add(LanguageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var LangEntity = Mapper.Map<Language>(model);
                languageService.Add(LangEntity);
                TempData["Notification"] = new NotificationViewModel { Type = "success", Title = "تم الحفظ بنجاح", Description = "" };
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public JsonResult GetLanguagesList()
        {
            var data = languageService.List();
            return Json(new { data, recordsTotal = data.Count, recordsFiltered = data.Count }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetLanguageCulture()
        {
            var data = System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.SpecificCultures)
                .Select(x => new { id = x.IetfLanguageTag, text = string.Format("{0}. {1}", x.IetfLanguageTag, x.EnglishName) });
            return Json(data, JsonRequestBehavior.AllowGet);
        }





    }
}