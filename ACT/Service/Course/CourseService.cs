using ACT.Models;
using ACT.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ACT.Service
{

    public class CourseService : GenericService<Course>, ICourseService
    {
        public CourseService(ActEntities db) : base(db) { }
    }
}