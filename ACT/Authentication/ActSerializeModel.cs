using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACT.Authentication
{
    public class ActSerializeModel
    {
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
        public int MyLevelNumber { get; set; }
        public List<int> MenuIdsPermission { get; set; }
        public Nullable<bool> IsSystemAdmin { get; set; }
        public Models.vw_All_Level LevelResponsibleForMe { get; set; }

    }
}