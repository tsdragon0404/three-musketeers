IF EXISTS ( SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnc_XXX]') AND type in (N'FN') )
BEGIN
    DROP FUNCTION [dbo].[fnc_XXX]
END
GO
/*==============================================================================
* NAME: fnc_XXX
* PURPOSE: 
* NOTE:
* DATE         VERSION           AUTHOR           DESCRIPTION
********************************************************************************
* Create date  version           author           Create new
********************************************************************************
==============================================================================*/
CREATE FUNCTION [dbo].[fnc_XXX]
  @I_vInputParameter BIGINT
RETURNS VARCHAR(5)
AS
BEGIN
  ---- VARIABLE DECLARATIONS
  DECLARE @strResult VARCHAR(5);
  
  ---- SET DEFAULT VALUE FOR VARIABLE
  SELECT @strResult = '';

  --- MAIN ACTION ----
  SET NOCOUNT ON
  
  --- END ACTION ----
       
  RETURN @strResult  
END
GO