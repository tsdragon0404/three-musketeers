
DELETE FROM dbo.ErrorMessage
GO
INSERT INTO dbo.ErrorMessage ( ErrorMessageID, BranchID, ENMessage, VNMessage )
VALUES 
( 1, 1, N'{0} is not valid', N'{0} không hợp lệ' ),
( 2, 1, N'Incorrect username or password', N'Tên đăng nhập hoặc mật khẩu không chính xác' ),
( 3, 1, N'This user is temporary locked, please contact admin', N'Tài khoản tạm khóa, vui lòng liên hệ quản trị viên' ),
( 4, 1, N'No branch available for this user. Please contact administrator.', N'Tài khoản này không có quyền truy cập vào bất cứ chi nhánh nào. Vui lòng liên hệ quản trị viên' )

GO
