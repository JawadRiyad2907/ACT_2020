using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACT.Service
{
    
    public class SystemSettingService : GenericService<SystemSetting>, ISystemSettingService
    {
        public SystemSettingService(ActEntities db) : base(db) { }
    }
}