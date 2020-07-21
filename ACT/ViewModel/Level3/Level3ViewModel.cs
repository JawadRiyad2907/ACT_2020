using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACT.ViewModel
{
    public class Level3ViewModel
    {
        public decimal Id { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level3Level1")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        public decimal Level1Id { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level3Level2Name")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        public decimal Level2Id { get; set; }

        [Required( ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level3Name")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level3Published")]
        public bool Published { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level3DisplayOrder")]
        public decimal DisplayOrder { get; set; }

       
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level3IsDefault")]
        public bool IsDefault { get; set; }

        public Nullable<decimal> DirectResponsible { get; set; }

        //FK Names
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level3Level1Name")]
        public string Level1Name { get; set; }

      

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level3Level2Name")]
        public string Level2Name { get; set; }
    }
}