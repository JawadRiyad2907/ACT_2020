
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/22/2020 03:34:47
-- Generated from EDMX file: D:\JawadAsp\ACT_2020\ACT\Models\ActModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ACT-DB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[SystemManagment].[FK_Categories_Level1]', 'F') IS NOT NULL
    ALTER TABLE [SystemManagment].[UserCategory] DROP CONSTRAINT [FK_Categories_Level1];
GO
IF OBJECT_ID(N'[SystemManagment].[FK_Categories_Level2]', 'F') IS NOT NULL
    ALTER TABLE [SystemManagment].[UserCategory] DROP CONSTRAINT [FK_Categories_Level2];
GO
IF OBJECT_ID(N'[SystemManagment].[FK_Categories_Level3]', 'F') IS NOT NULL
    ALTER TABLE [SystemManagment].[UserCategory] DROP CONSTRAINT [FK_Categories_Level3];
GO
IF OBJECT_ID(N'[SystemManagment].[FK_Categories_Level4]', 'F') IS NOT NULL
    ALTER TABLE [SystemManagment].[UserCategory] DROP CONSTRAINT [FK_Categories_Level4];
GO
IF OBJECT_ID(N'[User].[FK_CertificatesAndAward_User]', 'F') IS NOT NULL
    ALTER TABLE [User].[CertificatesAndAward] DROP CONSTRAINT [FK_CertificatesAndAward_User];
GO
IF OBJECT_ID(N'[User].[FK_Course_User]', 'F') IS NOT NULL
    ALTER TABLE [User].[Course] DROP CONSTRAINT [FK_Course_User];
GO
IF OBJECT_ID(N'[WorkPlanning].[FK_EnterpriseUnits_EnterpriseUnits]', 'F') IS NOT NULL
    ALTER TABLE [WorkPlanning].[EnterpriseUnits] DROP CONSTRAINT [FK_EnterpriseUnits_EnterpriseUnits];
GO
IF OBJECT_ID(N'[WorkPlanning].[FK_EnterpriseUnits_EnterpriseUnits1]', 'F') IS NOT NULL
    ALTER TABLE [WorkPlanning].[EnterpriseUnits] DROP CONSTRAINT [FK_EnterpriseUnits_EnterpriseUnits1];
GO
IF OBJECT_ID(N'[WorkPlanning].[FK_EnterpriseUnits_Level1]', 'F') IS NOT NULL
    ALTER TABLE [WorkPlanning].[EnterpriseUnits] DROP CONSTRAINT [FK_EnterpriseUnits_Level1];
GO
IF OBJECT_ID(N'[WorkPlanning].[FK_EnterpriseUnits_Level2]', 'F') IS NOT NULL
    ALTER TABLE [WorkPlanning].[EnterpriseUnits] DROP CONSTRAINT [FK_EnterpriseUnits_Level2];
GO
IF OBJECT_ID(N'[WorkPlanning].[FK_EnterpriseUnits_Level3]', 'F') IS NOT NULL
    ALTER TABLE [WorkPlanning].[EnterpriseUnits] DROP CONSTRAINT [FK_EnterpriseUnits_Level3];
GO
IF OBJECT_ID(N'[WorkPlanning].[FK_EnterpriseUnits_Level4]', 'F') IS NOT NULL
    ALTER TABLE [WorkPlanning].[EnterpriseUnits] DROP CONSTRAINT [FK_EnterpriseUnits_Level4];
GO
IF OBJECT_ID(N'[SystemManagment].[FK_Evidence_Standard]', 'F') IS NOT NULL
    ALTER TABLE [SystemManagment].[Evidence] DROP CONSTRAINT [FK_Evidence_Standard];
GO
IF OBJECT_ID(N'[SystemManagment].[FK_Item_Sector]', 'F') IS NOT NULL
    ALTER TABLE [SystemManagment].[Item] DROP CONSTRAINT [FK_Item_Sector];
GO
IF OBJECT_ID(N'[SystemManagment].[FK_ItemNACategory_Item]', 'F') IS NOT NULL
    ALTER TABLE [SystemManagment].[ItemNACategory] DROP CONSTRAINT [FK_ItemNACategory_Item];
GO
IF OBJECT_ID(N'[SystemManagment].[FK_ItemNACategory_UserCategory]', 'F') IS NOT NULL
    ALTER TABLE [SystemManagment].[ItemNACategory] DROP CONSTRAINT [FK_ItemNACategory_UserCategory];
GO
IF OBJECT_ID(N'[SystemManagment].[FK_JobTitle_Level1]', 'F') IS NOT NULL
    ALTER TABLE [SystemManagment].[JobTitle] DROP CONSTRAINT [FK_JobTitle_Level1];
GO
IF OBJECT_ID(N'[SystemManagment].[FK_JobTitle_Level2]', 'F') IS NOT NULL
    ALTER TABLE [SystemManagment].[JobTitle] DROP CONSTRAINT [FK_JobTitle_Level2];
GO
IF OBJECT_ID(N'[SystemManagment].[FK_JobTitle_Level3]', 'F') IS NOT NULL
    ALTER TABLE [SystemManagment].[JobTitle] DROP CONSTRAINT [FK_JobTitle_Level3];
GO
IF OBJECT_ID(N'[SystemManagment].[FK_JobTitle_Level4]', 'F') IS NOT NULL
    ALTER TABLE [SystemManagment].[JobTitle] DROP CONSTRAINT [FK_JobTitle_Level4];
GO
IF OBJECT_ID(N'[SystemManagment].[FK_JobTitle_UserCategory]', 'F') IS NOT NULL
    ALTER TABLE [SystemManagment].[JobTitle] DROP CONSTRAINT [FK_JobTitle_UserCategory];
GO
IF OBJECT_ID(N'[Level].[FK_Level1_User]', 'F') IS NOT NULL
    ALTER TABLE [Level].[Level1] DROP CONSTRAINT [FK_Level1_User];
GO
IF OBJECT_ID(N'[Level].[FK_Level2_Level1]', 'F') IS NOT NULL
    ALTER TABLE [Level].[Level2] DROP CONSTRAINT [FK_Level2_Level1];
GO
IF OBJECT_ID(N'[Level].[FK_Level2_User]', 'F') IS NOT NULL
    ALTER TABLE [Level].[Level2] DROP CONSTRAINT [FK_Level2_User];
GO
IF OBJECT_ID(N'[Level].[FK_Level3_Level1]', 'F') IS NOT NULL
    ALTER TABLE [Level].[Level3] DROP CONSTRAINT [FK_Level3_Level1];
GO
IF OBJECT_ID(N'[Level].[FK_Level3_Level2]', 'F') IS NOT NULL
    ALTER TABLE [Level].[Level3] DROP CONSTRAINT [FK_Level3_Level2];
