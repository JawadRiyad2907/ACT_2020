using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACT.Service
{
 
    public interface IUserCategoryService : IGenericService<UserCategory>
    {
        List<Models.UserCategory> GetUserCategoryLevels(decimal? level1Id, decimal? level2Id, decimal? level3Id, decimal? level4Id);
    }
}