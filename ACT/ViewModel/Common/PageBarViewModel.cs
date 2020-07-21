using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACT.ViewModel
{
    public class PageBarViewModel
    {
      
        public string Description { get; set; }
        public string Url { get; set; }
        public int Order { get; set; }
        public bool IsFirst  { get; set; }
        public bool IsLast { get; set; }
    }
}