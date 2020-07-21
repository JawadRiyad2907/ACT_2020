using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;

namespace ACT.ViewModel
{
    public class CourseViewModel
    {

       
        public decimal Id { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Course_TrainingCourse")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        public string TrainingCourse { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Course_institution")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        public string institution { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Course_Period")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        public int Period { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Course_FromDate")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        public string FromDate { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Course_ToDate")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        public string ToDate { get; set; }

    }
}