USE [master]
GO
/****** Object:  Database [HospitalProject]    Script Date: 17.07.2023 16:03:15 ******/
CREATE DATABASE [HospitalProject]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HospitalProject', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HospitalProject.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HospitalProject_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HospitalProject_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HospitalProject] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HospitalProject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HospitalProject] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HospitalProject] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HospitalProject] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HospitalProject] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HospitalProject] SET ARITHABORT OFF 
GO
ALTER DATABASE [HospitalProject] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HospitalProject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HospitalProject] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HospitalProject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HospitalProject] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HospitalProject] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HospitalProject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HospitalProject] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HospitalProject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HospitalProject] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HospitalProject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HospitalProject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HospitalProject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HospitalProject] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HospitalProject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HospitalProject] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HospitalProject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HospitalProject] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HospitalProject] SET  MULTI_USER 
GO
ALTER DATABASE [HospitalProject] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HospitalProject] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HospitalProject] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HospitalProject] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HospitalProject] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HospitalProject] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HospitalProject] SET QUERY_STORE = OFF
GO
USE [HospitalProject]
GO
/****** Object:  Table [dbo].[Table_Announcements]    Script Date: 17.07.2023 16:03:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_Announcements](
	[AnouncementID] [smallint] IDENTITY(1,1) NOT NULL,
	[Anouncements] [varchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_Appointments]    Script Date: 17.07.2023 16:03:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_Appointments](
	[AppointmentID] [int] IDENTITY(1,1) NOT NULL,
	[AppointmentDate] [varchar](10) NOT NULL,
	[AppointmentTime] [varchar](5) NULL,
	[AppointmentBranch] [varchar](30) NULL,
	[AppointmentDoctor] [varchar](20) NULL,
	[AppointmentSituation] [bit] NULL,
	[PatientTC] [char](11) NULL,
	[PatienceCompliments] [varchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_Branches]    Script Date: 17.07.2023 16:03:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_Branches](
	[BranchID] [tinyint] IDENTITY(1,1) NOT NULL,
	[BranchName] [varchar](30) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_Doctors]    Script Date: 17.07.2023 16:03:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_Doctors](
	[DoctorID] [smallint] IDENTITY(1,1) NOT NULL,
	[DoctorName] [varchar](15) NULL,
	[DoctorSurname] [varchar](15) NULL,
	[DoctorBranch] [varchar](30) NULL,
	[DoctorTC] [char](11) NULL,
	[DoctorPassword] [varchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_Patients]    Script Date: 17.07.2023 16:03:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_Patients](
	[PatientID] [smallint] IDENTITY(1,1) NOT NULL,
	[PatientName] [varchar](15) NULL,
	[PatientSurname] [varchar](15) NULL,
	[PatientTC] [char](11) NULL,
	[PatientPhoneNumber] [varchar](15) NULL,
	[PatientPassword] [varchar](50) NULL,
	[PatientGender] [varchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_Secretaries]    Script Date: 17.07.2023 16:03:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_Secretaries](
	[SecretaryID] [tinyint] IDENTITY(1,1) NOT NULL,
	[SecretaryNameSurname] [varchar](30) NULL,
	[SecretaryTC] [char](11) NULL,
	[SecretaryPassword] [varchar](10) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Table_Appointments] ADD  CONSTRAINT [DF_Table_Appointments_AppointmentSituation]  DEFAULT ((0)) FOR [AppointmentSituation]
GO
USE [master]
GO
ALTER DATABASE [HospitalProject] SET  READ_WRITE 
GO
