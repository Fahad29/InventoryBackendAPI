Create Proc p_GetAll_Categories
As
Begin
	SELECT  Id, Name,IsActive  FROM  dbo.ProductCategory Where IsActive=1
End

Create Proc p_Create_Category
@Id int,
@Name varchar(250),
@IsActive bit
As
Begin
	INSERT INTO  dbo.ProductCategory 
	(Name , IsActive )
	VALUES
	(@Name ,1)
	
	Select Top 1 * From dbo.ProductCategory Where Id = SCOPE_IDENTITY() Order by 1 desc
End

Alter Proc p_Delete_Category
@CategoryId as Int
As
Begin
	Update ProductCategory
	Set IsActive = 0
	Where Id=@CategoryId

	Select * From dbo.ProductCategory Where IsActive=1 Order by 1 desc
End