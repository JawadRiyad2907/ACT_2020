using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ACT.Service
{

    public class ItemNACategoryService : GenericService<ItemNACategory>, IItemNACategoryService
    {
        public ItemNACategoryService(ActEntities db) : base(db) { }

  
    }
}