using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ACT.Service
{

    public class EvidenceService : GenericService<Evidence>, IEvidenceService
    {
        public EvidenceService(ActEntities db) : base(db) { }

    }
}