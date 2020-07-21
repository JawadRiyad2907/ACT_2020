using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACT.ViewModel
{
    public class SubIndicatorsViewModel
    {
        public decimal SectorId { get; set; }
        public decimal ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal DisplayOrder { get; set; }
        public bool IsNaItem { get; set; }
        public decimal TargetCategory { get; set; }
        public SubIndicatorsNextPrevious NextItem { get; set; }
        public SubIndicatorsNextPrevious PreviousItem { get; set; }

        public List<UserCategoryViewModel> userCategories { get; set; }
        public List<StandardSubIndicatorsViewModel> standardSubIndicators { get; set; }
    }

    public class StandardSubIndicatorsViewModel
    {
        public decimal StandardId { get; set; }
        public string StandardName { get; set; }
        public decimal Weight { get; set; }
        public decimal DisplayOrder { get; set; }
        public List<SubIndicatorsCategoryViewModel> subIndicatorsCategories { get; set; }
    }

    public class SubIndicatorsCategoryViewModel
    {
        public int Id { get; set; }
        public decimal categoryId { get; set; }
        public bool IsContinuous { get; set; }
        public string Quantity { get; set; }
    }



    public class SubIndicatorsNextPrevious
    {
        public decimal? ItemId { get; set; }
        public string ItemName { get; set; }

    }

}