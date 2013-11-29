IF NOT EXISTS ( SELECT TOP 1 1 FROM dbo.[Function] WHERE FunctionID = 1000 )
BEGIN
	INSERT INTO dbo.[Function] ( FunctionID, VNName, ENName, VNDescription, ENDescription, Enable ) VALUES ( 1000, N'Main' , N'Main', N'frmMain', N'frmMain', 1 )
END

IF NOT EXISTS ( SELECT TOP 1 1 FROM dbo.[Function] WHERE FunctionID = 1001 )
BEGIN
	INSERT INTO dbo.[Function] ( FunctionID, VNName, ENName, VNDescription, ENDescription, Enable ) VALUES ( 1001, N'User' , N'User', N'frmUser', N'frmUser', 1 )
END

IF NOT EXISTS ( SELECT TOP 1 1 FROM dbo.[Function] WHERE FunctionID = 1002 )
BEGIN
	INSERT INTO dbo.[Function] ( FunctionID, VNName, ENName, VNDescription, ENDescription, Enable ) VALUES ( 1002, N'Branch' , N'Branch', N'frmBranch', N'frmBranch', 1 )
END

IF NOT EXISTS ( SELECT TOP 1 1 FROM dbo.[Function] WHERE FunctionID = 1003 )
BEGIN
	INSERT INTO dbo.[Function] ( FunctionID, VNName, ENName, VNDescription, ENDescription, Enable ) VALUES ( 1003, N'Login' , N'Login', N'frmLoginAdmin', N'frmLoginAdmin', 1 )
END

IF NOT EXISTS ( SELECT TOP 1 1 FROM dbo.[Function] WHERE FunctionID = 1004 )
BEGIN
	INSERT INTO dbo.[Function] ( FunctionID, VNName, ENName, VNDescription, ENDescription, Enable ) VALUES ( 1004, N'Product category' , N'Product category', N'frmProductCategory', N'frmProductCategory', 1 )
END

IF NOT EXISTS ( SELECT TOP 1 1 FROM dbo.[Function] WHERE FunctionID = 1005 )
BEGIN
	INSERT INTO dbo.[Function] ( FunctionID, VNName, ENName, VNDescription, ENDescription, Enable ) VALUES ( 1005, N'Product' , N'Product', N'frmProduct', N'frmProduct', 1 )
END

IF NOT EXISTS ( SELECT TOP 1 1 FROM dbo.[Function] WHERE FunctionID = 1006 )
BEGIN
	INSERT INTO dbo.[Function] ( FunctionID, VNName, ENName, VNDescription, ENDescription, Enable ) VALUES ( 1006, N'Unit' , N'Unit', N'frmUnit', N'frmUnit', 1 )
END