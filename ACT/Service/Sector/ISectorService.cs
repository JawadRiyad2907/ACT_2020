using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACT.Service
{
 
    public interface ISectorService : IGenericService<Sector>
    {
        List<Sector> SectorsItems(decimal UserCategoryId);
    }
}