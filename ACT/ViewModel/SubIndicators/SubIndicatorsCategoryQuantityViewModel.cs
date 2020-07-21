using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACT.ViewModel
{
    public class SubIndicatorsCategoryQuantityViewModel
    {

        public decimal Id { get; set; }
        public decimal TargetCategory { get; set; }
        public decimal CategoryId { get; set; }
        public decimal ItemId { get; set; }
        public decimal StandardId { get; set; }
        public bool? IsContinuous { get; set; }
        public string Quantity { get; set; }

    }
}