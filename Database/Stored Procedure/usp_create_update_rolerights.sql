-- =============================================
-- Author:  Muhammad Fahad
-- Create date: 08-Sep_2023
-- Description: insertion Of Roles and Its Rights
-- =============================================
Alter PROC usp_create_update_rolerights
  @Roleid AS       int ,
  @Moduleid AS     int,
  @Allowview AS    bit,
  @Allowcreate AS  bit ,
  @Allowupdate AS  bit,
  @Allowdelete AS  bit
AS
  BEGIN
    DECLARE @Currentrolerightsid AS int
    SELECT TOP 1  @Currentrolerightsid = id  FROM   rolesrights WHERE  roleid=@Roleid AND moduleid=@Moduleid

    IF (isnull(@Currentrolerightsid,0)>0)
    BEGIN
      UPDATE rolesrights
      SET    allowview = @Allowview,
             allowcreate =@Allowcreate,
             allowupdate =@Allowupdate,
             allowdelete =@Allowdelete
      WHERE  id=@Currentrolerightsid
    END
    ELSE
    BEGIN
      INSERT INTO dbo.rolesrights
                  (
                              moduleid,
                              roleid,
                              allowview,
                              allowcreate,
                              allowupdate,
                              allowdelete
                  )
                  VALUES
                  (
                              @Moduleid ,
                              @Roleid ,
                              @Allowview ,
                              @Allowcreate ,
                              @Allowupdate ,
                              @Allowdelete
                  )
    END
  END