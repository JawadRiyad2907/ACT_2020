using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ACT.Service
{

    public class Level3Service : GenericService<Level3>, ILevel3Service
    {
        public Level3Service(ActEntities db) : base(db) { }

        public void UpdateDefaultFalse()
        {
            var AllDefault = context.Level3.Where(x => x.IsDefault == true).ToList();
            foreach (var entity in AllDefault)
            {
                entity.IsDefault = false;
                context.Level3.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}