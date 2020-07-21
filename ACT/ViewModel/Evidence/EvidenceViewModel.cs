using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACT.ViewModel
{
    public class EvidenceViewModel
    {
        public decimal Id { get; set; }
        public decimal StandardId { get; set; }




        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Evidence_EvidenceDescription")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        public string EvidenceDescription { get; set; }
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Evidence_DisplayOrder")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        public decimal DisplayOrder { get; set; }

    }
}