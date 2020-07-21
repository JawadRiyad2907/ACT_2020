using ACT.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACT.Utilities.Extensions
{
    public abstract class ActViewPage : WebViewPage
    {
        public virtual new ActPrincipal User
        {
            get { return base.User as ActPrincipal; }
        }
    }

    public abstract class ActViewPage<TModel> : WebViewPage<TModel>
    {
        public virtual new ActPrincipal User
        {
            get { return base.User as ActPrincipal; }
        }
    }
}