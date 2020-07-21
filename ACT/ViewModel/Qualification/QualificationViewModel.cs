using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;

namespace ACT.ViewModel
{
    public class QualificationViewModel
    {

        public QualificationViewModel()
        {
            AlvailableDegreeList = new List<SelectListItem>();
        }

        public decimal Id { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Qualification_ScientificDegreeId")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        public decimal ScientificDegreeId { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Qualification_Specialization")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        public string Specialization { get; set; }


        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Qualification_University")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        public string University { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Qualification_Year")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        public int Year { get; set; }

        //Alvailable List
        public List<SelectListItem> AlvailableDegreeList { get; set; }

        //Fk Names
        public string ScientificDegreeName { get; set; }
    }
}