using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ACT.Service
{

    public class CientificDegreeService : GenericService<CientificDegree>, ICientificDegreeService
    {
        public CientificDegreeService(ActEntities db) : base(db) { }
    }
}