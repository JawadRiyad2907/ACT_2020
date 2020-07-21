using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACT.General.Json
{
    public class GeneralJsonResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public string ReturnUrl { get; set; }
    }
}