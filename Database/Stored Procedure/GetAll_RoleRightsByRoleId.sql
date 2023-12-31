
-- =============================================
-- Author:  Muhammad Fahad
-- Create date: 08-Sep_2023
-- Description: insertion Of Roles and Its Rights
-- Execution: GetAll_RoleRightsByRoleId 1
-- =============================================
ALTER Proc [dbo].[GetAll_RoleRightsByRoleId] 
@RoleId as Int
As
	Begin
		Select RR.ID as RoleRightId,M.ID as ModuleId, M.Name as ModuleName, ISNULL(RR.RoleId,@RoleId) As RoleId,IsNUll([AllowView],0) as [AllowView], 
		ISNULL(RR.AllowCreate,0) As [AllowCreate], ISNULL(RR.[AllowUpdate],0) As [AllowUpdate],IsNUll([AllowDelete],0) as [AllowDelete] 
		From Modules M
		Left Join RolesRights RR On M.Id= RR.ModuleId AND RR.RoleId=@RoleId
		Where M.IsActive=1 AND (RR.RoleId=@RoleId OR RR.RoleId is NULL)
	End



