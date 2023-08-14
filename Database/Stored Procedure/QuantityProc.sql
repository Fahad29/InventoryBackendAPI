Create Proc p_GetAll_Quantities
As
Begin
	SELECT  Id, CategoryId,	Quantity, Unit, IsActive  FROM  dbo.ProductQuantity Where IsActive=1
End

Create Proc p_Create_Quantity
@Id int,
@CategoryId varchar(250),
@Quantity decimal(18,2),
@Unit varchar(250),
@IsActive bit
As
Begin
	INSERT INTO  dbo.ProductQuantity 
	(CategoryId, Quantity, Unit,IsActive )
	VALUES
	(@CategoryId,@Quantity,@Unit,1)
	
	Select Top 1 * From dbo.ProductQuantity Where Id = SCOPE_IDENTITY() Order by 1 desc
End

Alter Proc p_Delete_Quantity
@QuantityId as Int
As
Begin
	Update ProductQuantity
	Set IsActive = 0
	Where Id=@QuantityId

	--Select * From dbo.ProductQuantity Where IsActive=1 Order by 1 desc
End