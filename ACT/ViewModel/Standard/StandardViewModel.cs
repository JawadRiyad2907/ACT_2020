using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACT.ViewModel
{
    public class StandardViewModel
    {


        public decimal Id { get; set; }
        public decimal ItemId { get; set; }
        public decimal CategoryId { get; set; }


        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Standard_Name")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        public string Name { get; set; }



        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Standard_Weight")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        public decimal Weight { get; set; }


        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Standard_DisplayOrder")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        public decimal DisplayOrder { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Standard_Publish")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        public bool Publish { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Standard_Evidences")]
        public ICollection<EvidenceViewModel> Evidences { get; set; }

    }
}