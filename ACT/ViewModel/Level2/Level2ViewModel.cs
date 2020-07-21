using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACT.ViewModel
{
    public class Level2ViewModel
    {
        public decimal Id { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level2Level1")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        public decimal Level1Id { get; set; }

        [Required( ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level2Name")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level2Published")]
        public bool Published { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level2DisplayOrder")]
        public decimal DisplayOrder { get; set; }

       
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level2IsDefault")]
        public bool IsDefault { get; set; }

        public Nullable<decimal> DirectResponsible { get; set; }

        //FK Names
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level2Level1Name")]
        public string Level1Name { get; set; }


    }
}