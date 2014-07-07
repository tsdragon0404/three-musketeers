INSERT INTO [User] ( UserName, Password, DisplayName, IsSystemAdmin )
VALUES ( 'system', '123', 'system', 1)
GO

INSERT INTO dbo.Page ( PageID, VNTitle, ENTitle, VNDescription, ENDescription, Area, Controller, [Action] )
VALUES 
( 0, N'Global', N'Global', N'Global', N'Global', NULL, NULL, NULL ),
( 1, N'Trang chủ', N'Homepage', N'Trang chủ', N'Homepage', NULL, N'Home', N'Index' ),
( 2, N'Thanh toán', N'Cashier', N'Thanh toán', N'Cashier', NULL, N'Cashier', N'Index' ),
( 3, N'Bếp', N'Kitchen', N'Bếp', N'Kitchen', NULL, N'Kitchen', N'Index' ),
( 4, N'Đăng nhập', N'Login', N'Đăng nhập', N'Login', NULL, N'Account', N'Login' ),

( 99, N'Xem thống kê', N'Report viewer', N'Xem thống kê', N'Report viewer', NULL, NULL, N'/Reports/ReportViewer.aspx' ),

( 20, N'Branch', N'Branch', N'Branch', N'Branch', N'Branch', N'BranchHome', N'Index' ),
( 21, N'Global label', N'Global label', N'Global label', N'Global label', N'Branch', N'GlobalLabel', N'Index' ),
( 22, N'Role', N'Role', N'Role', N'Role', N'Branch', N'Role', N'Index' ),
( 23, N'User', N'User', N'User', N'User', N'Branch', N'User', N'Index' ),

( 40, N'BranchData', N'BranchData', N'BranchData', N'BranchData', N'BranchData', N'BranchDataHome', N'Index' ),
( 41, N'Khu vực', N'Area', N'Quản lý khu vực', N'Maintain area', N'BranchData', N'Area', N'Index' ),
( 42, N'Bàn', N'Table', N'Quản lý bàn', N'Maintain table', N'BranchData', N'Table', N'Index' ),
( 43, N'Nhóm sản phẩm', N'Product Category', N'Quản lý nhóm sản phẩm', N'Maintain product category', N'BranchData', N'ProductCategory', N'Index' )
GO

INSERT INTO dbo.PageMenu ( GroupName, PageID, SEQ )
VALUES 
( N'MainMenu', 1, 10 ),
( N'MainMenu', 2, 20 ),
( N'MainMenu', 3, 30 ),
( N'MainMenu', 20, 40 ),
( N'MainMenu', 40, 50 ),

( N'BranchTabMenu', 21, 10 ),
( N'BranchTabMenu', 22, 20 ),
( N'BranchTabMenu', 23, 30 ),

( N'BranchDataTabMenu', 41, 10 ),
( N'BranchDataTabMenu', 42, 20 ),
( N'BranchDataTabMenu', 43, 30 )

INSERT INTO dbo.OrderStatus ( [OrderStatusID], [VNName], [ENName] )
VALUES 
(1, N'Chưa chuyển bếp', N'Chưa chuyển bếp'),
(2, N'Đã chuyển bếp', N'Đã chuyển bếp'),
(3, N'Bếp nhận', N'Bếp nhận'),
(4, N'Bếp trả lại', N'Bếp trả lại'),
(5, N'Giao khách', N'Giao khách')
GO

INSERT INTO dbo.ErrorMessage ( ErrorMessageID, MessageID, BranchID, ENMessage, VNMessage )
VALUES 
( -1, -1, 0, N'Incorrect username or password.', N'Tên đăng nhập hoặc mật khẩu không chính xác.' ),
( -2, -2, 0, N'This user is temporary locked, please contact administrator.', N'Tài khoản tạm khóa, vui lòng liên hệ quản trị viên.' ),
( -3, -3, 0, N'This user cannot log into this branch. Please contact administrator.', N'Tài khoản này không có quyền truy cập vào chi nhánh này. Vui lòng liên hệ quản trị viên.' ),

( 1, 1, 1, N'{0} is not valid', N'{0} không hợp lệ' )
GO