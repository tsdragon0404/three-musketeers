
DELETE FROM dbo.ErrorMessage
GO
INSERT INTO dbo.ErrorMessage ( ErrorMessageID, BranchID, ENMessage, VNMessage )
VALUES 
( 1, 1, N'{0} is not valid', N'{0} không hợp lệ' ),
( 2, 1, N'Incorrect username or password', N'Tên đăng nhập hoặc mật khẩu không chính xác' ),
( 3, 1, N'{0} is not valid', N'{0} không hợp lệ' )

GO
