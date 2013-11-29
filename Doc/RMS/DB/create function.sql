DECLARE @FunctionID INT,
		@VNName VARCHAR(255),
		@ENName VARCHAR(255),
		@VNDescription VARCHAR(255),
		@ENDescription VARCHAR(255),
		@Enable CHAR(1),
		@str NVARCHAR(4000)

DECLARE cur CURSOR FAST_FORWARD READ_ONLY FOR
SELECT FunctionID, VNName, ENName, VNDescription, ENDescription, Enable FROM dbo.[Function] ORDER BY FunctionID

OPEN cur

FETCH NEXT FROM cur INTO @FunctionID, @VNName, @ENName, @VNDescription, @ENDescription, @Enable

WHILE @@FETCH_STATUS = 0
BEGIN
	SELECT @str = '
IF NOT EXISTS ( SELECT TOP 1 1 FROM dbo.[Function] WHERE FunctionID = ' + CAST(@FunctionID AS VARCHAR) + ' )
BEGIN
	INSERT INTO dbo.[Function] ( FunctionID, VNName, ENName, VNDescription, ENDescription, Enable ) VALUES ( ' + CAST(@FunctionID AS VARCHAR) + ', N''' + @VNName + ''' , N''' + @ENName + ''', N''' + @VNDescription + ''', N''' + @ENDescription + ''', ' + CAST(@Enable AS VARCHAR(1)) + ' )
END';
	
	PRINT(@str);

FETCH NEXT FROM cur INTO @FunctionID, @VNName, @ENName, @VNDescription, @ENDescription, @Enable

END

CLOSE cur
DEALLOCATE cur