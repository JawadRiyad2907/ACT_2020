using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;

namespace ACT.ViewModel
{
    public class CertificatesAndAwardViewModel
    {


        public decimal Id { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "CertificatesAndAward_Name")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "CertificatesAndAward_Source")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        public string Source { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "CertificatesAndAward_DateOfCertificate")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        public string DateOfCertificate { get; set; }

    }
}