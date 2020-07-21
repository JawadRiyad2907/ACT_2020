using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACT.ViewModel
{
    public class BaseCategoryViewModel
    {
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Common_Level1Id")]
        public Nullable<decimal> Level1Id { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Common_Level2Id")]
        public Nullable<decimal> Level2Id { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Common_Level3Id")]
        public Nullable<decimal> Level3Id { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Common_Level4Id")]
        public Nullable<decimal> Level4Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Common_UserCategoryId")]
        public decimal UserCategoryId { get; set; }
    }
}