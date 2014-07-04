
DELETE FROM dbo.ErrorMessage
GO
INSERT INTO dbo.ErrorMessage ( ErrorMessageID, MessageID, BranchID, ENMessage, VNMessage )
VALUES 
( -1, -1, 0, N'Incorrect username or password', N'Tên đăng nhập hoặc mật khẩu không chính xác' ),
( -2, -2, 0, N'This user is temporary locked, please contact admin', N'Tài khoản tạm khóa, vui lòng liên hệ quản trị viên' ),
( -3, -3, 0, N'This user cannot log into this branch. Please contact administrator.', N'Tài khoản này không có quyền truy cập vào chi nhánh này. Vui lòng liên hệ quản trị viên' ),

( 1, 1, 1, N'{0} is not valid', N'{0} không hợp lệ' )
GO
