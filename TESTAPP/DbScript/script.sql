USE [master]
GO
/****** Object:  Database [ShopLiteDb]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  StoredProcedure [dbo].[ADDUSERGROUP]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  StoredProcedure [dbo].[DeleteTill]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  StoredProcedure [dbo].[EditSupp]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  StoredProcedure [dbo].[EditUnit]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  StoredProcedure [dbo].[EditVat]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  StoredProcedure [dbo].[GetPos]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  StoredProcedure [dbo].[GetTill]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  StoredProcedure [dbo].[GetTills]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  StoredProcedure [dbo].[Sp_Cust_Stmt]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  StoredProcedure [dbo].[Sp_Top_10_Cust_Stmt]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SPADDUSER]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SPBRANCH]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpGetCustomer]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpGetCustomers]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpGetGrnSummaries]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpGetLastGrnNo]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spGetValues]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpStockCard]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spUpdateDept]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SPUPDATEUSER]    Script Date: 9/24/2021 9:35:38 AM ******/
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
	@GROUPCODE NVARCHAR (50)
	
AS
	begin
	UPDATE TBLUSERS
	SET FULLNAME=@Fname,
	[PASSWORD]=@Pwd,
	GROUPCODE=@GROUPCODE
	WHERE USERNAME=@UNAME
	
	end


' 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateTill]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  StoredProcedure [dbo].[UPDATEUSERGROUP]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[Cust_Stmt]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[GrnDetails]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[GrnMaster]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[INVOICEDETAILS]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[InvoiceMaster]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[ISSUEDETAILS]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[ISSUEMASTER]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[RECEIPTDETAILS]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[RECEIPTMASTER]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[TBLBRNCH]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[TBLCMPNY]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[TBLCPHIST]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[TblCust]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[tblDept]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[TBLPOLICIES]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[TblPosDetails]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[TblPosMaster]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[TblProd]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[TblProdHist]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[TblReasons]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[TblScnCd]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[TBLSPHIST]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[TblSupp]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[tblUnit]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[TBLUSERGROUPS]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[TBLUSERROLE]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[TBLUSERS]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[tblVat]    Script Date: 9/24/2021 9:35:38 AM ******/
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
/****** Object:  Table [dbo].[TillManager]    Script Date: 9/24/2021 9:35:38 AM ******/
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
USE [master]
GO
ALTER DATABASE [ShopLiteDb] SET  READ_WRITE 
GO
