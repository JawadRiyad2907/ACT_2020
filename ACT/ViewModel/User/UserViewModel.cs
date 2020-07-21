using ACT.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACT.ViewModel
{
    public class UserViewModel : BaseJobTitleViewModel
    {

        public UserViewModel()
        {
            AlvailableGenderList = new List<SelectListItem>();
        }


        public decimal Id { get; set; }



        [System.Web.Mvc.Remote(action: "IsUserNameAvailable", controller: "User", areaName: "UsersManagement", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_IsExists")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "User_UserName")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        public string UserName { get; set; }


        [System.Web.Mvc.Remote(action: "IsEmailAvailable", controller: "User", areaName: "UsersManagement", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_IsExists")]
        [RegularExpression(Formats.EmailRegex, ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Email")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "User_Email")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        public string Email { get; set; }


        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "User_Password")]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "User_Active")]
        public bool Active { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "User_FirstName")]
        public string FirstName { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "User_SecondName")]
        public string SecondName { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "User_ThirdName")]
        public string ThirdName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "User_LastName")]
        public string LastName { get; set; }


        [RegularExpression(Formats.OnlyNumberRegex, ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Number")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "User_PhoneNumber")]
        public string PhoneNumber { get; set; }

        [RegularExpression(Formats.OnlyNumberRegex, ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Number")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "User_AnotherPhoneNumber")]
        public string AnotherPhoneNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "User_GenderId")]
        public short GenderId { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "User_Address")]
        public string Address { get; set; }

        [RegularExpression(@"^[A-Za-z0-9_]+$", ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_EnglishChar")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "User_FirstNameEn")]
        public string FirstNameEn { get; set; }

        [RegularExpression(@"^[A-Za-z0-9_]+$", ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_EnglishChar")]
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "User_LastNameEn")]
        public string LastNameEn { get; set; }


        //Alvailable List
        public List<SelectListItem> AlvailableGenderList { get; set; }

        //FK
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "User_UserCategoryName")]
        public string UserCategoryName { get; set; }
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "User_JobTitleName")]
        public string JobTitleName { get; set; }


        //Enum localization
        public string GenderLoc { get; set; }
    }
}