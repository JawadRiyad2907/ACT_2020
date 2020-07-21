using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACT.Service
{

    public class MenuService : GenericService<Menu>, IMenuService
    {
        public MenuService(ActEntities db) : base(db) { }

        public Menu GetByUrl(string Url)
        {
            return context.Menus.AsNoTracking().Where(x => x.Url == Url).FirstOrDefault();
        }

        public List<Menu> GetMenuByPermission(List<int> MenuIdsPermission)
        {

            var AllMenu = (from m in context.Menus where m.Active == true select m).ToList();
            var dataMenu = AllMenu.Where(x => MenuIdsPermission.Contains(x.Id));
            var parentIds = dataMenu.Select(x => x.ParentId);
            var dataParent = AllMenu.Where(x => parentIds.Contains(x.Id));
            return dataMenu.Concat(dataParent).Distinct().OrderBy(x => x.Order).ThenBy(x => x.Id).ToList();
        }


        #region GetRootMenu
        /// <summary>
        /// This function use to get menu items which it parents
        /// </summary>
        /// <returns>List<Menu></returns>
        public List<Menu> GetRootMenu()
        {
            var list = context.Menus.Where(menu => !menu.ParentId.HasValue ).ToList();
            return list;
        }
        #endregion

        #region GetChildMenu
        ///<summary>
        /// This function use to get menu items which it an chaid
        /// </summary>
        /// <returns>List<Menu></returns>
        public List<Menu> GetChildMenu(int parentId)
        {

            var list = context.Menus.Where(menu => menu.ParentId.HasValue && menu.ParentId.Value == parentId).ToList();
            return list;
        }

        public bool HasChild(int nodeId)
        {
            int childCount = context.Menus.Where(menu => menu.ParentId == nodeId).Count();
            if (childCount != 0)
            {
                return true;
            }
            return false;
        }

        #endregion



    }
}