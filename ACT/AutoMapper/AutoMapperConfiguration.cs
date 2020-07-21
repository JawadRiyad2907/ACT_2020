using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACT.Models;
using ACT.ViewModel;
using ACT.ViewModel.JobTitle;
using ACT.Utilities.Extensions;
using ACT.Utilities.Enum;
using ACT.Utilities.Helper;
using ACT.ViewModel.Privelages;
using ACT.Authentication;
using ACT.Utilities.Constants;
using ACT.ViewModel.UnitUsers;
namespace ACT.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static void Configure(IMapperConfigurationExpression config)
        {
            ConfigureToViewModel(config);
            ConfigureToModel(config);
        }


        public static void ConfigureToModel(IMapperConfigurationExpression config)
        {
            config.CreateMap<UnitUser, UnitUserJoinUserModel>().ReverseMap();
        }

        public static void ConfigureToViewModel(IMapperConfigurationExpression config)
        {
            //Language
            config.CreateMap<Language, LanguageViewModel>().ReverseMap();
            config.CreateMap<Language, LanguageMenuViewModel>().ReverseMap();
            config.CreateMap<Language, LanguageMenuBaseViewModel>().ReverseMap();

            //Level1
            config.CreateMap<Level1, Level1ViewModel>().ReverseMap();

            //Level2
            config.CreateMap<Level2, Level2ViewModel>()
                .ForMember(dest => dest.Level1Name, opt => opt.MapFrom(s => s.Level1.Name));

            config.CreateMap<Level2ViewModel, Level2>()
                .ForMember(dest => dest.Level1, opt => opt.Ignore());

            //Level3
            config.CreateMap<Level3, Level3ViewModel>()
                .ForMember(dest => dest.Level1Name, opt => opt.MapFrom(s => s.Level2.Level1.Name))
                 .ForMember(dest => dest.Level2Name, opt => opt.MapFrom(s => s.Level2.Name));

            config.CreateMap<Level3ViewModel, Level3>()
                .ForMember(dest => dest.Level1, opt => opt.Ignore())
                .ForMember(dest => dest.Level2, opt => opt.Ignore());


            //Level4
            config.CreateMap<Level4, Level4ViewModel>()
                .ForMember(dest => dest.Level1Name, opt => opt.MapFrom(s => s.Level1.Name))
                 .ForMember(dest => dest.Level2Name, opt => opt.MapFrom(s => s.Level2.Name))
                  .ForMember(dest => dest.Level3Name, opt => opt.MapFrom(s => s.Level3.Name));

            config.CreateMap<Level4ViewModel, Level4>()
                .ForMember(dest => dest.Level1, opt => opt.Ignore())
                .ForMember(dest => dest.Level2, opt => opt.Ignore())
                .ForMember(dest => dest.Level3, opt => opt.Ignore());


            //Category
            config.CreateMap<UserCategory, UserCategoryViewModel>()
                 .ForMember(dest => dest.LevelName, opt => opt.MapFrom(s =>
                 (s.Level1 == null ? "" : s.Level1.Name) +
                  (s.Level2 == null ? "" : " / " + s.Level2.Name) +
                   (s.Level3 == null ? "" : " / " + s.Level3.Name) +
                    (s.Level4 == null ? "" : " / " + s.Level4.Name)
                 ));

            config.CreateMap<UserCategoryViewModel, UserCategory>()
                .ForMember(dest => dest.Level1, opt => opt.Ignore())
                .ForMember(dest => dest.Level2, opt => opt.Ignore())
                .ForMember(dest => dest.Level3, opt => opt.Ignore())
                 .ForMember(dest => dest.Level4, opt => opt.Ignore());

            //JobTitle
            config.CreateMap<JobTitle, JobTitleViewModel>()
            .ForMember(dest => dest.UserCategoryName, opt => opt.MapFrom(s => s.UserCategory.Name));

            //MenuPrvilages
            config.CreateMap<MenuPrivelag, MenuPrivelagesViewModel>().ReverseMap();


            config.CreateMap<JobTitleViewModel, JobTitle>()
                .ForMember(dest => dest.Level1, opt => opt.Ignore())
                .ForMember(dest => dest.Level2, opt => opt.Ignore())
                .ForMember(dest => dest.Level3, opt => opt.Ignore())
                 .ForMember(dest => dest.Level4, opt => opt.Ignore());


            //User
            config.CreateMap<User, UserViewModel>()
            .ForMember(dest => dest.UserCategoryName, opt => opt.MapFrom(s => s.UserCategory.Name))
             .ForMember(dest => dest.JobTitleName, opt => opt.MapFrom(s => s.JobTitle.JobName))
               .ForMember(dest => dest.GenderLoc, opt => opt.MapFrom(s => EnumExtentions.GetEnumStringById(typeof(GenderEnum), s.GenderId)));

            config.CreateMap<UserViewModel, User>()
            .ForMember(dest => dest.Level1, opt => opt.Ignore())
            .ForMember(dest => dest.Level2, opt => opt.Ignore())
            .ForMember(dest => dest.Level3, opt => opt.Ignore())
             .ForMember(dest => dest.Level4, opt => opt.Ignore())
             .ForMember(dest => dest.UserCategory, opt => opt.Ignore())
             .ForMember(dest => dest.JobTitle, opt => opt.Ignore())
              .ForMember(dest => dest.Password, opt => opt.MapFrom(s => Cryptor.Encrypt(s.Password)));

            //Authentication
            config.CreateMap<ActMembershipUser, ActSerializeModel>().ReverseMap();


            //Enterprise Unit
            config.CreateMap<EnterpriseUnit, AdministrativeUnitsViewModel>()
                .ForMember(dest => dest.children, opt => opt.MapFrom(s => s.EnterpriseUnits1))
                .ForMember(dest => dest.ParentName, opt => opt.MapFrom(s => s.EnterpriseUnit1 != null ? s.EnterpriseUnit1.Name : ""))
                .ForMember(dest => dest.UnitUsersFullName, opt => opt.MapFrom(s => s.UnitUsers != null ? s.UnitUsers.Select(x => x.User.FirstName + " " + x.User.SecondName + " " + x.User.ThirdName + " " + x.User.LastName) : new List<string>()))
                .ForMember(dest => dest.CountAdditiveUsers, opt => opt.MapFrom(s => s.UnitUsers != null ? s.UnitUsers.Count : 0));


            config.CreateMap<AdministrativeUnitsViewModel, EnterpriseUnit>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


            config.CreateMap<EnterpriseUnit, EducationalUnitsViewModel>()
              .ForMember(dest => dest.children, opt => opt.MapFrom(s => s.EnterpriseUnits1))
              .ForMember(dest => dest.ParentName, opt => opt.MapFrom(s => s.EnterpriseUnit1 != null ? s.EnterpriseUnit1.Name : ""))
              .ForMember(dest => dest.UnitUsersFullName, opt => opt.MapFrom(s => s.UnitUsers != null ? s.UnitUsers.Select(x => x.User.FirstName + " " + x.User.SecondName + " " + x.User.ThirdName + " " + x.User.LastName) : new List<string>()))
              .ForMember(dest => dest.CountAdditiveUsers, opt => opt.MapFrom(s => s.UnitUsers != null ? s.UnitUsers.Count : 0));

            config.CreateMap<EducationalUnitsViewModel, EnterpriseUnit>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            //User Leve lInfo ViewModel 
            config.CreateMap<User, UserLevelInfoViewModel>()
           .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(s => s.UserCategory.Name))
            .ForMember(dest => dest.JobName, opt => opt.MapFrom(s => s.JobTitle.JobName))
            .ForMember(dest => dest.level1Name, opt => opt.MapFrom(s => s.Level11.Name))
            .ForMember(dest => dest.level2Name, opt => opt.MapFrom(s => s.Level21.Name))
            .ForMember(dest => dest.level3Name, opt => opt.MapFrom(s => s.Level31.Name))
            .ForMember(dest => dest.level4Name, opt => opt.MapFrom(s => s.Level41.Name))
            .ForMember(dest => dest.LevelNumber, opt => opt.MapFrom(s => GetLevelNumber(s.Level1Id, s.Level2Id, s.Level3Id, s.Level4Id)));


            //My Info Read Only
            config.CreateMap<User, MyInfoReadOnlyViewModel>()
              .ForMember(dest => dest.Gender, opt => opt.MapFrom(s => EnumExtentions.GetEnumStringById(typeof(GenderEnum), s.GenderId)));

            //My Info
            config.CreateMap<User, MyInfoViewModel>().ReverseMap();


            //Qualification
            config.CreateMap<Qualification, QualificationViewModel>()
              .ForMember(dest => dest.ScientificDegreeName, opt => opt.MapFrom(s => s.CientificDegree.Name));


            config.CreateMap<QualificationViewModel, Qualification>();


            //Course

            config.CreateMap<Course, CourseViewModel>()
            .ForMember(dest => dest.FromDate, opt => opt.MapFrom(s => s.FromDate.ToString(Formats.UkFormatForString)))
             .ForMember(dest => dest.ToDate, opt => opt.MapFrom(s => s.ToDate.ToString(Formats.UkFormatForString)));

            config.CreateMap<CourseViewModel, Course>()
             .ForMember(dest => dest.FromDate, opt => opt.MapFrom(s => DateTime.Parse(s.FromDate)))
             .ForMember(dest => dest.ToDate, opt => opt.MapFrom(s => DateTime.Parse(s.ToDate)));


            //Course

            config.CreateMap<CertificatesAndAward, CertificatesAndAwardViewModel>()
            .ForMember(dest => dest.DateOfCertificate, opt => opt.MapFrom(s => s.DateOfCertificate.ToString(Formats.UkFormatForString)));

            config.CreateMap<CertificatesAndAwardViewModel, CertificatesAndAward>()
             .ForMember(dest => dest.DateOfCertificate, opt => opt.MapFrom(s => DateTime.Parse(s.DateOfCertificate)));

            //Standard
            config.CreateMap<Standard, StandardViewModel>();

            config.CreateMap<StandardViewModel, Standard>()
        .ForMember(dest => dest.Item, opt => opt.Ignore());

            //Sub Indicators 

            config.CreateMap<SubIndicatorsCategory, SubIndicatorsCategoryViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.Id))
             .ForMember(dest => dest.categoryId, opt => opt.MapFrom(s => s.CategoryId))
            .ForMember(dest => dest.IsContinuous, opt => opt.MapFrom(s => s.IsContinuous))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(s => s.Quantity));


            config.CreateMap<Standard, StandardSubIndicatorsViewModel>()
            .ForMember(dest => dest.StandardId, opt => opt.MapFrom(s => s.Id))
            .ForMember(dest => dest.StandardName, opt => opt.MapFrom(s => s.Name))
            .ForMember(dest => dest.Weight, opt => opt.MapFrom(s => s.Weight))
            .ForMember(dest => dest.DisplayOrder, opt => opt.MapFrom(s => s.DisplayOrder))
            .ForMember(dest => dest.subIndicatorsCategories, opt => opt.MapFrom(s => s.SubIndicatorsCategories));

            //Sub Indicators Category Quantity
            config.CreateMap<SubIndicatorsCategoryQuantityViewModel, SubIndicatorsCategory>().ReverseMap();

            //Unit User
            config.CreateMap<UnitUserJoinUserModel, UnitUserViewModel>().ReverseMap();


            //Evidence
            config.CreateMap<Evidence, EvidenceViewModel>();

            config.CreateMap<EvidenceViewModel, Evidence>()
            .ForMember(dest => dest.Standard, opt => opt.Ignore());

            //ViewCategoryAndItemAndStandard 
            config.CreateMap<Standard, ViewCategoryAndItemStandardViewModel>()
           .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(s => s.UserCategory.Name))
           .ForMember(dest => dest.ItemName, opt => opt.MapFrom(s => s.Item.Name))
           .ForMember(dest => dest.StandardName, opt => opt.MapFrom(s => s.Name));

        }


        public static int GetLevelNumber(decimal? Level1, decimal? Level2, decimal? Level3, decimal? Level4)
        {
            int levelNumber = 0;
            if (Level4.HasValue)
            {
                levelNumber = 4;
            }
            else if (Level3.HasValue)
            {
                levelNumber = 3;
            }
            else if (Level2.HasValue)
            {
                levelNumber = 2;
            }
            else if (Level1.HasValue)
            {
                levelNumber = 1;
            }
            return levelNumber;
        }

    }
}