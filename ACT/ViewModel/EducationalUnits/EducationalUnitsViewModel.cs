using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACT.ViewModel
{
    public class EducationalUnitsViewModel : BaseLevelViewModel
    {
        public EducationalUnitsViewModel()
        {
            children = new List<EducationalUnitsViewModel>();
        }
        public decimal Id { get; set; }
        public Nullable<decimal> Parent { get; set; }
      
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "EnterpriseUnits_Name")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "EnterpriseUnits_DisplayOrder")]
        public decimal DisplayOrder { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "EnterpriseUnits_UnitUsersFullName")]
        public List<string> UnitUsersFullName { get; set; }



        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "EnterpriseUnits_CountAdditiveUsers")]
        public int CountAdditiveUsers { get; set; }

        public List<EducationalUnitsViewModel> children { get; set; }


        //For display
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "EnterpriseUnits_Parent")]
        public string ParentName { get; set; }
    }
}