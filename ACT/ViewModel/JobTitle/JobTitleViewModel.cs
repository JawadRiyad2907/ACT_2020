using ACT.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACT.ViewModel.JobTitle
{
    public class JobTitleViewModel: BaseCategoryViewModel
    {
        public decimal Id { get; set; }
      
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "DisplayOrder")]
        public decimal DisplayOrder { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "UserCategory_Active")]
        public bool Active { get; set; } = true;
        public int CreatedBy { get; set; } =1;

        public bool Deleted { get; set; } = false;
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "JobName")]
        public string JobName { get; set; }



        //FK for datatable jquery
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Common_UserCategoryId")]
        public string UserCategoryName { get; set; }

    }
}