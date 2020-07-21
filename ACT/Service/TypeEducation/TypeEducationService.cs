using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACT.Service
{
    
    public class TypeEducationService : GenericService<TypeEducation>, ITypeEducationService
    {
        public TypeEducationService(ActEntities db) : base(db) { }
    }
}