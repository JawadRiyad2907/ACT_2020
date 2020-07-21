using ACT.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACT.ViewModel
{
    public class MyInfoViewModel
    {

        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "MyInfo_FirstName")]
        public string FirstName { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "MyInfo_SecondName")]
        public string SecondName { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "MyInfo_ThirdName")]
        public string ThirdName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "MyInfo_LastName")]
        public string LastName { get; set; }


        [RegularExpression(Formats.OnlyNumberRegex, ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Number")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "MyInfo_PhoneNumber")]
        public string PhoneNumber { get; set; }

        [RegularExpression(Formats.OnlyNumberRegex, ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Number")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "MyInfo_AnotherPhoneNumber")]
        public string AnotherPhoneNumber { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "MyInfo_Address")]
        public string Address { get; set; }
      
    }
}