using ACT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT.Service.Privelags
{
   public interface IPrivelagsService:IGenericService<MenuPrivelag>
    {
        List<int> GetIdsByJobTitleId(int jobId);
        List<int> GetIdsByCategoryId(int catId);
    }
}