GO
IF OBJECT_ID(N'[Level].[FK_Level3_User]', 'F') IS NOT NULL
    ALTER TABLE [Level].[Level3] DROP CONSTRAINT [FK_Level3_User];
GO
IF OBJECT_ID(N'[Level].[FK_Level4_Level1]', 'F') IS NOT NULL
    ALTER TABLE [Level].[Level4] DROP CONSTRAINT [FK_Level4_Level1];
GO
IF OBJECT_ID(N'[Level].[FK_Level4_Level2]', 'F') IS NOT NULL
    ALTER TABLE [Level].[Level4] DROP CONSTRAINT [FK_Level4_Level2];
GO
IF OBJECT_ID(N'[Level].[FK_Level4_Level3]', 'F') IS NOT NULL
    ALTER TABLE [Level].[Level4] DROP CONSTRAINT [FK_Level4_Level3];
GO
IF OBJECT_ID(N'[Level].[FK_Level4_SchoolType]', 'F') IS NOT NULL
    ALTER TABLE [Level].[Level4] DROP CONSTRAINT [FK_Level4_SchoolType];
GO
IF OBJECT_ID(N'[Level].[FK_Level4_TypeEducation]', 'F') IS NOT NULL
    ALTER TABLE [Level].[Level4] DROP CONSTRAINT [FK_Level4_TypeEducation];
GO
IF OBJECT_ID(N'[Level].[FK_Level4_User]', 'F') IS NOT NULL
    ALTER TABLE [Level].[Level4] DROP CONSTRAINT [FK_Level4_User];
GO
IF OBJECT_ID(N'[Lookup].[FK_Menu_Menu1]', 'F') IS NOT NULL
    ALTER TABLE [Lookup].[Menu] DROP CONSTRAINT [FK_Menu_Menu1];
GO
IF OBJECT_ID(N'[Privelags].[FK_MenuPrivelags_Menu]', 'F') IS NOT NULL
    ALTER TABLE [Privelags].[MenuPrivelags] DROP CONSTRAINT [FK_MenuPrivelags_Menu];
GO
IF OBJECT_ID(N'[Privelags].[FK_MenuPrivelags_MenuPrivelags]', 'F') IS NOT NULL
    ALTER TABLE [Privelags].[MenuPrivelags] DROP CONSTRAINT [FK_MenuPrivelags_MenuPrivelags];
GO
IF OBJECT_ID(N'[Privelags].[FK_MenuPrivelags_UserCategory]', 'F') IS NOT NULL
    ALTER TABLE [Privelags].[MenuPrivelags] DROP CONSTRAINT [FK_MenuPrivelags_UserCategory];
GO
IF OBJECT_ID(N'[User].[FK_Qualification_CientificDegree]', 'F') IS NOT NULL
    ALTER TABLE [User].[Qualification] DROP CONSTRAINT [FK_Qualification_CientificDegree];
GO
IF OBJECT_ID(N'[User].[FK_Qualification_User]', 'F') IS NOT NULL
    ALTER TABLE [User].[Qualification] DROP CONSTRAINT [FK_Qualification_User];
GO
IF OBJECT_ID(N'[SystemManagment].[FK_Standard_Item]', 'F') IS NOT NULL
    ALTER TABLE [SystemManagment].[Standard] DROP CONSTRAINT [FK_Standard_Item];
GO
IF OBJECT_ID(N'[SystemManagment].[FK_Standard_UserCategory]', 'F') IS NOT NULL
    ALTER TABLE [SystemManagment].[Standard] DROP CONSTRAINT [FK_Standard_UserCategory];
GO
IF OBJECT_ID(N'[WorkPlanning].[FK_SubIndicatorsCategory_Item]', 'F') IS NOT NULL
    ALTER TABLE [WorkPlanning].[SubIndicatorsCategory] DROP CONSTRAINT [FK_SubIndicatorsCategory_Item];
GO
IF OBJECT_ID(N'[WorkPlanning].[FK_SubIndicatorsCategory_Standard]', 'F') IS NOT NULL
    ALTER TABLE [WorkPlanning].[SubIndicatorsCategory] DROP CONSTRAINT [FK_SubIndicatorsCategory_Standard];
GO
IF OBJECT_ID(N'[WorkPlanning].[FK_SubIndicatorsCategory_UserCategory]', 'F') IS NOT NULL
    ALTER TABLE [WorkPlanning].[SubIndicatorsCategory] DROP CONSTRAINT [FK_SubIndicatorsCategory_UserCategory];
GO
IF OBJECT_ID(N'[WorkPlanning].[FK_SubIndicatorsCategory_UserCategory1]', 'F') IS NOT NULL
    ALTER TABLE [WorkPlanning].[SubIndicatorsCategory] DROP CONSTRAINT [FK_SubIndicatorsCategory_UserCategory1];
GO
IF OBJECT_ID(N'[User].[FK_UnitUsers_EnterpriseUnits]', 'F') IS NOT NULL
    ALTER TABLE [User].[UnitUsers] DROP CONSTRAINT [FK_UnitUsers_EnterpriseUnits];
GO
IF OBJECT_ID(N'[User].[FK_UnitUsers_User]', 'F') IS NOT NULL
    ALTER TABLE [User].[UnitUsers] DROP CONSTRAINT [FK_UnitUsers_User];
GO
IF OBJECT_ID(N'[User].[FK_User_JobTitle]', 'F') IS NOT NULL
    ALTER TABLE [User].[User] DROP CONSTRAINT [FK_User_JobTitle];
GO
IF OBJECT_ID(N'[User].[FK_User_Level1]', 'F') IS NOT NULL
    ALTER TABLE [User].[User] DROP CONSTRAINT [FK_User_Level1];
GO
IF OBJECT_ID(N'[User].[FK_User_Level2]', 'F') IS NOT NULL
    ALTER TABLE [User].[User] DROP CONSTRAINT [FK_User_Level2];
GO
IF OBJECT_ID(N'[User].[FK_User_Level3]', 'F') IS NOT NULL
    ALTER TABLE [User].[User] DROP CONSTRAINT [FK_User_Level3];
GO
IF OBJECT_ID(N'[User].[FK_User_Level4]', 'F') IS NOT NULL
    ALTER TABLE [User].[User] DROP CONSTRAINT [FK_User_Level4];
GO
IF OBJECT_ID(N'[User].[FK_User_UserCategory]', 'F') IS NOT NULL
    ALTER TABLE [User].[User] DROP CONSTRAINT [FK_User_UserCategory];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[Level].[Level1]', 'U') IS NOT NULL
    DROP TABLE [Level].[Level1];
GO
IF OBJECT_ID(N'[Level].[Level2]', 'U') IS NOT NULL
    DROP TABLE [Level].[Level2];
