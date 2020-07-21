using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ACT.Service
{

    public class DirectResponsibleService : IDirectResponsibleService
    {
        protected readonly ActEntities context;
        public DirectResponsibleService(ActEntities context)
        {
            this.context = context;
        }

        public (List<DirectResponsibleViewModel> EntityData, int Count) GetForlevel1(int pageSize, int page, string levelName, string ResponsibleName)
        {
            var query = from lv in context.Level1
                        join user in context.Users on lv.DirectResponsible equals user.Id into left
                        from userLeft in left.DefaultIfEmpty()
                        select new DirectResponsibleViewModel
                        {
                            LevelName = lv.Name,
                            ResponsibleId = lv.DirectResponsible,
                            LevelId = lv.Id,
                            LevelNumber = 1,
                            DisplayOrder = lv.DisplayOrder,
                            ResponsibleName = userLeft == null ? null : (userLeft.FirstName + " " + userLeft.SecondName + " " + userLeft.ThirdName + " " + userLeft.LastName)
                        };



            if (!string.IsNullOrEmpty(levelName))
            {
                query = query.Where(x => x.LevelName.Contains(levelName));
            }
            if (!string.IsNullOrEmpty(ResponsibleName))
            {
                query = query.Where(x => x.ResponsibleName.Contains(ResponsibleName));
            }
            query = query.OrderBy(x => x.DisplayOrder);
            var count = query.Count();
            var data = query.Skip(page).Take(pageSize).ToList();
            return (data, count);
        }

        public (List<DirectResponsibleViewModel> EntityData, int Count) GetForlevel2(int pageSize, int page, string levelName, string ResponsibleName)
        {
            var query = from lv in context.Level2
                        join user in context.Users on lv.DirectResponsible equals user.Id into left
                        from userLeft in left.DefaultIfEmpty()
                        select new DirectResponsibleViewModel
                        {
                            LevelName = lv.Name,
                            ResponsibleId = lv.DirectResponsible,
                            LevelId = lv.Id,
                            LevelNumber = 2,
                            DisplayOrder = lv.DisplayOrder,
                            ResponsibleName = userLeft == null ? null : (userLeft.FirstName + " " + userLeft.SecondName + " " + userLeft.ThirdName + " " + userLeft.LastName)
                        };
            if (!string.IsNullOrEmpty(levelName))
            {
                query = query.Where(x => x.LevelName.Contains(levelName));
            }
            if (!string.IsNullOrEmpty(ResponsibleName))
            {
                query = query.Where(x => x.ResponsibleName.Contains(ResponsibleName));
            }
            query = query.OrderBy(x => x.DisplayOrder);
            var count = query.Count();
            var data = query.Skip(page).Take(pageSize).ToList();
            return (data, count);
        }


        public (List<DirectResponsibleViewModel> EntityData, int Count) GetForlevel3(int pageSize, int page, string levelName, string ResponsibleName)
        {
            var query = from lv in context.Level3
                        join user in context.Users on lv.DirectResponsible equals user.Id into left
                        from userLeft in left.DefaultIfEmpty()
                        select new DirectResponsibleViewModel
                        {
                            LevelName = lv.Name,
                            ResponsibleId = lv.DirectResponsible,
                            LevelId = lv.Id,
                            LevelNumber = 3,
                            DisplayOrder = lv.DisplayOrder,
                            ResponsibleName = userLeft == null ? null : (userLeft.FirstName + " " + userLeft.SecondName + " " + userLeft.ThirdName + " " + userLeft.LastName)
                        };
            if (!string.IsNullOrEmpty(levelName))
            {
                query = query.Where(x => x.LevelName.Contains(levelName));
            }
            if (!string.IsNullOrEmpty(ResponsibleName))
            {
                query = query.Where(x => x.ResponsibleName.Contains(ResponsibleName));
            }
            query = query.OrderBy(x => x.DisplayOrder);
            var count = query.Count();
            var data = query.Skip(page).Take(pageSize).ToList();
            return (data, count);
        }


        public (List<DirectResponsibleViewModel> EntityData, int Count) GetForlevel4(int pageSize, int page, string levelName, string ResponsibleName)
        {
            var query = from lv in context.Level4
                        join user in context.Users on lv.DirectResponsible equals user.Id into left
                        from userLeft in left.DefaultIfEmpty()
                        select new DirectResponsibleViewModel
                        {
                            LevelName = lv.Name,
                            ResponsibleId = lv.DirectResponsible,
                            LevelId = lv.Id,
                            LevelNumber = 4,
                            DisplayOrder = lv.DisplayOrder,
                            ResponsibleName = userLeft == null ? null : (userLeft.FirstName + " " + userLeft.SecondName + " " + userLeft.ThirdName + " " + userLeft.LastName)
                        };
            if (!string.IsNullOrEmpty(levelName))
            {
                query = query.Where(x => x.LevelName.Contains(levelName));
            }
            if (!string.IsNullOrEmpty(ResponsibleName))
            {
                query = query.Where(x => x.ResponsibleName.Contains(ResponsibleName));
            }
            query = query.OrderBy(x => x.DisplayOrder);
            var count = query.Count();
            var data = query.Skip(page).Take(pageSize).ToList();
            return (data, count);
        }


        public DirectResponsibleViewModel GetDirectResponsiblelevel(decimal LevelId, int MyLevelNumber)
        {
            IQueryable<DirectResponsibleViewModel> query = Enumerable.Empty<DirectResponsibleViewModel>().AsQueryable();
            if (MyLevelNumber == 0)
            {
                query = from lv in context.Level1
                        join user in context.Users on lv.DirectResponsible equals user.Id into left
                        from userLeft in left.DefaultIfEmpty()
                        where lv.Id == LevelId
                        select new DirectResponsibleViewModel
                        {
                            LevelName = lv.Name,
                            ResponsibleId = lv.DirectResponsible,
                            LevelId = lv.Id,
                            LevelNumber = 1,
                            DisplayOrder = lv.DisplayOrder,
                            ResponsibleName = userLeft.FirstName + " " + userLeft.SecondName + " " + userLeft.ThirdName + " " + userLeft.LastName
                        };
            }
            else if (MyLevelNumber == 1)
            {
                query = from lv in context.Level2
                        join user in context.Users on lv.DirectResponsible equals user.Id into left
                        from userLeft in left.DefaultIfEmpty()
                        where lv.Id == LevelId
                        select new DirectResponsibleViewModel
                        {
                            LevelName = lv.Name,
                            ResponsibleId = lv.DirectResponsible,
                            LevelId = lv.Id,
                            LevelNumber = 2,
                            DisplayOrder = lv.DisplayOrder,
                            ResponsibleName = userLeft.FirstName + " " + userLeft.SecondName + " " + userLeft.ThirdName + " " + userLeft.LastName
                        };
            }
            else if (MyLevelNumber == 2)
            {
                query = from lv in context.Level3
                        join user in context.Users on lv.DirectResponsible equals user.Id into left
                        from userLeft in left.DefaultIfEmpty()
                        where lv.Id == LevelId
                        select new DirectResponsibleViewModel
                        {
                            LevelName = lv.Name,
                            ResponsibleId = lv.DirectResponsible,
                            LevelId = lv.Id,
                            LevelNumber = 3,
                            DisplayOrder = lv.DisplayOrder,
                            ResponsibleName = userLeft.FirstName + " " + userLeft.SecondName + " " + userLeft.ThirdName + " " + userLeft.LastName
                        };
            }
            else if (MyLevelNumber == 3)
            {
                query = from lv in context.Level4
                        join user in context.Users on lv.DirectResponsible equals user.Id into left
                        from userLeft in left.DefaultIfEmpty()
                        where lv.Id == LevelId
                        select new DirectResponsibleViewModel
                        {
                            LevelName = lv.Name,
                            ResponsibleId = lv.DirectResponsible,
                            LevelId = lv.Id,
                            LevelNumber = 4,
                            DisplayOrder = lv.DisplayOrder,
                            ResponsibleName = userLeft.FirstName + " " + userLeft.SecondName + " " + userLeft.ThirdName + " " + userLeft.LastName
                        };
            }
            return query.FirstOrDefault();
        }


        public void UpdateDirectResponsiblelevel(DirectResponsibleViewModel model)
        {

            if (model.LevelNumber == 0)
            {
                var entityModel = context.Level1.Find(model.LevelId);
                entityModel.DirectResponsible = model.ResponsibleId;
                context.Set<Level1>().Attach(entityModel);
                context.Entry(entityModel).State = EntityState.Modified;
                context.SaveChanges();
                context.Entry(entityModel).State = EntityState.Detached;
            }
            else if (model.LevelNumber == 1)
            {
                var entityModel = context.Level2.Find(model.LevelId);
                entityModel.DirectResponsible = model.ResponsibleId;
                context.Set<Level2>().Attach(entityModel);
                context.Entry(entityModel).State = EntityState.Modified;
                context.SaveChanges();
                context.Entry(entityModel).State = EntityState.Detached;
            }
            else if (model.LevelNumber == 2)
            {
                var entityModel = context.Level3.Find(model.LevelId);
                entityModel.DirectResponsible = model.ResponsibleId;
                context.Set<Level3>().Attach(entityModel);
                context.Entry(entityModel).State = EntityState.Modified;
                context.SaveChanges();
                context.Entry(entityModel).State = EntityState.Detached;
            }
            else if (model.LevelNumber == 3)
            {
                var entityModel = context.Level4.Find(model.LevelId);
                entityModel.DirectResponsible = model.ResponsibleId;
                context.Set<Level4>().Attach(entityModel);
                context.Entry(entityModel).State = EntityState.Modified;
                context.SaveChanges();
                context.Entry(entityModel).State = EntityState.Detached;
            }

        }


    }
}