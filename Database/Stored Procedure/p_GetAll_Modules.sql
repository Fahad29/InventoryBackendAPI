USE [IMS]
GO
/****** Object:  StoredProcedure [dbo].[p_GetAll_Modules]    Script Date: 9/6/2023 11:30:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Proc [dbo].[p_GetAll_Modules]
As
Begin 
	Select Id,Name From Modules Where IsActive=1
End