GO
IF OBJECT_ID(N'[Level].[Level3]', 'U') IS NOT NULL
    DROP TABLE [Level].[Level3];
GO
IF OBJECT_ID(N'[Level].[Level4]', 'U') IS NOT NULL
    DROP TABLE [Level].[Level4];
GO
IF OBJECT_ID(N'[Lookup].[CientificDegree]', 'U') IS NOT NULL
    DROP TABLE [Lookup].[CientificDegree];
GO
IF OBJECT_ID(N'[Lookup].[Language]', 'U') IS NOT NULL
    DROP TABLE [Lookup].[Language];
GO
IF OBJECT_ID(N'[Lookup].[Menu]', 'U') IS NOT NULL
    DROP TABLE [Lookup].[Menu];
GO
IF OBJECT_ID(N'[Lookup].[SchoolType]', 'U') IS NOT NULL
    DROP TABLE [Lookup].[SchoolType];
GO
IF OBJECT_ID(N'[Lookup].[SystemSetting]', 'U') IS NOT NULL
    DROP TABLE [Lookup].[SystemSetting];
GO
IF OBJECT_ID(N'[Lookup].[TypeEducation]', 'U') IS NOT NULL
    DROP TABLE [Lookup].[TypeEducation];
GO
IF OBJECT_ID(N'[Privelags].[MenuPrivelags]', 'U') IS NOT NULL
    DROP TABLE [Privelags].[MenuPrivelags];
GO
IF OBJECT_ID(N'[SystemManagment].[Evidence]', 'U') IS NOT NULL
    DROP TABLE [SystemManagment].[Evidence];
GO
IF OBJECT_ID(N'[SystemManagment].[Item]', 'U') IS NOT NULL
    DROP TABLE [SystemManagment].[Item];
GO
IF OBJECT_ID(N'[SystemManagment].[ItemNACategory]', 'U') IS NOT NULL
    DROP TABLE [SystemManagment].[ItemNACategory];
GO
IF OBJECT_ID(N'[SystemManagment].[JobTitle]', 'U') IS NOT NULL
    DROP TABLE [SystemManagment].[JobTitle];
GO
IF OBJECT_ID(N'[SystemManagment].[Sector]', 'U') IS NOT NULL
    DROP TABLE [SystemManagment].[Sector];
GO
IF OBJECT_ID(N'[SystemManagment].[Standard]', 'U') IS NOT NULL
    DROP TABLE [SystemManagment].[Standard];
GO
IF OBJECT_ID(N'[SystemManagment].[UserCategory]', 'U') IS NOT NULL
    DROP TABLE [SystemManagment].[UserCategory];
GO
IF OBJECT_ID(N'[User].[CertificatesAndAward]', 'U') IS NOT NULL
    DROP TABLE [User].[CertificatesAndAward];
GO
IF OBJECT_ID(N'[User].[Course]', 'U') IS NOT NULL
    DROP TABLE [User].[Course];
GO
IF OBJECT_ID(N'[User].[Qualification]', 'U') IS NOT NULL
    DROP TABLE [User].[Qualification];
GO
IF OBJECT_ID(N'[User].[UnitUsers]', 'U') IS NOT NULL
    DROP TABLE [User].[UnitUsers];
GO
IF OBJECT_ID(N'[User].[User]', 'U') IS NOT NULL
    DROP TABLE [User].[User];
GO
IF OBJECT_ID(N'[WorkPlanning].[EnterpriseUnits]', 'U') IS NOT NULL
    DROP TABLE [WorkPlanning].[EnterpriseUnits];
GO
IF OBJECT_ID(N'[WorkPlanning].[SubIndicatorsCategory]', 'U') IS NOT NULL
    DROP TABLE [WorkPlanning].[SubIndicatorsCategory];
GO
IF OBJECT_ID(N'[ModelStoreContainer].[vw_All_Level]', 'U') IS NOT NULL
    DROP TABLE [ModelStoreContainer].[vw_All_Level];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Level1'
CREATE TABLE [dbo].[Level1] (
    [Id] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NULL,
    [Published] bit  NOT NULL,
    [DisplayOrder] decimal(18,0)  NOT NULL,
    [IsDefault] bit  NULL,
    [DirectResponsible] decimal(18,0)  NULL
);
GO

-- Creating table 'Level2'
CREATE TABLE [dbo].[Level2] (
    [Id] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [Level1Id] decimal(18,0)  NOT NULL,
    [Name] nvarchar(50)  NULL,
    [DisplayOrder] decimal(18,0)  NOT NULL,
    [Published] bit  NULL,
    [IsDefault] bit  NOT NULL,
    [DirectResponsible] decimal(18,0)  NULL
);
GO

-- Creating table 'Level3'
CREATE TABLE [dbo].[Level3] (
    [Id] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [Level1Id] decimal(18,0)  NOT NULL,
    [Level2Id] decimal(18,0)  NOT NULL,
    [Name] nvarchar(50)  NULL,
    [DisplayOrder] decimal(18,0)  NOT NULL,
    [Published] bit  NULL,
    [IsDefault] bit  NULL,
    [DirectResponsible] decimal(18,0)  NULL
);
GO

-- Creating table 'Level4'
CREATE TABLE [dbo].[Level4] (
    [Id] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [Level1Id] decimal(18,0)  NOT NULL,
    [Level2Id] decimal(18,0)  NOT NULL,
    [Level3Id] decimal(18,0)  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [TypeEducationId] decimal(18,0)  NOT NULL,
    [TypeId] decimal(18,0)  NOT NULL,
    [IsKindergarten] bit  NOT NULL,
    [IsBasic] bit  NOT NULL,
    [IsMedium] bit  NOT NULL,
    [IsSecondary] bit  NOT NULL,
    [IsMinistryEducation] bit  NOT NULL,
    [IsOtherEducation] bit  NOT NULL,
    [OtherEducationName] nvarchar(100)  NULL,
    [DisplayOrder] decimal(18,0)  NOT NULL,
    [Published] bit  NOT NULL,
    [IsDefault] bit  NULL,
    [DirectResponsible] decimal(18,0)  NULL
);
GO

-- Creating table 'CientificDegrees'
CREATE TABLE [dbo].[CientificDegrees] (
    [Id] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NULL
);
GO

