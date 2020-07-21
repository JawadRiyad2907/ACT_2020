using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACT.ViewModel
{
    public class LanguageMenuBaseViewModel
    {
        public LanguageMenuViewModel Currnet { get; set; }
        public List<LanguageMenuViewModel> Menu { get; set; }
    }
    public class LanguageMenuViewModel
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string LanguageCulture { get; set; }
        public string UniqueSeoCode { get; set; }
        public string FlagImageFileName { get; set; }
        public bool Rtl { get; set; }
        public bool Published { get; set; }
        public decimal DisplayOrder { get; set; }
    }
}