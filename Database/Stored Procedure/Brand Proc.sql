Alter Proc p_GetAll_Brands
As
Begin
	SELECT  Id, Name, Logo , IsActive  FROM  IMS . dbo . ProductBrand Where IsActive=1
End

Alter Proc p_Create_Brand
@Id int,
@Name varchar(250),
@Logo varchar(max),
@IsActive bit
As
Begin
	INSERT INTO  dbo . ProductBrand 
	(Name , IsActive )
	VALUES
	(@Name ,1)
	
	Select Top 1 * From dbo . ProductBrand  Order by 1 desc
End

Alter Proc p_Delete_Brand
@BrandId as Int
As
Begin
	Update ProductBrand
	Set IsActive = 0
	Where Id=@BrandId

	Select * From dbo . ProductBrand  Order by 1 desc
End