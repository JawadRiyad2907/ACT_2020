using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ACT.Service
{

    public class UserService : GenericService<User>, IUserService
    {
        public UserService(ActEntities db) : base(db) { }


        public bool CheckLoginUser(string email, string password)
        {
            var isExist = context.Users.Any(u => u.Email == email
                                && u.Password == password && u.Active != false);
            return isExist;
        }


        public User GetByEmail(string email)
        {
            var user = context
                .Users
                .Where(a => a.Email == email)
                .Include(x => x.JobTitle.MenuPrivelags)
                .Include(x => x.UserCategory.MenuPrivelags)
                .FirstOrDefault();
            return user;
        }


        public List<User> GetDirectResponsibleSameLevel(int LevelNumber, decimal? SelectedLevel)
        {

            var query = from u in context.Users
                        join vw in context.vw_All_Level on u.Id equals vw.DirectResponsible into lefjoin
                        from vwLeft in lefjoin.DefaultIfEmpty()
                        where (
                          (LevelNumber == 1 && u.Level1Id == null) ||
                        (LevelNumber == 2 && u.Level1Id != null && u.Level2Id == null) ||
                        (LevelNumber == 3 && u.Level2Id != null && u.Level3Id == null) ||
                         (LevelNumber == 4 && u.Level3Id != null && u.Level4Id == null))
                         &&
                         (vwLeft.DirectResponsible == null || (
                          (LevelNumber == 1 && vwLeft.Level1Id == SelectedLevel) ||
                        (LevelNumber == 2 && vwLeft.Level2Id == SelectedLevel) ||
                        (LevelNumber == 3 && vwLeft.Level3Id == SelectedLevel) ||
                         (LevelNumber == 4 && vwLeft.Level4Id == SelectedLevel)))
                        select u;
            return query.ToList();
        }

    }
}