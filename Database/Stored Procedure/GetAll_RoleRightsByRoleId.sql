Alter Proc GetAll_RoleRightsByRoleId 
@RoleId as Int
As
	Begin
		Select RR.ID as RoleRightId,M.ID as ModuleId, M.Name as ModuleName, ISNULL(RR.RoleId,@RoleId) As RoleId,
		ISNULL(RR.[Create],0) As [AllowCreate], ISNULL(RR.[Update],0) As [AllowUpdate],IsNUll([Delete],0) as [AllowDelete] 
		From Modules M
		Left Join RolesRights RR On M.Id= RR.ModuleId AND RR.RoleId=@RoleId
		Where M.IsActive=1 AND (RR.RoleId=@RoleId OR RR.RoleId is NULL)
	End



