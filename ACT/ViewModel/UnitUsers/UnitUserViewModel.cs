using ACT.Utilities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACT.ViewModel.UnitUsers
{
    public class UnitUserViewModel
    {


        public string UnitName { get; set; }

        public decimal UnitId { get; set; }

        public decimal[] UserNotAdded { get; set; }

        public IEnumerable<SelectListItem> UserNotAddedList { get; set; }

        public decimal[] UserAdded { get; set; }

        public IEnumerable<SelectListItem> UserAddedList { get; set; }


        public decimal[] UserResponsible { get; set; }

        public IEnumerable<SelectListItem> UserResponsibleList { get; set; }

        public EnterpriseUnitsTypeEnum type { get; set; }

    }
}