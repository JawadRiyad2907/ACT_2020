using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACT.ViewModel.Common
{
    public class BaseSearchViewModel
    {
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "UserCategory_Level1Id")]
        public Nullable<decimal> Level1Id { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "UserCategory_Level2Id")]
        public Nullable<decimal> Level2Id { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "UserCategory_Level3Id")]
        public Nullable<decimal> Level3Id { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "UserCategory_Level4Id")]
        public Nullable<decimal> Level4Id { get; set; }

        
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "UserCategory_Name")]
        public string Name { get; set; }

    }
}