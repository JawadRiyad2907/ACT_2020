using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ACT.Service
{

    public class StandardService : GenericService<Standard>, IStandardService
    {
        public StandardService(ActEntities db) : base(db) { }


        public bool IsStanderdWeightSumGreaterItem(decimal TargetCategory, decimal ItemId, decimal StandardId, decimal NewWeight)
        {
            var Item = context.Items.Find(ItemId);
            if (Item != null && Item.FixedWeight.HasValue)
            {
                decimal ItemWeight = Item.FixedWeight.Value;
                var Standards = context.Standards.Where(x => x.CategoryId == TargetCategory && x.ItemId == ItemId && x.Id != StandardId).ToList();
                decimal StanderdWeightSum = Standards.Sum(x => x.Weight);
                StanderdWeightSum += NewWeight;
                if (StanderdWeightSum <= ItemWeight)
                {
                    return false;
                }
            }
            return true;
        }

    }
}