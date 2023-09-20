Alter Proc p_GetAll_DropdownByModuleId
@ModuleId as Int
As
Begin 

	If(@ModuleId= 1) -- Country
		Begin 
			Select Id, Name From Country Where IsActive=1
		End
	Else If(@ModuleId= 2) --City
		Begin 
			Select Id, Name From City Where IsActive=1
		End
	Else If(@ModuleId= 3) 
		Begin 
			Select Id, Name From ProductBrand Where IsActive=1
		End
	Else If(@ModuleId= 9) -- Users
		Begin 
			Select UserId as Id, CONCAT(FirstName,' ', LastName ,' (', UserId ,')') as Name From [User] Where IsActive=1
		End
	Else If(@ModuleId= 10) -- Roles
		Begin 
			Select Id, Name From Roles Where IsActive=1
		End

End