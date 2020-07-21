using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ACT.Service
{

    public class Level1Service : GenericService<Level1>, ILevel1Service
    {
        public Level1Service(ActEntities db) : base(db) { }

        public void UpdateDefaultFalse()
        {
            var AllDefault = context.Level1.Where(x => x.IsDefault == true).ToList();
            foreach (var entity in AllDefault)
            {
                entity.IsDefault = false;
                context.Level1.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}