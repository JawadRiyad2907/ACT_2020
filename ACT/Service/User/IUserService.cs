using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACT.Service
{
 
    public interface IUserService : IGenericService<User>
    {
        bool CheckLoginUser(string email, string password);
        User GetByEmail(string email);
        List<User> GetDirectResponsibleSameLevel( int LevelNumber, decimal? SelectedLevel);
    }
}