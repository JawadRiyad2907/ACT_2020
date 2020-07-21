using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACT.Service
{

    public interface ISubIndicatorsService : IGenericService<SubIndicatorsCategory>
    {
        SubIndicatorsViewModel GetSubIndicators(decimal? Level1Id, decimal? Level2Id, decimal? Level3Id, decimal? Level4Id, decimal TargetCategory, decimal? ItemId);
        bool IsItemNa(decimal itemId, decimal TargetCategory);
    }
}