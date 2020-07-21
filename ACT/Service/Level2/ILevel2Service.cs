using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACT.Service
{
 
    public interface ILevel2Service : IGenericService<Level2>
    {
        void UpdateDefaultFalse();
    }
}