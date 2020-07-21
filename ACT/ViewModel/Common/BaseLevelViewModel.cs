using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACT.ViewModel
{
    public class BaseLevelViewModel
    {
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Common_Level1Id")]
        public Nullable<decimal> Level1Id { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Common_Level2Id")]
        public Nullable<decimal> Level2Id { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Common_Level3Id")]
        public Nullable<decimal> Level3Id { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Common_Level4Id")]
        public Nullable<decimal> Level4Id { get; set; }
    }
}