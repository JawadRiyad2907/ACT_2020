using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACT.ViewModel
{
    public class UserLevelInfoViewModel
    {
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Common_Level1Id")]
        public string level1Name { get; set; }
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Common_Level2Id")]
        public string level2Name { get; set; }
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Common_Level3Id")]
        public string level3Name { get; set; }
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Common_Level4Id")]
        public string level4Name { get; set; }

        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Common_UserCategoryId")]
        public string CategoryName { get; set; }
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "Common_JobTitleId")]
        public string JobName { get; set; }


        //falg for display in page
        public bool ShowCategory { get; set; }
        public bool ShowJobTitle { get; set; }


        public int LevelNumber { get; set; }
    }
}