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

    public class SectorService : GenericService<Sector>, ISectorService
    {
        public SectorService(ActEntities db) : base(db) { }


        public List<Sector> SectorsItems(decimal UserCategoryId)
        {      
            var sectorList= context.Sectors.OrderBy(x=>x.DisplayOrder).ToList();
            var itemList = context.Items.IncludeFilter(x => x.Standards.Where(c => c.CategoryId == UserCategoryId)).IncludeFilter(x => x.ItemNACategories.Where(c => c.CategoryId == UserCategoryId)).OrderBy(x => x.DisplayOrder).ToList();
            foreach (var sec in sectorList)
            {
                sec.Items = itemList.Where(x=>x.SectorId== sec.Id).ToList();
            }
            return sectorList;
        }
    }
}