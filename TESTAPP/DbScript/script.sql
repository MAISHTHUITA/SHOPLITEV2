USE [master]
GO
/****** Object:  Database [ShopLiteDb]    Script Date: 9/27/2021 6:28:09 PM ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'ShopLiteDb')
BEGIN
CREATE DATABASE [ShopLiteDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShopLiteDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ShopLiteDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShopLiteDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ShopLiteDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
END

GO
ALTER DATABASE [ShopLiteDb] SET COMPATIBILITY_LEVEL = 110
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
ALTER DATABASE [ShopLiteDb] SET AUTO_CREATE_STATISTICS ON 
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
USE [ShopLiteDb]
GO
/****** Object:  StoredProcedure [dbo].[AddGroup]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddGroup]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[AddGroup]
@GROUPCODE VARCHAR(20),
@GROUPNAME VARCHAR(100),
@CREATEDBY VARCHAR(50),
@ISACTIVE BIT
AS
BEGIN
INSERT INTO USERGROUPS (GROUPCODE,GROUPNAME,CREATEDBY,ISACTIVE) VALUES (@GROUPCODE,@GROUPNAME,@CREATEDBY,@ISACTIVE)
INSERT INTO GROUPPOLICY (MODULECODE, GROUPCODE, POLICY,CREATEDBY) 
SELECT MODULEMASTER.MODULECODE, @GROUPCODE,''N'',@CREATEDBY
FROM MODULEMASTER
END


' 
END
GO
/****** Object:  StoredProcedure [dbo].[ADDUSERGROUP]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ADDUSERGROUP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[CheckPolicy]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CheckPolicy]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[CheckPolicy]
@Username varchar(20),
@Module varchar(10)
as
begin
select modulecode from grouppolicy gp join TBLUSERS u on gp.GROUPCODE=u.GROUPCODE  where u.USERNAME=@username and ModuleCode=@module and Policy=''Y''
end' 
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteTill]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteTill]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create proc [dbo].[DeleteTill] 
@TillCode int

as
begin
delete from tillmanager where tillcode=@TillCode
end' 
END
GO
/****** Object:  StoredProcedure [dbo].[EditSupp]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EditSupp]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[EditSupp]
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[EditUnit]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EditUnit]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create proc [dbo].[EditUnit] 
@Unitcd nvarchar (20),
@unitnm nvarchar (50)
as 
begin
Update tblUnit
set 
UnitNm=@unitnm where UnitCd=@Unitcd
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[EditVat]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EditVat]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create proc [dbo].[EditVat]
@VatCd nvarchar (20),
@VatPercentage decimal
as 
begin
update tblVat
set
VatPercentage=@VatPercentage where VatCd=@VatCd
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GETGROUP]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GETGROUP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[GETGROUP]
@groupcode varchar(50)
AS
BEGIN
SELECT GROUPCODE,GROUPNAME,ISACTIVE FROM USERGROUPS WHERE GROUPCODE=@groupcode
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[GETGROUPS]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GETGROUPS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[GETGROUPS]
AS
BEGIN
SELECT GROUPCODE,GROUPNAME FROM USERGROUPS
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[GETPOLICY]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GETPOLICY]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[GETPOLICY]
@GROUPCODE VARCHAR(20)
AS 
BEGIN
SELECT GP.MODULECODE,MM.MODULEDESCRIPTION,POLICY FROM GROUPPOLICY GP JOIN MODULEMASTER MM ON GP.MODULECODE=MM.MODULECODE WHERE GP.GROUPCODE = @GROUPCODE
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetPos]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetPos]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[GetPos] 
@ReceiptNo int
as
begin
select PM.PosNumber, PM.PosDate,PM.VatAmount,PM.TotalAmount,PM.Username,PM.PaymentMethod,PM.PaymentNarration,PM.CmpnyCd,PM.BrnchCd,PM.CashGiven,PD.ProdCd,PD.ProdNm, PD.UnitCd,PD.Quantity,PD.Sp,PD.Vatcd,PD.LineAmount from TblPosMaster PM join TblPosDetails PD on PM.PosNumber = pd.PosNumber where pm.PosNumber=@ReceiptNo
end' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetTill]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTill]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetTill] 
@TillCode int
as
begin
select TillCode,MachineName,IsActive from TillManager where TillCode=@TillCode
end' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetTills]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTills]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetTills]
as
begin
select TillCode,MachineName,IsActive from TillManager
end' 
END
GO
/****** Object:  StoredProcedure [dbo].[GETUSER]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GETUSER]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[GETUSER]
@Username VARCHAR(50)
AS
BEGIN
SELECT USERNAME,FULLNAME,PASSWORD,GROUPCODE,ISACTIVE FROM TBLUSERS WHERE USERNAME = @USERNAME
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_Cust_Stmt]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sp_Cust_Stmt]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Sp_Cust_Stmt] @fromdt datetime, @todt datetime, @fromcust nvarchar(20),@tocust nvarchar(20)
as
begin
select INV_RET_CN_NO,[TYPE],CUSTOMER_CODE, CUSTOMER_NAME, AMOUNT, [DATE] from Cust_Stmt WHERE [DATE] BETWEEN @fromdt AND 
@todt AND CUSTOMER_CODE BETWEEN @fromcust AND @tocust order by [date] asc
end' 
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_Top_10_Cust_Stmt]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sp_Top_10_Cust_Stmt]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Sp_Top_10_Cust_Stmt] @fromdt datetime, @todt datetime, @fromcust nvarchar(20),@tocust nvarchar(20)
as
begin
select top 10 INV_RET_CN_NO,[TYPE],CUSTOMER_CODE, CUSTOMER_NAME, AMOUNT, [DATE] from Cust_Stmt WHERE [DATE] BETWEEN @fromdt AND 
@todt AND CUSTOMER_CODE BETWEEN @fromcust AND @tocust order by [DATE] Asc
end' 
END
GO
/****** Object:  StoredProcedure [dbo].[SPADDUSER]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SPADDUSER]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[SPBRANCH]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SPBRANCH]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SPBRANCH]
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[SpGetCustomer]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SpGetCustomer]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[SpGetCustomer] @Custcd nvarchar(50)
as 
begin
Select CustCd, CustNm,CustBox,CustCity,CustLocation,CustTelephone,CustPin,CustEmail,CustCreditLimit,CustMobile,CustFax,CustVat,CustLimitDays,CustPaymentMode,IsActive from tblCust where custcd = @Custcd or custnm =@custcd
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[SpGetCustomers]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SpGetCustomers]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE procedure [dbo].[SpGetCustomers] 
as 
begin
Select CustCd, CustNm,CustBox,CustCity,CustLocation,CustTelephone,CustPin,CustEmail,CustCreditLimit,CustMobile,CustFax,CustVat,CustLimitDays,CustPaymentMode,IsActive from tblCust
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[SpGetGrnSummaries]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SpGetGrnSummaries]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[SpGetGrnSummaries]
@FromSupp Nvarchar(50),@ToSupp Nvarchar(50),@FromDt datetime, @ToDt datetime,@fromgrn int,@toGrn int
as
begin
select SrNo as GrnNo,SuppCd,SuppNm,InvoiceNumber,GrnMaster.GrnDate as DateReceived,(TotalAmount+VatAmount) as InvoiceAmount
  from GrnMaster where SuppCd between @FromSupp and @ToSupp and GrnDate between @FromDt and @ToDt and SrNo between @fromgrn and @toGrn
  order by SrNo Asc
end' 
END
GO
/****** Object:  StoredProcedure [dbo].[SpGetLastGrnNo]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SpGetLastGrnNo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[SpGetLastGrnNo]
as
begin
select SrNo as Grn_No from GrnMaster where SrNo=(select Max(SrNo) from GrnMaster)
end' 
END
GO
/****** Object:  StoredProcedure [dbo].[spGetValues]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGetValues]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create proc [dbo].[spGetValues]
as
begin
select top 1 CMPNYNM as [Company], BRNCHNM as [Branch] from TBLBRNCH join TBLCMPNY on TBLBRNCH.CMPNYCD=TBLCMPNY.CMPNYCD 
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[SpStockCard]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SpStockCard]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[SpStockCard] @fromProd nvarchar (50),@toProd nvarchar (50),@fromdt datetime,@todt datetime,@fromsupp nvarchar (50),@tosupp nvarchar (50),@fromdept nvarchar (50),@todept nvarchar (50)
as 
begin 
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
 Txn_Cp decimal,
 Txn_Sp decimal,
 Account_No nvarchar (150),
 Qty decimal (18,2),
 Balance decimal (18,2)
)
SELECT PH.INT_QTY,PH.PROD_CD,P.PRODNM,S.SuppNm,U.UnitNm,D.DeptNm,P.Cp,P.Sp,V.VatPercentage,P.QtyAvble,PH.INT_QTY 
AS QUANTITY,PH.TXN_DATE, row_number() over (partition by pH.PROD_CD order by PH.TXN_DATE ) as row_number INTO #TMPOP
 from TblProdHist ph LEFT OUTER join TblProd p on ph.PROD_CD=p.ProdCd LEFT OUTER join TblSupp s on p.SuppCd=s.SuppCd
  LEFT OUTER join tblDept d on p.DeptCd=d.DeptCd LEFT OUTER join tblVat v on p.VatCd=v.VatCd LEFT OUTER join tblUnit u
   on p.UnitCd= u.UnitCd
where p.ProdCd between @fromProd and @toProd AND s.SuppCd between @fromsupp and @tosupp and ph.TXN_DATE between
 @fromdt and @Todt and d.DeptCd between @fromdept and @todept
INSERT INTO #tmpStockCard
 (Qty,ProdCd,ProdNm,ProdUnit,ProdDepartment,ProdSupplier ,Cp,Sp,Vat,QuantityAvailable,Txn_Date,Account_No,balance,
 Txn_Type) 
 SELECT INT_QTY,PROD_CD,PRODNM,UnitNm,DeptNm,SuppNm,Cp,Sp,VatPercentage,QtyAvble,TXN_DATE,''OP_BAL'',INT_QTY,''OP_BAL''
  FROM #TMPOP WHERE ROW_NUMBER=1
insert into #tmpStockCard
select
 ph.PROD_CD as ProdCd, 
 p.prodnm as ProdNm,
 s.suppnm as ProdSupplier, 
 d.DeptNm as ProdDepartment,
 p.cp as Cp,
 p.sp as Sp,
 V.VatPercentage as Vat,
 u.UnitNm as ProdUnit,
 p.QtyAvble as QuantityAvailable,
 ph.TXN_DATE,
 ph.TXN_TYPE,
 ph.DOC_NO,
 ph.PROD_CP as Txn_Cp,
 ph.PROD_SP as Txn_Sp, 
 ph.ACCOUNT_NO,
 ph.QTY,
 ph.NW_QTY as Balance
 from TblProdHist ph
  join TblProd p on ph.PROD_CD=p.ProdCd 
 join TblSupp s on p.SuppCd=s.SuppCd join tblDept d on p.DeptCd=d.DeptCd join tblVat v on p.VatCd=v.VatCd join tblUnit u
  on
   p.UnitCd= u.UnitCd
where
 p.ProdCd between @fromProd and @toProd AND s.SuppCd between @fromsupp and @tosupp and ph.TXN_DATE between @fromdt and @Todt
  and d.DeptCd between @fromdept and @todept
-- select data from the temporary table
select * from #tmpStockCard
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateDept]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateDept]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create proc [dbo].[spUpdateDept]
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[SPUPDATEUSER]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SPUPDATEUSER]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[SPUPDATEUSER]
	@Uname nvarchar (50),
	@Fname nvarchar (150),
	@Pwd nvarchar (250),
	@GROUPCODE NVARCHAR (50),
	@IsActive bit
	
AS
	begin
	UPDATE TBLUSERS
	SET FULLNAME=@Fname,
	[PASSWORD]=@Pwd,
	GROUPCODE=@GROUPCODE,
	ISACTIVE=@ISACTIVE
	WHERE USERNAME=@UNAME
	
	end


' 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateTill]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateTill]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[UpdateTill] 
@TillCode int,
@MachineName varchar(80),
@IsActive bit
as
begin
Update tillmanager 
set
MachineName=@MachineName,
IsActive=@IsActive
 where tillcode=@tillcode
end' 
END
GO
/****** Object:  StoredProcedure [dbo].[UPDATEUSERGROUP]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UPDATEUSERGROUP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[UPDATEUSERGROUP]
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
' 
END
GO
/****** Object:  Table [dbo].[Cust_Stmt]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cust_Stmt]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cust_Stmt](
	[INV_RET_CN_NO] [int] NULL,
	[TYPE] [nvarchar](30) NULL,
	[CUSTOMER_CODE] [nvarchar](20) NULL,
	[CUSTOMER_NAME] [nvarchar](200) NULL,
	[AMOUNT] [decimal](18, 2) NULL,
	[DATE] [datetime] NULL,
	[UPLOAD_FLAG] [nvarchar](1) NULL,
	[CREATEDBY] [nvarchar](50) NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[GrnDetails]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GrnDetails]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[GrnMaster]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GrnMaster]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[GROUPPOLICY]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GROUPPOLICY]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[GROUPPOLICY](
	[MODULECODE] [varchar](5) NULL,
	[GROUPCODE] [varchar](20) NULL,
	[POLICY] [char](1) NULL,
	[CREATEDBY] [varchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INVOICEDETAILS]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[INVOICEDETAILS]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[InvoiceMaster]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceMaster]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[ISSUEDETAILS]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ISSUEDETAILS]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[ISSUEMASTER]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ISSUEMASTER]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[MODULEMASTER]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MODULEMASTER]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MODULEMASTER](
	[MODULECODE] [varchar](5) NOT NULL,
	[MODULEDESCRIPTION] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[MODULECODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RECEIPTDETAILS]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RECEIPTDETAILS]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[RECEIPTMASTER]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RECEIPTMASTER]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[TBLBRNCH]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TBLBRNCH]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TBLBRNCH](
	[BRNCHCD] [nvarchar](50) NOT NULL,
	[BRNCHNM] [nvarchar](150) NOT NULL,
	[CMPNYCD] [nvarchar](50) NOT NULL,
	[BRNCHLOCATION] [nvarchar](150) NULL,
	[BRNCHTELEPHONE] [nvarchar](50) NULL,
	[BRNCHIP] [nvarchar](50) NULL,
	[BRNCHINSTANCE] [nvarchar](50) NULL,
	[BRNCHPWD] [nvarchar](50) NULL,
	[ISCHILD] [bit] NOT NULL,
	[ISPARENT] [bit] NOT NULL,
	[CREATEDBY] [nvarchar](50) NULL,
	[CREATEDON] [datetime] NULL,
	[UPLOADFLG] [nchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BRNCHCD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TBLCMPNY]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TBLCMPNY]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TBLCMPNY](
	[CMPNYCD] [nvarchar](20) NOT NULL,
	[CMPNYNM] [nvarchar](150) NOT NULL,
	[CMPNYADDR] [nvarchar](50) NULL,
	[CMPNYTEL] [nvarchar](50) NULL,
	[CMPNYTAXPIN] [nvarchar](50) NULL,
	[CMPNYREGNO] [nvarchar](50) NULL,
	[CREATEDBY] [nvarchar](50) NULL,
	[CREATEDON] [datetime] NULL,
	[UPLOADFLG] [nvarchar](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CMPNYCD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TBLCPHIST]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TBLCPHIST]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TBLCPHIST](
	[PROD_CD] [nvarchar](50) NOT NULL,
	[INT_CP] [decimal](18, 2) NULL,
	[NW_CP] [decimal](18, 2) NULL,
	[USR_NM] [nvarchar](50) NULL,
	[CHG_DT] [datetime] NULL,
	[BRCH_CD] [nvarchar](50) NULL,
	[CMPY_CD] [nvarchar](50) NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TblCust]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblCust]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[tblDept]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblDept]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[TBLPOLICIES]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TBLPOLICIES]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblPosDetails]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblPosDetails]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TblPosDetails](
	[PosNumber] [int] NOT NULL,
	[ProdCd] [nvarchar](50) NULL,
	[ProdNm] [nvarchar](250) NULL,
	[UnitCd] [nvarchar](50) NULL,
	[Quantity] [decimal](18, 4) NULL,
	[Sp] [decimal](18, 2) NULL,
	[LineVat] [decimal](18, 1) NULL,
	[LineAmount] [decimal](18, 2) NULL,
	[Vatcd] [nvarchar](50) NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TblPosMaster]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblPosMaster]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TblPosMaster](
	[PosNumber] [int] IDENTITY(1,1) NOT NULL,
	[PosDate] [datetime] NULL,
	[VatAmount] [decimal](18, 2) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[MachineName] [nvarchar](50) NULL,
	[Username] [nvarchar](50) NULL,
	[PaymentMethod] [nvarchar](50) NULL,
	[CmpnyCd] [nvarchar](20) NULL,
	[BrnchCd] [nvarchar](20) NULL,
	[Discount] [decimal](18, 2) NULL,
	[DiscountNarration] [nvarchar](150) NULL,
	[CashGiven] [decimal](18, 2) NULL,
	[PaymentNarration] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[PosNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblProd]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblProd]') AND type in (N'U'))
BEGIN
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
	[DefaultQuantity] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProdCd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblProdHist]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblProdHist]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[TblReasons]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblReasons]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[TblScnCd]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblScnCd]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[TBLSPHIST]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TBLSPHIST]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[TblSupp]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblSupp]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[tblUnit]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblUnit]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[TBLUSERGROUPS]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TBLUSERGROUPS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TBLUSERGROUPS](
	[GROUPCODE] [nvarchar](50) NOT NULL,
	[GROUPNAME] [nvarchar](100) NOT NULL,
	[CANADDSTOCK] [bit] NOT NULL,
	[CANVIEWSTOCK] [bit] NOT NULL,
	[CANISSUESTOCK] [bit] NOT NULL,
	[CANMANAGEUSERS] [bit] NOT NULL,
	[CANCHANGECP] [bit] NOT NULL,
	[CANCHANGESP] [bit] NOT NULL,
	[CANADJUSTSTOCK] [bit] NOT NULL,
	[CREATEDBY] [nvarchar](50) NULL,
	[CREATEDON] [datetime] NULL,
	[UPLOADFLG] [varchar](1) NULL,
	[ISACTIVE] [bit] NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBLUSERROLE]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TBLUSERROLE]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBLUSERS]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TBLUSERS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TBLUSERS](
	[USERNAME] [nvarchar](50) NOT NULL,
	[FULLNAME] [nvarchar](100) NOT NULL,
	[PASSWORD] [nvarchar](250) NULL,
	[GROUPCODE] [nvarchar](50) NULL,
	[CREATEDBY] [nvarchar](50) NULL,
	[CREATEDON] [datetime] NULL,
	[UPLOADFLG] [varchar](1) NULL,
	[ISACTIVE] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[USERNAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblVat]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblVat]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[TillManager]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TillManager]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TillManager](
	[TillCode] [int] NOT NULL,
	[MachineName] [varchar](80) NOT NULL,
	[CreatedBy] [varchar](50) NULL,
	[Createdon] [datetime] NULL,
	[IsActive] [bit] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USERGROUPS]    Script Date: 9/27/2021 6:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USERGROUPS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[USERGROUPS](
	[GROUPCODE] [varchar](20) NOT NULL,
	[GROUPNAME] [varchar](50) NULL,
	[CREATEDBY] [varchar](50) NULL,
	[CREATEDON] [datetime] NULL,
	[ISACTIVE] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[GROUPCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Cust_Stmt] ([INV_RET_CN_NO], [TYPE], [CUSTOMER_CODE], [CUSTOMER_NAME], [AMOUNT], [DATE], [UPLOAD_FLAG], [CREATEDBY]) VALUES (1, N'INV', N'TCT', N'Test customer', CAST(1200.00 AS Decimal(18, 2)), CAST(0x0000AD8000000000 AS DateTime), N'Y', N'Thuita')
INSERT [dbo].[Cust_Stmt] ([INV_RET_CN_NO], [TYPE], [CUSTOMER_CODE], [CUSTOMER_NAME], [AMOUNT], [DATE], [UPLOAD_FLAG], [CREATEDBY]) VALUES (4, N'INVOICE', N'TCT', N'NEW CUSTOMER', CAST(3938.00 AS Decimal(18, 2)), CAST(0x0000AD8F0099259D AS DateTime), N'Y', N'TEST')
INSERT [dbo].[Cust_Stmt] ([INV_RET_CN_NO], [TYPE], [CUSTOMER_CODE], [CUSTOMER_NAME], [AMOUNT], [DATE], [UPLOAD_FLAG], [CREATEDBY]) VALUES (5, N'INVOICE', N'CUST1', N'TEST CUSTOMER ', CAST(1020.00 AS Decimal(18, 2)), CAST(0x0000AD8F00A6C141 AS DateTime), N'Y', N'TEST')
INSERT [dbo].[Cust_Stmt] ([INV_RET_CN_NO], [TYPE], [CUSTOMER_CODE], [CUSTOMER_NAME], [AMOUNT], [DATE], [UPLOAD_FLAG], [CREATEDBY]) VALUES (1004, N'INVOICE', N'TCT', N'NEW CUSTOMER', CAST(2800.00 AS Decimal(18, 2)), CAST(0x0000AD940119F5FE AS DateTime), N'Y', N'TEST')
INSERT [dbo].[Cust_Stmt] ([INV_RET_CN_NO], [TYPE], [CUSTOMER_CODE], [CUSTOMER_NAME], [AMOUNT], [DATE], [UPLOAD_FLAG], [CREATEDBY]) VALUES (1005, N'INVOICE', N'TCT', N'NEW CUSTOMER', CAST(95668.00 AS Decimal(18, 2)), CAST(0x0000AD9F00A83E8B AS DateTime), N'Y', N'ADMIN')
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (6, N'1001', N'TEST ITEM 1', N'PCSFGHG', CAST(12.0000 AS Decimal(18, 4)), CAST(16.00 AS Decimal(18, 2)), CAST(166.00 AS Decimal(18, 2)), CAST(26.00 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (6, N'1002', N'TEST ITEM 2', N'PCS', CAST(12.0000 AS Decimal(18, 4)), CAST(145.00 AS Decimal(18, 2)), CAST(1500.00 AS Decimal(18, 2)), CAST(240.00 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (7, N'1001', N'TEST ITEM 1', N'PCSFGHG', CAST(12.0000 AS Decimal(18, 4)), CAST(16.00 AS Decimal(18, 2)), CAST(166.00 AS Decimal(18, 2)), CAST(26.00 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (7, N'1002', N'TEST ITEM 2', N'PCS', CAST(12.0000 AS Decimal(18, 4)), CAST(145.00 AS Decimal(18, 2)), CAST(1500.00 AS Decimal(18, 2)), CAST(240.00 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (8, N'1001', N'TEST ITEM 1', N'PCSFGHG', CAST(12.0000 AS Decimal(18, 4)), CAST(16.00 AS Decimal(18, 2)), CAST(166.00 AS Decimal(18, 2)), CAST(26.00 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (8, N'1002', N'TEST ITEM 2', N'PCS', CAST(12.0000 AS Decimal(18, 4)), CAST(145.00 AS Decimal(18, 2)), CAST(1500.00 AS Decimal(18, 2)), CAST(240.00 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (9, N'1001', N'TEST ITEM 1', N'PCSFGHG', CAST(12.0000 AS Decimal(18, 4)), CAST(16.00 AS Decimal(18, 2)), CAST(166.00 AS Decimal(18, 2)), CAST(26.00 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (9, N'1002', N'TEST ITEM 2', N'PCS', CAST(12.0000 AS Decimal(18, 4)), CAST(145.00 AS Decimal(18, 2)), CAST(1500.00 AS Decimal(18, 2)), CAST(240.00 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (10, N'1002', N'TEST ITEM 2', N'PCS', CAST(12.0000 AS Decimal(18, 4)), CAST(145.00 AS Decimal(18, 2)), CAST(1500.00 AS Decimal(18, 2)), CAST(240.00 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (10, N'1001', N'TEST ITEM 1', N'PCSFGHG', CAST(12.0000 AS Decimal(18, 4)), CAST(16.00 AS Decimal(18, 2)), CAST(166.00 AS Decimal(18, 2)), CAST(26.00 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (11, N'1001', N'TEST ITEM 1', N'PCSFGHG', CAST(16.0000 AS Decimal(18, 4)), CAST(16.00 AS Decimal(18, 2)), CAST(221.00 AS Decimal(18, 2)), CAST(35.00 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (11, N'1002', N'TEST ITEM 2', N'PCS', CAST(25.0000 AS Decimal(18, 4)), CAST(145.00 AS Decimal(18, 2)), CAST(3125.00 AS Decimal(18, 2)), CAST(500.00 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (12, N'1002', N'TEST ITEM 2', N'PCS', CAST(14.0000 AS Decimal(18, 4)), CAST(145.00 AS Decimal(18, 2)), CAST(1750.00 AS Decimal(18, 2)), CAST(280.00 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (12, N'1001', N'TEST ITEM 1', N'PCSFGHG', CAST(14.0000 AS Decimal(18, 4)), CAST(16.00 AS Decimal(18, 2)), CAST(193.00 AS Decimal(18, 2)), CAST(31.00 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (13, N'1001', N'TEST ITEM 1', N'PCSFGHG', CAST(12.0000 AS Decimal(18, 4)), CAST(16.00 AS Decimal(18, 2)), CAST(165.52 AS Decimal(18, 2)), CAST(26.48 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (13, N'1002', N'TEST ITEM 2', N'PCS', CAST(11.0000 AS Decimal(18, 4)), CAST(145.00 AS Decimal(18, 2)), CAST(1375.00 AS Decimal(18, 2)), CAST(220.00 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (13, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(14.0000 AS Decimal(18, 4)), CAST(120.00 AS Decimal(18, 2)), CAST(1448.28 AS Decimal(18, 2)), CAST(231.72 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (14, N'1001', N'TEST ITEM 1', N'PCSFGHG', CAST(14.0000 AS Decimal(18, 4)), CAST(16.00 AS Decimal(18, 2)), CAST(193.10 AS Decimal(18, 2)), CAST(30.90 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (14, N'1002', N'TEST ITEM 2', N'PCS', CAST(12.0000 AS Decimal(18, 4)), CAST(145.00 AS Decimal(18, 2)), CAST(1500.00 AS Decimal(18, 2)), CAST(240.00 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (14, N'1004', N'TESHDHHH', N'PCS', CAST(10.0000 AS Decimal(18, 4)), CAST(10.00 AS Decimal(18, 2)), CAST(86.21 AS Decimal(18, 2)), CAST(13.79 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (14, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(16.0000 AS Decimal(18, 4)), CAST(120.00 AS Decimal(18, 2)), CAST(1655.17 AS Decimal(18, 2)), CAST(264.83 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (14, N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', CAST(14.0000 AS Decimal(18, 4)), CAST(53.00 AS Decimal(18, 2)), CAST(639.66 AS Decimal(18, 2)), CAST(102.34 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (15, N'1001', N'TEST ITEM 1', N'PCSFGHG', CAST(12.0000 AS Decimal(18, 4)), CAST(16.00 AS Decimal(18, 2)), CAST(165.52 AS Decimal(18, 2)), CAST(26.48 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (16, N'1001', N'TEST ITEM 1', N'PCSFGHG', CAST(12.0000 AS Decimal(18, 4)), CAST(16.00 AS Decimal(18, 2)), CAST(165.52 AS Decimal(18, 2)), CAST(26.48 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (16, N'1002', N'TEST ITEM 2', N'PCS', CAST(14.0000 AS Decimal(18, 4)), CAST(145.00 AS Decimal(18, 2)), CAST(1750.00 AS Decimal(18, 2)), CAST(280.00 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (16, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(40.0000 AS Decimal(18, 4)), CAST(120.00 AS Decimal(18, 2)), CAST(4137.93 AS Decimal(18, 2)), CAST(662.07 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (16, N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', CAST(12.0000 AS Decimal(18, 4)), CAST(53.00 AS Decimal(18, 2)), CAST(548.28 AS Decimal(18, 2)), CAST(87.72 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (1016, N'1001', N'TEST ITEM 1', N'PCS', CAST(15.0000 AS Decimal(18, 4)), CAST(16.00 AS Decimal(18, 2)), CAST(206.90 AS Decimal(18, 2)), CAST(33.10 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (1016, N'1002', N'TEST ITEM 2', N'PCS', CAST(15.0000 AS Decimal(18, 4)), CAST(145.00 AS Decimal(18, 2)), CAST(1875.00 AS Decimal(18, 2)), CAST(300.00 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (1016, N'1004', N'TESHDHHH', N'PCS', CAST(14.0000 AS Decimal(18, 4)), CAST(10.00 AS Decimal(18, 2)), CAST(120.69 AS Decimal(18, 2)), CAST(19.31 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (1016, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(14.0000 AS Decimal(18, 4)), CAST(120.00 AS Decimal(18, 2)), CAST(1448.28 AS Decimal(18, 2)), CAST(231.72 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (1016, N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', CAST(10.0000 AS Decimal(18, 4)), CAST(53.00 AS Decimal(18, 2)), CAST(456.90 AS Decimal(18, 2)), CAST(73.10 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (1017, N'1002', N'TEST ITEM 2', N'PCS', CAST(12.0000 AS Decimal(18, 4)), CAST(145.00 AS Decimal(18, 2)), CAST(1500.00 AS Decimal(18, 2)), CAST(240.00 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (1017, N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', CAST(72.0000 AS Decimal(18, 4)), CAST(53.00 AS Decimal(18, 2)), CAST(3289.66 AS Decimal(18, 2)), CAST(526.34 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (1018, N'1002', N'TEST ITEM 2', N'PCS', CAST(16.0000 AS Decimal(18, 4)), CAST(145.00 AS Decimal(18, 2)), CAST(2000.00 AS Decimal(18, 2)), CAST(320.00 AS Decimal(18, 2)))
INSERT [dbo].[GrnDetails] ([GrnSrNo], [ProdCd], [ProdNm], [UnitCd], [Quantity], [CostPrice], [LineNetAmt], [LineVatAmt]) VALUES (1018, N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', CAST(12.0000 AS Decimal(18, 4)), CAST(53.00 AS Decimal(18, 2)), CAST(548.28 AS Decimal(18, 2)), CAST(87.72 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[GrnMaster] ON 

INSERT [dbo].[GrnMaster] ([SrNo], [SuppCd], [SuppNm], [InvoiceNumber], [UserName], [TotalAmount], [VatAmount], [GrnDate]) VALUES (6, N'TST', N'TEST SUPPLIER', N'2152454', N'TEST', CAST(1666.00 AS Decimal(18, 2)), CAST(266.00 AS Decimal(18, 2)), CAST(0x0000ACE40093E382 AS DateTime))
INSERT [dbo].[GrnMaster] ([SrNo], [SuppCd], [SuppNm], [InvoiceNumber], [UserName], [TotalAmount], [VatAmount], [GrnDate]) VALUES (7, N'TST', N'TEST SUPPLIER', N'TST INVOICE', N'TEST', CAST(1666.00 AS Decimal(18, 2)), CAST(266.00 AS Decimal(18, 2)), CAST(0x0000ACEA00C050FD AS DateTime))
INSERT [dbo].[GrnMaster] ([SrNo], [SuppCd], [SuppNm], [InvoiceNumber], [UserName], [TotalAmount], [VatAmount], [GrnDate]) VALUES (8, N'TST', N'TEST SUPPLIER', N'TST INVOICE', N'TEST', CAST(1666.00 AS Decimal(18, 2)), CAST(266.00 AS Decimal(18, 2)), CAST(0x0000ACEA00C83EAF AS DateTime))
INSERT [dbo].[GrnMaster] ([SrNo], [SuppCd], [SuppNm], [InvoiceNumber], [UserName], [TotalAmount], [VatAmount], [GrnDate]) VALUES (9, N'TST', N'TEST SUPPLIER', N'TST INVOICE', N'TEST', CAST(1666.00 AS Decimal(18, 2)), CAST(266.00 AS Decimal(18, 2)), CAST(0x0000ACEA00C8617E AS DateTime))
INSERT [dbo].[GrnMaster] ([SrNo], [SuppCd], [SuppNm], [InvoiceNumber], [UserName], [TotalAmount], [VatAmount], [GrnDate]) VALUES (10, N'TST', N'TEST SUPPLIER', N'HDB', N'TEST', CAST(1666.00 AS Decimal(18, 2)), CAST(266.00 AS Decimal(18, 2)), CAST(0x0000ACEA00C9485D AS DateTime))
INSERT [dbo].[GrnMaster] ([SrNo], [SuppCd], [SuppNm], [InvoiceNumber], [UserName], [TotalAmount], [VatAmount], [GrnDate]) VALUES (11, N'TST', N'TEST SUPPLIER', N'1245', N'TEST', CAST(3346.00 AS Decimal(18, 2)), CAST(535.00 AS Decimal(18, 2)), CAST(0x0000ACEA00DB572A AS DateTime))
INSERT [dbo].[GrnMaster] ([SrNo], [SuppCd], [SuppNm], [InvoiceNumber], [UserName], [TotalAmount], [VatAmount], [GrnDate]) VALUES (12, N'TST', N'TEST SUPPLIER', N'01124', N'TEST', CAST(1943.00 AS Decimal(18, 2)), CAST(311.00 AS Decimal(18, 2)), CAST(0x0000ACEA00DC01D3 AS DateTime))
INSERT [dbo].[GrnMaster] ([SrNo], [SuppCd], [SuppNm], [InvoiceNumber], [UserName], [TotalAmount], [VatAmount], [GrnDate]) VALUES (13, N'TST', N'TEST SUPPLIER', N'BOOKS', N'TEST', CAST(2988.80 AS Decimal(18, 2)), CAST(478.20 AS Decimal(18, 2)), CAST(0x0000ACEB0093488B AS DateTime))
INSERT [dbo].[GrnMaster] ([SrNo], [SuppCd], [SuppNm], [InvoiceNumber], [UserName], [TotalAmount], [VatAmount], [GrnDate]) VALUES (14, N'TST', N'TEST SUPPLIER', N'TEST', N'TEST', CAST(4074.14 AS Decimal(18, 2)), CAST(651.86 AS Decimal(18, 2)), CAST(0x0000ACEB00E5D29C AS DateTime))
INSERT [dbo].[GrnMaster] ([SrNo], [SuppCd], [SuppNm], [InvoiceNumber], [UserName], [TotalAmount], [VatAmount], [GrnDate]) VALUES (15, N'TST', N'TEST SUPPLIER', N'01234', N'TEST', CAST(165.52 AS Decimal(18, 2)), CAST(26.48 AS Decimal(18, 2)), CAST(0x0000ACEC0083118B AS DateTime))
INSERT [dbo].[GrnMaster] ([SrNo], [SuppCd], [SuppNm], [InvoiceNumber], [UserName], [TotalAmount], [VatAmount], [GrnDate]) VALUES (16, N'TST', N'TEST SUPPLIER', N'123', N'TEST', CAST(6601.73 AS Decimal(18, 2)), CAST(1056.27 AS Decimal(18, 2)), CAST(0x0000ACEC00936798 AS DateTime))
INSERT [dbo].[GrnMaster] ([SrNo], [SuppCd], [SuppNm], [InvoiceNumber], [UserName], [TotalAmount], [VatAmount], [GrnDate]) VALUES (1016, N'TEST', N'TEST SUPP', N'TEST', N'TEST', CAST(4107.77 AS Decimal(18, 2)), CAST(657.23 AS Decimal(18, 2)), CAST(0x0000ACEE00F1FA35 AS DateTime))
INSERT [dbo].[GrnMaster] ([SrNo], [SuppCd], [SuppNm], [InvoiceNumber], [UserName], [TotalAmount], [VatAmount], [GrnDate]) VALUES (1017, N'TEST', N'TEST SUPP', N'14522', N'TEST', CAST(4789.66 AS Decimal(18, 2)), CAST(766.34 AS Decimal(18, 2)), CAST(0x0000AD8D00C0B0BD AS DateTime))
INSERT [dbo].[GrnMaster] ([SrNo], [SuppCd], [SuppNm], [InvoiceNumber], [UserName], [TotalAmount], [VatAmount], [GrnDate]) VALUES (1018, N'TEST', N'TEST SUPP', N'test invoice', N'TEST', CAST(2548.28 AS Decimal(18, 2)), CAST(407.72 AS Decimal(18, 2)), CAST(0x0000AD8F01356812 AS DateTime))
SET IDENTITY_INSERT [dbo].[GrnMaster] OFF
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'BU', N'ADMIN', N'Y', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'CBM', N'ADMIN', N'Y', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'CM', N'ADMIN', N'Y', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'DM', N'ADMIN', N'Y', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'GI', N'ADMIN', N'Y', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'GM', N'ADMIN', N'Y', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'GR', N'ADMIN', N'Y', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'MI', N'ADMIN', N'Y', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'MR', N'ADMIN', N'Y', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'MU', N'ADMIN', N'Y', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'PC', N'ADMIN', N'Y', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'PM', N'ADMIN', N'Y', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'POS', N'ADMIN', N'Y', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'RM', N'ADMIN', N'Y', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'SC', N'ADMIN', N'Y', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'SM', N'ADMIN', N'Y', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'TM', N'ADMIN', N'Y', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'UM', N'ADMIN', N'Y', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'VG', N'ADMIN', N'Y', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'VI', N'ADMIN', N'Y', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'VM', N'ADMIN', N'Y', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'BU', N'labels', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'CBM', N'labels', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'CM', N'labels', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'DM', N'labels', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'GI', N'labels', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'GM', N'labels', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'GR', N'labels', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'MI', N'labels', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'MR', N'labels', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'MU', N'labels', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'PC', N'labels', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'PM', N'labels', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'POS', N'labels', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'RM', N'labels', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'SC', N'labels', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'SM', N'labels', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'TM', N'labels', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'UM', N'labels', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'VG', N'labels', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'VI', N'labels', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'VM', N'labels', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'BU', N'BO', N'Y', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'CBM', N'BO', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'CM', N'BO', N'Y', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'DM', N'BO', N'Y', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'GI', N'BO', N'Y', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'GM', N'BO', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'GR', N'BO', N'Y', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'MI', N'BO', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'MR', N'BO', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'MU', N'BO', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'PC', N'BO', N'Y', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'PM', N'BO', N'Y', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'POS', N'BO', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'RM', N'BO', N'Y', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'SC', N'BO', N'Y', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'SM', N'BO', N'Y', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'TM', N'BO', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'UM', N'BO', N'Y', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'VG', N'BO', N'Y', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'VI', N'BO', N'Y', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'VM', N'BO', N'Y', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'BU', N'STOCKS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'CBM', N'STOCKS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'CM', N'STOCKS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'DM', N'STOCKS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'GI', N'STOCKS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'GM', N'STOCKS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'GR', N'STOCKS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'MI', N'STOCKS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'MR', N'STOCKS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'MU', N'STOCKS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'PC', N'STOCKS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'PM', N'STOCKS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'POS', N'STOCKS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'RM', N'STOCKS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'SC', N'STOCKS', N'Y', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'SM', N'STOCKS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'TM', N'STOCKS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'UM', N'STOCKS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'VG', N'STOCKS', N'Y', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'VI', N'STOCKS', N'Y', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'VM', N'STOCKS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'BU', N'MANAGERS', N'Y', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'CBM', N'MANAGERS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'CM', N'MANAGERS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'DM', N'MANAGERS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'GI', N'MANAGERS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'GM', N'MANAGERS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'GR', N'MANAGERS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'MI', N'MANAGERS', N'Y', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'MR', N'MANAGERS', N'Y', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'MU', N'MANAGERS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'PC', N'MANAGERS', N'Y', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'PM', N'MANAGERS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'POS', N'MANAGERS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'RM', N'MANAGERS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'SC', N'MANAGERS', N'Y', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'SM', N'MANAGERS', N'Y', N'TEST')
GO
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'TM', N'MANAGERS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'UM', N'MANAGERS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'VG', N'MANAGERS', N'Y', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'VI', N'MANAGERS', N'Y', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'VM', N'MANAGERS', N'N', N'TEST')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'BU', N'FO', N'N', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'CBM', N'FO', N'N', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'CM', N'FO', N'N', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'DM', N'FO', N'N', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'GI', N'FO', N'N', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'GM', N'FO', N'N', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'GR', N'FO', N'N', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'MI', N'FO', N'N', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'MR', N'FO', N'N', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'MU', N'FO', N'N', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'PC', N'FO', N'N', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'PM', N'FO', N'N', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'POS', N'FO', N'Y', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'RM', N'FO', N'N', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'SC', N'FO', N'N', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'SM', N'FO', N'N', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'TM', N'FO', N'N', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'UM', N'FO', N'N', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'VG', N'FO', N'N', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'VI', N'FO', N'N', N'ADMIN')
INSERT [dbo].[GROUPPOLICY] ([MODULECODE], [GROUPCODE], [POLICY], [CREATEDBY]) VALUES (N'VM', N'FO', N'N', N'ADMIN')
INSERT [dbo].[INVOICEDETAILS] ([InvoiceSerialNumber], [ProdCd], [ProdNm], [Unitcd], [QUANTITY], [CP], [LINEVATAMT], [LINENETAMOUNT], [DISCOUNTAMOUNT]) VALUES (4, N'1001', N'TEST ITEM 1', N'PCS', CAST(12.0000 AS Decimal(18, 4)), CAST(54.00 AS Decimal(18, 2)), CAST(89.38 AS Decimal(18, 2)), CAST(558.62 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[INVOICEDETAILS] ([InvoiceSerialNumber], [ProdCd], [ProdNm], [Unitcd], [QUANTITY], [CP], [LINEVATAMT], [LINENETAMOUNT], [DISCOUNTAMOUNT]) VALUES (4, N'1002', N'TEST ITEM 2', N'PCS', CAST(14.0000 AS Decimal(18, 4)), CAST(235.00 AS Decimal(18, 2)), CAST(453.79 AS Decimal(18, 2)), CAST(2836.21 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[INVOICEDETAILS] ([InvoiceSerialNumber], [ProdCd], [ProdNm], [Unitcd], [QUANTITY], [CP], [LINEVATAMT], [LINENETAMOUNT], [DISCOUNTAMOUNT]) VALUES (5, N'1004', N'TESHDHHH', N'PCS', CAST(12.0000 AS Decimal(18, 4)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[INVOICEDETAILS] ([InvoiceSerialNumber], [ProdCd], [ProdNm], [Unitcd], [QUANTITY], [CP], [LINEVATAMT], [LINENETAMOUNT], [DISCOUNTAMOUNT]) VALUES (5, N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', CAST(17.0000 AS Decimal(18, 4)), CAST(60.00 AS Decimal(18, 2)), CAST(140.69 AS Decimal(18, 2)), CAST(879.31 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[INVOICEDETAILS] ([InvoiceSerialNumber], [ProdCd], [ProdNm], [Unitcd], [QUANTITY], [CP], [LINEVATAMT], [LINENETAMOUNT], [DISCOUNTAMOUNT]) VALUES (1004, N'1002', N'TEST ITEM 2', N'PCS', CAST(14.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(386.21 AS Decimal(18, 2)), CAST(2413.79 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[INVOICEDETAILS] ([InvoiceSerialNumber], [ProdCd], [ProdNm], [Unitcd], [QUANTITY], [CP], [LINEVATAMT], [LINENETAMOUNT], [DISCOUNTAMOUNT]) VALUES (1005, N'1001', N'TEST ITEM 1', N'PCS', CAST(12.0000 AS Decimal(18, 4)), CAST(54.00 AS Decimal(18, 2)), CAST(89.38 AS Decimal(18, 2)), CAST(558.62 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[INVOICEDETAILS] ([InvoiceSerialNumber], [ProdCd], [ProdNm], [Unitcd], [QUANTITY], [CP], [LINEVATAMT], [LINENETAMOUNT], [DISCOUNTAMOUNT]) VALUES (1005, N'1002', N'TEST ITEM 2', N'PCS', CAST(15.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(413.79 AS Decimal(18, 2)), CAST(2586.21 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[INVOICEDETAILS] ([InvoiceSerialNumber], [ProdCd], [ProdNm], [Unitcd], [QUANTITY], [CP], [LINEVATAMT], [LINENETAMOUNT], [DISCOUNTAMOUNT]) VALUES (1005, N'1004', N'TESHDHHH', N'PCS', CAST(12.0000 AS Decimal(18, 4)), CAST(150.00 AS Decimal(18, 2)), CAST(248.28 AS Decimal(18, 2)), CAST(1551.72 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[INVOICEDETAILS] ([InvoiceSerialNumber], [ProdCd], [ProdNm], [Unitcd], [QUANTITY], [CP], [LINEVATAMT], [LINENETAMOUNT], [DISCOUNTAMOUNT]) VALUES (1005, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(60.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(12016.55 AS Decimal(18, 2)), CAST(75103.45 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[INVOICEDETAILS] ([InvoiceSerialNumber], [ProdCd], [ProdNm], [Unitcd], [QUANTITY], [CP], [LINEVATAMT], [LINENETAMOUNT], [DISCOUNTAMOUNT]) VALUES (1005, N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', CAST(12.0000 AS Decimal(18, 4)), CAST(60.00 AS Decimal(18, 2)), CAST(99.31 AS Decimal(18, 2)), CAST(620.69 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[INVOICEDETAILS] ([InvoiceSerialNumber], [ProdCd], [ProdNm], [Unitcd], [QUANTITY], [CP], [LINEVATAMT], [LINENETAMOUNT], [DISCOUNTAMOUNT]) VALUES (1005, N'10500002', N'ARIMIS MILKING JELLY 72*100G', N'PCS', CAST(14.0000 AS Decimal(18, 4)), CAST(170.00 AS Decimal(18, 2)), CAST(328.28 AS Decimal(18, 2)), CAST(2051.72 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[InvoiceMaster] ON 

INSERT [dbo].[InvoiceMaster] ([SRNO], [CUSTCD], [CUSTNM], [DATERECEIVED], [VATAMOUNT], [NETAMOUNT], [DATEDUE], [ISPAID], [COMMENT], [PAYMENTMODE], [USRNM]) VALUES (4, N'TCT', N'NEW CUSTOMER', CAST(0x0000AD8F00992584 AS DateTime), CAST(543.17 AS Decimal(18, 2)), CAST(3394.83 AS Decimal(18, 2)), CAST(0xEF420B00 AS Date), 0, N'pay by jan 17', NULL, N'TEST')
INSERT [dbo].[InvoiceMaster] ([SRNO], [CUSTCD], [CUSTNM], [DATERECEIVED], [VATAMOUNT], [NETAMOUNT], [DATEDUE], [ISPAID], [COMMENT], [PAYMENTMODE], [USRNM]) VALUES (5, N'CUST1', N'TEST CUSTOMER ', CAST(0x0000AD8F00A6C12E AS DateTime), CAST(140.69 AS Decimal(18, 2)), CAST(879.31 AS Decimal(18, 2)), CAST(0x08430B00 AS Date), 0, N'THED ', NULL, N'TEST')
INSERT [dbo].[InvoiceMaster] ([SRNO], [CUSTCD], [CUSTNM], [DATERECEIVED], [VATAMOUNT], [NETAMOUNT], [DATEDUE], [ISPAID], [COMMENT], [PAYMENTMODE], [USRNM]) VALUES (1004, N'TCT', N'NEW CUSTOMER', CAST(0x0000AD940119F5E7 AS DateTime), CAST(386.21 AS Decimal(18, 2)), CAST(2413.79 AS Decimal(18, 2)), CAST(0xF4420B00 AS Date), 0, N'', NULL, N'TEST')
INSERT [dbo].[InvoiceMaster] ([SRNO], [CUSTCD], [CUSTNM], [DATERECEIVED], [VATAMOUNT], [NETAMOUNT], [DATEDUE], [ISPAID], [COMMENT], [PAYMENTMODE], [USRNM]) VALUES (1005, N'TCT', N'NEW CUSTOMER', CAST(0x0000AD9F00A83E61 AS DateTime), CAST(13195.59 AS Decimal(18, 2)), CAST(82472.41 AS Decimal(18, 2)), CAST(0xFF420B00 AS Date), 0, N'', NULL, N'ADMIN')
SET IDENTITY_INSERT [dbo].[InvoiceMaster] OFF
INSERT [dbo].[ISSUEDETAILS] ([ISSUESRNO], [PRODCD], [PRODNM], [UNITCD], [QUANTITY], [CP], [SP], [LINEVATAMOUNT], [LINENETAMOUNT]) VALUES (1, N'1002', N'TEST ITEM 2', N'PCS', CAST(15.0000 AS Decimal(18, 4)), CAST(145.00 AS Decimal(18, 2)), CAST(235.00 AS Decimal(18, 2)), CAST(300.00 AS Decimal(18, 2)), CAST(1875.00 AS Decimal(18, 2)))
INSERT [dbo].[ISSUEDETAILS] ([ISSUESRNO], [PRODCD], [PRODNM], [UNITCD], [QUANTITY], [CP], [SP], [LINEVATAMOUNT], [LINENETAMOUNT]) VALUES (1, N'1004', N'TESHDHHH', N'PCS', CAST(12.0000 AS Decimal(18, 4)), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(16.55 AS Decimal(18, 2)), CAST(103.45 AS Decimal(18, 2)))
INSERT [dbo].[ISSUEDETAILS] ([ISSUESRNO], [PRODCD], [PRODNM], [UNITCD], [QUANTITY], [CP], [SP], [LINEVATAMOUNT], [LINENETAMOUNT]) VALUES (2, N'1002', N'TEST ITEM 2', N'PCS', CAST(14.0000 AS Decimal(18, 4)), CAST(145.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), CAST(280.00 AS Decimal(18, 2)), CAST(1750.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[ISSUEMASTER] ON 

INSERT [dbo].[ISSUEMASTER] ([SRNO], [DATEISSUED], [USERNAME], [NETAMOUNT], [VATAMOUNT], [REASON]) VALUES (1, CAST(0x0000AD8D009D4DDA AS DateTime), N'TEST', CAST(1978.45 AS Decimal(18, 2)), CAST(316.55 AS Decimal(18, 2)), N'ADJUST')
INSERT [dbo].[ISSUEMASTER] ([SRNO], [DATEISSUED], [USERNAME], [NETAMOUNT], [VATAMOUNT], [REASON]) VALUES (2, CAST(0x0000ADA2010235BE AS DateTime), N'TEST', CAST(1750.00 AS Decimal(18, 2)), CAST(280.00 AS Decimal(18, 2)), N'01')
SET IDENTITY_INSERT [dbo].[ISSUEMASTER] OFF
INSERT [dbo].[MODULEMASTER] ([MODULECODE], [MODULEDESCRIPTION]) VALUES (N'BU', N'BACK UP MODULE')
INSERT [dbo].[MODULEMASTER] ([MODULECODE], [MODULEDESCRIPTION]) VALUES (N'CBM', N'COMPANYBRANCH MASTER')
INSERT [dbo].[MODULEMASTER] ([MODULECODE], [MODULEDESCRIPTION]) VALUES (N'CM', N'CUSTOMER MASTER')
INSERT [dbo].[MODULEMASTER] ([MODULECODE], [MODULEDESCRIPTION]) VALUES (N'DM', N'DEPARTMENT MASTER')
INSERT [dbo].[MODULEMASTER] ([MODULECODE], [MODULEDESCRIPTION]) VALUES (N'GI', N'GENERATE INVOICE')
INSERT [dbo].[MODULEMASTER] ([MODULECODE], [MODULEDESCRIPTION]) VALUES (N'GM', N'GROUP MASTER')
INSERT [dbo].[MODULEMASTER] ([MODULECODE], [MODULEDESCRIPTION]) VALUES (N'GR', N'GOOD RECIEVE')
INSERT [dbo].[MODULEMASTER] ([MODULECODE], [MODULEDESCRIPTION]) VALUES (N'MI', N'MISCELLENOUS ISSUE')
INSERT [dbo].[MODULEMASTER] ([MODULECODE], [MODULEDESCRIPTION]) VALUES (N'MR', N'MISCELLENOUS RECEIPT')
INSERT [dbo].[MODULEMASTER] ([MODULECODE], [MODULEDESCRIPTION]) VALUES (N'MU', N'MANAGE USERS')
INSERT [dbo].[MODULEMASTER] ([MODULECODE], [MODULEDESCRIPTION]) VALUES (N'PC', N'PRICE CHANGE')
INSERT [dbo].[MODULEMASTER] ([MODULECODE], [MODULEDESCRIPTION]) VALUES (N'PM', N'PRODUCT MASTER')
INSERT [dbo].[MODULEMASTER] ([MODULECODE], [MODULEDESCRIPTION]) VALUES (N'POS', N'POINT OF SALE')
INSERT [dbo].[MODULEMASTER] ([MODULECODE], [MODULEDESCRIPTION]) VALUES (N'RM', N'REASON MASTER')
INSERT [dbo].[MODULEMASTER] ([MODULECODE], [MODULEDESCRIPTION]) VALUES (N'SC', N'STOCK CARD')
INSERT [dbo].[MODULEMASTER] ([MODULECODE], [MODULEDESCRIPTION]) VALUES (N'SM', N'SUPPLIER MASTER')
INSERT [dbo].[MODULEMASTER] ([MODULECODE], [MODULEDESCRIPTION]) VALUES (N'TM', N'TILL MANAGEMENT')
INSERT [dbo].[MODULEMASTER] ([MODULECODE], [MODULEDESCRIPTION]) VALUES (N'UM', N'UNIT MASTER')
INSERT [dbo].[MODULEMASTER] ([MODULECODE], [MODULEDESCRIPTION]) VALUES (N'VG', N'VIEW GRN')
INSERT [dbo].[MODULEMASTER] ([MODULECODE], [MODULEDESCRIPTION]) VALUES (N'VI', N'VIEW INVOICES')
INSERT [dbo].[MODULEMASTER] ([MODULECODE], [MODULEDESCRIPTION]) VALUES (N'VM', N'VAT MASTER')
INSERT [dbo].[TBLBRNCH] ([BRNCHCD], [BRNCHNM], [CMPNYCD], [BRNCHLOCATION], [BRNCHTELEPHONE], [BRNCHIP], [BRNCHINSTANCE], [BRNCHPWD], [ISCHILD], [ISPARENT], [CREATEDBY], [CREATEDON], [UPLOADFLG]) VALUES (N'01', N'THUITAS NAROK', N'TN001', N'NAROK', N'0702157779', N'192.168.8.104', N'WSERVER', NULL, 0, 1, N'ADMIN', CAST(0x0000ACB5009E5D0F AS DateTime), N'Y         ')
INSERT [dbo].[TBLCMPNY] ([CMPNYCD], [CMPNYNM], [CMPNYADDR], [CMPNYTEL], [CMPNYTAXPIN], [CMPNYREGNO], [CREATEDBY], [CREATEDON], [UPLOADFLG]) VALUES (N'TN001', N'THUITAS CYBER CAFE', N'144', N'0702157779', N'A000212', N'BGA01254', N'ADMIN', CAST(0x0000ACB5009E1A10 AS DateTime), N'Y')
INSERT [dbo].[TBLCPHIST] ([PROD_CD], [INT_CP], [NW_CP], [USR_NM], [CHG_DT], [BRCH_CD], [CMPY_CD]) VALUES (N'1021', CAST(545.00 AS Decimal(18, 2)), CAST(12.00 AS Decimal(18, 2)), N'ADMIN', CAST(0x0000ACA901491711 AS DateTime), N'NRK', N'TT')
INSERT [dbo].[TBLCPHIST] ([PROD_CD], [INT_CP], [NW_CP], [USR_NM], [CHG_DT], [BRCH_CD], [CMPY_CD]) VALUES (N'1001', CAST(0.00 AS Decimal(18, 2)), CAST(12.00 AS Decimal(18, 2)), N'ADMIN', CAST(0x0000ACA9014BA3E1 AS DateTime), N'NRK', N'TT')
INSERT [dbo].[TBLCPHIST] ([PROD_CD], [INT_CP], [NW_CP], [USR_NM], [CHG_DT], [BRCH_CD], [CMPY_CD]) VALUES (N'1001', CAST(12.00 AS Decimal(18, 2)), CAST(13.00 AS Decimal(18, 2)), N'ADMIN', CAST(0x0000ACA9014C330F AS DateTime), N'NRK', N'TT')
INSERT [dbo].[TBLCPHIST] ([PROD_CD], [INT_CP], [NW_CP], [USR_NM], [CHG_DT], [BRCH_CD], [CMPY_CD]) VALUES (N'1001', CAST(13.00 AS Decimal(18, 2)), CAST(12.00 AS Decimal(18, 2)), N'ADMIN', CAST(0x0000ACA9014CB5BA AS DateTime), N'NRK', N'TT')
INSERT [dbo].[TBLCPHIST] ([PROD_CD], [INT_CP], [NW_CP], [USR_NM], [CHG_DT], [BRCH_CD], [CMPY_CD]) VALUES (N'1001', CAST(12.00 AS Decimal(18, 2)), CAST(145.00 AS Decimal(18, 2)), N'ADMIN', CAST(0x0000ACA9014D41A9 AS DateTime), N'NRK', N'TT')
INSERT [dbo].[TBLCPHIST] ([PROD_CD], [INT_CP], [NW_CP], [USR_NM], [CHG_DT], [BRCH_CD], [CMPY_CD]) VALUES (N'1001', CAST(145.00 AS Decimal(18, 2)), CAST(12.00 AS Decimal(18, 2)), N'ADMIN', CAST(0x0000ACA9014E0605 AS DateTime), N'NRK', N'TT')
INSERT [dbo].[TBLCPHIST] ([PROD_CD], [INT_CP], [NW_CP], [USR_NM], [CHG_DT], [BRCH_CD], [CMPY_CD]) VALUES (N'1001', CAST(12.00 AS Decimal(18, 2)), CAST(12.53 AS Decimal(18, 2)), N'ADMIN', CAST(0x0000ACA9014F5CB9 AS DateTime), N'NRK', N'TT')
INSERT [dbo].[TBLCPHIST] ([PROD_CD], [INT_CP], [NW_CP], [USR_NM], [CHG_DT], [BRCH_CD], [CMPY_CD]) VALUES (N'1001', CAST(13.00 AS Decimal(18, 2)), CAST(14.52 AS Decimal(18, 2)), N'ADMIN', CAST(0x0000ACA901501C60 AS DateTime), N'NRK', N'TT')
INSERT [dbo].[TBLCPHIST] ([PROD_CD], [INT_CP], [NW_CP], [USR_NM], [CHG_DT], [BRCH_CD], [CMPY_CD]) VALUES (N'1001', CAST(14.52 AS Decimal(18, 2)), CAST(16.00 AS Decimal(18, 2)), N'ADMIN', CAST(0x0000ACB501277DD0 AS DateTime), N'NRK', N'TT')
INSERT [dbo].[TBLCPHIST] ([PROD_CD], [INT_CP], [NW_CP], [USR_NM], [CHG_DT], [BRCH_CD], [CMPY_CD]) VALUES (N'10500001', CAST(14.23 AS Decimal(18, 2)), CAST(53.00 AS Decimal(18, 2)), N'ADMIN', CAST(0x0000ACDD011A66A6 AS DateTime), N'NRK', N'TT')
INSERT [dbo].[TBLCPHIST] ([PROD_CD], [INT_CP], [NW_CP], [USR_NM], [CHG_DT], [BRCH_CD], [CMPY_CD]) VALUES (N'1004', CAST(0.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), N'ADMIN', CAST(0x0000ACDE00A69FB0 AS DateTime), N'NRK', N'TT')
INSERT [dbo].[TBLCPHIST] ([PROD_CD], [INT_CP], [NW_CP], [USR_NM], [CHG_DT], [BRCH_CD], [CMPY_CD]) VALUES (N'1002', CAST(0.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), N'ADMIN', CAST(0x0000ACE201429888 AS DateTime), N'NRK', N'TT')
INSERT [dbo].[TBLCPHIST] ([PROD_CD], [INT_CP], [NW_CP], [USR_NM], [CHG_DT], [BRCH_CD], [CMPY_CD]) VALUES (N'1002', CAST(150.00 AS Decimal(18, 2)), CAST(1502.00 AS Decimal(18, 2)), N'ADMIN', CAST(0x0000ACE300B0AA45 AS DateTime), N'NRK', N'TT')
INSERT [dbo].[TBLCPHIST] ([PROD_CD], [INT_CP], [NW_CP], [USR_NM], [CHG_DT], [BRCH_CD], [CMPY_CD]) VALUES (N'1002', CAST(1502.00 AS Decimal(18, 2)), CAST(145.00 AS Decimal(18, 2)), N'TEST', CAST(0x0000ACE300B39C83 AS DateTime), N'NRK', N'TT')
INSERT [dbo].[TBLCPHIST] ([PROD_CD], [INT_CP], [NW_CP], [USR_NM], [CHG_DT], [BRCH_CD], [CMPY_CD]) VALUES (N'1001', CAST(16.00 AS Decimal(18, 2)), CAST(17.00 AS Decimal(18, 2)), N'TEST', CAST(0x0000AD8D00946B66 AS DateTime), N'NRK', N'TT')
INSERT [dbo].[TblCust] ([CUSTCD], [CUSTNM], [CUSTBOX], [CUSTCITY], [CUSTLOCATION], [CUSTTELEPHONE], [CUSTPIN], [CUSTEMAIL], [CUSTFAX], [CUSTCREDITLIMIT], [CUSTMOBILE], [CUSTVAT], [CUSTLIMITDAYS], [CUSTPAYMENTMODE], [ISACTIVE], [CREATEDBY], [CREATEDON]) VALUES (N'CUST1', N'TEST CUSTOMER ', N'140', N'NAROK', N'NAROK', N'0702157779', N'A001241221S', N'TECGS', N'1454', CAST(4521.00 AS Decimal(18, 2)), N'054545', N'212145', 30, N'CHEQUE', 1, N'TEST', CAST(0x0000AD8F00A68293 AS DateTime))
INSERT [dbo].[TblCust] ([CUSTCD], [CUSTNM], [CUSTBOX], [CUSTCITY], [CUSTLOCATION], [CUSTTELEPHONE], [CUSTPIN], [CUSTEMAIL], [CUSTFAX], [CUSTCREDITLIMIT], [CUSTMOBILE], [CUSTVAT], [CUSTLIMITDAYS], [CUSTPAYMENTMODE], [ISACTIVE], [CREATEDBY], [CREATEDON]) VALUES (N'TCT', N'NEW CUSTOMER', N'140', N'MOLO', N'MOLO', N'0702157779', N'A0012S111', N'GSJJDK', N'145505', CAST(145.00 AS Decimal(18, 2)), N'102455', N'SHHD', 5, N'CHEQUE', 1, N'TEST', CAST(0x0000AD82009277D4 AS DateTime))
INSERT [dbo].[tblDept] ([DeptCd], [DeptNm], [Createdby], [CreatedOn]) VALUES (N'DEPT1', N'DEPARTMENT tested', N'Test', CAST(0x0000AC8E0078B747 AS DateTime))
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (8, N'1002', N'TEST ITEM 2', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(172.4 AS Decimal(18, 1)), CAST(200.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (8, N'1004', N'TESHDHHH', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(150.00 AS Decimal(18, 2)), CAST(129.3 AS Decimal(18, 1)), CAST(150.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (9, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(1452.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (10, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(1452.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (11, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(1452.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (12, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(0.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (13, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(0.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (13, N'1004', N'TESHDHHH', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(150.00 AS Decimal(18, 2)), CAST(20.7 AS Decimal(18, 1)), CAST(150.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (13, N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', CAST(12.0000 AS Decimal(18, 4)), CAST(60.00 AS Decimal(18, 2)), CAST(99.3 AS Decimal(18, 1)), CAST(720.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (1002, N'1004', N'TESHDHHH', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(150.00 AS Decimal(18, 2)), CAST(20.7 AS Decimal(18, 1)), CAST(150.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (1002, N'1002', N'TEST ITEM 2', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(27.6 AS Decimal(18, 1)), CAST(200.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (1003, N'1004', N'TESHDHHH', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(150.00 AS Decimal(18, 2)), CAST(20.7 AS Decimal(18, 1)), CAST(150.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (1004, N'1002', N'TEST ITEM 2', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(27.6 AS Decimal(18, 1)), CAST(200.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (1005, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(0.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (1006, N'1001', N'TEST ITEM 1', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(54.00 AS Decimal(18, 2)), CAST(7.5 AS Decimal(18, 1)), CAST(54.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (1007, N'1002', N'TEST ITEM 2', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(27.6 AS Decimal(18, 1)), CAST(200.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (1008, N'1002', N'TEST ITEM 2', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(27.6 AS Decimal(18, 1)), CAST(200.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (1008, N'1004', N'TESHDHHH', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(150.00 AS Decimal(18, 2)), CAST(20.7 AS Decimal(18, 1)), CAST(150.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (1009, N'1002', N'TEST ITEM 2', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(27.6 AS Decimal(18, 1)), CAST(200.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (1009, N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', CAST(12.0000 AS Decimal(18, 4)), CAST(60.00 AS Decimal(18, 2)), CAST(99.3 AS Decimal(18, 1)), CAST(720.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (1010, N'1004', N'TESHDHHH', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(150.00 AS Decimal(18, 2)), CAST(20.7 AS Decimal(18, 1)), CAST(150.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (1010, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(0.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (1011, N'1004', N'TESHDHHH', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(150.00 AS Decimal(18, 2)), CAST(20.7 AS Decimal(18, 1)), CAST(150.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (1012, N'1004', N'TESHDHHH', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(150.00 AS Decimal(18, 2)), CAST(20.7 AS Decimal(18, 1)), CAST(150.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2011, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(0.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2012, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(0.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2013, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(0.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2014, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(0.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2015, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(0.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2016, N'1001', N'TEST ITEM 1', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(54.00 AS Decimal(18, 2)), CAST(7.5 AS Decimal(18, 1)), CAST(54.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2016, N'1002', N'TEST ITEM 2', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(27.6 AS Decimal(18, 1)), CAST(200.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2016, N'1004', N'TESHDHHH', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(150.00 AS Decimal(18, 2)), CAST(20.7 AS Decimal(18, 1)), CAST(150.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2016, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(0.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2016, N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(60.00 AS Decimal(18, 2)), CAST(8.3 AS Decimal(18, 1)), CAST(60.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2016, N'10500002', N'ARIMIS MILKING JELLY 72*100G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(170.00 AS Decimal(18, 2)), CAST(23.5 AS Decimal(18, 1)), CAST(170.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2017, N'1001', N'TEST ITEM 1', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(54.00 AS Decimal(18, 2)), CAST(7.5 AS Decimal(18, 1)), CAST(54.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2017, N'1002', N'TEST ITEM 2', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(27.6 AS Decimal(18, 1)), CAST(200.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2017, N'1004', N'TESHDHHH', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(150.00 AS Decimal(18, 2)), CAST(20.7 AS Decimal(18, 1)), CAST(150.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2017, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(0.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2017, N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(60.00 AS Decimal(18, 2)), CAST(8.3 AS Decimal(18, 1)), CAST(60.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2017, N'10500002', N'ARIMIS MILKING JELLY 72*100G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(170.00 AS Decimal(18, 2)), CAST(23.5 AS Decimal(18, 1)), CAST(170.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2018, N'1001', N'TEST ITEM 1', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(54.00 AS Decimal(18, 2)), CAST(7.5 AS Decimal(18, 1)), CAST(54.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2019, N'1001', N'TEST ITEM 1', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(54.00 AS Decimal(18, 2)), CAST(7.5 AS Decimal(18, 1)), CAST(54.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2019, N'1002', N'TEST ITEM 2', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(27.6 AS Decimal(18, 1)), CAST(200.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2019, N'1004', N'TESHDHHH', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(150.00 AS Decimal(18, 2)), CAST(20.7 AS Decimal(18, 1)), CAST(150.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2019, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(0.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2019, N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(60.00 AS Decimal(18, 2)), CAST(8.3 AS Decimal(18, 1)), CAST(60.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2019, N'10500002', N'ARIMIS MILKING JELLY 72*100G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(170.00 AS Decimal(18, 2)), CAST(23.5 AS Decimal(18, 1)), CAST(170.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2020, N'1001', N'TEST ITEM 1', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(54.00 AS Decimal(18, 2)), CAST(7.5 AS Decimal(18, 1)), CAST(54.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2020, N'1002', N'TEST ITEM 2', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(27.6 AS Decimal(18, 1)), CAST(200.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2020, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(0.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2020, N'1004', N'TESHDHHH', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(150.00 AS Decimal(18, 2)), CAST(20.7 AS Decimal(18, 1)), CAST(150.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2020, N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', CAST(2.0000 AS Decimal(18, 4)), CAST(60.00 AS Decimal(18, 2)), CAST(16.6 AS Decimal(18, 1)), CAST(120.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2020, N'10500002', N'ARIMIS MILKING JELLY 72*100G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(170.00 AS Decimal(18, 2)), CAST(23.5 AS Decimal(18, 1)), CAST(170.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2021, N'1001', N'TEST ITEM 1', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(54.00 AS Decimal(18, 2)), CAST(7.5 AS Decimal(18, 1)), CAST(54.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2021, N'1002', N'TEST ITEM 2', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(27.6 AS Decimal(18, 1)), CAST(200.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2021, N'1004', N'TESHDHHH', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(150.00 AS Decimal(18, 2)), CAST(20.7 AS Decimal(18, 1)), CAST(150.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2021, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(0.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2021, N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(60.00 AS Decimal(18, 2)), CAST(8.3 AS Decimal(18, 1)), CAST(60.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2021, N'10500002', N'ARIMIS MILKING JELLY 72*100G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(170.00 AS Decimal(18, 2)), CAST(23.5 AS Decimal(18, 1)), CAST(170.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2022, N'1001', N'TEST ITEM 1', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(54.00 AS Decimal(18, 2)), CAST(7.5 AS Decimal(18, 1)), CAST(54.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2023, N'10500002', N'ARIMIS MILKING JELLY 72*100G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(170.00 AS Decimal(18, 2)), CAST(23.5 AS Decimal(18, 1)), CAST(170.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2024, N'10500002', N'ARIMIS MILKING JELLY 72*100G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(170.00 AS Decimal(18, 2)), CAST(23.5 AS Decimal(18, 1)), CAST(170.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2025, N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(60.00 AS Decimal(18, 2)), CAST(8.3 AS Decimal(18, 1)), CAST(60.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2026, N'10500002', N'ARIMIS MILKING JELLY 72*100G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(170.00 AS Decimal(18, 2)), CAST(23.5 AS Decimal(18, 1)), CAST(170.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2027, N'10500002', N'ARIMIS MILKING JELLY 72*100G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(170.00 AS Decimal(18, 2)), CAST(23.5 AS Decimal(18, 1)), CAST(170.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2028, N'10500002', N'ARIMIS MILKING JELLY 72*100G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(170.00 AS Decimal(18, 2)), CAST(23.5 AS Decimal(18, 1)), CAST(170.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2029, N'10500002', N'ARIMIS MILKING JELLY 72*100G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(170.00 AS Decimal(18, 2)), CAST(23.5 AS Decimal(18, 1)), CAST(170.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2030, N'10500002', N'ARIMIS MILKING JELLY 72*100G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(170.00 AS Decimal(18, 2)), CAST(23.5 AS Decimal(18, 1)), CAST(170.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2031, N'1001', N'TEST ITEM 1', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(54.00 AS Decimal(18, 2)), CAST(7.5 AS Decimal(18, 1)), CAST(54.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2031, N'1002', N'TEST ITEM 2', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(27.6 AS Decimal(18, 1)), CAST(200.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2031, N'1004', N'TESHDHHH', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(150.00 AS Decimal(18, 2)), CAST(20.7 AS Decimal(18, 1)), CAST(150.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2031, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(0.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2031, N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(60.00 AS Decimal(18, 2)), CAST(8.3 AS Decimal(18, 1)), CAST(60.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2031, N'10500002', N'ARIMIS MILKING JELLY 72*100G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(170.00 AS Decimal(18, 2)), CAST(23.5 AS Decimal(18, 1)), CAST(170.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2032, N'1001', N'TEST ITEM 1', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(54.00 AS Decimal(18, 2)), CAST(7.5 AS Decimal(18, 1)), CAST(54.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2032, N'1002', N'TEST ITEM 2', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(27.6 AS Decimal(18, 1)), CAST(200.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2032, N'1004', N'TESHDHHH', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(150.00 AS Decimal(18, 2)), CAST(20.7 AS Decimal(18, 1)), CAST(150.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2032, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(0.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2032, N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(60.00 AS Decimal(18, 2)), CAST(8.3 AS Decimal(18, 1)), CAST(60.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2032, N'10500002', N'ARIMIS MILKING JELLY 72*100G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(170.00 AS Decimal(18, 2)), CAST(23.5 AS Decimal(18, 1)), CAST(170.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2036, N'1001', N'TEST ITEM 1', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(54.00 AS Decimal(18, 2)), CAST(7.5 AS Decimal(18, 1)), CAST(54.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2036, N'1002', N'TEST ITEM 2', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(27.6 AS Decimal(18, 1)), CAST(200.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2036, N'1004', N'TESHDHHH', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(150.00 AS Decimal(18, 2)), CAST(20.7 AS Decimal(18, 1)), CAST(150.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2037, N'1001', N'TEST ITEM 1', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(54.00 AS Decimal(18, 2)), CAST(7.5 AS Decimal(18, 1)), CAST(54.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2038, N'1002', N'TEST ITEM 2', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(27.6 AS Decimal(18, 1)), CAST(200.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2039, N'1002', N'TEST ITEM 2', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(27.6 AS Decimal(18, 1)), CAST(200.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2040, N'1002', N'TEST ITEM 2', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(27.6 AS Decimal(18, 1)), CAST(200.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2041, N'1001', N'TEST ITEM 1', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(54.00 AS Decimal(18, 2)), CAST(7.5 AS Decimal(18, 1)), CAST(54.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2041, N'1002', N'TEST ITEM 2', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(27.6 AS Decimal(18, 1)), CAST(200.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2042, N'1002', N'TEST ITEM 2', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(27.6 AS Decimal(18, 1)), CAST(200.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2042, N'1004', N'TESHDHHH', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(150.00 AS Decimal(18, 2)), CAST(20.7 AS Decimal(18, 1)), CAST(150.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2042, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(0.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2043, N'1001', N'TEST ITEM 1', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(54.00 AS Decimal(18, 2)), CAST(7.5 AS Decimal(18, 1)), CAST(54.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2043, N'1002', N'TEST ITEM 2', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(27.6 AS Decimal(18, 1)), CAST(200.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2043, N'1004', N'TESHDHHH', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(150.00 AS Decimal(18, 2)), CAST(20.7 AS Decimal(18, 1)), CAST(150.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2043, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(0.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2043, N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', CAST(12.0000 AS Decimal(18, 4)), CAST(60.00 AS Decimal(18, 2)), CAST(99.3 AS Decimal(18, 1)), CAST(720.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2043, N'10500002', N'ARIMIS MILKING JELLY 72*100G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(170.00 AS Decimal(18, 2)), CAST(23.5 AS Decimal(18, 1)), CAST(170.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2044, N'10500002', N'ARIMIS MILKING JELLY 72*100G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(170.00 AS Decimal(18, 2)), CAST(23.5 AS Decimal(18, 1)), CAST(170.00 AS Decimal(18, 2)), N'A')
GO
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2045, N'10500002', N'ARIMIS MILKING JELLY 72*100G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(170.00 AS Decimal(18, 2)), CAST(23.5 AS Decimal(18, 1)), CAST(170.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2046, N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', CAST(12.0000 AS Decimal(18, 4)), CAST(60.00 AS Decimal(18, 2)), CAST(99.3 AS Decimal(18, 1)), CAST(720.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2047, N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', CAST(12.0000 AS Decimal(18, 4)), CAST(60.00 AS Decimal(18, 2)), CAST(99.3 AS Decimal(18, 1)), CAST(720.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2048, N'1001', N'TEST ITEM 1', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(54.00 AS Decimal(18, 2)), CAST(7.5 AS Decimal(18, 1)), CAST(54.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2048, N'1002', N'TEST ITEM 2', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(27.6 AS Decimal(18, 1)), CAST(200.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2048, N'1004', N'TESHDHHH', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(150.00 AS Decimal(18, 2)), CAST(20.7 AS Decimal(18, 1)), CAST(150.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2048, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(0.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2048, N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(60.00 AS Decimal(18, 2)), CAST(8.3 AS Decimal(18, 1)), CAST(60.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2048, N'10500002', N'ARIMIS MILKING JELLY 72*100G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(170.00 AS Decimal(18, 2)), CAST(23.5 AS Decimal(18, 1)), CAST(170.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2049, N'1002', N'TEST ITEM 2', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(27.6 AS Decimal(18, 1)), CAST(200.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2049, N'1001', N'TEST ITEM 1', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(54.00 AS Decimal(18, 2)), CAST(7.5 AS Decimal(18, 1)), CAST(54.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2049, N'1004', N'TESHDHHH', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(150.00 AS Decimal(18, 2)), CAST(20.7 AS Decimal(18, 1)), CAST(150.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2049, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(0.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2049, N'10500002', N'ARIMIS MILKING JELLY 72*100G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(170.00 AS Decimal(18, 2)), CAST(23.5 AS Decimal(18, 1)), CAST(170.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2050, N'1001', N'TEST ITEM 1', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(54.00 AS Decimal(18, 2)), CAST(7.5 AS Decimal(18, 1)), CAST(54.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2050, N'1002', N'TEST ITEM 2', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(27.6 AS Decimal(18, 1)), CAST(200.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2050, N'1004', N'TESHDHHH', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(150.00 AS Decimal(18, 2)), CAST(20.7 AS Decimal(18, 1)), CAST(150.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2050, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(0.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2050, N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(60.00 AS Decimal(18, 2)), CAST(8.3 AS Decimal(18, 1)), CAST(60.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2050, N'10500002', N'ARIMIS MILKING JELLY 72*100G', N'PCS', CAST(2.0000 AS Decimal(18, 4)), CAST(170.00 AS Decimal(18, 2)), CAST(46.9 AS Decimal(18, 1)), CAST(340.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2051, N'1004', N'TESHDHHH', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(150.00 AS Decimal(18, 2)), CAST(20.7 AS Decimal(18, 1)), CAST(150.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2051, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(0.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2051, N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(60.00 AS Decimal(18, 2)), CAST(8.3 AS Decimal(18, 1)), CAST(60.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2051, N'1001', N'TEST ITEM 1', N'PCS', CAST(2.0000 AS Decimal(18, 4)), CAST(54.00 AS Decimal(18, 2)), CAST(14.9 AS Decimal(18, 1)), CAST(108.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2051, N'1002', N'TEST ITEM 2', N'PCS', CAST(2.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(55.2 AS Decimal(18, 1)), CAST(400.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2052, N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', CAST(12.0000 AS Decimal(18, 4)), CAST(60.00 AS Decimal(18, 2)), CAST(99.3 AS Decimal(18, 1)), CAST(720.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2053, N'10500002', N'ARIMIS MILKING JELLY 72*100G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(170.00 AS Decimal(18, 2)), CAST(23.5 AS Decimal(18, 1)), CAST(170.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2054, N'1002', N'TEST ITEM 2', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(27.6 AS Decimal(18, 1)), CAST(200.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2054, N'1001', N'TEST ITEM 1', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(54.00 AS Decimal(18, 2)), CAST(7.5 AS Decimal(18, 1)), CAST(54.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2054, N'1004', N'TESHDHHH', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(150.00 AS Decimal(18, 2)), CAST(20.7 AS Decimal(18, 1)), CAST(150.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2054, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(0.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2054, N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(60.00 AS Decimal(18, 2)), CAST(8.3 AS Decimal(18, 1)), CAST(60.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2054, N'10500002', N'ARIMIS MILKING JELLY 72*100G', N'PCS', CAST(2.0000 AS Decimal(18, 4)), CAST(170.00 AS Decimal(18, 2)), CAST(46.9 AS Decimal(18, 1)), CAST(340.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2033, N'1001', N'TEST ITEM 1', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(54.00 AS Decimal(18, 2)), CAST(7.5 AS Decimal(18, 1)), CAST(54.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2033, N'1002', N'TEST ITEM 2', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(27.6 AS Decimal(18, 1)), CAST(200.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2033, N'1004', N'TESHDHHH', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(150.00 AS Decimal(18, 2)), CAST(20.7 AS Decimal(18, 1)), CAST(150.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2033, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(0.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2033, N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(60.00 AS Decimal(18, 2)), CAST(8.3 AS Decimal(18, 1)), CAST(60.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2033, N'10500002', N'ARIMIS MILKING JELLY 72*100G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(170.00 AS Decimal(18, 2)), CAST(23.5 AS Decimal(18, 1)), CAST(170.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2034, N'1001', N'TEST ITEM 1', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(54.00 AS Decimal(18, 2)), CAST(7.5 AS Decimal(18, 1)), CAST(54.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2034, N'1002', N'TEST ITEM 2', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(27.6 AS Decimal(18, 1)), CAST(200.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2034, N'1004', N'TESHDHHH', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(150.00 AS Decimal(18, 2)), CAST(20.7 AS Decimal(18, 1)), CAST(150.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2034, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(0.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2034, N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(60.00 AS Decimal(18, 2)), CAST(8.3 AS Decimal(18, 1)), CAST(60.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2034, N'10500002', N'ARIMIS MILKING JELLY 72*100G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(170.00 AS Decimal(18, 2)), CAST(23.5 AS Decimal(18, 1)), CAST(170.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2035, N'1001', N'TEST ITEM 1', N'PCS', CAST(3.0000 AS Decimal(18, 4)), CAST(54.00 AS Decimal(18, 2)), CAST(22.3 AS Decimal(18, 1)), CAST(162.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2035, N'1002', N'TEST ITEM 2', N'PCS', CAST(2.0000 AS Decimal(18, 4)), CAST(200.00 AS Decimal(18, 2)), CAST(55.2 AS Decimal(18, 1)), CAST(400.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2035, N'1004', N'TESHDHHH', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(150.00 AS Decimal(18, 2)), CAST(20.7 AS Decimal(18, 1)), CAST(150.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2035, N'1022', N'YHHFECBCSHHCVSHV', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(1452.00 AS Decimal(18, 2)), CAST(0.0 AS Decimal(18, 1)), CAST(1452.00 AS Decimal(18, 2)), N'Z')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2035, N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', CAST(1.0000 AS Decimal(18, 4)), CAST(60.00 AS Decimal(18, 2)), CAST(8.3 AS Decimal(18, 1)), CAST(60.00 AS Decimal(18, 2)), N'A')
INSERT [dbo].[TblPosDetails] ([PosNumber], [ProdCd], [ProdNm], [UnitCd], [Quantity], [Sp], [LineVat], [LineAmount], [Vatcd]) VALUES (2035, N'10500002', N'ARIMIS MILKING JELLY 72*100G', N'PCS', CAST(2.0000 AS Decimal(18, 4)), CAST(170.00 AS Decimal(18, 2)), CAST(46.9 AS Decimal(18, 1)), CAST(340.00 AS Decimal(18, 2)), N'A')
SET IDENTITY_INSERT [dbo].[TblPosMaster] ON 

INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (8, CAST(0x0000ADA2010661DE AS DateTime), CAST(6.32 AS Decimal(18, 2)), CAST(10.01 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'Admin', N'Cash', N'001', N'0001', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(1000.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (9, CAST(0x0000ADA2010889FA AS DateTime), CAST(6.32 AS Decimal(18, 2)), CAST(10.01 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'Admin', N'Cash', N'001', N'0001', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(1000.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (10, CAST(0x0000ADA2010FF9A3 AS DateTime), CAST(6.32 AS Decimal(18, 2)), CAST(10.01 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'Admin', N'Cash', N'001', N'0001', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(1000.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (11, CAST(0x0000ADA2010FFFEE AS DateTime), CAST(6.32 AS Decimal(18, 2)), CAST(10.01 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'Admin', N'Cash', N'001', N'0001', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(1000.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (12, CAST(0x0000ADA20110F8C7 AS DateTime), CAST(6.32 AS Decimal(18, 2)), CAST(10.01 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'Admin', N'Cash', N'001', N'0001', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(1000.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (13, CAST(0x0000ADA2011195BD AS DateTime), CAST(6.32 AS Decimal(18, 2)), CAST(10.01 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'Admin', N'Cash', N'001', N'0001', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(1000.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (1002, CAST(0x0000ADA30088F539 AS DateTime), CAST(6.32 AS Decimal(18, 2)), CAST(10.01 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'Cash', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(1000.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (1003, CAST(0x0000ADA300A01416 AS DateTime), CAST(6.32 AS Decimal(18, 2)), CAST(10.01 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'Cash', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(1000.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (1004, CAST(0x0000ADA300A6E571 AS DateTime), CAST(6.32 AS Decimal(18, 2)), CAST(10.01 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'Cash', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(1000.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (1005, CAST(0x0000ADA300AA1212 AS DateTime), CAST(6.32 AS Decimal(18, 2)), CAST(10.01 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'Cash', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(1000.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (1006, CAST(0x0000ADA300AB7D18 AS DateTime), CAST(6.32 AS Decimal(18, 2)), CAST(10.01 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'Cash', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(1000.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (1007, CAST(0x0000ADA300AC2C2E AS DateTime), CAST(6.32 AS Decimal(18, 2)), CAST(10.01 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'Cash', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(1000.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (1008, CAST(0x0000ADA300D2CEA6 AS DateTime), CAST(48.28 AS Decimal(18, 2)), CAST(350.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(500.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (1009, CAST(0x0000ADA300D89F69 AS DateTime), CAST(126.90 AS Decimal(18, 2)), CAST(920.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'ADMIN', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(1000.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (1010, CAST(0x0000ADA300D8DE98 AS DateTime), CAST(20.69 AS Decimal(18, 2)), CAST(1602.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'ADMIN', N'OTHER METHODS', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(1700.00 AS Decimal(18, 2)), N'Mpesa')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (1011, CAST(0x0000ADA5014543BA AS DateTime), CAST(20.69 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(200.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (1012, CAST(0x0000ADA50145DFFE AS DateTime), CAST(20.69 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(200.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2011, CAST(0x0000ADA6009325AA AS DateTime), CAST(0.00 AS Decimal(18, 2)), CAST(1452.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(1500.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2012, CAST(0x0000ADA60093E42B AS DateTime), CAST(0.00 AS Decimal(18, 2)), CAST(1452.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(1550.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2013, CAST(0x0000ADA60095EB08 AS DateTime), CAST(0.00 AS Decimal(18, 2)), CAST(1452.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(1500.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2014, CAST(0x0000ADA600966731 AS DateTime), CAST(0.00 AS Decimal(18, 2)), CAST(1452.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(1600.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2015, CAST(0x0000ADA60098CC7B AS DateTime), CAST(0.00 AS Decimal(18, 2)), CAST(1452.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(1500.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2016, CAST(0x0000ADA600A2B41A AS DateTime), CAST(87.46 AS Decimal(18, 2)), CAST(2086.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(2500.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2017, CAST(0x0000ADA600A34C27 AS DateTime), CAST(87.46 AS Decimal(18, 2)), CAST(2086.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(2600.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2018, CAST(0x0000ADA600A86606 AS DateTime), CAST(7.45 AS Decimal(18, 2)), CAST(54.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(60.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2019, CAST(0x0000ADA600C6F825 AS DateTime), CAST(87.46 AS Decimal(18, 2)), CAST(2086.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(2700.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2020, CAST(0x0000ADA600CF53D4 AS DateTime), CAST(95.73 AS Decimal(18, 2)), CAST(2146.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(2800.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2021, CAST(0x0000ADA6012D87D1 AS DateTime), CAST(87.46 AS Decimal(18, 2)), CAST(2086.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(2700.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2022, CAST(0x0000ADA6012F4DF1 AS DateTime), CAST(7.45 AS Decimal(18, 2)), CAST(54.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(54.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2023, CAST(0x0000ADA6012FC59D AS DateTime), CAST(23.45 AS Decimal(18, 2)), CAST(170.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(200.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2024, CAST(0x0000ADA6013028EE AS DateTime), CAST(23.45 AS Decimal(18, 2)), CAST(170.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(200.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2025, CAST(0x0000ADA601306364 AS DateTime), CAST(8.28 AS Decimal(18, 2)), CAST(60.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(70.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2026, CAST(0x0000ADA60130C1FB AS DateTime), CAST(23.45 AS Decimal(18, 2)), CAST(170.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(200.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2027, CAST(0x0000ADA601312DB6 AS DateTime), CAST(23.45 AS Decimal(18, 2)), CAST(170.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(600.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2028, CAST(0x0000ADA601325079 AS DateTime), CAST(23.45 AS Decimal(18, 2)), CAST(170.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(200.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2029, CAST(0x0000ADA60135D111 AS DateTime), CAST(23.45 AS Decimal(18, 2)), CAST(170.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(200.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2030, CAST(0x0000ADA601367551 AS DateTime), CAST(23.45 AS Decimal(18, 2)), CAST(170.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(170.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2031, CAST(0x0000ADA60137047F AS DateTime), CAST(87.46 AS Decimal(18, 2)), CAST(2086.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(2600.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2032, CAST(0x0000ADA601378E8D AS DateTime), CAST(87.46 AS Decimal(18, 2)), CAST(2086.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(2400.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2033, CAST(0x0000ADA601407005 AS DateTime), CAST(87.46 AS Decimal(18, 2)), CAST(2086.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(2100.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2034, CAST(0x0000ADA601418D1E AS DateTime), CAST(87.46 AS Decimal(18, 2)), CAST(2086.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(2100.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2035, CAST(0x0000ADA6014419F8 AS DateTime), CAST(153.38 AS Decimal(18, 2)), CAST(2564.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(4500.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2036, CAST(0x0000ADA60147376B AS DateTime), CAST(55.73 AS Decimal(18, 2)), CAST(404.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(500.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2037, CAST(0x0000ADA800CD0C81 AS DateTime), CAST(7.45 AS Decimal(18, 2)), CAST(54.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(60.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2038, CAST(0x0000ADA800CD91B6 AS DateTime), CAST(27.59 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(250.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2039, CAST(0x0000ADA800CDBD65 AS DateTime), CAST(27.59 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(200.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2040, CAST(0x0000ADA800D2C360 AS DateTime), CAST(27.59 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(200.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2041, CAST(0x0000ADA800D31883 AS DateTime), CAST(35.04 AS Decimal(18, 2)), CAST(254.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(300.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2042, CAST(0x0000ADA800D3AC10 AS DateTime), CAST(48.28 AS Decimal(18, 2)), CAST(1802.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(2000.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2043, CAST(0x0000ADA800D53D50 AS DateTime), CAST(178.49 AS Decimal(18, 2)), CAST(2746.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(3000.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2044, CAST(0x0000ADA800D72853 AS DateTime), CAST(23.45 AS Decimal(18, 2)), CAST(170.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(200.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2045, CAST(0x0000ADA800D7D1AF AS DateTime), CAST(23.45 AS Decimal(18, 2)), CAST(170.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(200.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2046, CAST(0x0000ADA800D82CA0 AS DateTime), CAST(99.31 AS Decimal(18, 2)), CAST(720.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(750.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2047, CAST(0x0000ADA800D9193E AS DateTime), CAST(99.31 AS Decimal(18, 2)), CAST(720.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(800.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2048, CAST(0x0000ADA8010946FD AS DateTime), CAST(87.46 AS Decimal(18, 2)), CAST(2086.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(2100.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2049, CAST(0x0000ADA8010A2C8C AS DateTime), CAST(79.18 AS Decimal(18, 2)), CAST(2026.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(2050.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2050, CAST(0x0000ADA8010DB42C AS DateTime), CAST(110.91 AS Decimal(18, 2)), CAST(2256.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(2260.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2051, CAST(0x0000ADA801184FFB AS DateTime), CAST(99.04 AS Decimal(18, 2)), CAST(2170.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(2200.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2052, CAST(0x0000ADA90110DCC6 AS DateTime), CAST(99.31 AS Decimal(18, 2)), CAST(720.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'CASH', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(750.00 AS Decimal(18, 2)), N'CASH')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2053, CAST(0x0000ADA9011349EA AS DateTime), CAST(23.45 AS Decimal(18, 2)), CAST(170.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'OTHER METHODS', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(0.00 AS Decimal(18, 2)), N'p0245sdsfc')
INSERT [dbo].[TblPosMaster] ([PosNumber], [PosDate], [VatAmount], [TotalAmount], [MachineName], [Username], [PaymentMethod], [CmpnyCd], [BrnchCd], [Discount], [DiscountNarration], [CashGiven], [PaymentNarration]) VALUES (2054, CAST(0x0000ADA90115D15F AS DateTime), CAST(110.91 AS Decimal(18, 2)), CAST(2256.00 AS Decimal(18, 2)), N'DESKTOP-FB3HSFF', N'TEST', N'OTHER METHODS', N'THUITAS CYBER CAFE', N'THUITAS NAROK', CAST(0.00 AS Decimal(18, 2)), N'no discount', CAST(0.00 AS Decimal(18, 2)), N'Mpesa')
SET IDENTITY_INSERT [dbo].[TblPosMaster] OFF
INSERT [dbo].[TblProd] ([ProdCd], [ProdNm], [UnitCd], [DeptCd], [SuppCd], [Cp], [Sp], [QtyOnOrder], [QtyAvble], [Isactive], [VatCd], [CreatedBy], [CreatedOn], [UploadFlag], [DefaultQuantity]) VALUES (N'1001', N'TEST ITEM 1', N'PCS', N'dept1', N'tst', CAST(17.00 AS Decimal(18, 2)), CAST(54.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(106.00 AS Decimal(18, 2)), 1, N'A', N'Admin', CAST(0x0000ACA2013064F3 AS DateTime), N'Y', CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[TblProd] ([ProdCd], [ProdNm], [UnitCd], [DeptCd], [SuppCd], [Cp], [Sp], [QtyOnOrder], [QtyAvble], [Isactive], [VatCd], [CreatedBy], [CreatedOn], [UploadFlag], [DefaultQuantity]) VALUES (N'1002', N'TEST ITEM 2', N'PCS', N'dept1', N'tst', CAST(145.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(77.00 AS Decimal(18, 2)), 1, N'A', N'ADMIN', CAST(0x0000ACA300C6E480 AS DateTime), N'Y', CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[TblProd] ([ProdCd], [ProdNm], [UnitCd], [DeptCd], [SuppCd], [Cp], [Sp], [QtyOnOrder], [QtyAvble], [Isactive], [VatCd], [CreatedBy], [CreatedOn], [UploadFlag], [DefaultQuantity]) VALUES (N'1004', N'TESHDHHH', N'PCS', N'dept1', N'tst', CAST(10.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(-38.00 AS Decimal(18, 2)), 1, N'A', N'ADMIN', CAST(0x0000ACA300C904AF AS DateTime), N'Y', CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[TblProd] ([ProdCd], [ProdNm], [UnitCd], [DeptCd], [SuppCd], [Cp], [Sp], [QtyOnOrder], [QtyAvble], [Isactive], [VatCd], [CreatedBy], [CreatedOn], [UploadFlag], [DefaultQuantity]) VALUES (N'1022', N'YHHFECBCSHHCVSHV', N'PCS', N'DEPT1', N'TST', CAST(120.00 AS Decimal(18, 2)), CAST(1452.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(-5.00 AS Decimal(18, 2)), 1, N'Z', N'ADMIN', CAST(0x0000ACA700B51918 AS DateTime), N'Y', CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[TblProd] ([ProdCd], [ProdNm], [UnitCd], [DeptCd], [SuppCd], [Cp], [Sp], [QtyOnOrder], [QtyAvble], [Isactive], [VatCd], [CreatedBy], [CreatedOn], [UploadFlag], [DefaultQuantity]) VALUES (N'10500001', N'ARIMIS MILKING JELLY 72*50G', N'PCS', N'dept1', N'tst', CAST(53.00 AS Decimal(18, 2)), CAST(60.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), 1, N'A', N'ADMIN', CAST(0x0000ACAC00CADBB6 AS DateTime), N'Y', CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[TblProd] ([ProdCd], [ProdNm], [UnitCd], [DeptCd], [SuppCd], [Cp], [Sp], [QtyOnOrder], [QtyAvble], [Isactive], [VatCd], [CreatedBy], [CreatedOn], [UploadFlag], [DefaultQuantity]) VALUES (N'10500002', N'ARIMIS MILKING JELLY 72*100G', N'PCS', N'DEPT1', N'TST', CAST(145.00 AS Decimal(18, 2)), CAST(170.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(-42.00 AS Decimal(18, 2)), 1, N'A', N'TEST', CAST(0x0000AD930108CECB AS DateTime), N'Y', CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'GRN', 6, CAST(0.00 AS Decimal(18, 2)), CAST(12.00 AS Decimal(18, 2)), CAST(12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACE40093EBD7 AS DateTime), CAST(16.00 AS Decimal(18, 2)), NULL, N'TEST', N'2152454', NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'GRN', 6, CAST(0.00 AS Decimal(18, 2)), CAST(12.00 AS Decimal(18, 2)), CAST(12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACE40093FD50 AS DateTime), CAST(145.00 AS Decimal(18, 2)), NULL, N'TEST', N'2152454', NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'GRN', 7, CAST(12.00 AS Decimal(18, 2)), CAST(24.00 AS Decimal(18, 2)), CAST(12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEA00C062B1 AS DateTime), CAST(16.00 AS Decimal(18, 2)), NULL, N'TEST', N'TST INVOICE', NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'GRN', 7, CAST(12.00 AS Decimal(18, 2)), CAST(24.00 AS Decimal(18, 2)), CAST(12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEA00C06ECC AS DateTime), CAST(145.00 AS Decimal(18, 2)), NULL, N'TEST', N'TST INVOICE', NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'GRN', 8, CAST(24.00 AS Decimal(18, 2)), CAST(36.00 AS Decimal(18, 2)), CAST(12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEA00C84C45 AS DateTime), CAST(16.00 AS Decimal(18, 2)), NULL, N'TEST', N'TST INVOICE', NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'GRN', 8, CAST(24.00 AS Decimal(18, 2)), CAST(36.00 AS Decimal(18, 2)), CAST(12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEA00C84C4B AS DateTime), CAST(145.00 AS Decimal(18, 2)), NULL, N'TEST', N'TST INVOICE', NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'GRN', 9, CAST(36.00 AS Decimal(18, 2)), CAST(48.00 AS Decimal(18, 2)), CAST(12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEA00C86180 AS DateTime), CAST(16.00 AS Decimal(18, 2)), NULL, N'TEST', N'TST INVOICE', NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'GRN', 9, CAST(36.00 AS Decimal(18, 2)), CAST(48.00 AS Decimal(18, 2)), CAST(12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEA00C86181 AS DateTime), CAST(145.00 AS Decimal(18, 2)), NULL, N'TEST', N'TST INVOICE', NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'GRN', 10, CAST(48.00 AS Decimal(18, 2)), CAST(60.00 AS Decimal(18, 2)), CAST(12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEA00C94867 AS DateTime), CAST(145.00 AS Decimal(18, 2)), NULL, N'TEST', N'HDB', NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'GRN', 10, CAST(48.00 AS Decimal(18, 2)), CAST(60.00 AS Decimal(18, 2)), CAST(12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEA00C9486E AS DateTime), CAST(16.00 AS Decimal(18, 2)), NULL, N'TEST', N'HDB', NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'GRN', 11, CAST(60.00 AS Decimal(18, 2)), CAST(76.00 AS Decimal(18, 2)), CAST(16.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEA00DB573C AS DateTime), CAST(16.00 AS Decimal(18, 2)), NULL, N'TEST', N'1245', NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'GRN', 11, CAST(60.00 AS Decimal(18, 2)), CAST(85.00 AS Decimal(18, 2)), CAST(25.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEA00DB5740 AS DateTime), CAST(145.00 AS Decimal(18, 2)), NULL, N'TEST', N'1245', NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'GRN', 12, CAST(85.00 AS Decimal(18, 2)), CAST(99.00 AS Decimal(18, 2)), CAST(14.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEA00DC01DA AS DateTime), CAST(145.00 AS Decimal(18, 2)), NULL, N'TEST', N'01124', NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'GRN', 12, CAST(76.00 AS Decimal(18, 2)), CAST(90.00 AS Decimal(18, 2)), CAST(14.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEA00DC01DD AS DateTime), CAST(16.00 AS Decimal(18, 2)), NULL, N'TEST', N'01124', NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'GRN', 13, CAST(90.00 AS Decimal(18, 2)), CAST(102.00 AS Decimal(18, 2)), CAST(12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEB0093489A AS DateTime), CAST(16.00 AS Decimal(18, 2)), NULL, N'TEST', N'BOOKS', NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'GRN', 13, CAST(99.00 AS Decimal(18, 2)), CAST(110.00 AS Decimal(18, 2)), CAST(11.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEB0093489E AS DateTime), CAST(145.00 AS Decimal(18, 2)), NULL, N'TEST', N'BOOKS', NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'GRN', 13, CAST(0.00 AS Decimal(18, 2)), CAST(14.00 AS Decimal(18, 2)), CAST(14.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEB009348CB AS DateTime), CAST(120.00 AS Decimal(18, 2)), NULL, N'TEST', N'BOOKS', NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'GRN', 14, CAST(102.00 AS Decimal(18, 2)), CAST(116.00 AS Decimal(18, 2)), CAST(14.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEB00E5D2DD AS DateTime), CAST(16.00 AS Decimal(18, 2)), NULL, N'TEST', N'TEST', NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'GRN', 14, CAST(110.00 AS Decimal(18, 2)), CAST(122.00 AS Decimal(18, 2)), CAST(12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEB00E5D2E6 AS DateTime), CAST(145.00 AS Decimal(18, 2)), NULL, N'TEST', N'TEST', NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'GRN', 14, CAST(0.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(10.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEB00E5D2EF AS DateTime), CAST(10.00 AS Decimal(18, 2)), NULL, N'TEST', N'TEST', NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'GRN', 14, CAST(14.00 AS Decimal(18, 2)), CAST(30.00 AS Decimal(18, 2)), CAST(16.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEB00E5D2F2 AS DateTime), CAST(120.00 AS Decimal(18, 2)), NULL, N'TEST', N'TEST', NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500001', N'GRN', 14, CAST(0.00 AS Decimal(18, 2)), CAST(14.00 AS Decimal(18, 2)), CAST(14.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEB00E5D2F8 AS DateTime), CAST(53.00 AS Decimal(18, 2)), NULL, N'TEST', N'TEST', NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'GRN', 15, CAST(116.00 AS Decimal(18, 2)), CAST(128.00 AS Decimal(18, 2)), CAST(12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEC008311A0 AS DateTime), CAST(16.00 AS Decimal(18, 2)), NULL, N'TEST', N'01234', NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'GRN', 16, CAST(128.00 AS Decimal(18, 2)), CAST(140.00 AS Decimal(18, 2)), CAST(12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEC009367A9 AS DateTime), CAST(16.00 AS Decimal(18, 2)), NULL, N'TEST', N'123', N'TEST SUPPLIER')
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'GRN', 16, CAST(122.00 AS Decimal(18, 2)), CAST(136.00 AS Decimal(18, 2)), CAST(14.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEC009367AD AS DateTime), CAST(145.00 AS Decimal(18, 2)), NULL, N'TEST', N'123', N'TEST SUPPLIER')
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'GRN', 16, CAST(30.00 AS Decimal(18, 2)), CAST(70.00 AS Decimal(18, 2)), CAST(40.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEC009367B0 AS DateTime), CAST(120.00 AS Decimal(18, 2)), NULL, N'TEST', N'123', N'TEST SUPPLIER')
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500001', N'GRN', 16, CAST(14.00 AS Decimal(18, 2)), CAST(26.00 AS Decimal(18, 2)), CAST(12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEC009367B4 AS DateTime), CAST(53.00 AS Decimal(18, 2)), NULL, N'TEST', N'123', N'TEST SUPPLIER')
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'GRN', 1016, CAST(140.00 AS Decimal(18, 2)), CAST(155.00 AS Decimal(18, 2)), CAST(15.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEE00F1FA4B AS DateTime), CAST(16.00 AS Decimal(18, 2)), NULL, N'TEST', N'TEST', N'TEST SUPP')
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'GRN', 1016, CAST(136.00 AS Decimal(18, 2)), CAST(151.00 AS Decimal(18, 2)), CAST(15.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEE00F1FA4E AS DateTime), CAST(145.00 AS Decimal(18, 2)), NULL, N'TEST', N'TEST', N'TEST SUPP')
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'GRN', 1016, CAST(10.00 AS Decimal(18, 2)), CAST(24.00 AS Decimal(18, 2)), CAST(14.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEE00F1FA51 AS DateTime), CAST(10.00 AS Decimal(18, 2)), NULL, N'TEST', N'TEST', N'TEST SUPP')
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'GRN', 1016, CAST(70.00 AS Decimal(18, 2)), CAST(84.00 AS Decimal(18, 2)), CAST(14.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEE00F1FA55 AS DateTime), CAST(120.00 AS Decimal(18, 2)), NULL, N'TEST', N'TEST', N'TEST SUPP')
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500001', N'GRN', 1016, CAST(26.00 AS Decimal(18, 2)), CAST(36.00 AS Decimal(18, 2)), CAST(10.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ACEE00F1FA58 AS DateTime), CAST(53.00 AS Decimal(18, 2)), NULL, N'TEST', N'TEST', N'TEST SUPP')
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'ADJUST', 1, CAST(151.00 AS Decimal(18, 2)), CAST(136.00 AS Decimal(18, 2)), CAST(-15.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000AD8D009D4DF0 AS DateTime), CAST(145.00 AS Decimal(18, 2)), CAST(235.00 AS Decimal(18, 2)), N'TEST', NULL, N'Miscellenous Issue')
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'ADJUST', 1, CAST(24.00 AS Decimal(18, 2)), CAST(12.00 AS Decimal(18, 2)), CAST(-12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000AD8D009D4DF7 AS DateTime), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'TEST', NULL, N'Miscellenous Issue')
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'GRN', 1017, CAST(136.00 AS Decimal(18, 2)), CAST(148.00 AS Decimal(18, 2)), CAST(12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000AD8D00C0B0F3 AS DateTime), CAST(145.00 AS Decimal(18, 2)), CAST(235.00 AS Decimal(18, 2)), N'TEST', N'14522', N'TEST SUPP')
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500001', N'GRN', 1017, CAST(36.00 AS Decimal(18, 2)), CAST(108.00 AS Decimal(18, 2)), CAST(72.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000AD8D00C0B0F9 AS DateTime), CAST(53.00 AS Decimal(18, 2)), CAST(60.00 AS Decimal(18, 2)), N'TEST', N'14522', N'TEST SUPP')
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'INVOICE', 4, CAST(155.00 AS Decimal(18, 2)), CAST(143.00 AS Decimal(18, 2)), CAST(-12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000AD8F00992596 AS DateTime), CAST(17.00 AS Decimal(18, 2)), CAST(54.00 AS Decimal(18, 2)), N'TEST', N'pay by jan 17', N'NEW CUSTOMER')
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'INVOICE', 4, CAST(148.00 AS Decimal(18, 2)), CAST(134.00 AS Decimal(18, 2)), CAST(-14.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000AD8F0099259A AS DateTime), CAST(145.00 AS Decimal(18, 2)), CAST(235.00 AS Decimal(18, 2)), N'TEST', N'pay by jan 17', N'NEW CUSTOMER')
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'INVOICE', 5, CAST(12.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(-12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000AD8F00A6C132 AS DateTime), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'TEST', N'THED ', N'TEST CUSTOMER ')
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'GRN', 1018, CAST(134.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), CAST(16.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000AD8F013568DF AS DateTime), CAST(145.00 AS Decimal(18, 2)), CAST(235.00 AS Decimal(18, 2)), N'TEST', N'test invoice', N'TEST SUPP')
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500001', N'GRN', 1018, CAST(91.00 AS Decimal(18, 2)), CAST(103.00 AS Decimal(18, 2)), CAST(12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000AD8F013568F7 AS DateTime), CAST(53.00 AS Decimal(18, 2)), CAST(60.00 AS Decimal(18, 2)), N'TEST', N'test invoice', N'TEST SUPP')
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'INVOICE', 1004, CAST(150.00 AS Decimal(18, 2)), CAST(136.00 AS Decimal(18, 2)), CAST(-14.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000AD940119F5FB AS DateTime), CAST(145.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), N'TEST', N'', N'NEW CUSTOMER')
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'INVOICE', 1005, CAST(143.00 AS Decimal(18, 2)), CAST(131.00 AS Decimal(18, 2)), CAST(-12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000AD9F00A83E79 AS DateTime), CAST(17.00 AS Decimal(18, 2)), CAST(54.00 AS Decimal(18, 2)), N'ADMIN', N'', N'NEW CUSTOMER')
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'INVOICE', 1005, CAST(136.00 AS Decimal(18, 2)), CAST(121.00 AS Decimal(18, 2)), CAST(-15.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000AD9F00A83E80 AS DateTime), CAST(145.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), N'ADMIN', N'', N'NEW CUSTOMER')
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'INVOICE', 1005, CAST(0.00 AS Decimal(18, 2)), CAST(-12.00 AS Decimal(18, 2)), CAST(-12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000AD9F00A83E82 AS DateTime), CAST(10.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), N'ADMIN', N'', N'NEW CUSTOMER')
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'INVOICE', 1005, CAST(84.00 AS Decimal(18, 2)), CAST(24.00 AS Decimal(18, 2)), CAST(-60.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000AD9F00A83E83 AS DateTime), CAST(120.00 AS Decimal(18, 2)), CAST(1452.00 AS Decimal(18, 2)), N'ADMIN', N'', N'NEW CUSTOMER')
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500001', N'INVOICE', 1005, CAST(103.00 AS Decimal(18, 2)), CAST(91.00 AS Decimal(18, 2)), CAST(-12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000AD9F00A83E85 AS DateTime), CAST(53.00 AS Decimal(18, 2)), CAST(60.00 AS Decimal(18, 2)), N'ADMIN', N'', N'NEW CUSTOMER')
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500002', N'INVOICE', 1005, CAST(0.00 AS Decimal(18, 2)), CAST(-14.00 AS Decimal(18, 2)), CAST(-14.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000AD9F00A83E86 AS DateTime), CAST(145.00 AS Decimal(18, 2)), CAST(170.00 AS Decimal(18, 2)), N'ADMIN', N'', N'NEW CUSTOMER')
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'01', 2, CAST(121.00 AS Decimal(18, 2)), CAST(107.00 AS Decimal(18, 2)), CAST(-14.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA2010235CD AS DateTime), CAST(145.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), N'TEST', NULL, N'Miscellenous Issue')
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'POS', 8, CAST(107.00 AS Decimal(18, 2)), CAST(106.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA201061ED6 AS DateTime), NULL, CAST(200.00 AS Decimal(18, 2)), N'Admin', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 10, CAST(23.00 AS Decimal(18, 2)), CAST(22.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA2010FF9A5 AS DateTime), NULL, CAST(1452.00 AS Decimal(18, 2)), N'Admin', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 11, CAST(22.00 AS Decimal(18, 2)), CAST(21.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA2010FFFF6 AS DateTime), NULL, CAST(1452.00 AS Decimal(18, 2)), N'Admin', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'POS', 1002, CAST(-14.00 AS Decimal(18, 2)), CAST(-15.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA30088F544 AS DateTime), NULL, CAST(150.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'POS', 1002, CAST(106.00 AS Decimal(18, 2)), CAST(105.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA30088F54D AS DateTime), NULL, CAST(200.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'POS', 1003, CAST(-15.00 AS Decimal(18, 2)), CAST(-16.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA300A0144B AS DateTime), NULL, CAST(150.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'POS', 1004, CAST(105.00 AS Decimal(18, 2)), CAST(104.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA300A6E576 AS DateTime), NULL, CAST(200.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 1005, CAST(19.00 AS Decimal(18, 2)), CAST(18.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA300AA121D AS DateTime), NULL, CAST(1452.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'POS', 1006, CAST(131.00 AS Decimal(18, 2)), CAST(130.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA300AB7D1E AS DateTime), NULL, CAST(54.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'POS', 1007, CAST(104.00 AS Decimal(18, 2)), CAST(103.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA300AC2C33 AS DateTime), NULL, CAST(200.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'POS', 1008, CAST(103.00 AS Decimal(18, 2)), CAST(102.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA300D2CEC1 AS DateTime), NULL, CAST(200.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'POS', 1008, CAST(-16.00 AS Decimal(18, 2)), CAST(-17.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA300D2CEC9 AS DateTime), NULL, CAST(150.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'POS', 1009, CAST(102.00 AS Decimal(18, 2)), CAST(101.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA300D89F6B AS DateTime), NULL, CAST(200.00 AS Decimal(18, 2)), N'ADMIN', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500001', N'POS', 1009, CAST(79.00 AS Decimal(18, 2)), CAST(67.00 AS Decimal(18, 2)), CAST(-12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA300D89F6C AS DateTime), NULL, CAST(60.00 AS Decimal(18, 2)), N'ADMIN', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500001', N'INVOICE', 5, CAST(108.00 AS Decimal(18, 2)), CAST(91.00 AS Decimal(18, 2)), CAST(-17.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000AD8F00A6C136 AS DateTime), CAST(53.00 AS Decimal(18, 2)), CAST(60.00 AS Decimal(18, 2)), N'TEST', N'THED ', N'TEST CUSTOMER ')
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'POS', 8, CAST(-12.00 AS Decimal(18, 2)), CAST(-13.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA201062AEC AS DateTime), NULL, CAST(150.00 AS Decimal(18, 2)), N'Admin', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'POS', 1010, CAST(-17.00 AS Decimal(18, 2)), CAST(-18.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA300D8DE99 AS DateTime), NULL, CAST(150.00 AS Decimal(18, 2)), N'ADMIN', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 1010, CAST(18.00 AS Decimal(18, 2)), CAST(17.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA300D8DE9F AS DateTime), NULL, CAST(1452.00 AS Decimal(18, 2)), N'ADMIN', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'POS', 1011, CAST(-18.00 AS Decimal(18, 2)), CAST(-19.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA5014543DC AS DateTime), NULL, CAST(150.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'POS', 1012, CAST(-19.00 AS Decimal(18, 2)), CAST(-20.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA50145E001 AS DateTime), NULL, CAST(150.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 2011, CAST(17.00 AS Decimal(18, 2)), CAST(16.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA6009325CB AS DateTime), NULL, CAST(1452.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 2012, CAST(16.00 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA60093E42D AS DateTime), NULL, CAST(1452.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 2013, CAST(15.00 AS Decimal(18, 2)), CAST(14.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA60095EB0E AS DateTime), NULL, CAST(1452.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 2014, CAST(14.00 AS Decimal(18, 2)), CAST(13.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA600966733 AS DateTime), NULL, CAST(1452.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 2015, CAST(13.00 AS Decimal(18, 2)), CAST(12.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA60098CC80 AS DateTime), NULL, CAST(1452.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'POS', 2016, CAST(130.00 AS Decimal(18, 2)), CAST(129.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA600A2B41F AS DateTime), NULL, CAST(54.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'POS', 2016, CAST(101.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA600A2B423 AS DateTime), NULL, CAST(200.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'POS', 2016, CAST(-20.00 AS Decimal(18, 2)), CAST(-21.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA600A2B42A AS DateTime), NULL, CAST(150.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 2016, CAST(12.00 AS Decimal(18, 2)), CAST(11.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA600A2B42C AS DateTime), NULL, CAST(1452.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500001', N'POS', 2016, CAST(67.00 AS Decimal(18, 2)), CAST(66.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA600A2B42F AS DateTime), NULL, CAST(60.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500002', N'POS', 2016, CAST(-14.00 AS Decimal(18, 2)), CAST(-15.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA600A2B433 AS DateTime), NULL, CAST(170.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'POS', 2017, CAST(129.00 AS Decimal(18, 2)), CAST(128.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA600A34C29 AS DateTime), NULL, CAST(54.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'POS', 2017, CAST(100.00 AS Decimal(18, 2)), CAST(99.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA600A34C2B AS DateTime), NULL, CAST(200.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'POS', 2017, CAST(-21.00 AS Decimal(18, 2)), CAST(-22.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA600A34C2D AS DateTime), NULL, CAST(150.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 2017, CAST(11.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA600A34C2F AS DateTime), NULL, CAST(1452.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500001', N'POS', 2017, CAST(66.00 AS Decimal(18, 2)), CAST(65.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA600A34C31 AS DateTime), NULL, CAST(60.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500002', N'POS', 2017, CAST(-15.00 AS Decimal(18, 2)), CAST(-16.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA600A34C33 AS DateTime), NULL, CAST(170.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'POS', 2018, CAST(128.00 AS Decimal(18, 2)), CAST(127.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA600A86608 AS DateTime), NULL, CAST(54.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'POS', 2019, CAST(127.00 AS Decimal(18, 2)), CAST(126.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA600C6F83D AS DateTime), NULL, CAST(54.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'POS', 2019, CAST(99.00 AS Decimal(18, 2)), CAST(98.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA600C6F84F AS DateTime), NULL, CAST(200.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'POS', 2019, CAST(-22.00 AS Decimal(18, 2)), CAST(-23.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA600C6F85D AS DateTime), NULL, CAST(150.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 2019, CAST(10.00 AS Decimal(18, 2)), CAST(9.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA600C6F87B AS DateTime), NULL, CAST(1452.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500001', N'POS', 2019, CAST(65.00 AS Decimal(18, 2)), CAST(64.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA600C6F890 AS DateTime), NULL, CAST(60.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500002', N'POS', 2019, CAST(-16.00 AS Decimal(18, 2)), CAST(-17.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA600C6F89D AS DateTime), NULL, CAST(170.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'POS', 2020, CAST(126.00 AS Decimal(18, 2)), CAST(125.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA600CF53DD AS DateTime), NULL, CAST(54.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'POS', 2020, CAST(98.00 AS Decimal(18, 2)), CAST(97.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA600CF53DF AS DateTime), NULL, CAST(200.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 2020, CAST(9.00 AS Decimal(18, 2)), CAST(8.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA600CF53E2 AS DateTime), NULL, CAST(1452.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'POS', 2020, CAST(-23.00 AS Decimal(18, 2)), CAST(-24.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA600CF53E4 AS DateTime), NULL, CAST(150.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500001', N'POS', 2020, CAST(64.00 AS Decimal(18, 2)), CAST(62.00 AS Decimal(18, 2)), CAST(-2.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA600CF5412 AS DateTime), NULL, CAST(60.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500002', N'POS', 2020, CAST(-17.00 AS Decimal(18, 2)), CAST(-18.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA600CF5415 AS DateTime), NULL, CAST(170.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'POS', 2021, CAST(125.00 AS Decimal(18, 2)), CAST(124.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA6012D87E4 AS DateTime), NULL, CAST(54.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
GO
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'POS', 2021, CAST(97.00 AS Decimal(18, 2)), CAST(96.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA6012D87FB AS DateTime), NULL, CAST(200.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'POS', 2021, CAST(-24.00 AS Decimal(18, 2)), CAST(-25.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA6012D8801 AS DateTime), NULL, CAST(150.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 2021, CAST(8.00 AS Decimal(18, 2)), CAST(7.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA6012D880A AS DateTime), NULL, CAST(1452.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500001', N'POS', 2021, CAST(62.00 AS Decimal(18, 2)), CAST(61.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA6012D880C AS DateTime), NULL, CAST(60.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500002', N'POS', 2021, CAST(-18.00 AS Decimal(18, 2)), CAST(-19.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA6012D8825 AS DateTime), NULL, CAST(170.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'POS', 2022, CAST(124.00 AS Decimal(18, 2)), CAST(123.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA6012F4DFF AS DateTime), NULL, CAST(54.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500002', N'POS', 2023, CAST(-19.00 AS Decimal(18, 2)), CAST(-20.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA6012FC5A4 AS DateTime), NULL, CAST(170.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500002', N'POS', 2024, CAST(-20.00 AS Decimal(18, 2)), CAST(-21.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA6013028F8 AS DateTime), NULL, CAST(170.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500001', N'POS', 2025, CAST(61.00 AS Decimal(18, 2)), CAST(60.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA60130636B AS DateTime), NULL, CAST(60.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500002', N'POS', 2026, CAST(-21.00 AS Decimal(18, 2)), CAST(-22.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA60130C200 AS DateTime), NULL, CAST(170.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500002', N'POS', 2027, CAST(-22.00 AS Decimal(18, 2)), CAST(-23.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA601312DC2 AS DateTime), NULL, CAST(170.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500002', N'POS', 2028, CAST(-23.00 AS Decimal(18, 2)), CAST(-24.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA601325084 AS DateTime), NULL, CAST(170.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500002', N'POS', 2029, CAST(-24.00 AS Decimal(18, 2)), CAST(-25.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA60135D129 AS DateTime), NULL, CAST(170.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500002', N'POS', 2030, CAST(-25.00 AS Decimal(18, 2)), CAST(-26.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA601367554 AS DateTime), NULL, CAST(170.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'POS', 2031, CAST(123.00 AS Decimal(18, 2)), CAST(122.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA60137048F AS DateTime), NULL, CAST(54.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'POS', 2031, CAST(96.00 AS Decimal(18, 2)), CAST(95.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA6013704C4 AS DateTime), NULL, CAST(200.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'POS', 2031, CAST(-25.00 AS Decimal(18, 2)), CAST(-26.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA6013704C9 AS DateTime), NULL, CAST(150.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 2031, CAST(7.00 AS Decimal(18, 2)), CAST(6.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA6013704D0 AS DateTime), NULL, CAST(1452.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500001', N'POS', 2031, CAST(60.00 AS Decimal(18, 2)), CAST(59.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA6013704D3 AS DateTime), NULL, CAST(60.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500002', N'POS', 2031, CAST(-26.00 AS Decimal(18, 2)), CAST(-27.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA6013704D8 AS DateTime), NULL, CAST(170.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'POS', 2032, CAST(122.00 AS Decimal(18, 2)), CAST(121.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA601378E8F AS DateTime), NULL, CAST(54.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'POS', 2032, CAST(95.00 AS Decimal(18, 2)), CAST(94.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA601378E97 AS DateTime), NULL, CAST(200.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'POS', 2032, CAST(-26.00 AS Decimal(18, 2)), CAST(-27.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA601378E99 AS DateTime), NULL, CAST(150.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 2032, CAST(6.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA601378E9D AS DateTime), NULL, CAST(1452.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500001', N'POS', 2032, CAST(59.00 AS Decimal(18, 2)), CAST(58.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA601378EA4 AS DateTime), NULL, CAST(60.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500002', N'POS', 2032, CAST(-27.00 AS Decimal(18, 2)), CAST(-28.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA601378EA6 AS DateTime), NULL, CAST(170.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'POS', 2033, CAST(121.00 AS Decimal(18, 2)), CAST(120.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA601407008 AS DateTime), NULL, CAST(54.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'POS', 2033, CAST(94.00 AS Decimal(18, 2)), CAST(93.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA601407012 AS DateTime), NULL, CAST(200.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'POS', 2033, CAST(-27.00 AS Decimal(18, 2)), CAST(-28.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA601407015 AS DateTime), NULL, CAST(150.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 2033, CAST(5.00 AS Decimal(18, 2)), CAST(4.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA601407017 AS DateTime), NULL, CAST(1452.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500001', N'POS', 2033, CAST(58.00 AS Decimal(18, 2)), CAST(57.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA601407019 AS DateTime), NULL, CAST(60.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500002', N'POS', 2033, CAST(-28.00 AS Decimal(18, 2)), CAST(-29.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA60140701C AS DateTime), NULL, CAST(170.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'POS', 2034, CAST(120.00 AS Decimal(18, 2)), CAST(119.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA601418D45 AS DateTime), NULL, CAST(54.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'POS', 2034, CAST(93.00 AS Decimal(18, 2)), CAST(92.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA601418D48 AS DateTime), NULL, CAST(200.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'POS', 2034, CAST(-28.00 AS Decimal(18, 2)), CAST(-29.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA601418D4B AS DateTime), NULL, CAST(150.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 2034, CAST(4.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA601418D4D AS DateTime), NULL, CAST(1452.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500001', N'POS', 2034, CAST(57.00 AS Decimal(18, 2)), CAST(56.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA601418D4F AS DateTime), NULL, CAST(60.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 9, CAST(24.00 AS Decimal(18, 2)), CAST(23.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA201088A02 AS DateTime), NULL, CAST(1452.00 AS Decimal(18, 2)), N'Admin', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 12, CAST(21.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA20110F8CB AS DateTime), NULL, CAST(1452.00 AS Decimal(18, 2)), N'Admin', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 13, CAST(20.00 AS Decimal(18, 2)), CAST(19.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA2011195BF AS DateTime), NULL, CAST(1452.00 AS Decimal(18, 2)), N'Admin', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'POS', 13, CAST(-13.00 AS Decimal(18, 2)), CAST(-14.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA2011195C3 AS DateTime), NULL, CAST(150.00 AS Decimal(18, 2)), N'Admin', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500001', N'POS', 13, CAST(91.00 AS Decimal(18, 2)), CAST(79.00 AS Decimal(18, 2)), CAST(-12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA2011195C7 AS DateTime), NULL, CAST(60.00 AS Decimal(18, 2)), N'Admin', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500002', N'POS', 2034, CAST(-29.00 AS Decimal(18, 2)), CAST(-30.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA601418D52 AS DateTime), NULL, CAST(170.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'POS', 2035, CAST(119.00 AS Decimal(18, 2)), CAST(116.00 AS Decimal(18, 2)), CAST(-3.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA601441A19 AS DateTime), NULL, CAST(54.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'POS', 2035, CAST(92.00 AS Decimal(18, 2)), CAST(90.00 AS Decimal(18, 2)), CAST(-2.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA601441A35 AS DateTime), NULL, CAST(200.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'POS', 2035, CAST(-29.00 AS Decimal(18, 2)), CAST(-30.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA601441A51 AS DateTime), NULL, CAST(150.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 2035, CAST(3.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA601441A68 AS DateTime), NULL, CAST(1452.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500001', N'POS', 2035, CAST(56.00 AS Decimal(18, 2)), CAST(55.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA601441A71 AS DateTime), NULL, CAST(60.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500002', N'POS', 2035, CAST(-30.00 AS Decimal(18, 2)), CAST(-32.00 AS Decimal(18, 2)), CAST(-2.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA601441A78 AS DateTime), NULL, CAST(170.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'POS', 2036, CAST(116.00 AS Decimal(18, 2)), CAST(115.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA60147376D AS DateTime), NULL, CAST(54.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'POS', 2036, CAST(90.00 AS Decimal(18, 2)), CAST(89.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA601473770 AS DateTime), NULL, CAST(200.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'POS', 2036, CAST(-30.00 AS Decimal(18, 2)), CAST(-31.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA601473776 AS DateTime), NULL, CAST(150.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'POS', 2037, CAST(115.00 AS Decimal(18, 2)), CAST(114.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA800CD0CC2 AS DateTime), NULL, CAST(54.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'POS', 2038, CAST(89.00 AS Decimal(18, 2)), CAST(88.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA800CD91BA AS DateTime), NULL, CAST(200.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'POS', 2039, CAST(88.00 AS Decimal(18, 2)), CAST(87.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA800CDBD67 AS DateTime), NULL, CAST(200.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'POS', 2040, CAST(87.00 AS Decimal(18, 2)), CAST(86.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA800D2C367 AS DateTime), NULL, CAST(200.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'POS', 2041, CAST(114.00 AS Decimal(18, 2)), CAST(113.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA800D3188A AS DateTime), NULL, CAST(54.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'POS', 2041, CAST(86.00 AS Decimal(18, 2)), CAST(85.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA800D31896 AS DateTime), NULL, CAST(200.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'POS', 2042, CAST(85.00 AS Decimal(18, 2)), CAST(84.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA800D3AC12 AS DateTime), NULL, CAST(200.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'POS', 2042, CAST(-31.00 AS Decimal(18, 2)), CAST(-32.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA800D3AC16 AS DateTime), NULL, CAST(150.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 2042, CAST(2.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA800D3AC19 AS DateTime), NULL, CAST(1452.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'POS', 2043, CAST(113.00 AS Decimal(18, 2)), CAST(112.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA800D53D5A AS DateTime), NULL, CAST(54.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'POS', 2043, CAST(84.00 AS Decimal(18, 2)), CAST(83.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA800D53D5F AS DateTime), NULL, CAST(200.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'POS', 2043, CAST(-32.00 AS Decimal(18, 2)), CAST(-33.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA800D53D63 AS DateTime), NULL, CAST(150.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 2043, CAST(1.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA800D53D66 AS DateTime), NULL, CAST(1452.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500001', N'POS', 2043, CAST(55.00 AS Decimal(18, 2)), CAST(43.00 AS Decimal(18, 2)), CAST(-12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA800D53D6A AS DateTime), NULL, CAST(60.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500002', N'POS', 2043, CAST(-32.00 AS Decimal(18, 2)), CAST(-33.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA800D53D6E AS DateTime), NULL, CAST(170.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500002', N'POS', 2044, CAST(-33.00 AS Decimal(18, 2)), CAST(-34.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA800D7285B AS DateTime), NULL, CAST(170.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500002', N'POS', 2045, CAST(-34.00 AS Decimal(18, 2)), CAST(-35.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA800D7D1B6 AS DateTime), NULL, CAST(170.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500001', N'POS', 2046, CAST(43.00 AS Decimal(18, 2)), CAST(31.00 AS Decimal(18, 2)), CAST(-12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA800D82CA3 AS DateTime), NULL, CAST(60.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500001', N'POS', 2047, CAST(31.00 AS Decimal(18, 2)), CAST(19.00 AS Decimal(18, 2)), CAST(-12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA800D91943 AS DateTime), NULL, CAST(60.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'POS', 2048, CAST(112.00 AS Decimal(18, 2)), CAST(111.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA801094747 AS DateTime), NULL, CAST(54.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'POS', 2048, CAST(83.00 AS Decimal(18, 2)), CAST(82.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA80109475A AS DateTime), NULL, CAST(200.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'POS', 2048, CAST(-33.00 AS Decimal(18, 2)), CAST(-34.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA801094766 AS DateTime), NULL, CAST(150.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 2048, CAST(0.00 AS Decimal(18, 2)), CAST(-1.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA801094781 AS DateTime), NULL, CAST(1452.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500001', N'POS', 2048, CAST(19.00 AS Decimal(18, 2)), CAST(18.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA80109479E AS DateTime), NULL, CAST(60.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500002', N'POS', 2048, CAST(-35.00 AS Decimal(18, 2)), CAST(-36.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA8010947AC AS DateTime), NULL, CAST(170.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'POS', 2049, CAST(82.00 AS Decimal(18, 2)), CAST(81.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA8010A2C8F AS DateTime), NULL, CAST(200.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'POS', 2049, CAST(111.00 AS Decimal(18, 2)), CAST(110.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA8010A2C92 AS DateTime), NULL, CAST(54.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'POS', 2049, CAST(-34.00 AS Decimal(18, 2)), CAST(-35.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA8010A2C96 AS DateTime), NULL, CAST(150.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 2049, CAST(-1.00 AS Decimal(18, 2)), CAST(-2.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA8010A2C9A AS DateTime), NULL, CAST(1452.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500002', N'POS', 2049, CAST(-36.00 AS Decimal(18, 2)), CAST(-37.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA8010A2C9C AS DateTime), NULL, CAST(170.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'POS', 2050, CAST(110.00 AS Decimal(18, 2)), CAST(109.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA8010DB436 AS DateTime), NULL, CAST(54.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'POS', 2050, CAST(81.00 AS Decimal(18, 2)), CAST(80.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA8010DB43C AS DateTime), NULL, CAST(200.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'POS', 2050, CAST(-35.00 AS Decimal(18, 2)), CAST(-36.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA8010DB440 AS DateTime), NULL, CAST(150.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 2050, CAST(-2.00 AS Decimal(18, 2)), CAST(-3.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA8010DB443 AS DateTime), NULL, CAST(1452.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500001', N'POS', 2050, CAST(18.00 AS Decimal(18, 2)), CAST(17.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA8010DB447 AS DateTime), NULL, CAST(60.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500002', N'POS', 2050, CAST(-37.00 AS Decimal(18, 2)), CAST(-39.00 AS Decimal(18, 2)), CAST(-2.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA8010DB44A AS DateTime), NULL, CAST(170.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'POS', 2051, CAST(-36.00 AS Decimal(18, 2)), CAST(-37.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA801185008 AS DateTime), NULL, CAST(150.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 2051, CAST(-3.00 AS Decimal(18, 2)), CAST(-4.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA80118500E AS DateTime), NULL, CAST(1452.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500001', N'POS', 2051, CAST(17.00 AS Decimal(18, 2)), CAST(16.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA801185018 AS DateTime), NULL, CAST(60.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'POS', 2051, CAST(109.00 AS Decimal(18, 2)), CAST(107.00 AS Decimal(18, 2)), CAST(-2.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA80118501C AS DateTime), NULL, CAST(54.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'POS', 2051, CAST(80.00 AS Decimal(18, 2)), CAST(78.00 AS Decimal(18, 2)), CAST(-2.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA801185021 AS DateTime), NULL, CAST(200.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500001', N'POS', 2052, CAST(16.00 AS Decimal(18, 2)), CAST(4.00 AS Decimal(18, 2)), CAST(-12.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA90110DCD4 AS DateTime), CAST(53.00 AS Decimal(18, 2)), CAST(60.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500002', N'POS', 2053, CAST(-39.00 AS Decimal(18, 2)), CAST(-40.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA9011349F2 AS DateTime), CAST(145.00 AS Decimal(18, 2)), CAST(170.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1002', N'POS', 2054, CAST(78.00 AS Decimal(18, 2)), CAST(77.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA90115D167 AS DateTime), CAST(145.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1001', N'POS', 2054, CAST(107.00 AS Decimal(18, 2)), CAST(106.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA90115D16C AS DateTime), CAST(17.00 AS Decimal(18, 2)), CAST(54.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1004', N'POS', 2054, CAST(-37.00 AS Decimal(18, 2)), CAST(-38.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA90115D170 AS DateTime), CAST(10.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'1022', N'POS', 2054, CAST(-4.00 AS Decimal(18, 2)), CAST(-5.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA90115D173 AS DateTime), CAST(120.00 AS Decimal(18, 2)), CAST(1452.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500001', N'POS', 2054, CAST(4.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), CAST(-1.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA90115D177 AS DateTime), CAST(53.00 AS Decimal(18, 2)), CAST(60.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
GO
INSERT [dbo].[TblProdHist] ([PROD_CD], [TXN_TYPE], [DOC_NO], [INT_QTY], [NW_QTY], [QTY], [BRCH_CD], [CMPY_CD], [TXN_DATE], [PROD_CP], [PROD_SP], [USR_NM], [INV_NO], [ACCOUNT_NO]) VALUES (N'10500002', N'POS', 2054, CAST(-40.00 AS Decimal(18, 2)), CAST(-42.00 AS Decimal(18, 2)), CAST(-2.000 AS Decimal(18, 3)), NULL, NULL, CAST(0x0000ADA90115D17A AS DateTime), CAST(145.00 AS Decimal(18, 2)), CAST(170.00 AS Decimal(18, 2)), N'TEST', NULL, NULL)
INSERT [dbo].[TblReasons] ([ReasonCode], [ReasonName], [CreatedBy], [CreatedOn], [UploadFlg]) VALUES (N'01', N'STOCK ADJUSTMENT', N'TEST', CAST(0x0000AD8D009AC093 AS DateTime), N'Y')
INSERT [dbo].[TblReasons] ([ReasonCode], [ReasonName], [CreatedBy], [CreatedOn], [UploadFlg]) VALUES (N'02', N'ISSUE', N'TEST', CAST(0x0000AD8D009B00C3 AS DateTime), N'Y')
INSERT [dbo].[TblScnCd] ([ScanCode], [ProdCd], [UnitCd], [Upload_Flg], [CreatedBy], [CreatedOn]) VALUES (N'123456', N'1001', N'PCSFGHG', N'Y', N'ADMIN', CAST(0x0000ACD0008C2554 AS DateTime))
INSERT [dbo].[TblScnCd] ([ScanCode], [ProdCd], [UnitCd], [Upload_Flg], [CreatedBy], [CreatedOn]) VALUES (N'1452', N'10500001', N'PCS', N'Y', N'ADMIN', CAST(0x0000ACAC00E4BAF3 AS DateTime))
INSERT [dbo].[TblScnCd] ([ScanCode], [ProdCd], [UnitCd], [Upload_Flg], [CreatedBy], [CreatedOn]) VALUES (N'6008677000549', N'10500001', N'PCS', N'Y', N'ADMIN', CAST(0x0000ACE300A5FC90 AS DateTime))
SET IDENTITY_INSERT [dbo].[TBLSPHIST] ON 

INSERT [dbo].[TBLSPHIST] ([PROD_CD], [INT_SP], [NW_SP], [USR_NM], [CHG_DT], [BRCH_CD], [CMPY_CD], [Sr_No]) VALUES (N'1001', CAST(14.56 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), N'ADMIN', CAST(0x0000ACAB0146358B AS DateTime), N'NRK', N'TT', 1)
INSERT [dbo].[TBLSPHIST] ([PROD_CD], [INT_SP], [NW_SP], [USR_NM], [CHG_DT], [BRCH_CD], [CMPY_CD], [Sr_No]) VALUES (N'1001', CAST(20.00 AS Decimal(18, 2)), CAST(145.00 AS Decimal(18, 2)), N'ADMIN', CAST(0x0000ACB501276B1E AS DateTime), N'NRK', N'TT', 2)
INSERT [dbo].[TBLSPHIST] ([PROD_CD], [INT_SP], [NW_SP], [USR_NM], [CHG_DT], [BRCH_CD], [CMPY_CD], [Sr_No]) VALUES (N'1001', CAST(145.00 AS Decimal(18, 2)), CAST(54.00 AS Decimal(18, 2)), N'ADMIN', CAST(0x0000ACC500B4F775 AS DateTime), N'NRK', N'TT', 3)
INSERT [dbo].[TBLSPHIST] ([PROD_CD], [INT_SP], [NW_SP], [USR_NM], [CHG_DT], [BRCH_CD], [CMPY_CD], [Sr_No]) VALUES (N'10500001', CAST(25.00 AS Decimal(18, 2)), CAST(60.00 AS Decimal(18, 2)), N'ADMIN', CAST(0x0000ACDD011A5688 AS DateTime), N'NRK', N'TT', 4)
INSERT [dbo].[TBLSPHIST] ([PROD_CD], [INT_SP], [NW_SP], [USR_NM], [CHG_DT], [BRCH_CD], [CMPY_CD], [Sr_No]) VALUES (N'1002', CAST(0.00 AS Decimal(18, 2)), CAST(235.00 AS Decimal(18, 2)), N'ADMIN', CAST(0x0000ACE20142A3FA AS DateTime), N'NRK', N'TT', 5)
INSERT [dbo].[TBLSPHIST] ([PROD_CD], [INT_SP], [NW_SP], [USR_NM], [CHG_DT], [BRCH_CD], [CMPY_CD], [Sr_No]) VALUES (N'1002', CAST(235.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), N'TEST', CAST(0x0000AD94009651D6 AS DateTime), N'NRK', N'TT', 6)
INSERT [dbo].[TBLSPHIST] ([PROD_CD], [INT_SP], [NW_SP], [USR_NM], [CHG_DT], [BRCH_CD], [CMPY_CD], [Sr_No]) VALUES (N'1004', CAST(0.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), N'TEST', CAST(0x0000AD9500B8EBEF AS DateTime), N'NRK', N'TT', 7)
SET IDENTITY_INSERT [dbo].[TBLSPHIST] OFF
INSERT [dbo].[TblSupp] ([SuppCd], [SuppNm], [SuppBox], [SuppCity], [SuppLocation], [SuppTel], [SuppPinCode], [SuppEmail], [SuppFax], [SuppCreditLimit], [SuppMobile], [SuppPaymentTerms], [SuppLimitDays], [SuppVatNo], [CreatedBy]) VALUES (N'TEST', N'TEST SUPP', N'140', N'MOLO', N'MOLO', N'0702157779', N'A00023235B', N'mahdhhdhahh', N'10246646464646', CAST(1450 AS Decimal(18, 0)), N'0702157779', N'CHEQUE', 40, N'BSKKFSFHFH', N'Test')
INSERT [dbo].[TblSupp] ([SuppCd], [SuppNm], [SuppBox], [SuppCity], [SuppLocation], [SuppTel], [SuppPinCode], [SuppEmail], [SuppFax], [SuppCreditLimit], [SuppMobile], [SuppPaymentTerms], [SuppLimitDays], [SuppVatNo], [CreatedBy]) VALUES (N'TST', N'TEST SUPPLIER', N'140', N'NAROK', N'HOME SWEET', N'4575274', N'A002175845L', N'testsupplier@gmail.com', N'FSFSF', CAST(120 AS Decimal(18, 0)), N'0702157779', N'CHEQUE', 90, N'DSFSDFAS', N'Test')
INSERT [dbo].[tblUnit] ([UnitCd], [UnitNm], [CreatedBy], [CreatedOn], [UploadFlag]) VALUES (N'HSYATYDY', N'HUGSUATDU', N'Test', CAST(0x0000AC90012227E1 AS DateTime), N'Y')
INSERT [dbo].[tblUnit] ([UnitCd], [UnitNm], [CreatedBy], [CreatedOn], [UploadFlag]) VALUES (N'PCS', N'PIECES', N'Test', CAST(0x0000ACEB00E8BC5E AS DateTime), N'Y')
INSERT [dbo].[tblUnit] ([UnitCd], [UnitNm], [CreatedBy], [CreatedOn], [UploadFlag]) VALUES (N'TESDT', N'GAHDHSFGHSFC', N'Test', CAST(0x0000AC90012651B9 AS DateTime), N'Y')
INSERT [dbo].[tblUnit] ([UnitCd], [UnitNm], [CreatedBy], [CreatedOn], [UploadFlag]) VALUES (N'TEST UNIT', N'TEST UNIT DESCRIPTION', N'Test', CAST(0x0000AC900124C9E9 AS DateTime), N'Y')
INSERT [dbo].[tblUnit] ([UnitCd], [UnitNm], [CreatedBy], [CreatedOn], [UploadFlag]) VALUES (N'THSFH', N'JHDSJUSUFGESFUS', N'Test', CAST(0x0000AC900126B7F4 AS DateTime), N'Y')
INSERT [dbo].[tblUnit] ([UnitCd], [UnitNm], [CreatedBy], [CreatedOn], [UploadFlag]) VALUES (N'UNIT1', N'unit 1 edited ', N'Test', CAST(0x0000AC8F00D7E125 AS DateTime), N'Y')
INSERT [dbo].[tblUnit] ([UnitCd], [UnitNm], [CreatedBy], [CreatedOn], [UploadFlag]) VALUES (N'UNIT2', N'UNIT 2', N'Test', CAST(0x0000AC8F01043D59 AS DateTime), N'Y')
INSERT [dbo].[TBLUSERGROUPS] ([GROUPCODE], [GROUPNAME], [CANADDSTOCK], [CANVIEWSTOCK], [CANISSUESTOCK], [CANMANAGEUSERS], [CANCHANGECP], [CANCHANGESP], [CANADJUSTSTOCK], [CREATEDBY], [CREATEDON], [UPLOADFLG], [ISACTIVE]) VALUES (N'ADMIN', N'ADMINISTRATORS', 1, 1, 1, 1, 1, 1, 1, N'TEST', CAST(0x0000ACDF01183D55 AS DateTime), N'Y', 1)
INSERT [dbo].[TBLUSERGROUPS] ([GROUPCODE], [GROUPNAME], [CANADDSTOCK], [CANVIEWSTOCK], [CANISSUESTOCK], [CANMANAGEUSERS], [CANCHANGECP], [CANCHANGESP], [CANADJUSTSTOCK], [CREATEDBY], [CREATEDON], [UPLOADFLG], [ISACTIVE]) VALUES (N'STOCKS', N'STOCK TEAM', 0, 1, 0, 0, 0, 0, 0, N'TEST', CAST(0x0000ACDF01196709 AS DateTime), N'Y', 1)
INSERT [dbo].[TBLUSERGROUPS] ([GROUPCODE], [GROUPNAME], [CANADDSTOCK], [CANVIEWSTOCK], [CANISSUESTOCK], [CANMANAGEUSERS], [CANCHANGECP], [CANCHANGESP], [CANADJUSTSTOCK], [CREATEDBY], [CREATEDON], [UPLOADFLG], [ISACTIVE]) VALUES (N'USERS', N'BACKOFFICE USER', 1, 1, 1, 0, 1, 1, 0, N'TEST', CAST(0x0000ACE000C0B7CB AS DateTime), N'Y', 1)
INSERT [dbo].[TBLUSERS] ([USERNAME], [FULLNAME], [PASSWORD], [GROUPCODE], [CREATEDBY], [CREATEDON], [UPLOADFLG], [ISACTIVE]) VALUES (N'ADMIN', N'ADMINISTRATOR', N'gG/qJRgy3/A=', N'ADMIN', N'ADMIN', CAST(0x0000ACB2011DFF40 AS DateTime), N'Y', 1)
INSERT [dbo].[TBLUSERS] ([USERNAME], [FULLNAME], [PASSWORD], [GROUPCODE], [CREATEDBY], [CREATEDON], [UPLOADFLG], [ISACTIVE]) VALUES (N'SIMON', N'SIMON MUNENE', N'gG/qJRgy3/A=', N'STOCKS', N'TEST', CAST(0x0000ADAF012A0375 AS DateTime), N'Y', 1)
INSERT [dbo].[TBLUSERS] ([USERNAME], [FULLNAME], [PASSWORD], [GROUPCODE], [CREATEDBY], [CREATEDON], [UPLOADFLG], [ISACTIVE]) VALUES (N'TEST', N'MICHAEL MAINA', N'gG/qJRgy3/A=', N'FO', N'admin', CAST(0x0000ACB2011DFF40 AS DateTime), N'Y', 1)
INSERT [dbo].[tblVat] ([VatCd], [VatPercentage], [CreatedBy], [CreatedOn]) VALUES (N'A', CAST(16 AS Decimal(18, 0)), N'Admin', CAST(0x0000AC9300BF267E AS DateTime))
INSERT [dbo].[tblVat] ([VatCd], [VatPercentage], [CreatedBy], [CreatedOn]) VALUES (N'Z', CAST(0 AS Decimal(18, 0)), N'Admin', CAST(0x0000AC9300C77D34 AS DateTime))
INSERT [dbo].[TillManager] ([TillCode], [MachineName], [CreatedBy], [Createdon], [IsActive]) VALUES (1, N'Thuitas01', N'TEST', CAST(0x0000ADAD009B7400 AS DateTime), 1)
INSERT [dbo].[USERGROUPS] ([GROUPCODE], [GROUPNAME], [CREATEDBY], [CREATEDON], [ISACTIVE]) VALUES (N'ADMIN', N'ADMINISTRATORS', N'ADMIN', CAST(0x0000ADAF0133C6D7 AS DateTime), 1)
INSERT [dbo].[USERGROUPS] ([GROUPCODE], [GROUPNAME], [CREATEDBY], [CREATEDON], [ISACTIVE]) VALUES (N'BO', N'BACK OFFICE', N'TEST', CAST(0x0000ADAE012BF05C AS DateTime), 1)
INSERT [dbo].[USERGROUPS] ([GROUPCODE], [GROUPNAME], [CREATEDBY], [CREATEDON], [ISACTIVE]) VALUES (N'FO', N'FRONT OFFICE USER', N'ADMIN', CAST(0x0000ADB000DCDE56 AS DateTime), 1)
INSERT [dbo].[USERGROUPS] ([GROUPCODE], [GROUPNAME], [CREATEDBY], [CREATEDON], [ISACTIVE]) VALUES (N'labels', N'labellers', N'TEST', CAST(0x0000ADB0008188C5 AS DateTime), 1)
INSERT [dbo].[USERGROUPS] ([GROUPCODE], [GROUPNAME], [CREATEDBY], [CREATEDON], [ISACTIVE]) VALUES (N'MANAGERS', N'MANAGERS', N'TEST', CAST(0x0000ADAF00CFCE76 AS DateTime), 1)
INSERT [dbo].[USERGROUPS] ([GROUPCODE], [GROUPNAME], [CREATEDBY], [CREATEDON], [ISACTIVE]) VALUES (N'STOCKS', N'STOCK USERS', N'TEST', CAST(0x0000ADAF00CC3472 AS DateTime), 1)
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__Cust_Stmt__DATE__151B244E]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cust_Stmt] ADD  DEFAULT (getdate()) FOR [DATE]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__Cust_Stmt__UPLOA__160F4887]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cust_Stmt] ADD  DEFAULT ('Y') FOR [UPLOAD_FLAG]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__GrnMaster__GrnDa__49C3F6B7]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[GrnMaster] ADD  DEFAULT (getdate()) FOR [GrnDate]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__GROUPPOLI__POLIC__2F9A1060]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[GROUPPOLICY] ADD  DEFAULT ('N') FOR [POLICY]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__INVOICEDE__DISCO__4AB81AF0]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[INVOICEDETAILS] ADD  DEFAULT ((0)) FOR [DISCOUNTAMOUNT]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__InvoiceMa__DATER__4BAC3F29]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[InvoiceMaster] ADD  DEFAULT (getdate()) FOR [DATERECEIVED]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__InvoiceMa__ISPAI__4CA06362]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[InvoiceMaster] ADD  DEFAULT ('FALSE') FOR [ISPAID]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__ISSUEMAST__DATEI__4D94879B]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ISSUEMASTER] ADD  DEFAULT (getdate()) FOR [DATEISSUED]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__RECEIPTMA__DATER__4E88ABD4]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[RECEIPTMASTER] ADD  DEFAULT (getdate()) FOR [DATERECEIVED]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TBLBRNCH__ISCHIL__1BFD2C07]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBLBRNCH] ADD  DEFAULT ((1)) FOR [ISCHILD]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TBLBRNCH__ISPARE__1CF15040]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBLBRNCH] ADD  DEFAULT ((0)) FOR [ISPARENT]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TBLBRNCH__CREATE__1DE57479]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBLBRNCH] ADD  DEFAULT (getdate()) FOR [CREATEDON]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TBLBRNCH__UPLOAD__1ED998B2]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBLBRNCH] ADD  DEFAULT ('Y') FOR [UPLOADFLG]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TBLCMPNY__CREATE__21B6055D]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBLCMPNY] ADD  DEFAULT (getdate()) FOR [CREATEDON]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TBLCMPNY__UPLOAD__22AA2996]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBLCMPNY] ADD  DEFAULT ('Y') FOR [UPLOADFLG]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TBLCPHIST__CHG_D__4F7CD00D]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBLCPHIST] ADD  DEFAULT (getdate()) FOR [CHG_DT]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TblCust__ISACTIV__5070F446]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TblCust] ADD  DEFAULT ('TRUE') FOR [ISACTIVE]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TblCust__CREATED__5165187F]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TblCust] ADD  DEFAULT (getdate()) FOR [CREATEDON]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__tblDept__Created__52593CB8]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[tblDept] ADD  DEFAULT (getdate()) FOR [CreatedOn]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TBLPOLICI__CREAT__534D60F1]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBLPOLICIES] ADD  DEFAULT (getdate()) FOR [CREATEDON]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TBLPOLICI__UPLOA__5441852A]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBLPOLICIES] ADD  DEFAULT ('Y') FOR [UPLOADFLG]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TBLPOLICI__ISACT__5535A963]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBLPOLICIES] ADD  DEFAULT ((1)) FOR [ISACTIVE]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TblPosMas__PosDa__671F4F74]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TblPosMaster] ADD  DEFAULT (getdate()) FOR [PosDate]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TblPosMas__CashG__681373AD]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TblPosMaster] ADD  DEFAULT ((0)) FOR [CashGiven]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TblProd__QtyOnOr__5629CD9C]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TblProd] ADD  DEFAULT ((0)) FOR [QtyOnOrder]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TblProd__QtyAvbl__571DF1D5]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TblProd] ADD  DEFAULT ((0)) FOR [QtyAvble]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TblProd__Isactiv__5812160E]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TblProd] ADD  DEFAULT ((1)) FOR [Isactive]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TblProd__Created__59063A47]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TblProd] ADD  DEFAULT (getdate()) FOR [CreatedOn]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TblProd__UploadF__59FA5E80]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TblProd] ADD  DEFAULT ('Y') FOR [UploadFlag]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_TblProd_DefaultQuantity]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TblProd] ADD  CONSTRAINT [DF_TblProd_DefaultQuantity]  DEFAULT ((1)) FOR [DefaultQuantity]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TblProdHi__TXN_D__5AEE82B9]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TblProdHist] ADD  DEFAULT (getdate()) FOR [TXN_DATE]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TblReason__Creat__5BE2A6F2]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TblReasons] ADD  DEFAULT (getdate()) FOR [CreatedOn]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TblReason__Uploa__5CD6CB2B]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TblReasons] ADD  DEFAULT ('Y') FOR [UploadFlg]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TblScnCd__Upload__5DCAEF64]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TblScnCd] ADD  DEFAULT ('Y') FOR [Upload_Flg]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TblScnCd__Create__5EBF139D]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TblScnCd] ADD  DEFAULT (getdate()) FOR [CreatedOn]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TBLSPHIST__CHG_D__5FB337D6]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBLSPHIST] ADD  DEFAULT (getdate()) FOR [CHG_DT]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__tblUnit__Created__60A75C0F]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[tblUnit] ADD  DEFAULT (getdate()) FOR [CreatedOn]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__tblUnit__UploadF__619B8048]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[tblUnit] ADD  DEFAULT ('Y') FOR [UploadFlag]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TBLUSERGR__CANAD__37A5467C]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBLUSERGROUPS] ADD  DEFAULT ((0)) FOR [CANADDSTOCK]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TBLUSERGR__CANVI__38996AB5]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBLUSERGROUPS] ADD  DEFAULT ((0)) FOR [CANVIEWSTOCK]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TBLUSERGR__CANIS__398D8EEE]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBLUSERGROUPS] ADD  DEFAULT ((0)) FOR [CANISSUESTOCK]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TBLUSERGR__CANMA__3A81B327]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBLUSERGROUPS] ADD  DEFAULT ((0)) FOR [CANMANAGEUSERS]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TBLUSERGR__CANCH__3B75D760]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBLUSERGROUPS] ADD  DEFAULT ((0)) FOR [CANCHANGECP]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TBLUSERGR__CANCH__3C69FB99]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBLUSERGROUPS] ADD  DEFAULT ((0)) FOR [CANCHANGESP]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TBLUSERGR__CANAD__3D5E1FD2]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBLUSERGROUPS] ADD  DEFAULT ((0)) FOR [CANADJUSTSTOCK]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TBLUSERGR__CREAT__3E52440B]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBLUSERGROUPS] ADD  DEFAULT (getdate()) FOR [CREATEDON]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TBLUSERGR__UPLOA__3F466844]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBLUSERGROUPS] ADD  DEFAULT ('Y') FOR [UPLOADFLG]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TBLUSERGR__ISACT__403A8C7D]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBLUSERGROUPS] ADD  DEFAULT ((1)) FOR [ISACTIVE]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TBLUSERRO__CREAT__628FA481]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBLUSERROLE] ADD  DEFAULT (getdate()) FOR [CREATEDON]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TBLUSERRO__UPLOA__6383C8BA]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBLUSERROLE] ADD  DEFAULT ('Y') FOR [UPLOADFLG]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TBLUSERRO__ISACT__6477ECF3]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBLUSERROLE] ADD  DEFAULT ((1)) FOR [ISACTIVE]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TBLUSERS__CREATE__44FF419A]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBLUSERS] ADD  DEFAULT (getdate()) FOR [CREATEDON]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TBLUSERS__UPLOAD__45F365D3]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBLUSERS] ADD  DEFAULT ('Y') FOR [UPLOADFLG]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TBLUSERS__ISACTI__46E78A0C]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TBLUSERS] ADD  DEFAULT ((1)) FOR [ISACTIVE]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__tblVat__CreatedO__656C112C]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[tblVat] ADD  DEFAULT (getdate()) FOR [CreatedOn]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TillManag__Creat__078C1F06]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TillManager] ADD  CONSTRAINT [DF__TillManag__Creat__078C1F06]  DEFAULT (getdate()) FOR [Createdon]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_TillManager_IsActive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TillManager] ADD  CONSTRAINT [DF_TillManager_IsActive]  DEFAULT ((1)) FOR [IsActive]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__USERGROUP__CREAT__32767D0B]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[USERGROUPS] ADD  DEFAULT (getdate()) FOR [CREATEDON]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_USERGROUPS_ISACTIVE]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[USERGROUPS] ADD  CONSTRAINT [DF_USERGROUPS_ISACTIVE]  DEFAULT ((0)) FOR [ISACTIVE]
END

GO
USE [master]
GO
ALTER DATABASE [ShopLiteDb] SET  READ_WRITE 
GO
