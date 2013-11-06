IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[spa_XXX]') AND TYPE IN (N'P'))
BEGIN
  DROP PROCEDURE [dbo].[spa_XXX]
END
GO
/*==============================================================================
* NAME: spa_XXX
* PURPOSE: 
* NOTE:
* DATE         VERSION           AUTHOR           DESCRIPTION
********************************************************************************
* Create date  version           author           Create new
********************************************************************************
DECLARE @ID bigint
EXEC dbo.spa_XXX  @I_vObjectName = 'Area',@O_vObjectID = @ID out
SELECT @ID
==============================================================================*/
CREATE PROCEDURE [dbo].[spa_XXX]
  @I_vintCurUserID    INT,
  @I_vstrBranchID     NVARCHAR(32),
  @I_vstrLang         NVARCHAR(2),
  @I_vObjectName      NVARCHAR(100),
  @O_vObjectID        BIGINT OUT
AS
BEGIN
  ---- VARIABLE DECLARATIONS
  DECLARE @intReturn INT;
  
  ---- SET DEFAULT VALUE FOR VARIABLES
  SET @intReturn = 0;
  
  --- MAIN ACTION ----
  SET NOCOUNT ON
  
  --- END ACTION ----
  
  RETURN @intReturn;
END
GO