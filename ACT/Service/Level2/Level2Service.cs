using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ACT.Service
{

    public class Level2Service : GenericService<Level2>, ILevel2Service
    {
        public Level2Service(ActEntities db) : base(db) { }

        public void UpdateDefaultFalse()
        {
            var AllDefault = context.Level2.Where(x => x.IsDefault == true).ToList();
            foreach (var entity in AllDefault)
            {
                entity.IsDefault = false;
                context.Level2.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}