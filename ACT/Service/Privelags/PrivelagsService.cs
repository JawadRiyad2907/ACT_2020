using ACT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACT.Service.Privelags
{
    public class PrivelagsService : GenericService<MenuPrivelag>, IPrivelagsService
    {
        public PrivelagsService(ActEntities context) : base(context)
        {
        }

        public List<int> GetIdsByJobTitleId(int jobId)
        {
            
           var result=  FindBy(mnu => mnu.JobTitleId.Value  == jobId).Select(priv=>priv.MenuId);
            if(result!=null)
            {
                return result.ToList();
            }
            return null;
        }

        public List<int> GetIdsByCategoryId(int catId) { 
            var result = FindBy(mnu => mnu.CategoryId.Value == catId).Select(priv => priv.MenuId); ;
            if (result != null)
            {
                return result.ToList();
            }
            return null;
        }
    }
}