USE [master]
GO
/****** Object:  Database [ShopLiteDb]    Script Date: 4/15/2021 9:30:27 AM ******/
CREATE DATABASE [ShopLiteDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShopLiteDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.WSERVER\MSSQL\DATA\ShopLiteDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShopLiteDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.WSERVER\MSSQL\DATA\ShopLiteDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShopLiteDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShopLiteDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShopLiteDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShopLiteDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShopLiteDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShopLiteDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShopLiteDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ShopLiteDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShopLiteDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShopLiteDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShopLiteDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShopLiteDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShopLiteDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShopLiteDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShopLiteDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShopLiteDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ShopLiteDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShopLiteDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShopLiteDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShopLiteDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShopLiteDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShopLiteDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShopLiteDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShopLiteDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ShopLiteDb] SET  MULTI_USER 
GO
ALTER DATABASE [ShopLiteDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShopLiteDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShopLiteDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShopLiteDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShopLiteDb] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ShopLiteDb]
GO
/****** Object:  User [user]    Script Date: 4/15/2021 9:30:27 AM ******/
CREATE USER [user] FOR LOGIN [user1] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [user]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [user]
GO
/****** Object:  Table [dbo].[GrnDetails]    Script Date: 4/15/2021 9:30:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GrnDetails](
	[GrnSrNo] [int] NULL,
	[ProdCd] [nvarchar](50) NULL,
	[ProdNm] [nvarchar](250) NULL,
	[UnitCd] [nvarchar](50) NULL,
	[Quantity] [decimal](18, 4) NULL,
	[CostPrice] [decimal](18, 2) NULL,
	[LineNetAmt] [decimal](18, 2) NULL,
	[LineVatAmt] [decimal](18, 2) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GrnMaster]    Script Date: 4/15/2021 9:30:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GrnMaster](
	[SrNo] [int] IDENTITY(1,1) NOT NULL,
	[SuppCd] [nvarchar](50) NULL,
	[SuppNm] [nvarchar](150) NULL,
	[InvoiceNumber] [nvarchar](150) NULL,
	[UserName] [nvarchar](100) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[VatAmount] [decimal](18, 2) NULL,
	[GrnDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[SrNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[INVOICEDETAILS]    Script Date: 4/15/2021 9:30:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INVOICEDETAILS](
	[InvoiceSerialNumber] [int] NULL,
	[ProdCd] [nvarchar](50) NULL,
	[ProdNm] [nvarchar](150) NULL,
	[Unitcd] [nvarchar](50) NULL,
	[QUANTITY] [decimal](18, 4) NULL,
	[CP] [decimal](18, 2) NULL,
	[LINEVATAMT] [decimal](18, 2) NULL,
	[LINENETAMOUNT] [decimal](18, 2) NULL,
	[DISCOUNTAMOUNT] [decimal](18, 2) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InvoiceMaster]    Script Date: 4/15/2021 9:30:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceMaster](
	[SRNO] [int] IDENTITY(1,1) NOT NULL,
	[CUSTCD] [nvarchar](50) NULL,
	[CUSTNM] [nvarchar](250) NULL,
	[DATERECEIVED] [datetime] NULL,
	[VATAMOUNT] [decimal](18, 2) NULL,
	[NETAMOUNT] [decimal](18, 2) NULL,
	[DATEDUE] [date] NULL,
	[ISPAID] [bit] NULL,
	[COMMENT] [nvarchar](500) NULL,
	[PAYMENTMODE] [nvarchar](50) NULL,
	[USRNM] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[SRNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ISSUEDETAILS]    Script Date: 4/15/2021 9:30:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ISSUEDETAILS](
	[ISSUESRNO] [int] NULL,
	[PRODCD] [nvarchar](50) NULL,
	[PRODNM] [nvarchar](150) NULL,
	[UNITCD] [nvarchar](20) NULL,
	[QUANTITY] [decimal](18, 4) NULL,
	[CP] [decimal](18, 2) NULL,
	[SP] [decimal](18, 2) NULL,
	[LINEVATAMOUNT] [decimal](18, 2) NULL,
	[LINENETAMOUNT] [decimal](18, 2) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ISSUEMASTER]    Script Date: 4/15/2021 9:30:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ISSUEMASTER](
	[SRNO] [int] IDENTITY(1,1) NOT NULL,
	[DATEISSUED] [datetime] NULL,
	[USERNAME] [nvarchar](50) NULL,
	[NETAMOUNT] [decimal](18, 2) NULL,
	[VATAMOUNT] [decimal](18, 2) NULL,
	[REASON] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[SRNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RECEIPTDETAILS]    Script Date: 4/15/2021 9:30:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RECEIPTDETAILS](
	[RECEIPTSRNO] [int] NULL,
	[PRODCD] [nvarchar](50) NULL,
	[PRODNM] [nvarchar](150) NULL,
	[UNITCD] [nvarchar](20) NULL,
	[QUANTITY] [decimal](18, 4) NULL,
	[CP] [decimal](18, 2) NULL,
	[SP] [decimal](18, 2) NULL,
	[LINEVATAMOUNT] [decimal](18, 2) NULL,
	[LINENETAMOUNT] [decimal](18, 2) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RECEIPTMASTER]    Script Date: 4/15/2021 9:30:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RECEIPTMASTER](
	[SRNO] [int] IDENTITY(1,1) NOT NULL,
	[DATERECEIVED] [datetime] NULL,
	[USERNAME] [nvarchar](50) NULL,
	[NETAMOUNT] [decimal](18, 2) NULL,
	[VATAMOUNT] [decimal](18, 2) NULL,
	[REASON] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[SRNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBLBRNCH]    Script Date: 4/15/2021 9:30:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLBRNCH](
	[BRNCHCD] [nvarchar](50) NOT NULL,
	[BRNCHNM] [nvarchar](150) NOT NULL,
	[CMPNYCD] [nvarchar](50) NOT NULL,
	[BRNCHLOCATION] [nvarchar](150) NULL,
	[BRNCHTELEPHONE] [nvarchar](50) NULL,
	[BRNCHIP] [nvarchar](50) NULL,
	[BRNCHINSTANCE] [nvarchar](50) NULL,
	[BRNCHPWD] [nvarchar](50) NULL,
	[ISCHILD] [bit] NOT NULL DEFAULT ((1)),
	[ISPARENT] [bit] NOT NULL DEFAULT ((0)),
	[CREATEDBY] [nvarchar](50) NULL,
	[CREATEDON] [datetime] NULL DEFAULT (getdate()),
	[UPLOADFLG] [nchar](10) NOT NULL DEFAULT ('Y'),
PRIMARY KEY CLUSTERED 
(
	[BRNCHCD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBLCMPNY]    Script Date: 4/15/2021 9:30:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLCMPNY](
	[CMPNYCD] [nvarchar](20) NOT NULL,
	[CMPNYNM] [nvarchar](150) NOT NULL,
	[CMPNYADDR] [nvarchar](50) NULL,
	[CMPNYTEL] [nvarchar](50) NULL,
	[CMPNYTAXPIN] [nvarchar](50) NULL,
	[CMPNYREGNO] [nvarchar](50) NULL,
	[CREATEDBY] [nvarchar](50) NULL,
	[CREATEDON] [datetime] NULL DEFAULT (getdate()),
	[UPLOADFLG] [nvarchar](1) NOT NULL DEFAULT ('Y'),
PRIMARY KEY CLUSTERED 
(
	[CMPNYCD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBLCPHIST]    Script Date: 4/15/2021 9:30:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLCPHIST](
	[PROD_CD] [nvarchar](50) NOT NULL,
	[INT_CP] [decimal](18, 2) NULL,
	[NW_CP] [decimal](18, 2) NULL,
	[USR_NM] [nvarchar](50) NULL,
	[CHG_DT] [datetime] NULL,
	[BRCH_CD] [nvarchar](50) NULL,
	[CMPY_CD] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblCust]    Script Date: 4/15/2021 9:30:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblCust](
	[CUSTCD] [nvarchar](50) NOT NULL,
	[CUSTNM] [nvarchar](250) NOT NULL,
	[CUSTBOX] [nvarchar](100) NULL,
	[CUSTCITY] [nvarchar](50) NULL,
	[CUSTLOCATION] [nvarchar](100) NULL,
	[CUSTTELEPHONE] [nvarchar](20) NULL,
	[CUSTPIN] [nvarchar](20) NULL,
	[CUSTEMAIL] [nvarchar](70) NULL,
	[CUSTFAX] [nvarchar](20) NULL,
	[CUSTCREDITLIMIT] [decimal](18, 2) NULL,
	[CUSTMOBILE] [nvarchar](20) NULL,
	[CUSTVAT] [nvarchar](50) NULL,
	[CUSTLIMITDAYS] [int] NULL,
	[CUSTPAYMENTMODE] [nvarchar](30) NULL,
	[ISACTIVE] [bit] NULL,
	[CREATEDBY] [nvarchar](50) NULL,
	[CREATEDON] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CUSTCD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblDept]    Script Date: 4/15/2021 9:30:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDept](
	[DeptCd] [nvarchar](20) NOT NULL,
	[DeptNm] [nvarchar](150) NOT NULL,
	[Createdby] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[DeptCd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBLPOLICIES]    Script Date: 4/15/2021 9:30:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBLPOLICIES](
	[GROUPCODE] [nvarchar](50) NOT NULL,
	[CANADDSTOCK] [bit] NULL,
	[CANVIEWSTOCK] [bit] NULL,
	[CANISSUESTOCK] [bit] NULL,
	[CANMANAGEUSERS] [bit] NULL,
	[CANADJUSTSTOCK] [bit] NULL,
	[CREATEDON] [datetime] NULL,
	[UPLOADFLG] [varchar](1) NULL,
	[ISACTIVE] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[GROUPCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblProd]    Script Date: 4/15/2021 9:30:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblProd](
	[ProdCd] [nvarchar](20) NOT NULL,
	[ProdNm] [nvarchar](150) NOT NULL,
	[UnitCd] [nvarchar](10) NULL,
	[DeptCd] [nvarchar](10) NULL,
	[SuppCd] [nvarchar](20) NULL,
	[Cp] [decimal](18, 2) NULL,
	[Sp] [decimal](18, 2) NULL,
	[QtyOnOrder] [decimal](18, 2) NULL,
	[QtyAvble] [decimal](18, 2) NULL,
	[Isactive] [bit] NULL,
	[VatCd] [nvarchar](5) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[UploadFlag] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProdCd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblProdHist]    Script Date: 4/15/2021 9:30:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblProdHist](
	[PROD_CD] [nvarchar](50) NOT NULL,
	[TXN_TYPE] [nvarchar](30) NULL,
	[DOC_NO] [int] NULL,
	[INT_QTY] [decimal](18, 2) NULL,
	[NW_QTY] [decimal](18, 2) NULL,
	[QTY] [decimal](18, 3) NULL,
	[BRCH_CD] [nvarchar](50) NULL,
	[CMPY_CD] [nvarchar](50) NULL,
	[TXN_DATE] [datetime] NULL,
	[PROD_CP] [decimal](18, 2) NULL,
	[PROD_SP] [decimal](18, 2) NULL,
	[USR_NM] [nvarchar](50) NULL,
	[INV_NO] [nvarchar](250) NULL,
	[ACCOUNT_NO] [nvarchar](250) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblReasons]    Script Date: 4/15/2021 9:30:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblReasons](
	[ReasonCode] [nvarchar](20) NOT NULL,
	[ReasonName] [nvarchar](150) NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[UploadFlg] [nvarchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[ReasonCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblScnCd]    Script Date: 4/15/2021 9:30:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblScnCd](
	[ScanCode] [nvarchar](25) NOT NULL,
	[ProdCd] [nvarchar](50) NULL,
	[UnitCd] [nvarchar](50) NULL,
	[Upload_Flg] [nchar](1) NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ScanCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBLSPHIST]    Script Date: 4/15/2021 9:30:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLSPHIST](
	[PROD_CD] [nvarchar](50) NOT NULL,
	[INT_SP] [decimal](18, 2) NULL,
	[NW_SP] [decimal](18, 2) NULL,
	[USR_NM] [nvarchar](50) NULL,
	[CHG_DT] [datetime] NULL,
	[BRCH_CD] [nvarchar](50) NULL,
	[CMPY_CD] [nvarchar](50) NULL,
	[Sr_No] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Sr_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblSupp]    Script Date: 4/15/2021 9:30:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblSupp](
	[SuppCd] [nvarchar](20) NOT NULL,
	[SuppNm] [nvarchar](150) NOT NULL,
	[SuppBox] [nvarchar](150) NULL,
	[SuppCity] [nvarchar](50) NULL,
	[SuppLocation] [nvarchar](100) NULL,
	[SuppTel] [nvarchar](100) NULL,
	[SuppPinCode] [nvarchar](100) NULL,
	[SuppEmail] [nvarchar](100) NULL,
	[SuppFax] [nvarchar](100) NULL,
	[SuppCreditLimit] [decimal](18, 0) NULL,
	[SuppMobile] [nvarchar](100) NULL,
	[SuppPaymentTerms] [nvarchar](100) NULL,
	[SuppLimitDays] [int] NULL,
	[SuppVatNo] [nvarchar](100) NULL,
	[CreatedBy] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[SuppCd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblUnit]    Script Date: 4/15/2021 9:30:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUnit](
	[UnitCd] [nvarchar](20) NOT NULL,
	[UnitNm] [nvarchar](150) NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[UploadFlag] [nvarchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[UnitCd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBLUSERGROUPS]    Script Date: 4/15/2021 9:30:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBLUSERGROUPS](
	[GROUPCODE] [nvarchar](50) NOT NULL,
	[GROUPNAME] [nvarchar](100) NOT NULL,
	[CANADDSTOCK] [bit] NOT NULL DEFAULT ((0)),
	[CANVIEWSTOCK] [bit] NOT NULL DEFAULT ((0)),
	[CANISSUESTOCK] [bit] NOT NULL DEFAULT ((0)),
	[CANMANAGEUSERS] [bit] NOT NULL DEFAULT ((0)),
	[CANCHANGECP] [bit] NOT NULL DEFAULT ((0)),
	[CANCHANGESP] [bit] NOT NULL DEFAULT ((0)),
	[CANADJUSTSTOCK] [bit] NOT NULL DEFAULT ((0)),
	[CREATEDBY] [nvarchar](50) NULL,
	[CREATEDON] [datetime] NULL DEFAULT (getdate()),
	[UPLOADFLG] [varchar](1) NULL DEFAULT ('Y'),
	[ISACTIVE] [bit] NULL DEFAULT ((1))
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBLUSERROLE]    Script Date: 4/15/2021 9:30:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[TBLUSERROLE](
	[USERNAME] [nvarchar](50) NOT NULL,
	[GROUPCODE] [nvarchar](50) NULL,
	[CREATEDON] [datetime] NULL,
	[UPLOADFLG] [varchar](1) NULL,
	[ISACTIVE] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[USERNAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBLUSERS]    Script Date: 4/15/2021 9:30:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBLUSERS](
	[USERNAME] [nvarchar](50) NOT NULL,
	[FULLNAME] [nvarchar](100) NOT NULL,
	[PASSWORD] [nvarchar](250) NULL,
	[GROUPCODE] [nvarchar](50) NULL,
	[CREATEDBY] [nvarchar](50) NULL,
	[CREATEDON] [datetime] NULL DEFAULT (getdate()),
	[UPLOADFLG] [varchar](1) NULL DEFAULT ('Y'),
	[ISACTIVE] [bit] NULL DEFAULT ((1)),
PRIMARY KEY CLUSTERED 
(
	[USERNAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblVat]    Script Date: 4/15/2021 9:30:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVat](
	[VatCd] [nvarchar](5) NOT NULL,
	[VatPercentage] [decimal](18, 0) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[VatCd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[TBLBRNCH] ([BRNCHCD], [BRNCHNM], [CMPNYCD], [BRNCHLOCATION], [BRNCHTELEPHONE], [BRNCHIP], [BRNCHINSTANCE], [BRNCHPWD], [ISCHILD], [ISPARENT], [CREATEDBY], [CREATEDON], [UPLOADFLG]) VALUES (N'01', N'THUITAS NAROK', N'TN001', N'NAROK', N'0702157779', N'192.168.8.104', N'WSERVER', NULL, 0, 1, N'ADMIN', CAST(N'2021-01-19 09:36:35.037' AS DateTime), N'Y')
INSERT [dbo].[TBLCMPNY] ([CMPNYCD], [CMPNYNM], [CMPNYADDR], [CMPNYTEL], [CMPNYTAXPIN], [CMPNYREGNO], [CREATEDBY], [CREATEDON], [UPLOADFLG]) VALUES (N'TN001', N'THUITAS CYBER CAFE', N'144', N'0702157779', N'A000212', N'BGA01254', N'ADMIN', CAST(N'2021-01-19 09:35:37.867' AS DateTime), N'Y')
INSERT [dbo].[TBLUSERGROUPS] ([GROUPCODE], [GROUPNAME], [CANADDSTOCK], [CANVIEWSTOCK], [CANISSUESTOCK], [CANMANAGEUSERS], [CANCHANGECP], [CANCHANGESP], [CANADJUSTSTOCK], [CREATEDBY], [CREATEDON], [UPLOADFLG], [ISACTIVE]) VALUES (N'ADMIN', N'ADMINISTRATORS', 1, 1, 1, 1, 1, 1, 1, N'ADMIN', CAST(N'2021-03-02 17:00:19.270' AS DateTime), N'Y', 1)
INSERT [dbo].[TBLUSERS] ([USERNAME], [FULLNAME], [PASSWORD], [GROUPCODE], [CREATEDBY], [CREATEDON], [UPLOADFLG], [ISACTIVE]) VALUES (N'ADMIN', N'ADMINISTRATOR', N'gG/qJRgy3/A=', N'ADMIN', N'ADMIN', CAST(N'2021-01-16 17:21:17.013' AS DateTime), N'Y', 1)
ALTER TABLE [dbo].[GrnMaster] ADD  DEFAULT (getdate()) FOR [GrnDate]
GO
ALTER TABLE [dbo].[INVOICEDETAILS] ADD  DEFAULT ((0)) FOR [DISCOUNTAMOUNT]
GO
ALTER TABLE [dbo].[InvoiceMaster] ADD  DEFAULT (getdate()) FOR [DATERECEIVED]
GO
ALTER TABLE [dbo].[InvoiceMaster] ADD  DEFAULT ('FALSE') FOR [ISPAID]
GO
ALTER TABLE [dbo].[ISSUEMASTER] ADD  DEFAULT (getdate()) FOR [DATEISSUED]
GO
ALTER TABLE [dbo].[RECEIPTMASTER] ADD  DEFAULT (getdate()) FOR [DATERECEIVED]
GO
ALTER TABLE [dbo].[TBLCPHIST] ADD  DEFAULT (getdate()) FOR [CHG_DT]
GO
ALTER TABLE [dbo].[TblCust] ADD  DEFAULT ('TRUE') FOR [ISACTIVE]
GO
ALTER TABLE [dbo].[TblCust] ADD  DEFAULT (getdate()) FOR [CREATEDON]
GO
ALTER TABLE [dbo].[tblDept] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[TBLPOLICIES] ADD  DEFAULT (getdate()) FOR [CREATEDON]
GO
ALTER TABLE [dbo].[TBLPOLICIES] ADD  DEFAULT ('Y') FOR [UPLOADFLG]
GO
ALTER TABLE [dbo].[TBLPOLICIES] ADD  DEFAULT ((1)) FOR [ISACTIVE]
GO
ALTER TABLE [dbo].[TblProd] ADD  DEFAULT ((0)) FOR [QtyOnOrder]
GO
ALTER TABLE [dbo].[TblProd] ADD  DEFAULT ((0)) FOR [QtyAvble]
GO
ALTER TABLE [dbo].[TblProd] ADD  DEFAULT ((1)) FOR [Isactive]
GO
ALTER TABLE [dbo].[TblProd] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[TblProd] ADD  DEFAULT ('Y') FOR [UploadFlag]
GO
ALTER TABLE [dbo].[TblProdHist] ADD  DEFAULT (getdate()) FOR [TXN_DATE]
GO
ALTER TABLE [dbo].[TblReasons] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[TblReasons] ADD  DEFAULT ('Y') FOR [UploadFlg]
GO
ALTER TABLE [dbo].[TblScnCd] ADD  DEFAULT ('Y') FOR [Upload_Flg]
GO
ALTER TABLE [dbo].[TblScnCd] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[TBLSPHIST] ADD  DEFAULT (getdate()) FOR [CHG_DT]
GO
ALTER TABLE [dbo].[tblUnit] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[tblUnit] ADD  DEFAULT ('Y') FOR [UploadFlag]
GO
ALTER TABLE [dbo].[TBLUSERROLE] ADD  DEFAULT (getdate()) FOR [CREATEDON]
GO
ALTER TABLE [dbo].[TBLUSERROLE] ADD  DEFAULT ('Y') FOR [UPLOADFLG]
GO
ALTER TABLE [dbo].[TBLUSERROLE] ADD  DEFAULT ((1)) FOR [ISACTIVE]
GO
ALTER TABLE [dbo].[tblVat] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  StoredProcedure [dbo].[ADDUSERGROUP]    Script Date: 4/15/2021 9:30:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[ADDUSERGROUP]
@GroupCode nvarchar(50),
@GroupName nvarchar (100),
@canaddstock bit,
@canviewstock bit,
@canissuestock bit,
@canmanageusers bit,
@canchangecp bit,
@canchangesp bit,
@canadjuststock bit,
@createdby nvarchar(50)

as
begin
insert into TBLUSERGROUPS (groupcode,GROUPNAME,CANADDSTOCK,CANVIEWSTOCK,CANISSUESTOCK,CANMANAGEUSERS,CANCHANGECP,CANCHANGESP,CANADJUSTSTOCK,CREATEDBY) values 
(@GroupCode,@GroupName,@canaddstock,@canviewstock,@canissuestock,@canmanageusers,@canchangecp,@canchangesp,@canadjuststock,@createdby)
end

GO
/****** Object:  StoredProcedure [dbo].[EditSupp]    Script Date: 4/15/2021 9:30:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[EditSupp]
@SuppCd nvarchar (20) ,
	@SuppNm nvarchar (150),
	@SuppBox nvarchar (150),
	@SuppCity nvarchar(50),
	@SuppLocation nvarchar(100),
	@SuppTel nvarchar(100),
	@SuppPinCode nvarchar(100),
	@SuppEmail nvarchar(100),
	@SuppFax nvarchar(100),
	@SuppCreditLimit decimal ,
	@SuppMobile nvarchar(100),
	@SuppPaymentTerms nvarchar(100),
	@SuppLimitDays int,
	@SuppVatNo nvarchar(100)

	as
	begin
	update TblSupp
	set
	SuppNm =@SuppNm,
	SuppBox = @SuppBox,
	SuppCity = @suppcity,
	SuppLocation =@SuppLocation,
	SuppTel= @SuppTel,
	SuppPinCode = @SuppPinCode,
	SuppEmail =@SuppEmail,
	SuppFax =@suppfax,
	SuppCreditLimit =@SuppCreditLimit ,
	SuppMobile =@SuppMobile,
	SuppPaymentTerms =@SuppPaymentTerms,
	SuppLimitDays =@SuppLimitDays,
	SuppVatNo =@SuppVatNo
	where SuppCd=@SuppCd
	end
GO
/****** Object:  StoredProcedure [dbo].[EditUnit]    Script Date: 4/15/2021 9:30:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EditUnit] 
@Unitcd nvarchar (20),
@unitnm nvarchar (50)
as 
begin
Update tblUnit
set 
UnitNm=@unitnm where UnitCd=@Unitcd
end
GO
/****** Object:  StoredProcedure [dbo].[EditVat]    Script Date: 4/15/2021 9:30:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EditVat]
@VatCd nvarchar (20),
@VatPercentage decimal
as 
begin
update tblVat
set
VatPercentage=@VatPercentage where VatCd=@VatCd
end
GO
/****** Object:  StoredProcedure [dbo].[SPADDUSER]    Script Date: 4/15/2021 9:30:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SPADDUSER]
	@Uname nvarchar (50),
	@Fname nvarchar (150),
	@Pwd nvarchar (250),
	@GROUPCODE NVARCHAR (50),
	@Createdby nvarchar (50)
AS
	begin
	insert into TBLUSERS (USERNAME,FULLNAME,[PASSWORD],GROUPCODE,CREATEDBY) values (@Uname,@Fname,@Pwd,@GROUPCODE,@Createdby)
	end

GO
/****** Object:  StoredProcedure [dbo].[SPBRANCH]    Script Date: 4/15/2021 9:30:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPBRANCH]
	@Cmpnycd nvarchar (50),
	@Brnchcd nvarchar (50),
	@Brnchnm nvarchar (150),
	@BrnchLocation nvarchar(150),
	@BrnchTelephone nvarchar (50),
	@BrnchIp nvarchar(50),
	@BrnchPwd nvarchar(50),
	@BrnchInstance nvarchar(50),
	@IsChild bit,
	@isParent bit,
	@CreatedBy nvarchar (50)
AS
	begin

	if exists (select * from TBLBRNCH where BRNCHCD=@Brnchcd)
	  update TBLBRNCH set 
	  CMPNYCD=@Cmpnycd,
	  BRNCHNM=@Brnchnm,
	  BRNCHLOCATION=@BrnchLocation,
	  BRNCHTELEPHONE=@BrnchTelephone,
	  BRNCHIP=@BrnchIp,
	  BRNCHINSTANCE=@BrnchInstance,
	  BRNCHPWD=@BrnchPwd,
	  ISCHILD=@IsChild,
	  ISPARENT=@isParent where BRNCHCD=@Brnchcd
	  else
	  insert into TBLBRNCH (CMPNYCD,BRNCHCD,BRNCHNM,BRNCHLOCATION,BRNCHTELEPHONE,BRNCHIP,BRNCHINSTANCE,BRNCHPWD,ISCHILD,ISPARENT) values
	  (@Cmpnycd,@Brnchcd,@Brnchnm,@BrnchLocation,@BrnchTelephone,@BrnchIp,@BrnchInstance,@BrnchPwd,@IsChild,@isParent)

	
	end
GO
/****** Object:  StoredProcedure [dbo].[spGetValues]    Script Date: 4/15/2021 9:30:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spGetValues]
as
begin
select top 1 CMPNYNM as [Company], BRNCHNM as [Branch] from TBLBRNCH join TBLCMPNY on TBLBRNCH.CMPNYCD=TBLCMPNY.CMPNYCD 
end
GO
/****** Object:  StoredProcedure [dbo].[SpStockCard]    Script Date: 4/15/2021 9:30:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[SpStockCard] @fromProd nvarchar (50),@toProd nvarchar (50),@fromdt datetime,@todt datetime,@fromsupp nvarchar (50),@tosupp nvarchar (50),@fromdept nvarchar (50),@todept nvarchar (50)
as 
begin 
DROP TABLE IF EXISTS #tmpStockCard
create table #tmpStockCard
(
ProdCd nvarchar (50), 
ProdNm Nvarchar (150),
ProdSupplier Nvarchar (150),
ProdDepartment Nvarchar (150),
Cp decimal (18,2),
Sp decimal (18,2),
Vat int,
 ProdUnit nvarchar (150),
 QuantityAvailable decimal (18,4),
 Txn_Date datetime,
 Txn_Type nvarchar (50),
 Doc_No int, 
 Account_No nvarchar (150),
 Qty decimal (18,2),
 Balance decimal (18,2),
 Txn_CP decimal (18,2),
 Txn_SP decimal (18,2)
)
DROP TABLE IF EXISTS #TMPOP 
SELECT PH.INT_QTY,PH.PROD_CD,P.PRODNM,S.SuppNm,U.UnitNm,D.DeptNm,P.Cp,P.Sp,V.VatPercentage,
P.QtyAvble,PH.INT_QTY AS QUANTITY,PH.TXN_DATE, row_number() over (partition by pH.PROD_CD 
order by PH.TXN_DATE ) as row_number INTO #TMPOP
 from TblProdHist ph LEFT OUTER join TblProd p on ph.PROD_CD=p.ProdCd LEFT OUTER join 
 TblSupp s on p.SuppCd=s.SuppCd LEFT OUTER join tblDept d on p.DeptCd=d.DeptCd LEFT OUTER join 
 tblVat v on p.VatCd=v.VatCd LEFT OUTER join tblUnit u on p.UnitCd= u.UnitCd
where p.ProdCd between @fromProd and @toProd AND s.SuppCd between @fromsupp and @tosupp and
 ph.TXN_DATE between @fromdt and @Todt and d.DeptCd between @fromdept and @todept
INSERT INTO #tmpStockCard
 (Qty,ProdCd,ProdNm,ProdUnit,ProdDepartment,ProdSupplier ,Cp,Sp,Vat,QuantityAvailable,Txn_Date,Account_No,balance,Txn_Type) 
 SELECT INT_QTY,PROD_CD,PRODNM,UnitNm,DeptNm,SuppNm,Cp,Sp,VatPercentage,QtyAvble,TXN_DATE,'OP_BAL',INT_QTY,'OP_BAL'
  FROM #TMPOP WHERE ROW_NUMBER=1
insert into #tmpStockCard
select ph.PROD_CD as ProdCd, p.prodnm as ProdNm,s.suppnm as ProdSupplier, d.DeptNm as
 ProdDepartment,p.cp as Cp,p.sp as Sp,V.VatPercentage 
as Vat,u.UnitNm as ProdUnit, p.QtyAvble as QuantityAvailable,ph.TXN_DATE,ph.TXN_TYPE,ph.DOC_NO,
ph.ACCOUNT_NO,ph.QTY,ph.NW_QTY as Balance,ph.PROD_CP,ph.Prod_SP 
from TblProdHist ph join TblProd p on ph.PROD_CD=p.ProdCd join TblSupp s on p.SuppCd=s.SuppCd
 join tblDept d on p.DeptCd=d.DeptCd join tblVat v on
 p.VatCd=v.VatCd join tblUnit u on p.UnitCd= u.UnitCd
where p.ProdCd between @fromProd and @toProd AND s.SuppCd between @fromsupp and @tosupp and 
ph.TXN_DATE between @fromdt and @Todt and d.DeptCd between @fromdept and @todept
-- select data from the temporary table
select * from #tmpStockCard
end

GO
/****** Object:  StoredProcedure [dbo].[spUpdateDept]    Script Date: 4/15/2021 9:30:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spUpdateDept]
@DeptCd nvarchar (20),
@DeptNm nvarchar (150)
as
begin
if exists(select deptcd from tblDept)
begin
update tblDept
set 
DeptNm=@DeptNm where DeptCd=@DeptCd
end
end
GO
/****** Object:  StoredProcedure [dbo].[SPUPDATEUSER]    Script Date: 4/15/2021 9:30:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SPUPDATEUSER]
	@Uname nvarchar (50),
	@Fname nvarchar (150),
	@Pwd nvarchar (250),
	@GROUPCODE NVARCHAR (50)
	
AS
	begin
	UPDATE TBLUSERS
	SET FULLNAME=@Fname,
	[PASSWORD]=@Pwd,
	GROUPCODE=@GROUPCODE
	WHERE USERNAME=@UNAME
	
	end


GO
/****** Object:  StoredProcedure [dbo].[UPDATEUSERGROUP]    Script Date: 4/15/2021 9:30:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UPDATEUSERGROUP]
@GroupCode nvarchar(50),
@GroupName nvarchar (100),
@canaddstock bit,
@canviewstock bit,
@canissuestock bit,
@canmanageusers bit,
@canchangecp bit,
@canchangesp bit,
@canadjuststock bit

as
begin
UPDATE TBLUSERGROUPS SET GROUPNAME=@GroupName,CANADDSTOCK=@canaddstock, 
CANVIEWSTOCK=@canviewstock,CANISSUESTOCK=@CANISSUESTOCK,CANMANAGEUSERS=@canmanageusers,
CANCHANGECP=@canchangecp,CANCHANGESP=@canchangesp,CANADJUSTSTOCK=@canadjuststock
WHERE GROUPCODE=@GroupCode
end
GO
USE [master]
GO
ALTER DATABASE [ShopLiteDb] SET  READ_WRITE 
GO
