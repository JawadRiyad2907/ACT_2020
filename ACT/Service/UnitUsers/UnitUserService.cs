using ACT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ACT.Utilities.Enum;
using ACT.ViewModel;

namespace ACT.Service.UnitUsers
{
    public class UnitUserService : GenericService<Models.UnitUser>, IUnitUserService
    {
        public UnitUserService(ActEntities context) : base(context)
        {
        }

        #region Methods

        public List<UnitUserJoinUserModel> GetUnitUserAdded(decimal unitId)
        {
            var query = (from usrUnitTbl in context.UnitUsers
                         join usrDataTbl in context.Users on usrUnitTbl.UserId equals usrDataTbl.Id
                         where usrUnitTbl.UnitId == unitId && (!usrUnitTbl.IsResponsible.HasValue || !usrUnitTbl.IsResponsible.Value)
                         select new UnitUserJoinUserModel()
                         {
                             FullName = usrDataTbl.FirstName + " " + usrDataTbl.SecondName + " " + usrDataTbl.ThirdName + " " + usrDataTbl.LastName,
                             Id = usrUnitTbl.Id,
                             UserId = usrDataTbl.Id,
                             UnitId = unitId
                         }
                        );
            return query.ToList();
        }


        public List<UnitUserJoinUserModel> GetResponsibleUser(decimal unitId)
        {
            var query = (from usrUnitTbl in context.UnitUsers
                         join usrDataTbl in context.Users on usrUnitTbl.UserId equals usrDataTbl.Id
                         where usrUnitTbl.UnitId == unitId && usrUnitTbl.IsResponsible.HasValue && usrUnitTbl.IsResponsible.Value
                         select new UnitUserJoinUserModel()
                         {
                             FullName = usrDataTbl.FirstName + " " + usrDataTbl.SecondName + " " + usrDataTbl.ThirdName + " " + usrDataTbl.LastName,
                             Id = usrUnitTbl.Id,
                             UserId = usrDataTbl.Id,
                             UnitId = unitId
                         }
                        );
            return query.ToList();
        }

        public List<UnitUserJoinUserModel> GetNonUnitUser(decimal unitId, Models.vw_All_Level levels, EnterpriseUnitsTypeEnum type)
        {
            var query = (from usrDataTbl in context.Users
                         join usrUnitTbl in context.UnitUsers on usrDataTbl.Id equals usrUnitTbl.UserId into usrs
                         join cat in context.UserCategories on usrDataTbl.UserCategoryId equals cat.Id
                         from usr in usrs.DefaultIfEmpty()
                         join userEnterUnitTbl in context.EnterpriseUnits on usr.UnitId equals userEnterUnitTbl.Id into usersEnter
                         from usrsEnter in usersEnter.DefaultIfEmpty()
                         where (usr.UnitId <= 0 || usr.UnitId == null) && cat.Type == (int)type
                          && (usrDataTbl.Level1Id == levels.Level1Id) && (usrDataTbl.Level2Id == levels.Level2Id) && (usrDataTbl.Level3Id == levels.Level3Id) && (usrDataTbl.Level4Id == levels.Level4Id)
                         // ||usr.UnitId != unitId //&& usrDataTbl.UserCategoryId == catId
                         select new UnitUserJoinUserModel()
                         {
                             FullName = usrDataTbl.FirstName + " " + usrDataTbl.SecondName + " " + usrDataTbl.ThirdName + " " + usrDataTbl.LastName,
                             Id = usrDataTbl.Id,
                             UserId = usrDataTbl.Id,
                             UnitId = usr.UnitId,
                             UnitName = usrsEnter.Name

                         }
                    );
            return query.ToList();

        }

        public void AddUserToUnit(decimal unitId, decimal[] UserAdded, decimal[] UserResponsible)
        {
            var unitUsers = new List<Models.UnitUser>();
            if (UserAdded != null)
            {
                foreach (var userId in UserAdded)
                {
                    unitUsers.Add(new UnitUser { UnitId = unitId, UserId = userId });
                }
            }
            if (UserResponsible != null)
            {
                foreach (var userId in UserResponsible)
                {
                    unitUsers.Add(new UnitUser { UnitId = unitId, UserId = userId, IsResponsible = true });
                }
            }

            AddRange(unitUsers);
        }


        public void RemoveAllUserForUnit(decimal unitId)
        {
            var entityRemove = context.UnitUsers.Where(x => x.UnitId == unitId);
            DeleteRange(entityRemove);
        }

        public int GetCountUserForLevel( Models.vw_All_Level levels, EnterpriseUnitsTypeEnum type)
        {
            var query = (from usrDataTbl in context.Users
                         join cat in context.UserCategories on usrDataTbl.UserCategoryId equals cat.Id
                         where cat.Type == (int)type
                          && (usrDataTbl.Level1Id == levels.Level1Id) && (usrDataTbl.Level2Id == levels.Level2Id) && (usrDataTbl.Level3Id == levels.Level3Id) && (usrDataTbl.Level4Id == levels.Level4Id)
                         select usrDataTbl.Id);
            return query.Count();
        }

       
        /// <summary>
        /// Use to get the  all users (added, and not)
        /// </summary>
        /// <param name="levels"></param>
        /// <returns>List of UnitUserJoinUserDto</returns>
        public List<UnitUserJoinUserModel> GetUnitUsersAll(Models.vw_All_Level levels, EnterpriseUnitsTypeEnum type)
        {
            var query = (from usrDataTbl in context.Users
                         join usrUnitTbl in context.UnitUsers on usrDataTbl.Id equals usrUnitTbl.UserId into usrs
                         join cat in context.UserCategories on usrDataTbl.UserCategoryId equals cat.Id
                         from usr in usrs.DefaultIfEmpty()
                         join userEnterUnitTbl in context.EnterpriseUnits on usr.UnitId equals userEnterUnitTbl.Id into usersEnter
                         from usrsEnter in usersEnter.DefaultIfEmpty()
                         where cat.Type == (int)type &&
                         (usrDataTbl.Level1Id == levels.Level1Id) && (usrDataTbl.Level2Id == levels.Level2Id) && (usrDataTbl.Level3Id == levels.Level3Id) && (usrDataTbl.Level4Id == levels.Level4Id)
                         // ||usr.UnitId != unitId //&& usrDataTbl.UserCategoryId == catId
                         select new UnitUserJoinUserModel()
                         {
                             FullName = usrDataTbl.FirstName + " " + usrDataTbl.SecondName + " " + usrDataTbl.ThirdName + " " + usrDataTbl.LastName,
                             Id = usr.Id,
                             UserId = usrDataTbl.Id,
                             UnitId = usr.UnitId,
                             UnitName = usrsEnter.Name

                         }
        );
            return query.ToList();

        }

        #endregion
    }
}