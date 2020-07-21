using ACT.Authentication;
using ACT.Controllers;
using ACT.Models;
using ACT.Service;
using ACT.Utilities.Enum;
using ACT.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using System.Linq;

namespace ACT.Areas.SystemManagment.Controllers
{
    public class ItemController : BaseController
    {
        #region Variable
        private readonly ISectorService _sectorService;
        private readonly IUserCategoryService _userCategoryService;
        private readonly IItemNACategoryService _itemNACategoryService;
        public readonly IItemService _itemService;
        #endregion

        #region ctor
        public ItemController(
            ISectorService sectorService,
            IItemNACategoryService itemNACategoryService
            , IUserCategoryService userCategoryService
            , IItemService itemService
            )
        {
            _sectorService = sectorService;
            _itemNACategoryService = itemNACategoryService;
            _userCategoryService = userCategoryService;
            _itemService = itemService;
        }
        #endregion

        #region PageBarFunction
        [NonAction]
        private List<PageBarViewModel> GetPageBar(string LocPageName)
        {
            return new List<PageBarViewModel>{
                new PageBarViewModel {Order=0,Description=Resources.PageTitle.SystemAdministration,IsFirst=true },
                 new PageBarViewModel {Order=1,Description=LocPageName,IsLast=true },
            };
        }


        #endregion

        #region Actinos
        [ActAuthorize(MenuEnum.Item)]
        public ActionResult Index(decimal? SearchSelectedCategoryId)
        {
            ViewBag.Title = Resources.PageTitle.Item_Index;
            ViewBag.PageBar = GetPageBar(Resources.PageTitle.Item_Index);

            var SearchSelected = new BaseCategoryViewModel();
            SearchSelected.Level1Id = CurrentUser.Level1Id;
            SearchSelected.Level2Id = CurrentUser.Level2Id;
            SearchSelected.Level3Id = CurrentUser.Level3Id;
            SearchSelected.Level4Id = CurrentUser.Level4Id;
            SearchSelected.UserCategoryId = CurrentUser.UserCategoryId;
            if (SearchSelectedCategoryId.HasValue)
            {
                var category = _userCategoryService.GetById(SearchSelectedCategoryId);
                SearchSelected.Level1Id = category.Level1Id;
                SearchSelected.Level2Id = category.Level2Id;
                SearchSelected.Level3Id = category.Level3Id;
                SearchSelected.Level4Id = category.Level4Id;
                SearchSelected.UserCategoryId = category.Id;
            }
            ViewBag.SearchSelected = SearchSelected;
            return View();
        }

        [ActAuthorize(MenuEnum.Item)]
        public ActionResult ItemTable()
        {
            string SearchUserCategoryStr = Request.QueryString["UserCategoryId"];
            if (string.IsNullOrEmpty(SearchUserCategoryStr))
            {
                return PartialView();
            }
            decimal SearchUserCategory = decimal.Parse(SearchUserCategoryStr);
            var data = _sectorService.SectorsItems(SearchUserCategory);
            var uerCategory = Mapper.Map<UserCategoryViewModel>(_userCategoryService.GetById(SearchUserCategory));
            ViewBag.UerCategory = uerCategory;
            return PartialView(data);
        }


        [HttpPost]
        [ActAuthorize(MenuEnum.Item)]
        public JsonResult EditNA(decimal UserCategoryId, decimal ItemId, bool isNA)
        {
            if (isNA)
            {
                var itemNa = _itemNACategoryService.GetBy(x => x.CategoryId == UserCategoryId && x.ItemId == ItemId);
                _itemNACategoryService.Delete(itemNa);
            }
            else
            {
                var itemNa = new ItemNACategory
                {
                    CategoryId = UserCategoryId,
                    ItemId = ItemId
                };
                _itemNACategoryService.Add(itemNa);
            }
            return Json(new { data = ItemId, success = true }, JsonRequestBehavior.AllowGet);
        }


        #region Fill
        [HttpGet]
        [ActAuthorize(MenuEnum.CommonAction)]
        public JsonResult FillMyItem()
        {
            var data = _itemService.MyItems(CurrentUser.UserCategoryId)
                .Select(x => new { id = x.Id, text = string.Format(@"{0}/{1} {2}", x.SectorId, x.DisplayOrder, x.Name) });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #endregion



    }
}