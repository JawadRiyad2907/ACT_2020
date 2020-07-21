using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACT.ViewModel
{
    public class LanguageViewModel
    {
        public decimal Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LanguageCulture { get; set; }
        public string UniqueSeoCode { get; set; }
        [Required]
        public string FlagImageFileName { get; set; }
        [Required]
        public bool Rtl { get; set; }
        [Required]
        public bool Published { get; set; }
        [Required]
        public decimal DisplayOrder { get; set; }
    }
}