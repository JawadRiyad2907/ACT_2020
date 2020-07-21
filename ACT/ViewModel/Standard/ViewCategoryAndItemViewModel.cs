using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACT.ViewModel
{
    public class ViewCategoryAndItemViewModel
    {
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "ViewCategoryAndItem_CategoryName")]
        public string CategoryName { get; set; }
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "ViewCategoryAndItem_ItemName")]
        public string ItemName { get; set; }

    }
}