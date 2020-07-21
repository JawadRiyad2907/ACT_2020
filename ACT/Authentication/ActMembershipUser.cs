using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Linq;
using System.Web;
namespace ACT.Authentication
{
    public class ActMembershipUser : MembershipUser
    {
        #region User Properties
        public decimal Id { get; set; }
        public Nullable<decimal> Level1Id { get; set; }
        public Nullable<decimal> Level2Id { get; set; }
        public Nullable<decimal> Level3Id { get; set; }
        public Nullable<decimal> Level4Id { get; set; }
        public decimal UserCategoryId { get; set; }
        public decimal JobTitleId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public Nullable<decimal> CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<decimal> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string AnotherPhoneNumber { get; set; }
        public short GenderId { get; set; }
        public string Address { get; set; }
        public List<int> MenuIdsPermission { get; set; }
        public int MyLevelNumber { get; set; }
        public Nullable<bool> IsSystemAdmin { get; set; }
        public Models.vw_All_Level LevelResponsibleForMe { get; set; }
        #endregion

        public ActMembershipUser(Models.User user, Models.vw_All_Level levelResponsibleForMe) : base("ActMembershipProvider", user.UserName, user.Id, user.Email, string.Empty, string.Empty, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now)
        {
            Id = user.Id;
            Level1Id = user.Level1Id;
            Level2Id = user.Level2Id;
            Level3Id = user.Level3Id;
            Level4Id = user.Level4Id;
            UserCategoryId = user.UserCategoryId;
            JobTitleId = user.JobTitleId;
            UserName = user.UserName;
            Email = user.Email;
            Password = user.Password;
            Active = user.Active;
            CreatedBy = user.CreatedBy;
            CreatedDate = user.CreatedDate;
            UpdatedBy = user.UpdatedBy;
            UpdatedDate = user.UpdatedDate;
            FirstName = user.FirstName;
            SecondName = user.SecondName;
            ThirdName = user.ThirdName;
            LastName = user.LastName;
            PhoneNumber = user.PhoneNumber;
            AnotherPhoneNumber = user.AnotherPhoneNumber;
            GenderId = user.GenderId;
            Address = user.Address;
            IsSystemAdmin = user.UserCategory?.IsSystemAdmin;
            //Check if is Manager for this level 
            LevelResponsibleForMe = levelResponsibleForMe;
            if (LevelResponsibleForMe != null && IsSystemAdmin == true)
                LevelResponsibleForMe.LevelName = Resources.LocalizedText.Level0;
          
            //get my level number
            MyLevelNumber = user.Level4Id.HasValue ? 4 :
              user.Level3Id.HasValue ? 3 :
              user.Level2Id.HasValue ? 2 :
              user.Level1Id.HasValue ? 1 :
              0;

            //set menu permisstion
            MenuIdsPermission = new List<int>();
            var JobTitlePermisstion = user.JobTitle.MenuPrivelags.Select(x => x.MenuId).ToList();
            var UserCategoryPermisstion = user.UserCategory.MenuPrivelags.Select(x => x.MenuId).ToList();
            MenuIdsPermission.AddRange(JobTitlePermisstion);
            MenuIdsPermission.AddRange(UserCategoryPermisstion);
            MenuIdsPermission = MenuIdsPermission.Distinct().ToList();
        }
    }
}