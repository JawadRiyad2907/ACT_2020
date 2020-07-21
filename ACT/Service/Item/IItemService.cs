using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACT.Service
{
 
    public interface IItemService : IGenericService<Item>
    {
        IList<Item> MyItems(decimal UserCategoryId);
        Item GetItem(decimal ItemId, decimal UserCategoryId);
    }
}