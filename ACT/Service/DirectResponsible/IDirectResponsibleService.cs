using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACT.Service
{

    public interface IDirectResponsibleService
    {
        (List<DirectResponsibleViewModel> EntityData, int Count) GetForlevel1(int pageSize, int page, string levelName, string ResponsibleName);
        (List<DirectResponsibleViewModel> EntityData, int Count) GetForlevel2(int pageSize, int page, string levelName, string ResponsibleName);
        (List<DirectResponsibleViewModel> EntityData, int Count) GetForlevel3(int pageSize, int page, string levelName, string ResponsibleName);
        (List<DirectResponsibleViewModel> EntityData, int Count) GetForlevel4(int pageSize, int page, string levelName, string ResponsibleName);
        DirectResponsibleViewModel GetDirectResponsiblelevel(decimal LevelId, int MyLevelNumber);
        void UpdateDirectResponsiblelevel(DirectResponsibleViewModel model);
    }
}