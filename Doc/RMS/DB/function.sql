IF NOT EXISTS ( SELECT TOP 1 1 FROM dbo.[Function] WHERE FunctionID = 1000 )
BEGIN
	INSERT INTO dbo.[Function] ( FunctionID, VNName, ENName, VNDescription, ENDescription, Enable ) VALUES ( 1000, N'Main', N'Main', 'frmMain', 'frmMain', 1 )
END

IF NOT EXISTS ( SELECT TOP 1 1 FROM dbo.[Function] WHERE FunctionID = 1001 )
BEGIN
	INSERT INTO dbo.[Function] ( FunctionID, VNName, ENName, VNDescription, ENDescription, Enable ) VALUES ( 1001, N'User', N'User', N'frmUser: thêm/sửa/xóa một user', 'frmUser: insert/update/delete user', 1 )
END

IF NOT EXISTS ( SELECT TOP 1 1 FROM dbo.[Function] WHERE FunctionID = 1002 )
BEGIN
	INSERT INTO dbo.[Function] ( FunctionID, VNName, ENName, VNDescription, ENDescription, Enable ) VALUES ( 1002, N'Branch', N'Branch', 'frmBranch', 'frmBranch', 1 )
END

IF NOT EXISTS ( SELECT TOP 1 1 FROM dbo.[Function] WHERE FunctionID = 1003 )
BEGIN
	INSERT INTO dbo.[Function] ( FunctionID, VNName, ENName, VNDescription, ENDescription, Enable ) VALUES ( 1003, N'Login', N'Login', 'frmLoginAdmin', 'frmLoginAdmin', 1 )
END

IF NOT EXISTS ( SELECT TOP 1 1 FROM dbo.[Function] WHERE FunctionID = 1004 )
BEGIN
	INSERT INTO dbo.[Function] ( FunctionID, VNName, ENName, VNDescription, ENDescription, Enable ) VALUES ( 1004, N'Product category', N'Product category', 'frmProductCategory', 'frmProductCategory', 1 )
END