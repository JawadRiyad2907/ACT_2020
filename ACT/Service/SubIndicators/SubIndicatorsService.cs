using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Z.EntityFramework.Plus;
using AutoMapper;

namespace ACT.Service
{

    public class SubIndicatorsService : GenericService<SubIndicatorsCategory>, ISubIndicatorsService
    {
        public SubIndicatorsService(ActEntities db) : base(db) { }

        public SubIndicatorsViewModel GetSubIndicators(decimal? Level1Id, decimal? Level2Id, decimal? Level3Id, decimal? Level4Id, decimal TargetCategory, decimal? ItemId)
        {
            var queryItem = (from itm in context.Items
                             select new SubIndicatorsViewModel
                             {
                                 ItemId = itm.Id,
                                 DisplayOrder = itm.DisplayOrder,
                                 ItemName = itm.Name,
                                 SectorId = itm.SectorId,
                                 TargetCategory = TargetCategory,
                             });
            if (ItemId.HasValue)
            {
                queryItem = queryItem.Where(x => x.ItemId == ItemId);
            }
            queryItem = queryItem.OrderBy(x => x.DisplayOrder);
            var itemModel = queryItem.FirstOrDefault();


            var allCategories = context.UserCategories.Where(c => c.Id != TargetCategory && c.Level1Id == Level1Id && c.Level2Id == Level2Id && c.Level3Id == Level3Id && c.Level4Id == Level4Id).OrderBy(x => x.DisplayOrder).ToList();
            var standard = context.Standards.Where(c => c.CategoryId == TargetCategory).IncludeFilter(i => i.SubIndicatorsCategories).Where(x => x.ItemId == itemModel.ItemId).OrderBy(x => x.DisplayOrder).ToList();
            itemModel.userCategories = Mapper.Map<List<UserCategoryViewModel>>(allCategories);
            itemModel.standardSubIndicators = Mapper.Map<List<StandardSubIndicatorsViewModel>>(standard);
            itemModel.NextItem = context.Items.Where(x => x.Id > itemModel.ItemId).OrderBy(x => x.Id).Select(x => new SubIndicatorsNextPrevious { ItemId = x.Id, ItemName = x.Name }).FirstOrDefault();
            itemModel.PreviousItem = context.Items.Where(x => x.Id < itemModel.ItemId).OrderByDescending(x => x.Id).Select(x => new SubIndicatorsNextPrevious { ItemId = x.Id, ItemName = x.Name }).FirstOrDefault();
            itemModel.IsNaItem = context.ItemNACategories.Where(x => x.CategoryId == TargetCategory && x.ItemId == ItemId).Any();
            return itemModel;
        }


        public bool IsItemNa(decimal itemId, decimal TargetCategory )
        {
          return  context.ItemNACategories.Where(x => x.CategoryId == TargetCategory && x.ItemId == itemId).Any();
        }
    }
}


