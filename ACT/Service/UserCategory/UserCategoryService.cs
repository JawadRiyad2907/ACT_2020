using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ACT.Service
{

    public class UserCategoryService : GenericService<UserCategory>, IUserCategoryService
    {
        public UserCategoryService(ActEntities db) : base(db) { }

        public List<Models.UserCategory> GetUserCategoryLevels(decimal? level1Id, decimal? level2Id, decimal? level3Id, decimal? level4Id)
        {
            var query = (from userCat in context.UserCategories
                         select userCat
                        ).AsQueryable();

            query = query.Where(lev => lev.Level1Id==level1Id && lev.Level2Id == level2Id && lev.Level3Id == level3Id && lev.Level4Id == level4Id );
            return query.ToList();

        }
    }
}