using ACT.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACT.ViewModel
{
    public class MyInfoReadOnlyViewModel
    {
       
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "MyInfoReadOnly_FirstName")]
        public string FirstName { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "MyInfoReadOnly_SecondName")]
        public string SecondName { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "MyInfoReadOnly_ThirdName")]
        public string ThirdName { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "MyInfoReadOnly_LastName")]
        public string LastName { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "MyInfoReadOnly_PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "MyInfoReadOnly_AnotherPhoneNumber")]
        public string AnotherPhoneNumber { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "MyInfoReadOnly_Address")]
        public string Address { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "MyInfoReadOnly_Gender")]
        public string Gender { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "MyInfoReadOnly_Email")]
        public string Email { get; set; }

      
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "MyInfoReadOnly_UserName")]
        public string UserName { get; set; }
    }
}