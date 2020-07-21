using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACT.ViewModel
{
    public class BaseUsersResponsibleForMeViewModel
    {

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Common_LevelName")]
        public string LevelName { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Common_UserCategoryId")]
        public decimal UserCategoryId { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Common_JobTitleId")]
        public decimal JobTitleId { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Common_User")]
        public decimal UserId { get; set; }

    }
}