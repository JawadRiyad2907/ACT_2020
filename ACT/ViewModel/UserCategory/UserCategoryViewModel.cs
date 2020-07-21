using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACT.ViewModel
{
    public class UserCategoryViewModel : BaseLevelViewModel
    {

        public UserCategoryViewModel()
        {
            TypeList = new List<SelectListItem>();
        }

        public decimal Id { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "UserCategory_Type")]
        public short Type { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "UserCategory_Name")]
        public string Name { get; set; }

       
        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "UserCategory_DisplayOrder")]
        public decimal DisplayOrder { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.LocalizedText), ErrorMessageResourceName = "Validation_Required")]
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "UserCategory_Active")]
        public bool Active { get; set; }


        //Select Lists
        public List<SelectListItem> TypeList { get; set; }


        //FK
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "UserCategory_LevelName")]
        public string LevelName { get; set; }

    }
}