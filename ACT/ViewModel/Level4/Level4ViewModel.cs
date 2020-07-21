using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACT.ViewModel
{
    public class Level4ViewModel
    {
        public decimal Id { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level4Level1")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        public decimal Level1Id { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level4Level2")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        public decimal Level2Id { get; set; }


        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level4Level3")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        public decimal Level3Id { get; set; }


        [Required( ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level4Name")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level4Published")]
        public bool Published { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level4DisplayOrder")]
        public decimal DisplayOrder { get; set; }

       
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level4IsDefault")]
        public bool IsDefault { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level4TypeEducationId")]
        public decimal TypeEducationId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level4TypeId")]
        public decimal TypeId { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level4IsKindergarten")]
        public bool IsKindergarten { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level4IsBasic")]
        public bool IsBasic { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level4IsMedium")]
        public bool IsMedium { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level4IsSecondary")]
        public bool IsSecondary { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level4IsMinistryEducation")]
        public bool IsMinistryEducation { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level4IsOtherEducation")]
        public bool IsOtherEducation { get; set; }

        [RequiredIf("IsOtherEducation", Operator.EqualTo, true, ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Resources.LocalizedText))]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level4OtherEducationName")]
        public string OtherEducationName { get; set; }

        public Nullable<decimal> DirectResponsible { get; set; }

        //FK Names
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level4Level1")]
        public string Level1Name { get; set; }

      

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level4Level2")]
        public string Level2Name { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Level4Level3")]
        public string Level3Name { get; set; }
    }
}