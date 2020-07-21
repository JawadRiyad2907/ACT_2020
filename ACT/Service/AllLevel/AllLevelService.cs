using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ACT.Service
{

    public class AllLevelService : GenericService<vw_All_Level>, IAllLevelService
    {
        public AllLevelService(ActEntities db) : base(db) { }

    }
}