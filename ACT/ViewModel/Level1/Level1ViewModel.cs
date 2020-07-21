using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACT.ViewModel
{
    public class Level1ViewModel
    {
        public decimal Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level1Name")]
        public string Name { get; set; }




        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level1Published")]
        public bool Published { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level1DisplayOrder")]
        public decimal DisplayOrder { get; set; }



        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level1IsDefault")]
        public bool IsDefault { get; set; }

        public Nullable<decimal> DirectResponsible { get; set; }
    }
}