using ACT.Authentication;
using ACT.AutoMapper;
using ACT.Modules;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace ACT
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Mapper.Initialize(AutoMapperConfiguration.Configure);

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();
            builder.RegisterModule(new ServiceModule());
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }


        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies["ActCookie"];
            if (authCookie != null)
            {
                if (authCookie.Value != "")
                {
                    authCookie.Expires = DateTime.Now.AddMinutes(60);
                    Response.Cookies.Add(authCookie);
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    var serializeModel = JsonConvert.DeserializeObject<ActSerializeModel>(authTicket.UserData);
                    ActPrincipal principal = new ActPrincipal(authTicket.Name);
                    principal.Id = serializeModel.Id;
                    principal.Level1Id = serializeModel.Level1Id;
                    principal.Level2Id = serializeModel.Level2Id;
                    principal.Level3Id = serializeModel.Level3Id;
                    principal.Level4Id = serializeModel.Level4Id;
                    principal.UserCategoryId = serializeModel.UserCategoryId;
                    principal.JobTitleId = serializeModel.JobTitleId;
                    principal.UserName = serializeModel.UserName;
                    principal.Email = serializeModel.Email;
                    principal.Password = serializeModel.Password;
                    principal.Active = serializeModel.Active;
                    principal.CreatedBy = serializeModel.CreatedBy;
                    principal.CreatedDate = serializeModel.CreatedDate;
                    principal.UpdatedBy = serializeModel.UpdatedBy;
                    principal.UpdatedDate = serializeModel.UpdatedDate;
                    principal.FirstName = serializeModel.FirstName;
                    principal.SecondName = serializeModel.SecondName;
                    principal.ThirdName = serializeModel.ThirdName;
                    principal.LastName = serializeModel.LastName;
                    principal.PhoneNumber = serializeModel.PhoneNumber;
                    principal.AnotherPhoneNumber = serializeModel.AnotherPhoneNumber;
                    principal.GenderId = serializeModel.GenderId;
                    principal.Address = serializeModel.Address;
                    principal.MenuIdsPermission = serializeModel.MenuIdsPermission;
                    principal.MyLevelNumber = serializeModel.MyLevelNumber;
                    principal.LevelResponsibleForMe = serializeModel.LevelResponsibleForMe;
                    principal.IsSystemAdmin = serializeModel.IsSystemAdmin;
                    HttpContext.Current.User = principal;
                }
            }
        }

        protected void Application_BeginRequest()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }
    }
}
