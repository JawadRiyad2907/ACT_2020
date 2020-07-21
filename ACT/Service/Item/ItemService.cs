using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Z.EntityFramework.Plus;

namespace ACT.Service
{

    public class ItemService : GenericService<Item>, IItemService
    {
        public ItemService(ActEntities db) : base(db) { }


        public IList<Item> MyItems(decimal UserCategoryId)
        {
            var itemList = context.Items.IncludeFilter(x => x.ItemNACategories.Where(c => c.CategoryId == UserCategoryId)).OrderBy(x => x.Sector.DisplayOrder).ThenBy(x => x.DisplayOrder).ToList();
            return itemList;
        }


        public Item GetItem(decimal ItemId, decimal UserCategoryId)
        {
            var item = context.Items.Where(x => x.Id == ItemId).FirstOrDefault();
            //var standards = context.Standards.IncludeFilter(i => i.Evidences).IncludeFilter(c => c.SubIndicatorsCategories.Where(cc => cc.CategoryId == UserCategoryId)).Where(x => x.ItemId == ItemId && x.CategoryId == UserCategoryId);
           

            var query = (from st in context.Standards
                        join sub in context.SubIndicatorsCategories on st.Id equals sub.StandardId
                        where sub.ItemId == ItemId && sub.CategoryId == UserCategoryId
                        select st);
            item.Standards = query.ToList();
            return item;
        }


    }
}