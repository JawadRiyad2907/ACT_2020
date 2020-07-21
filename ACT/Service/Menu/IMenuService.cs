using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACT.Service
{
 
    public interface IMenuService : IGenericService<Menu>
    {
        List<Menu> GetMenuByPermission(List<int> MenuIdsPermission);
        Menu GetByUrl(string Url);
        List<Menu> GetRootMenu();

        List<Menu> GetChildMenu(int parentId);
        bool HasChild(int nodeId);
    }
}