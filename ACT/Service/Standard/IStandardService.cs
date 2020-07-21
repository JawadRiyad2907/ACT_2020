using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACT.Service
{
 
    public interface IStandardService : IGenericService<Standard>
    {
        bool IsStanderdWeightSumGreaterItem(decimal TargetCategory, decimal ItemId, decimal StandardId, decimal NewWeight);
    }
}