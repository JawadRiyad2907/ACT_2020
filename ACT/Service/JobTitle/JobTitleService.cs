using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACT.Models;

namespace ACT.Service.JobTitle
{
    public class JobTitleService : GenericService<Models.JobTitle>, IJobTitleService
    {
        public JobTitleService(ActEntities context) : base(context)
        {
        }


    }

}