using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACT.ViewModel.Privelages
{
    public class MenuPrivelagesViewModel
    {
        public decimal Id { get; set; }
        public decimal MenuId { get; set; }
        public decimal? JobTitleId { get; set; }
        public decimal? CategoryId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public decimal CretaedBy { get; set; }
    }
}