-- Creating table 'Languages'
CREATE TABLE [dbo].[Languages] (
    [Id] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [LanguageCulture] nvarchar(20)  NOT NULL,
    [UniqueSeoCode] nvarchar(2)  NULL,
    [FlagImageFileName] nvarchar(50)  NULL,
    [Rtl] bit  NOT NULL,
    [Published] bit  NOT NULL,
    [DisplayOrder] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'Menus'
CREATE TABLE [dbo].[Menus] (
    [Id] int  NOT NULL,
    [DescriptionEn] varchar(200)  NOT NULL,
    [DescriptionAr] nvarchar(200)  NOT NULL,
    [ResourcesString] nvarchar(200)  NOT NULL,
    [Url] nvarchar(250)  NULL,
    [ParentId] int  NULL,
    [CssClass] nvarchar(100)  NULL,
    [Order] decimal(18,4)  NULL,
    [Active] bit  NULL
);
GO

-- Creating table 'SchoolTypes'
CREATE TABLE [dbo].[SchoolTypes] (
    [Id] decimal(18,0)  NOT NULL,
    [TypeName] nvarchar(50)  NULL
);
GO

-- Creating table 'SystemSettings'
CREATE TABLE [dbo].[SystemSettings] (
    [Id] int  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Value] nvarchar(200)  NULL
);
GO

-- Creating table 'TypeEducations'
CREATE TABLE [dbo].[TypeEducations] (
    [Id] decimal(18,0)  NOT NULL,
    [TypeName] nvarchar(50)  NULL
);
GO

