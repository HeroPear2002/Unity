USE [master]
GO
/****** Object:  Database [DPROS]    Script Date: 28/08/2024 11:59:18 AM ******/
CREATE DATABASE [DPROS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DPROS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DPROS.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DPROS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DPROS_log.ldf' , SIZE = 3136KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DPROS] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DPROS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DPROS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DPROS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DPROS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DPROS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DPROS] SET ARITHABORT OFF 
GO
ALTER DATABASE [DPROS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DPROS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DPROS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DPROS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DPROS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DPROS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DPROS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DPROS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DPROS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DPROS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DPROS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DPROS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DPROS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DPROS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DPROS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DPROS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DPROS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DPROS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DPROS] SET  MULTI_USER 
GO
ALTER DATABASE [DPROS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DPROS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DPROS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DPROS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DPROS] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DPROS]
GO
/****** Object:  Table [dbo].[BoxChecked]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoxChecked](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCheck] [bigint] NULL,
	[DateCheck] [datetime] NULL,
	[IdEmCheck] [int] NULL,
	[CountCheck] [int] NULL,
	[LotNo] [nvarchar](50) NULL,
	[QrCode] [nvarchar](50) NULL,
	[StatusCheck] [int] NULL,
	[Note] [nvarchar](350) NULL,
	[MoldNumber] [nvarchar](50) NULL,
	[MachineCode] [nvarchar](50) NULL,
	[IdPO] [bigint] NULL,
 CONSTRAINT [PK_BoxChecked] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BoxEffic]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoxEffic](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateNew] [datetime] NULL,
	[IdPart] [int] NULL,
	[Quantity] [int] NULL,
	[CountBox] [int] NULL,
	[CountBoxReal] [int] NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_BoxEffic] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BoxInfor]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoxInfor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdBox] [int] NULL,
	[IdPart] [int] NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_BoxInfor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BoxList]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoxList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BoxCode] [nvarchar](50) NULL,
	[BoxName] [nvarchar](50) NULL,
	[StyleBox] [nvarchar](50) NULL,
	[BoxIventory] [int] NULL,
 CONSTRAINT [PK_BoxList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BoxNature]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoxNature](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BoxName] [nvarchar](50) NULL,
	[Quantity] [int] NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_BoxNature] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CalibratQC]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalibratQC](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdDeviceQC] [int] NULL,
	[DateIn] [datetime] NULL,
	[People] [nvarchar](50) NULL,
	[EmCode] [nvarchar](50) NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_CalibratQC] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CateDataDefault]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CateDataDefault](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[UpperLimit] [float] NULL,
	[LowerLimit] [float] NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_CateDataDefault] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CateTestMachine]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CateTestMachine](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameCategory] [nvarchar](150) NULL,
	[Detail] [nvarchar](350) NULL,
	[Timer] [int] NULL,
	[Method] [nvarchar](350) NULL,
	[StatusCate] [int] NULL,
	[IdDevice] [int] NULL,
	[Limit] [nvarchar](50) NULL,
	[NoteCate] [nvarchar](350) NULL,
 CONSTRAINT [PK_CateTestMachine] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CheckDelivery]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CheckDelivery](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CheckCode] [nvarchar](50) NULL,
	[IdDe] [bigint] NULL,
	[IdEm] [int] NULL,
	[IdPO] [bigint] NULL,
	[QuantityCheck] [int] NULL,
	[QuantityOut] [int] NULL,
	[FactoryCode] [nvarchar](50) NULL,
	[StatusCheck] [int] NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_CheckDelivery] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CusCode] [nvarchar](50) NULL,
	[CusName] [nvarchar](250) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Note] [nvarchar](350) NULL,
	[WarnInputPO] [int] NULL,
	[WarnPOFix] [int] NULL,
	[WarnCus] [int] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DataCheck]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataCheck](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdSetup] [bigint] NULL,
	[DateCheck] [datetime] NULL,
	[ValueReal] [float] NULL,
	[Note] [nvarchar](350) NULL,
	[IdUser] [int] NULL,
 CONSTRAINT [PK_DataCheck] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DeliveryNote]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryNote](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DeCode] [nvarchar](50) NULL,
	[DateInput] [datetime] NULL,
	[DateOutput] [datetime] NULL,
	[EmCreate] [nvarchar](50) NULL,
	[EmChange] [nvarchar](50) NULL,
	[Note] [nvarchar](350) NULL,
	[DateDelivery] [datetime] NULL,
	[StatusDe] [int] NULL,
	[EmOut] [nvarchar](50) NULL,
	[DateChange] [datetime] NULL,
 CONSTRAINT [PK_DeliveryNote] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Device]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Device](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[StatusDevice] [int] NULL,
	[UrlEveryday] [nvarchar](50) NULL,
	[UrlMainten] [nvarchar](50) NULL,
	[FormCode] [nvarchar](50) NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_Device] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DeviceQC]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeviceQC](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Moldel] [nvarchar](50) NULL,
	[Serial] [nvarchar](50) NULL,
	[Maker] [nvarchar](50) NULL,
	[Status] [int] NULL,
	[Cycle] [int] NULL,
	[DateCheck] [datetime] NULL,
	[StatusCheck] [int] NULL,
	[StatusMail] [int] NULL,
	[DateInput] [datetime] NULL,
	[DateMail] [datetime] NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_DeviceQC] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DirectiveProduct]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DirectiveProduct](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DateInput] [datetime] NULL,
	[IdPart] [bigint] NULL,
	[Quantity] [int] NULL,
	[IdMachine] [bigint] NULL,
	[IdMold] [bigint] NULL,
	[NoteProduct] [nvarchar](350) NULL,
	[NoteMaterial] [nvarchar](350) NULL,
	[FactoryCode] [nvarchar](50) NULL,
	[WeightUse] [float] NULL,
	[WeightOut] [float] NULL,
	[Status] [int] NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_DirectiveProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DryingMaterial]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DryingMaterial](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdMaterial] [int] NULL,
	[IdMachine] [int] NULL,
	[QuantityDry] [float] NULL,
	[DateDrying] [datetime] NULL,
	[DatePour] [datetime] NULL,
	[Employess] [int] NULL,
	[IdPart] [int] NULL,
	[IdDry] [int] NULL,
	[StatusDry] [int] NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_DryingMaterial] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EditHistory]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EditHistory](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[bigint] [datetime] NULL,
	[datetime] [nvarchar](100) NULL,
	[Detail] [nvarchar](max) NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_EditHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employess]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employess](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmCode] [nvarchar](50) NULL,
	[EmName] [nvarchar](50) NULL,
	[RoomCode] [nvarchar](50) NULL,
	[DateInput] [datetime] NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_Employess] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Factory]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FacCode] [nvarchar](50) NULL,
	[FacName] [nvarchar](350) NULL,
	[CodeCus] [nvarchar](50) NULL,
	[IdCus] [int] NULL,
	[NameBillVN] [nvarchar](250) NULL,
	[NameBillEN] [nvarchar](250) NULL,
	[Address] [nvarchar](350) NULL,
	[Phone] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[TaxCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_Factory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FormPart]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormPart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPart] [int] NULL,
	[FormStart] [nvarchar](max) NULL,
	[FormPeriodic] [nvarchar](max) NULL,
	[FormExport] [nvarchar](max) NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_FormPart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HistoryDevice]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistoryDevice](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdRelationship] [bigint] NULL,
	[Result] [nvarchar](50) NULL,
	[DataCount] [float] NULL,
	[Status] [int] NULL,
	[DateCheck] [datetime] NULL,
	[IdUser] [int] NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_HistoryDevice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HistoryEditMachine]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistoryEditMachine](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdMachine] [int] NULL,
	[DateMachine] [datetime] NULL,
	[TimeMachine] [int] NULL,
	[ErrorName] [nvarchar](255) NULL,
	[Reason] [nvarchar](255) NULL,
	[Detail] [nvarchar](255) NULL,
	[Employees] [nvarchar](255) NULL,
	[Note] [nvarchar](255) NULL,
	[DateError] [datetime] NULL,
	[TimeStart] [int] NULL,
	[TimeMain] [int] NULL,
 CONSTRAINT [PK__HistoryE__3214EC076F823300] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HistoryQC]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistoryQC](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdInput] [bigint] NULL,
	[DateChange] [datetime] NULL,
	[StatusBefor] [nvarchar](50) NULL,
	[StatusAfter] [nvarchar](50) NULL,
	[IdEm] [int] NULL,
	[Note] [nvarchar](250) NULL,
 CONSTRAINT [PK_HistoryQC] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HistoryTem]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistoryTem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPart] [int] NULL,
	[IdMachine] [int] NULL,
	[IdMold] [int] NULL,
	[DatePrint] [datetime] NULL,
	[EmCode] [nvarchar](50) NULL,
	[NumberFrom] [int] NULL,
	[NumberTo] [int] NULL,
	[Lot] [datetime] NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_HistoryTem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InputMat]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InputMat](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdMat] [int] NULL,
	[DateInput] [datetime] NULL,
	[QuantityInput] [float] NULL,
	[IdWH] [int] NULL,
	[StatusInput] [int] NULL,
	[StyleInput] [nvarchar](50) NULL,
	[IdEm] [int] NULL,
	[Lot] [nvarchar](50) NULL,
	[Rohs] [nvarchar](50) NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_InputMat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InputMatMix]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InputMatMix](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdInput] [bigint] NULL,
	[QuantityMix] [int] NULL,
	[StatusMix] [int] NULL,
	[DateMix] [datetime] NULL,
	[IdEm] [int] NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_InputMatMix] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InputMatRecycle]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InputMatRecycle](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdInput] [bigint] NULL,
	[Quantity] [float] NULL,
	[StatusRecycle] [int] NULL,
	[DateRecycle] [datetime] NULL,
	[IdEm] [int] NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_InputMatRecycle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InputPart]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InputPart](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DateInput] [datetime] NULL,
	[QuantityInput] [int] NULL,
	[IdEm] [int] NULL,
	[IdMold] [int] NULL,
	[IdMachine] [int] NULL,
	[IdWareHouse] [int] NULL,
	[DateManufacturi] [datetime] NULL,
	[StatusInput] [int] NULL,
	[StyleInput] [nvarchar](50) NULL,
	[IdPart] [int] NULL,
	[NotePC] [nvarchar](50) NULL,
	[Lot] [nvarchar](50) NULL,
	[FactoryCode] [nvarchar](50) NULL,
	[Yellow] [nvarchar](50) NULL,
 CONSTRAINT [PK_InputPart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Location]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Machine]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Machine](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MachineCode] [nvarchar](50) NULL,
	[MachineName] [nvarchar](250) NULL,
	[MachineInfor] [nvarchar](250) NULL,
	[Manufacturer] [nvarchar](50) NULL,
	[SerialNumber] [nvarchar](50) NULL,
	[DateInput] [datetime] NULL,
	[CodeAsset] [nvarchar](150) NULL,
	[Vender] [nvarchar](50) NULL,
	[DateProduct] [datetime] NULL,
	[IdDevice] [int] NULL,
	[StatusMachine] [int] NULL,
	[Note] [nvarchar](350) NULL,
	[DateMaker] [datetime] NULL,
 CONSTRAINT [PK_Machine] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MachineDetail]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MachineDetail](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdMachine] [int] NULL,
	[DetailName] [nvarchar](50) NULL,
	[DetailInfor] [nvarchar](350) NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK__MachineD__3214EC079822C7BA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MachineDry]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MachineDry](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DryCode] [nvarchar](50) NULL,
	[DryName] [nvarchar](50) NULL,
	[WeightTray] [int] NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_MachineDry] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Material]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MatCode] [nvarchar](50) NULL,
	[MatName] [nvarchar](250) NULL,
	[WarnYllow] [int] NULL,
	[WarnCount] [int] NULL,
	[IdSup] [int] NULL,
	[Nature] [nvarchar](250) NULL,
	[RohsFile] [nvarchar](350) NULL,
	[ColorCode] [nvarchar](50) NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_Material] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MaterialBegin]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialBegin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdMat] [int] NULL,
	[WeightMin] [nvarchar](50) NULL,
	[TimeMin] [nvarchar](50) NULL,
 CONSTRAINT [PK_MaterialBegin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MaterialBy]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialBy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MatCode] [nvarchar](50) NULL,
	[QuantityBy] [int] NULL,
	[DateBy] [datetime] NULL,
	[QuantityOrder] [int] NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_MaterialBy] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MaterialMix]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialMix](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MatMix] [nvarchar](50) NULL,
	[MatCode] [nvarchar](50) NULL,
	[Quantity] [float] NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_MaterialMix] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MaterialPrice]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialPrice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateInput] [datetime] NULL,
	[IdMat] [image] NULL,
	[PriceVND] [decimal](18, 0) NULL,
	[PriceUSD] [nvarchar](50) NULL,
	[StatusPrice] [int] NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_MaterialPrice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Mold]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mold](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MoldCode] [nvarchar](50) NULL,
	[MoldName] [nvarchar](250) NULL,
	[Model] [nvarchar](50) NULL,
	[Maker] [nvarchar](50) NULL,
	[DateInput] [datetime] NULL,
	[Where] [nvarchar](50) NULL,
	[DateProduct] [nvarchar](50) NULL,
	[EmCode] [nvarchar](50) NULL,
	[ShotCount] [int] NULL,
	[Note] [nvarchar](50) NULL,
	[NumberMold] [nvarchar](50) NULL,
 CONSTRAINT [PK_Mold] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MoldError]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MoldError](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Status] [int] NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_MoldError] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MoldHistory]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MoldHistory](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdMachine] [int] NULL,
	[IdMold] [int] NULL,
	[DateError] [datetime] NULL,
	[CountShort] [int] NULL,
	[TotalShort] [int] NULL,
	[Category] [nvarchar](50) NULL,
	[Error] [nvarchar](250) NULL,
	[TribeError] [nvarchar](250) NULL,
	[Detail] [nvarchar](350) NULL,
	[DateStart] [datetime] NULL,
	[DateEnd] [datetime] NULL,
	[TotalTime] [nvarchar](50) NULL,
	[Detail1] [nvarchar](350) NULL,
	[Detail2] [nvarchar](350) NULL,
	[Detail3] [nvarchar](350) NULL,
	[Detail4] [nvarchar](350) NULL,
	[Detail5] [nvarchar](350) NULL,
	[Detail6] [nvarchar](350) NULL,
 CONSTRAINT [PK_MoldHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MoldUsing]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MoldUsing](
	[IdMold] [int] NOT NULL,
	[ShotPlan] [int] NULL,
	[ShotReality] [int] NULL,
	[TotalShot] [int] NULL,
	[ConfirmMold] [int] NULL,
	[Category] [nvarchar](50) NULL,
	[StatusMold] [nvarchar](250) NULL,
	[Cav] [int] NULL,
	[CavNG] [int] NULL,
	[PlanMold] [nvarchar](50) NULL,
	[DateCheck] [nvarchar](50) NULL,
	[Warn] [int] NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_MoldUsing] PRIMARY KEY CLUSTERED 
(
	[IdMold] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OutputMat]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OutputMat](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdInput] [bigint] NULL,
	[DateOutput] [datetime] NULL,
	[QuatityOutput] [float] NULL,
	[StyleOutput] [nvarchar](50) NULL,
	[IdEm] [int] NULL,
	[IdPart] [int] NULL,
	[IdMachine] [int] NULL,
	[Lot] [nvarchar](50) NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_OutputMat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OutputMatMix]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OutputMatMix](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdReInputMix] [bigint] NULL,
	[DateOutputMix] [datetime] NULL,
	[QuantityOutputMix] [float] NULL,
	[IdEm] [int] NULL,
	[Note] [nvarchar](350) NULL,
	[Reason] [nvarchar](50) NULL,
	[LotMix] [nvarchar](50) NULL,
	[QuantityMixPlan] [float] NULL,
 CONSTRAINT [PK_OutputMatMix] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OutputMatRecyle]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OutputMatRecyle](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdReInputCycle] [bigint] NULL,
	[DateReOutput] [datetime] NULL,
	[QuantityReOutput] [float] NULL,
	[IdEm] [int] NULL,
	[Lot] [nvarchar](50) NULL,
	[Note] [nvarchar](350) NULL,
	[Reason] [nvarchar](250) NULL,
	[LotCycle] [nvarchar](50) NULL,
	[QuantityCyclePlan] [float] NULL,
 CONSTRAINT [PK_OutputMatRecyle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OutputPart]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OutputPart](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdInput] [bigint] NULL,
	[DateOutput] [datetime] NULL,
	[IdEm] [int] NULL,
	[QuantityOut] [int] NULL,
	[StyleOutput] [nvarchar](50) NULL,
	[IdDe] [bigint] NULL,
	[IdPOInput] [bigint] NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_OutputPart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Part]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Part](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PartCode] [nvarchar](50) NULL,
	[Partname] [nvarchar](250) NULL,
	[MatCode] [nvarchar](50) NULL,
	[IdCus] [int] NULL,
	[CountPart] [int] NULL,
	[CountBox] [int] NULL,
	[WeightPart] [float] NULL,
	[WeightRunner] [float] NULL,
	[CycleTime] [float] NULL,
	[Cav] [int] NULL,
	[Height] [int] NULL,
	[NameVN] [nvarchar](350) NULL,
	[StylePart] [nvarchar](100) NULL,
 CONSTRAINT [PK_Part] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PartInfor]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartInfor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPart] [int] NULL,
	[Percentage] [float] NULL,
	[WeightBy] [float] NULL,
 CONSTRAINT [PK_PartInfor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PartLock]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartLock](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdTem] [int] NULL,
	[StatusWH] [int] NULL,
	[Yellow] [nvarchar](50) NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_PartLock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[POFix]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[POFix](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdPOInput] [bigint] NULL,
	[IdDe] [bigint] NULL,
	[Quantity] [int] NULL,
	[DateOut] [datetime] NULL,
	[Note] [nvarchar](350) NULL,
	[Status] [int] NULL,
	[DateInput] [datetime] NULL,
	[FactoryCustomer] [nvarchar](50) NULL,
	[CarNumber] [nvarchar](50) NULL,
	[QuantityOut] [int] NULL,
 CONSTRAINT [PK_POFix] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[POInput]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[POInput](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[POCode] [nvarchar](50) NULL,
	[IdPart] [int] NOT NULL,
	[QuantityIn] [int] NULL,
	[DateInput] [datetime] NULL,
	[StatusPO] [int] NULL,
	[IdFactory] [int] NULL,
	[Price] [float] NULL,
	[DateOut] [datetime] NULL,
	[IdCustomer] [int] NULL,
	[QuantityOut] [int] NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_POInput] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[POOutput]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[POOutput](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[POCode] [nvarchar](50) NULL,
	[DateOutput] [nvarchar](50) NULL,
	[QuantityOut] [int] NULL,
	[Note] [nvarchar](350) NULL,
	[IdInput] [bigint] NULL,
	[IdPOInput] [bigint] NULL,
	[IdDe] [bigint] NULL,
 CONSTRAINT [PK_POOutput] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RatioMaterial]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RatioMaterial](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdMat] [int] NULL,
	[RatioUsing] [int] NULL,
	[RatioInput] [int] NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_RatioMaterial] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reason]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reason](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReasonDetail] [nvarchar](350) NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_Reason] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReBox]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReBox](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdBox] [int] NULL,
	[DateCheck] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RelationMachineCate]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelationMachineCate](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdMachine] [int] NULL,
	[IdCategory] [int] NULL,
	[TimeReality] [int] NULL,
	[StatusRe] [int] NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_RelationMachineCate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Room]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SetupDefault]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SetupDefault](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCate] [int] NULL,
	[IdMold] [int] NULL,
	[IdMachine] [int] NULL,
	[ValueDefault] [float] NULL,
 CONSTRAINT [PK_SetupDefault] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StatusWHPart]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusWHPart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_StatusWHPart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SupCode] [nvarchar](50) NULL,
	[SupName] [nvarchar](150) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Note] [nvarchar](250) NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TemInfor]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TemInfor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPart] [int] NULL,
	[IdMachine] [int] NULL,
	[IdMold] [int] NULL,
	[CavStyle] [int] NULL,
	[Rev] [nvarchar](50) NULL,
	[FacCode] [nvarchar](50) NULL,
	[Standard] [nvarchar](50) NULL,
	[Important] [int] NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_TemInfor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[PassWord] [nvarchar](50) NULL,
	[EmCode] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WarehouseMat]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WarehouseMat](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[StatusWH] [int] NULL,
	[Style] [nvarchar](50) NULL,
	[WeightWH] [int] NULL,
	[Note] [nvarchar](350) NULL,
	[MaxRow] [int] NULL,
 CONSTRAINT [PK_WarehouseMat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WarehousePart]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WarehousePart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Status] [int] NULL,
	[Height] [int] NULL,
	[Style] [nvarchar](50) NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_WarehousePart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Weather]    Script Date: 28/08/2024 11:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Weather](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdLocation] [int] NULL,
	[Temperature] [float] NULL,
	[Humidity] [float] NULL,
	[DateWeather] [datetime] NULL,
	[IdUser] [int] NULL,
 CONSTRAINT [PK_Weather] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CateTestMachine]  WITH CHECK ADD FOREIGN KEY([IdDevice])
REFERENCES [dbo].[Device] ([Id])
GO
ALTER TABLE [dbo].[DataCheck]  WITH CHECK ADD FOREIGN KEY([IdSetup])
REFERENCES [dbo].[SetupDefault] ([Id])
GO
ALTER TABLE [dbo].[DataCheck]  WITH CHECK ADD FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[HistoryDevice]  WITH CHECK ADD FOREIGN KEY([IdRelationship])
REFERENCES [dbo].[RelationMachineCate] ([Id])
GO
ALTER TABLE [dbo].[HistoryDevice]  WITH CHECK ADD FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[HistoryEditMachine]  WITH CHECK ADD  CONSTRAINT [FK_HistoryEditMachine_Machine] FOREIGN KEY([IdMachine])
REFERENCES [dbo].[Machine] ([Id])
GO
ALTER TABLE [dbo].[HistoryEditMachine] CHECK CONSTRAINT [FK_HistoryEditMachine_Machine]
GO
ALTER TABLE [dbo].[Machine]  WITH CHECK ADD  CONSTRAINT [FK__Machine__IdDevic__29221CFB] FOREIGN KEY([IdDevice])
REFERENCES [dbo].[Device] ([Id])
GO
ALTER TABLE [dbo].[Machine] CHECK CONSTRAINT [FK__Machine__IdDevic__29221CFB]
GO
ALTER TABLE [dbo].[MachineDetail]  WITH CHECK ADD  CONSTRAINT [FK_MachineDetail_Machine] FOREIGN KEY([IdMachine])
REFERENCES [dbo].[Machine] ([Id])
GO
ALTER TABLE [dbo].[MachineDetail] CHECK CONSTRAINT [FK_MachineDetail_Machine]
GO
ALTER TABLE [dbo].[OutputPart]  WITH CHECK ADD FOREIGN KEY([IdInput])
REFERENCES [dbo].[InputPart] ([Id])
GO
ALTER TABLE [dbo].[OutputPart]  WITH CHECK ADD FOREIGN KEY([IdDe])
REFERENCES [dbo].[DeliveryNote] ([Id])
GO
ALTER TABLE [dbo].[OutputPart]  WITH CHECK ADD FOREIGN KEY([IdPOInput])
REFERENCES [dbo].[POInput] ([Id])
GO
ALTER TABLE [dbo].[POFix]  WITH CHECK ADD FOREIGN KEY([IdDe])
REFERENCES [dbo].[DeliveryNote] ([Id])
GO
ALTER TABLE [dbo].[POFix]  WITH CHECK ADD  CONSTRAINT [FK__POFix__IdPOInput__0A688BB1] FOREIGN KEY([IdPOInput])
REFERENCES [dbo].[POInput] ([Id])
GO
ALTER TABLE [dbo].[POFix] CHECK CONSTRAINT [FK__POFix__IdPOInput__0A688BB1]
GO
ALTER TABLE [dbo].[POInput]  WITH CHECK ADD  CONSTRAINT [FK__POInput__IdCusto__09746778] FOREIGN KEY([IdCustomer])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[POInput] CHECK CONSTRAINT [FK__POInput__IdCusto__09746778]
GO
ALTER TABLE [dbo].[POInput]  WITH CHECK ADD  CONSTRAINT [FK__POInput__IdFacto__17C286CF] FOREIGN KEY([IdFactory])
REFERENCES [dbo].[Factory] ([Id])
GO
ALTER TABLE [dbo].[POInput] CHECK CONSTRAINT [FK__POInput__IdFacto__17C286CF]
GO
ALTER TABLE [dbo].[POInput]  WITH CHECK ADD  CONSTRAINT [FK__POInput__IdPart__0880433F] FOREIGN KEY([IdPart])
REFERENCES [dbo].[Part] ([Id])
GO
ALTER TABLE [dbo].[POInput] CHECK CONSTRAINT [FK__POInput__IdPart__0880433F]
GO
ALTER TABLE [dbo].[RelationMachineCate]  WITH CHECK ADD  CONSTRAINT [FK__RelationM__IdCat__151B244E] FOREIGN KEY([IdCategory])
REFERENCES [dbo].[CateTestMachine] ([Id])
GO
ALTER TABLE [dbo].[RelationMachineCate] CHECK CONSTRAINT [FK__RelationM__IdCat__151B244E]
GO
ALTER TABLE [dbo].[RelationMachineCate]  WITH CHECK ADD  CONSTRAINT [FK__RelationM__IdMac__3587F3E0] FOREIGN KEY([IdMachine])
REFERENCES [dbo].[Machine] ([Id])
GO
ALTER TABLE [dbo].[RelationMachineCate] CHECK CONSTRAINT [FK__RelationM__IdMac__3587F3E0]
GO
ALTER TABLE [dbo].[SetupDefault]  WITH CHECK ADD FOREIGN KEY([IdCate])
REFERENCES [dbo].[CateDataDefault] ([Id])
GO
ALTER TABLE [dbo].[SetupDefault]  WITH CHECK ADD FOREIGN KEY([IdMachine])
REFERENCES [dbo].[Machine] ([Id])
GO
ALTER TABLE [dbo].[SetupDefault]  WITH CHECK ADD FOREIGN KEY([IdMold])
REFERENCES [dbo].[Mold] ([Id])
GO
ALTER TABLE [dbo].[Weather]  WITH CHECK ADD FOREIGN KEY([IdLocation])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[Weather]  WITH CHECK ADD FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([Id])
GO
USE [master]
GO
ALTER DATABASE [DPROS] SET  READ_WRITE 
GO
