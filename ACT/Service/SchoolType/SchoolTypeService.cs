using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACT.Service
{
    
    public class SchoolTypeService : GenericService<SchoolType>, ISchoolTypeService
    {
        public SchoolTypeService(ActEntities db) : base(db) { }
    }
}