-- Creating table 'MenuPrivelags'
CREATE TABLE [dbo].[MenuPrivelags] (
    [Id] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [MenuId] int  NOT NULL,
    [JobTitleId] decimal(18,0)  NULL,
    [CategoryId] decimal(18,0)  NULL,
    [CreatedDate] datetime  NOT NULL,
    [CretaedBy] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Evidences'
CREATE TABLE [dbo].[Evidences] (
    [Id] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [StandardId] decimal(18,0)  NOT NULL,
    [EvidenceDescription] nvarchar(max)  NOT NULL,
    [CreatedById] decimal(18,0)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [LastModifiedById] decimal(18,0)  NULL,
    [LastModifiedDate] datetime  NULL,
    [DisplayOrder] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Items'
CREATE TABLE [dbo].[Items] (
    [Id] decimal(18,0)  NOT NULL,
    [SectorId] decimal(18,0)  NOT NULL,
    [Name] nvarchar(500)  NOT NULL,
    [ShortName] nvarchar(400)  NOT NULL,
    [Goal] nvarchar(500)  NOT NULL,
    [ShortGoal] nvarchar(400)  NOT NULL,
    [FixedWeight] decimal(18,0)  NULL,
    [IntermediateWeight] decimal(18,0)  NULL,
    [FlexWeight] decimal(18,0)  NULL,
    [DisplayOrder] decimal(18,0)  NOT NULL,
    [Publish] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'ItemNACategories'
CREATE TABLE [dbo].[ItemNACategories] (
    [Id] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [CategoryId] decimal(18,0)  NOT NULL,
    [ItemId] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'JobTitles'
CREATE TABLE [dbo].[JobTitles] (
    [Id] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [Level1Id] decimal(18,0)  NULL,
    [Level2Id] decimal(18,0)  NULL,
    [Level3Id] decimal(18,0)  NULL,
    [Level4Id] decimal(18,0)  NULL,
    [UserCategoryId] decimal(18,0)  NOT NULL,
    [JobName] nvarchar(100)  NOT NULL,
    [DisplayOrder] decimal(18,0)  NOT NULL,
    [Active] bit  NOT NULL,
    [CreatedBy] int  NULL,
    [Deleted] bit  NOT NULL
);
GO

-- Creating table 'Sectors'
CREATE TABLE [dbo].[Sectors] (
    [Id] decimal(18,0)  NOT NULL,
    [Name] nvarchar(500)  NOT NULL,
    [ShortName] nvarchar(500)  NOT NULL,
    [DisplayOrder] decimal(18,0)  NOT NULL,
    [FixedWeight] decimal(18,0)  NULL,
    [IntermediateWeight] decimal(18,0)  NULL,
    [FlexWeight] decimal(18,0)  NULL
);
GO

-- Creating table 'Standards'
CREATE TABLE [dbo].[Standards] (
    [Id] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [ItemId] decimal(18,0)  NOT NULL,
    [CategoryId] decimal(18,0)  NOT NULL,
    [Name] nvarchar(1000)  NOT NULL,
    [Weight] decimal(18,0)  NOT NULL,
    [CreatedById] decimal(18,0)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [LastModifiedById] decimal(18,0)  NULL,
    [LastModifiedDate] datetime  NULL,
    [DisplayOrder] decimal(18,0)  NOT NULL,
    [Publish] bit  NOT NULL
);
GO

-- Creating table 'UserCategories'
CREATE TABLE [dbo].[UserCategories] (
    [Id] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [Level1Id] decimal(18,0)  NULL,
    [Level2Id] decimal(18,0)  NULL,
    [Level3Id] decimal(18,0)  NULL,
    [Level4Id] decimal(18,0)  NULL,
    [Type] smallint  NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [DisplayOrder] decimal(18,0)  NOT NULL,
    [Active] bit  NOT NULL,
    [IsSystemAdmin] bit  NULL
);
GO

-- Creating table 'CertificatesAndAwards'
CREATE TABLE [dbo].[CertificatesAndAwards] (
    [Id] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL,
    [Source] nvarchar(100)  NOT NULL,
    [DateOfCertificate] datetime  NOT NULL,
    [UserId] decimal(18,0)  NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'Courses'
CREATE TABLE [dbo].[Courses] (
    [Id] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [TrainingCourse] nvarchar(100)  NOT NULL,
    [institution] nvarchar(100)  NOT NULL,
    [Period] int  NOT NULL,
    [FromDate] datetime  NOT NULL,
    [ToDate] datetime  NOT NULL,
    [UserId] decimal(18,0)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'Qualifications'
CREATE TABLE [dbo].[Qualifications] (
    [Id] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [ScientificDegreeId] decimal(18,0)  NOT NULL,
    [Specialization] nvarchar(100)  NOT NULL,
    [University] nvarchar(100)  NOT NULL,
    [Year] int  NOT NULL,
    [UserId] decimal(18,0)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'UnitUsers'
CREATE TABLE [dbo].[UnitUsers] (
    [Id] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [UserId] decimal(18,0)  NOT NULL,
    [UnitId] decimal(18,0)  NOT NULL,
    [IsResponsible] bit  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [Level1Id] decimal(18,0)  NULL,
    [Level2Id] decimal(18,0)  NULL,
    [Level3Id] decimal(18,0)  NULL,
    [Level4Id] decimal(18,0)  NULL,
    [UserCategoryId] decimal(18,0)  NOT NULL,
    [JobTitleId] decimal(18,0)  NOT NULL,
    [UserName] nvarchar(150)  NOT NULL,
    [Email] nvarchar(150)  NULL,
    [Password] nvarchar(max)  NULL,
    [Active] bit  NOT NULL,
    [CreatedBy] decimal(18,0)  NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] decimal(18,0)  NULL,
    [UpdatedDate] datetime  NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [SecondName] nvarchar(50)  NULL,
    [ThirdName] nvarchar(50)  NULL,
    [LastName] nvarchar(50)  NOT NULL,
    [PhoneNumber] nvarchar(50)  NOT NULL,
    [AnotherPhoneNumber] nvarchar(50)  NULL,
    [GenderId] smallint  NOT NULL,
    [Address] nvarchar(300)  NULL,
    [FirstNameEn] nvarchar(50)  NOT NULL,
    [LastNameEn] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'EnterpriseUnits'
CREATE TABLE [dbo].[EnterpriseUnits] (
    [Id] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [Parent] decimal(18,0)  NULL,
    [EnterpriseUnitsType] smallint  NOT NULL,
    [Level1Id] decimal(18,0)  NULL,
    [Level2Id] decimal(18,0)  NULL,
    [Level3Id] decimal(18,0)  NULL,
    [Level4Id] decimal(18,0)  NULL,
    [Name] nvarchar(200)  NOT NULL,
    [DisplayOrder] decimal(18,0)  NOT NULL,
    [CreatedById] decimal(18,0)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdateBy] decimal(18,0)  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'SubIndicatorsCategories'
CREATE TABLE [dbo].[SubIndicatorsCategories] (
    [Id] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [TargetCategory] decimal(18,0)  NOT NULL,
    [CategoryId] decimal(18,0)  NOT NULL,
    [ItemId] decimal(18,0)  NOT NULL,
    [StandardId] decimal(18,0)  NOT NULL,
    [IsContinuous] bit  NOT NULL,
    [Quantity] nvarchar(200)  NULL
);
GO

-- Creating table 'vw_All_Level'
CREATE TABLE [dbo].[vw_All_Level] (
    [LevelId] decimal(18,0)  NOT NULL,
    [Level1Id] decimal(18,0)  NULL,
    [Level2Id] decimal(18,0)  NULL,
    [Level3Id] decimal(18,0)  NULL,
    [Level4Id] decimal(18,0)  NULL,
    [LevelName] nvarchar(100)  NULL,
    [DisplayOrder] decimal(18,0)  NOT NULL,
    [Published] int  NULL,
    [IsDefault] int  NULL,
    [DirectResponsible] decimal(18,0)  NULL,
    [levelNumber] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Level1'
ALTER TABLE [dbo].[Level1]
ADD CONSTRAINT [PK_Level1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Level2'
ALTER TABLE [dbo].[Level2]
ADD CONSTRAINT [PK_Level2]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Level3'
ALTER TABLE [dbo].[Level3]
ADD CONSTRAINT [PK_Level3]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Level4'
ALTER TABLE [dbo].[Level4]
ADD CONSTRAINT [PK_Level4]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CientificDegrees'
ALTER TABLE [dbo].[CientificDegrees]
ADD CONSTRAINT [PK_CientificDegrees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Languages'
ALTER TABLE [dbo].[Languages]
ADD CONSTRAINT [PK_Languages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Menus'
ALTER TABLE [dbo].[Menus]
ADD CONSTRAINT [PK_Menus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SchoolTypes'
ALTER TABLE [dbo].[SchoolTypes]
ADD CONSTRAINT [PK_SchoolTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SystemSettings'
ALTER TABLE [dbo].[SystemSettings]
ADD CONSTRAINT [PK_SystemSettings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TypeEducations'
ALTER TABLE [dbo].[TypeEducations]
ADD CONSTRAINT [PK_TypeEducations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MenuPrivelags'
ALTER TABLE [dbo].[MenuPrivelags]
ADD CONSTRAINT [PK_MenuPrivelags]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Evidences'
ALTER TABLE [dbo].[Evidences]
ADD CONSTRAINT [PK_Evidences]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [PK_Items]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ItemNACategories'
ALTER TABLE [dbo].[ItemNACategories]
ADD CONSTRAINT [PK_ItemNACategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'JobTitles'
ALTER TABLE [dbo].[JobTitles]
ADD CONSTRAINT [PK_JobTitles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Sectors'
ALTER TABLE [dbo].[Sectors]
ADD CONSTRAINT [PK_Sectors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Standards'
ALTER TABLE [dbo].[Standards]
ADD CONSTRAINT [PK_Standards]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserCategories'
ALTER TABLE [dbo].[UserCategories]
ADD CONSTRAINT [PK_UserCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CertificatesAndAwards'
ALTER TABLE [dbo].[CertificatesAndAwards]
ADD CONSTRAINT [PK_CertificatesAndAwards]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [PK_Courses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Qualifications'
ALTER TABLE [dbo].[Qualifications]
ADD CONSTRAINT [PK_Qualifications]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UnitUsers'
ALTER TABLE [dbo].[UnitUsers]
ADD CONSTRAINT [PK_UnitUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EnterpriseUnits'
ALTER TABLE [dbo].[EnterpriseUnits]
ADD CONSTRAINT [PK_EnterpriseUnits]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SubIndicatorsCategories'
ALTER TABLE [dbo].[SubIndicatorsCategories]
ADD CONSTRAINT [PK_SubIndicatorsCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LevelId], [DisplayOrder], [levelNumber] in table 'vw_All_Level'
ALTER TABLE [dbo].[vw_All_Level]
ADD CONSTRAINT [PK_vw_All_Level]
    PRIMARY KEY CLUSTERED ([LevelId], [DisplayOrder], [levelNumber] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Level1Id] in table 'UserCategories'
ALTER TABLE [dbo].[UserCategories]
ADD CONSTRAINT [FK_Categories_Level1]
    FOREIGN KEY ([Level1Id])
    REFERENCES [dbo].[Level1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Categories_Level1'
CREATE INDEX [IX_FK_Categories_Level1]
ON [dbo].[UserCategories]
    ([Level1Id]);
GO

-- Creating foreign key on [Level1Id] in table 'EnterpriseUnits'
ALTER TABLE [dbo].[EnterpriseUnits]
ADD CONSTRAINT [FK_EnterpriseUnits_Level1]
    FOREIGN KEY ([Level1Id])
    REFERENCES [dbo].[Level1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EnterpriseUnits_Level1'
CREATE INDEX [IX_FK_EnterpriseUnits_Level1]
ON [dbo].[EnterpriseUnits]
    ([Level1Id]);
GO

-- Creating foreign key on [Level1Id] in table 'JobTitles'
ALTER TABLE [dbo].[JobTitles]
ADD CONSTRAINT [FK_JobTitle_Level1]
    FOREIGN KEY ([Level1Id])
    REFERENCES [dbo].[Level1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JobTitle_Level1'
CREATE INDEX [IX_FK_JobTitle_Level1]
ON [dbo].[JobTitles]
    ([Level1Id]);
GO

-- Creating foreign key on [DirectResponsible] in table 'Level1'
ALTER TABLE [dbo].[Level1]
ADD CONSTRAINT [FK_Level1_User]
    FOREIGN KEY ([DirectResponsible])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Level1_User'
CREATE INDEX [IX_FK_Level1_User]
ON [dbo].[Level1]
    ([DirectResponsible]);
GO

-- Creating foreign key on [Level1Id] in table 'Level2'
ALTER TABLE [dbo].[Level2]
ADD CONSTRAINT [FK_Level2_Level1]
    FOREIGN KEY ([Level1Id])
    REFERENCES [dbo].[Level1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Level2_Level1'
CREATE INDEX [IX_FK_Level2_Level1]
ON [dbo].[Level2]
    ([Level1Id]);
GO

-- Creating foreign key on [Level1Id] in table 'Level3'
ALTER TABLE [dbo].[Level3]
ADD CONSTRAINT [FK_Level3_Level1]
    FOREIGN KEY ([Level1Id])
    REFERENCES [dbo].[Level1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Level3_Level1'
CREATE INDEX [IX_FK_Level3_Level1]
ON [dbo].[Level3]
    ([Level1Id]);
GO

-- Creating foreign key on [Level1Id] in table 'Level4'
ALTER TABLE [dbo].[Level4]
ADD CONSTRAINT [FK_Level4_Level1]
    FOREIGN KEY ([Level1Id])
    REFERENCES [dbo].[Level1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Level4_Level1'
CREATE INDEX [IX_FK_Level4_Level1]
ON [dbo].[Level4]
    ([Level1Id]);
GO

-- Creating foreign key on [Level1Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_User_Level1]
    FOREIGN KEY ([Level1Id])
    REFERENCES [dbo].[Level1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Level1'
CREATE INDEX [IX_FK_User_Level1]
ON [dbo].[Users]
    ([Level1Id]);
GO

-- Creating foreign key on [Level2Id] in table 'UserCategories'
ALTER TABLE [dbo].[UserCategories]
ADD CONSTRAINT [FK_Categories_Level2]
    FOREIGN KEY ([Level2Id])
    REFERENCES [dbo].[Level2]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Categories_Level2'
CREATE INDEX [IX_FK_Categories_Level2]
ON [dbo].[UserCategories]
    ([Level2Id]);
GO

-- Creating foreign key on [Level2Id] in table 'EnterpriseUnits'
ALTER TABLE [dbo].[EnterpriseUnits]
ADD CONSTRAINT [FK_EnterpriseUnits_Level2]
    FOREIGN KEY ([Level2Id])
    REFERENCES [dbo].[Level2]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EnterpriseUnits_Level2'
CREATE INDEX [IX_FK_EnterpriseUnits_Level2]
ON [dbo].[EnterpriseUnits]
    ([Level2Id]);
GO

-- Creating foreign key on [Level2Id] in table 'JobTitles'
ALTER TABLE [dbo].[JobTitles]
ADD CONSTRAINT [FK_JobTitle_Level2]
    FOREIGN KEY ([Level2Id])
    REFERENCES [dbo].[Level2]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JobTitle_Level2'
CREATE INDEX [IX_FK_JobTitle_Level2]
ON [dbo].[JobTitles]
    ([Level2Id]);
GO

-- Creating foreign key on [DirectResponsible] in table 'Level2'
ALTER TABLE [dbo].[Level2]
ADD CONSTRAINT [FK_Level2_User]
    FOREIGN KEY ([DirectResponsible])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Level2_User'
CREATE INDEX [IX_FK_Level2_User]
ON [dbo].[Level2]
    ([DirectResponsible]);
GO

-- Creating foreign key on [Level2Id] in table 'Level3'
ALTER TABLE [dbo].[Level3]
ADD CONSTRAINT [FK_Level3_Level2]
    FOREIGN KEY ([Level2Id])
    REFERENCES [dbo].[Level2]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Level3_Level2'
CREATE INDEX [IX_FK_Level3_Level2]
ON [dbo].[Level3]
    ([Level2Id]);
GO

-- Creating foreign key on [Level2Id] in table 'Level4'
ALTER TABLE [dbo].[Level4]
ADD CONSTRAINT [FK_Level4_Level2]
    FOREIGN KEY ([Level2Id])
    REFERENCES [dbo].[Level2]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Level4_Level2'
CREATE INDEX [IX_FK_Level4_Level2]
ON [dbo].[Level4]
    ([Level2Id]);
GO

-- Creating foreign key on [Level2Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_User_Level2]
    FOREIGN KEY ([Level2Id])
    REFERENCES [dbo].[Level2]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Level2'
CREATE INDEX [IX_FK_User_Level2]
ON [dbo].[Users]
    ([Level2Id]);
GO

-- Creating foreign key on [Level3Id] in table 'UserCategories'
ALTER TABLE [dbo].[UserCategories]
ADD CONSTRAINT [FK_Categories_Level3]
    FOREIGN KEY ([Level3Id])
    REFERENCES [dbo].[Level3]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Categories_Level3'
CREATE INDEX [IX_FK_Categories_Level3]
ON [dbo].[UserCategories]
    ([Level3Id]);
GO

-- Creating foreign key on [Level3Id] in table 'EnterpriseUnits'
ALTER TABLE [dbo].[EnterpriseUnits]
ADD CONSTRAINT [FK_EnterpriseUnits_Level3]
    FOREIGN KEY ([Level3Id])
    REFERENCES [dbo].[Level3]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EnterpriseUnits_Level3'
CREATE INDEX [IX_FK_EnterpriseUnits_Level3]
ON [dbo].[EnterpriseUnits]
    ([Level3Id]);
GO

-- Creating foreign key on [Level3Id] in table 'JobTitles'
ALTER TABLE [dbo].[JobTitles]
ADD CONSTRAINT [FK_JobTitle_Level3]
    FOREIGN KEY ([Level3Id])
    REFERENCES [dbo].[Level3]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JobTitle_Level3'
CREATE INDEX [IX_FK_JobTitle_Level3]
ON [dbo].[JobTitles]
    ([Level3Id]);
GO

-- Creating foreign key on [DirectResponsible] in table 'Level3'
ALTER TABLE [dbo].[Level3]
ADD CONSTRAINT [FK_Level3_User]
    FOREIGN KEY ([DirectResponsible])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Level3_User'
CREATE INDEX [IX_FK_Level3_User]
ON [dbo].[Level3]
    ([DirectResponsible]);
GO

-- Creating foreign key on [Level3Id] in table 'Level4'
ALTER TABLE [dbo].[Level4]
ADD CONSTRAINT [FK_Level4_Level3]
    FOREIGN KEY ([Level3Id])
    REFERENCES [dbo].[Level3]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Level4_Level3'
CREATE INDEX [IX_FK_Level4_Level3]
ON [dbo].[Level4]
    ([Level3Id]);
GO

-- Creating foreign key on [Level3Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_User_Level3]
    FOREIGN KEY ([Level3Id])
    REFERENCES [dbo].[Level3]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Level3'
CREATE INDEX [IX_FK_User_Level3]
ON [dbo].[Users]
    ([Level3Id]);
GO

-- Creating foreign key on [Level4Id] in table 'UserCategories'
ALTER TABLE [dbo].[UserCategories]
ADD CONSTRAINT [FK_Categories_Level4]
    FOREIGN KEY ([Level4Id])
    REFERENCES [dbo].[Level4]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Categories_Level4'
CREATE INDEX [IX_FK_Categories_Level4]
ON [dbo].[UserCategories]
    ([Level4Id]);
GO

-- Creating foreign key on [Level4Id] in table 'EnterpriseUnits'
ALTER TABLE [dbo].[EnterpriseUnits]
ADD CONSTRAINT [FK_EnterpriseUnits_Level4]
    FOREIGN KEY ([Level4Id])
    REFERENCES [dbo].[Level4]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EnterpriseUnits_Level4'
CREATE INDEX [IX_FK_EnterpriseUnits_Level4]
ON [dbo].[EnterpriseUnits]
    ([Level4Id]);
GO

-- Creating foreign key on [Level4Id] in table 'JobTitles'
ALTER TABLE [dbo].[JobTitles]
ADD CONSTRAINT [FK_JobTitle_Level4]
    FOREIGN KEY ([Level4Id])
    REFERENCES [dbo].[Level4]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JobTitle_Level4'
CREATE INDEX [IX_FK_JobTitle_Level4]
ON [dbo].[JobTitles]
    ([Level4Id]);
GO

-- Creating foreign key on [TypeId] in table 'Level4'
ALTER TABLE [dbo].[Level4]
ADD CONSTRAINT [FK_Level4_SchoolType]
    FOREIGN KEY ([TypeId])
    REFERENCES [dbo].[SchoolTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Level4_SchoolType'
CREATE INDEX [IX_FK_Level4_SchoolType]
ON [dbo].[Level4]
    ([TypeId]);
GO

-- Creating foreign key on [TypeEducationId] in table 'Level4'
ALTER TABLE [dbo].[Level4]
ADD CONSTRAINT [FK_Level4_TypeEducation]
    FOREIGN KEY ([TypeEducationId])
    REFERENCES [dbo].[TypeEducations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Level4_TypeEducation'
CREATE INDEX [IX_FK_Level4_TypeEducation]
ON [dbo].[Level4]
    ([TypeEducationId]);
GO

-- Creating foreign key on [DirectResponsible] in table 'Level4'
ALTER TABLE [dbo].[Level4]
ADD CONSTRAINT [FK_Level4_User]
    FOREIGN KEY ([DirectResponsible])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Level4_User'
CREATE INDEX [IX_FK_Level4_User]
ON [dbo].[Level4]
    ([DirectResponsible]);
GO

-- Creating foreign key on [Level4Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_User_Level4]
    FOREIGN KEY ([Level4Id])
    REFERENCES [dbo].[Level4]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Level4'
CREATE INDEX [IX_FK_User_Level4]
ON [dbo].[Users]
    ([Level4Id]);
GO

-- Creating foreign key on [ScientificDegreeId] in table 'Qualifications'
ALTER TABLE [dbo].[Qualifications]
ADD CONSTRAINT [FK_Qualification_CientificDegree]
    FOREIGN KEY ([ScientificDegreeId])
    REFERENCES [dbo].[CientificDegrees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Qualification_CientificDegree'
CREATE INDEX [IX_FK_Qualification_CientificDegree]
ON [dbo].[Qualifications]
    ([ScientificDegreeId]);
GO

-- Creating foreign key on [ParentId] in table 'Menus'
ALTER TABLE [dbo].[Menus]
ADD CONSTRAINT [FK_Menu_Menu1]
    FOREIGN KEY ([ParentId])
    REFERENCES [dbo].[Menus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Menu_Menu1'
CREATE INDEX [IX_FK_Menu_Menu1]
ON [dbo].[Menus]
    ([ParentId]);
GO

-- Creating foreign key on [MenuId] in table 'MenuPrivelags'
ALTER TABLE [dbo].[MenuPrivelags]
ADD CONSTRAINT [FK_MenuPrivelags_Menu]
    FOREIGN KEY ([MenuId])
    REFERENCES [dbo].[Menus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MenuPrivelags_Menu'
CREATE INDEX [IX_FK_MenuPrivelags_Menu]
ON [dbo].[MenuPrivelags]
    ([MenuId]);
GO

-- Creating foreign key on [JobTitleId] in table 'MenuPrivelags'
ALTER TABLE [dbo].[MenuPrivelags]
ADD CONSTRAINT [FK_MenuPrivelags_MenuPrivelags]
    FOREIGN KEY ([JobTitleId])
    REFERENCES [dbo].[JobTitles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MenuPrivelags_MenuPrivelags'
CREATE INDEX [IX_FK_MenuPrivelags_MenuPrivelags]
ON [dbo].[MenuPrivelags]
    ([JobTitleId]);
GO

-- Creating foreign key on [CategoryId] in table 'MenuPrivelags'
ALTER TABLE [dbo].[MenuPrivelags]
ADD CONSTRAINT [FK_MenuPrivelags_UserCategory]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[UserCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MenuPrivelags_UserCategory'
CREATE INDEX [IX_FK_MenuPrivelags_UserCategory]
ON [dbo].[MenuPrivelags]
    ([CategoryId]);
GO

-- Creating foreign key on [StandardId] in table 'Evidences'
ALTER TABLE [dbo].[Evidences]
ADD CONSTRAINT [FK_Evidence_Standard]
    FOREIGN KEY ([StandardId])
    REFERENCES [dbo].[Standards]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Evidence_Standard'
CREATE INDEX [IX_FK_Evidence_Standard]
ON [dbo].[Evidences]
    ([StandardId]);
GO

-- Creating foreign key on [SectorId] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [FK_Item_Sector]
    FOREIGN KEY ([SectorId])
    REFERENCES [dbo].[Sectors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Item_Sector'
CREATE INDEX [IX_FK_Item_Sector]
ON [dbo].[Items]
    ([SectorId]);
GO

-- Creating foreign key on [ItemId] in table 'ItemNACategories'
ALTER TABLE [dbo].[ItemNACategories]
ADD CONSTRAINT [FK_ItemNACategory_Item]
    FOREIGN KEY ([ItemId])
    REFERENCES [dbo].[Items]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ItemNACategory_Item'
CREATE INDEX [IX_FK_ItemNACategory_Item]
ON [dbo].[ItemNACategories]
    ([ItemId]);
GO

-- Creating foreign key on [ItemId] in table 'Standards'
ALTER TABLE [dbo].[Standards]
ADD CONSTRAINT [FK_Standard_Item]
    FOREIGN KEY ([ItemId])
    REFERENCES [dbo].[Items]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Standard_Item'
CREATE INDEX [IX_FK_Standard_Item]
ON [dbo].[Standards]
    ([ItemId]);
GO

-- Creating foreign key on [ItemId] in table 'SubIndicatorsCategories'
ALTER TABLE [dbo].[SubIndicatorsCategories]
ADD CONSTRAINT [FK_SubIndicatorsCategory_Item]
    FOREIGN KEY ([ItemId])
    REFERENCES [dbo].[Items]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubIndicatorsCategory_Item'
CREATE INDEX [IX_FK_SubIndicatorsCategory_Item]
ON [dbo].[SubIndicatorsCategories]
    ([ItemId]);
GO

-- Creating foreign key on [CategoryId] in table 'ItemNACategories'
ALTER TABLE [dbo].[ItemNACategories]
ADD CONSTRAINT [FK_ItemNACategory_UserCategory]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[UserCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ItemNACategory_UserCategory'
CREATE INDEX [IX_FK_ItemNACategory_UserCategory]
ON [dbo].[ItemNACategories]
    ([CategoryId]);
GO

-- Creating foreign key on [UserCategoryId] in table 'JobTitles'
ALTER TABLE [dbo].[JobTitles]
ADD CONSTRAINT [FK_JobTitle_UserCategory]
    FOREIGN KEY ([UserCategoryId])
    REFERENCES [dbo].[UserCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JobTitle_UserCategory'
CREATE INDEX [IX_FK_JobTitle_UserCategory]
ON [dbo].[JobTitles]
    ([UserCategoryId]);
GO

-- Creating foreign key on [JobTitleId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_User_JobTitle]
    FOREIGN KEY ([JobTitleId])
    REFERENCES [dbo].[JobTitles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_JobTitle'
CREATE INDEX [IX_FK_User_JobTitle]
ON [dbo].[Users]
    ([JobTitleId]);
GO

-- Creating foreign key on [CategoryId] in table 'Standards'
ALTER TABLE [dbo].[Standards]
ADD CONSTRAINT [FK_Standard_UserCategory]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[UserCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Standard_UserCategory'
CREATE INDEX [IX_FK_Standard_UserCategory]
ON [dbo].[Standards]
    ([CategoryId]);
GO

-- Creating foreign key on [StandardId] in table 'SubIndicatorsCategories'
ALTER TABLE [dbo].[SubIndicatorsCategories]
ADD CONSTRAINT [FK_SubIndicatorsCategory_Standard]
    FOREIGN KEY ([StandardId])
    REFERENCES [dbo].[Standards]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubIndicatorsCategory_Standard'
CREATE INDEX [IX_FK_SubIndicatorsCategory_Standard]
ON [dbo].[SubIndicatorsCategories]
    ([StandardId]);
GO

-- Creating foreign key on [CategoryId] in table 'SubIndicatorsCategories'
ALTER TABLE [dbo].[SubIndicatorsCategories]
ADD CONSTRAINT [FK_SubIndicatorsCategory_UserCategory]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[UserCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubIndicatorsCategory_UserCategory'
CREATE INDEX [IX_FK_SubIndicatorsCategory_UserCategory]
ON [dbo].[SubIndicatorsCategories]
    ([CategoryId]);
GO

-- Creating foreign key on [TargetCategory] in table 'SubIndicatorsCategories'
ALTER TABLE [dbo].[SubIndicatorsCategories]
ADD CONSTRAINT [FK_SubIndicatorsCategory_UserCategory1]
    FOREIGN KEY ([TargetCategory])
    REFERENCES [dbo].[UserCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubIndicatorsCategory_UserCategory1'
CREATE INDEX [IX_FK_SubIndicatorsCategory_UserCategory1]
ON [dbo].[SubIndicatorsCategories]
    ([TargetCategory]);
GO

-- Creating foreign key on [UserCategoryId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_User_UserCategory]
    FOREIGN KEY ([UserCategoryId])
    REFERENCES [dbo].[UserCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_UserCategory'
CREATE INDEX [IX_FK_User_UserCategory]
ON [dbo].[Users]
    ([UserCategoryId]);
GO

-- Creating foreign key on [UserId] in table 'CertificatesAndAwards'
ALTER TABLE [dbo].[CertificatesAndAwards]
ADD CONSTRAINT [FK_CertificatesAndAward_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CertificatesAndAward_User'
CREATE INDEX [IX_FK_CertificatesAndAward_User]
ON [dbo].[CertificatesAndAwards]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [FK_Course_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Course_User'
CREATE INDEX [IX_FK_Course_User]
ON [dbo].[Courses]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'Qualifications'
ALTER TABLE [dbo].[Qualifications]
ADD CONSTRAINT [FK_Qualification_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Qualification_User'
CREATE INDEX [IX_FK_Qualification_User]
ON [dbo].[Qualifications]
    ([UserId]);
GO

-- Creating foreign key on [UnitId] in table 'UnitUsers'
ALTER TABLE [dbo].[UnitUsers]
ADD CONSTRAINT [FK_UnitUsers_EnterpriseUnits]
    FOREIGN KEY ([UnitId])
    REFERENCES [dbo].[EnterpriseUnits]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UnitUsers_EnterpriseUnits'
CREATE INDEX [IX_FK_UnitUsers_EnterpriseUnits]
ON [dbo].[UnitUsers]
    ([UnitId]);
GO

-- Creating foreign key on [UserId] in table 'UnitUsers'
ALTER TABLE [dbo].[UnitUsers]
ADD CONSTRAINT [FK_UnitUsers_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UnitUsers_User'
CREATE INDEX [IX_FK_UnitUsers_User]
ON [dbo].[UnitUsers]
    ([UserId]);
GO

-- Creating foreign key on [Parent] in table 'EnterpriseUnits'
ALTER TABLE [dbo].[EnterpriseUnits]
ADD CONSTRAINT [FK_EnterpriseUnits_EnterpriseUnits]
    FOREIGN KEY ([Parent])
    REFERENCES [dbo].[EnterpriseUnits]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EnterpriseUnits_EnterpriseUnits'
CREATE INDEX [IX_FK_EnterpriseUnits_EnterpriseUnits]
ON [dbo].[EnterpriseUnits]
    ([Parent]);
GO

-- Creating foreign key on [Id] in table 'EnterpriseUnits'
ALTER TABLE [dbo].[EnterpriseUnits]
ADD CONSTRAINT [FK_EnterpriseUnits_EnterpriseUnits1]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[EnterpriseUnits]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------