/*
	Script create docker container

docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=123456@abc" \
   -p 1433:1433 --name sqlserver --hostname sqlserver \
   -d \
   mcr.microsoft.com/mssql/server:2022-latest

server name: localhost
username: sa
pass: 123456@abc

*/

/*
 Navicat Premium Data Transfer

 Source Server         : Local SQL Server
 Source Server Type    : SQL Server
 Source Server Version : 16004135
 Source Host           : localhost:1433
 Source Catalog        : School
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 16004135
 File Encoding         : 65001

 Date: 12/09/2024 20:40:24
*/


-- ----------------------------
-- Table structure for Course
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Course]') AND type IN ('U'))
	DROP TABLE [dbo].[Course]
GO

CREATE TABLE [dbo].[Course] (
  [CourseID] int  NOT NULL,
  [Title] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Credits] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Course] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for Enrollment
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Enrollment]') AND type IN ('U'))
	DROP TABLE [dbo].[Enrollment]
GO

CREATE TABLE [dbo].[Enrollment] (
  [EnrollmentID] int  IDENTITY(1,1) NOT NULL,
  [CourseID] int  NULL,
  [LearnerID] int  NULL,
  [Grade] float(53)  NULL
)
GO

ALTER TABLE [dbo].[Enrollment] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for Learner
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Learner]') AND type IN ('U'))
	DROP TABLE [dbo].[Learner]
GO

CREATE TABLE [dbo].[Learner] (
  [LearnerID] int  IDENTITY(1,1) NOT NULL,
  [LastName] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [FirstMidName] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [EnrollmentDate] datetime2(7)  NULL,
  [MajorID] int  NULL
)
GO

ALTER TABLE [dbo].[Learner] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for Major
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Major]') AND type IN ('U'))
	DROP TABLE [dbo].[Major]
GO

CREATE TABLE [dbo].[Major] (
  [MajorID] int  IDENTITY(1,1) NOT NULL,
  [MajorName] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Major] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Auto increment value for Course
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Course]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table Course
-- ----------------------------
ALTER TABLE [dbo].[Course] ADD CONSTRAINT [PK__Course__C92D7187505945FD] PRIMARY KEY CLUSTERED ([CourseID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Enrollment
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Enrollment]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table Enrollment
-- ----------------------------
ALTER TABLE [dbo].[Enrollment] ADD CONSTRAINT [PK__Enrollme__7F6877FB6E0FACF5] PRIMARY KEY CLUSTERED ([EnrollmentID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Learner
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Learner]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table Learner
-- ----------------------------
ALTER TABLE [dbo].[Learner] ADD CONSTRAINT [PK__Learner__67ABFCFA647C88D7] PRIMARY KEY CLUSTERED ([LearnerID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Major
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Major]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table Major
-- ----------------------------
ALTER TABLE [dbo].[Major] ADD CONSTRAINT [PK__Major__D5B8BFB145D047B7] PRIMARY KEY CLUSTERED ([MajorID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table Enrollment
-- ----------------------------
ALTER TABLE [dbo].[Enrollment] ADD CONSTRAINT [fk_enrollment_course] FOREIGN KEY ([CourseID]) REFERENCES [dbo].[Course] ([CourseID]) ON DELETE CASCADE ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[Enrollment] ADD CONSTRAINT [fk_enrollment_learner] FOREIGN KEY ([LearnerID]) REFERENCES [dbo].[Learner] ([LearnerID]) ON DELETE CASCADE ON UPDATE CASCADE
GO


-- ----------------------------
-- Foreign Keys structure for table Learner
-- ----------------------------
ALTER TABLE [dbo].[Learner] ADD CONSTRAINT [fk_learner_major] FOREIGN KEY ([MajorID]) REFERENCES [dbo].[Major] ([MajorID]) ON DELETE CASCADE ON UPDATE CASCADE
GO

