using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ACT.Service
{

    public class EnterpriseUnitService : GenericService<EnterpriseUnit>, IEnterpriseUnitService
    {
        public EnterpriseUnitService(ActEntities db) : base(db) { }

    }
}