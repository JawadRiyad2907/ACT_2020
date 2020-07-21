using ACT.Models;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ACT.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(ActEntities)).InstancePerDependency();
            builder.RegisterAssemblyTypes(Assembly.Load("ACT"))
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces()
                  .InstancePerRequest();
        }
    }
}