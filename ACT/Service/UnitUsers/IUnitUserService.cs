using ACT.Utilities.Enum;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT.Service.UnitUsers
{
   public interface IUnitUserService: IGenericService<Models.UnitUser>
    {
        List<UnitUserJoinUserModel> GetUnitUserAdded(decimal unitId);
        List<UnitUserJoinUserModel> GetNonUnitUser(decimal unitId, Models.vw_All_Level levels, EnterpriseUnitsTypeEnum type);
        List<UnitUserJoinUserModel> GetUnitUsersAll(Models.vw_All_Level levels, EnterpriseUnitsTypeEnum type);
        List<UnitUserJoinUserModel> GetResponsibleUser(decimal unitId);
        void AddUserToUnit(decimal unitId, decimal[] UserAdded, decimal[] UserResponsible);
        void RemoveAllUserForUnit(decimal unitId);
        int GetCountUserForLevel( Models.vw_All_Level levels, EnterpriseUnitsTypeEnum type);
        }
}
