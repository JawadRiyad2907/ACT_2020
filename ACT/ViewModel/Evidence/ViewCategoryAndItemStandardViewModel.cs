using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACT.ViewModel
{
    public class ViewCategoryAndItemStandardViewModel
    {
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "ViewCategoryAndItemStandard_CategoryName")]
        public string CategoryName { get; set; }
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "ViewCategoryAndItemStandard_ItemName")]
        public string ItemName { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "ViewCategoryAndItemStandard_StandardName")]
        public string StandardName { get; set; }
    }
}