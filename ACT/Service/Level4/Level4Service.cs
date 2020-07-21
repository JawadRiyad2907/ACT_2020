using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ACT.Service
{

    public class Level4Service : GenericService<Level4>, ILevel4Service
    {
        public Level4Service(ActEntities db) : base(db) { }

        public void UpdateDefaultFalse()
        {
            var AllDefault = context.Level4.Where(x => x.IsDefault == true).ToList();
            foreach (var entity in AllDefault)
            {
                entity.IsDefault = false;
                context.Level4.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}