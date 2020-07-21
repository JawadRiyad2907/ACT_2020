using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACT.ViewModel
{
    public class DirectResponsibleViewModel
    {
        public decimal LevelId { get; set; }
        public int LevelNumber { get; set; }
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "DirectResponsible_LevelName")]
        public string LevelName { get; set; }
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "DirectResponsible_ResponsibleName")]
        public decimal? ResponsibleId { get; set; }
        [Display(ResourceType = typeof(Resources.LocalizedText), Name = "DirectResponsible_ResponsibleName")]
        public string ResponsibleName { get; set; }
        public decimal DisplayOrder { get; set; }


        public List<SelectListItem> AlvailableResponsibleList { get; set; }
    }
}