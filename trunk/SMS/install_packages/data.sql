SET NOCOUNT ON;

INSERT INTO [User] ( UserName, Password, IsSystemAdmin )
VALUES ( 'system', '123', 1)
GO

INSERT INTO dbo.Page ( PageID, VNTitle, ENTitle, VNDescription, ENDescription, Area, Controller, [Action] )
VALUES 
( 0, N'Global', N'Global', N'Global', N'Global', NULL, NULL, NULL ),
( 1, N'Trang chủ', N'Homepage', N'Trang chủ', N'Homepage', NULL, N'Home', N'Index' ),
( 2, N'Thanh toán', N'Cashier', N'Thanh toán', N'Cashier', NULL, N'Cashier', N'Index' ),
( 3, N'Bếp', N'Kitchen', N'Bếp', N'Kitchen', NULL, N'Kitchen', N'Index' ),
( 4, N'Đăng nhập', N'Login', N'Đăng nhập', N'Login', NULL, N'Account', N'Login' ),
( 5, N'Không có quyền truy cập', N'Access denied', N'Không có quyền truy cập', N'Access denied', NULL, N'Error', N'AccessDenied' ),
( 6, N'Lỗi', N'Unknown error', N'Lỗi', N'Unknown Error', NULL, N'Error', N'Unknown' ),
( 7, N'Không tìm thấy', N'File not found', N'Không tìm thấy', N'File not found', NULL, N'Error', N'NotFound' ),
( 8, N'Thông tin cá nhân', N'Edit profile', N'Sửa thông tin cá nhân', N'Edit profile', NULL, N'Account', N'Edit' ),

( 99, N'Xem thống kê', N'Report viewer', N'Xem thống kê', N'Report viewer', NULL, NULL, N'/Reports/ReportViewer.aspx' ),

( 20, N'Chi nhánh', N'Branch', N'Chi nhánh', N'Branch', NULL, NULL, N'#' ),
( 21, N'Label', N'Label', N'Label', N'Label', N'Branch', N'GlobalLabel', N'Index' ),
( 22, N'Quyền truy cập', N'Role', N'Quyền truy cập', N'Role', N'Branch', N'Role', N'Index' ),
( 23, N'Người sử dụng', N'User', N'Quản lý người dùng', N'User', N'Branch', N'User', N'Index' ),

( 40, N'Dữ liệu', N'Data', N'Quản lý dữ liệu', N'Data management', NULL, NULL, N'#' ),
( 41, N'Khu vực', N'Area', N'Quản lý khu vực', N'Maintain area', N'BranchData', N'Area', N'Index' ),
( 42, N'Bàn', N'Table', N'Quản lý bàn', N'Maintain table', N'BranchData', N'Table', N'Index' ),
( 43, N'Nhóm sản phẩm', N'Product Category', N'Quản lý nhóm sản phẩm', N'Maintain product category', N'BranchData', N'ProductCategory', N'Index' ),
( 44, N'Sản phẩm', N'Product', N'Quản lý sản phẩm', N'Maintain product', N'BranchData', N'Product', N'Index' ),
( 45, N'Đơn vị tính', N'Unit', N'Quản lý đơn vị tính', N'Maintain unit', N'BranchData', N'Unit', N'Index' ),

( 60, N'Dashboard', N'Dashboard', N'Dashboard', N'Dashboard', N'Report', N'Dashboard', N'Index' ),

( 80, N'Hệ thống', N'System', N'Hệ thống', N'System', NULL, NULL, N'#' ),
( 81, N'Chi nhánh', N'Branch', N'Quản lý chi nhánh', N'Branch', N'System', N'Branch', N'Index' ),
( 82, N'Người sử dụng', N'User', N'Quản lý người sử dụng', N'User', N'System', N'User', N'Index' ),
( 83, N'Dữ liệu', N'Data', N'Thiết lập dữ liệu', N'Data', NULL, NULL, N'#' ),
( 84, N'Thuế', N'Tax', N'Thuế', N'Tax', N'SystemData', N'Tax', N'Index' ),
( 85, N'Tiền tệ', N'Currency', N'Loại tiền tệ', N'Setup currency', N'SystemData', N'Currency', N'Index' ),
( 86, N'Cài đặt', N'Setting', N'Cài đặt hệ thống', N'Setting', N'System', N'Configuration', N'Index' ),
( 87, N'Thông tin sử dụng', N'About', N'Thông tin sử dụng', N'About', N'System', N'About', N'Index' ),
( 88, N'Quản lý truy cập', N'User Access', N'Quản lý truy cập', N'User Access', N'System', N'UserAccess', N'Index' )
GO

INSERT INTO dbo.PageMenu ( PageMenuID, GroupName, ParentID, PageID, SEQ )
VALUES 
( 1, N'MainMenu', 0, 1, 10 ),
( 2, N'MainMenu', 0, 2, 20 ),
( 3, N'MainMenu', 0, 3, 30 ),
( 4, N'MainMenu', 0, 20, 40 ),
( 5, N'MainMenu', 4, 40, 50 ),
( 6, N'MainMenu', 4, 21, 60 ),
( 7, N'MainMenu', 4, 22, 70 ),
( 8, N'MainMenu', 4, 23, 80 ),
( 9, N'MainMenu', 0, 80, 90 ),

( 10, N'MainMenu', 9, 81, 10 ),
( 11, N'MainMenu', 9, 82, 20 ),
( 12, N'MainMenu', 0, 60, 120 ),
( 13, N'MainMenu', 5, 41, 10 ),
( 14, N'MainMenu', 5, 42, 20 ),
( 15, N'MainMenu', 5, 43, 30 ),
( 16, N'MainMenu', 5, 44, 40 ),
( 17, N'MainMenu', 5, 45, 40 ),
( 18, N'MainMenu', 9, 83, 30 ),
( 19, N'MainMenu', 18, 84, 10 ),
( 20, N'MainMenu', 18, 85, 10 ),
( 21, N'MainMenu', 9, 86, 40 ),
( 22, N'MainMenu', 9, 87, 50 ),
( 23, N'MainMenu', 9, 88, 60 ),

( 50, N'SystemDataTabMenu', 0, 84, 10 ),
( 51, N'SystemDataTabMenu', 0, 85, 20 ),

( 80, N'BranchDataTabMenu', 0, 41, 10 ),
( 81, N'BranchDataTabMenu', 0, 42, 20 ),
( 82, N'BranchDataTabMenu', 0, 43, 30 ),
( 83, N'BranchDataTabMenu', 0, 44, 40 ),
( 84, N'BranchDataTabMenu', 0, 45, 50 ),

( 100, N'SystemTabMenu', 0, 81, 10 ),
( 101, N'SystemTabMenu', 0, 82, 20 )

GO

SET IDENTITY_INSERT [dbo].[PageLabel] ON 
GO
INSERT [dbo].[PageLabel] ([PageLabelID], [LabelID], [BranchID], [PageID], [VNText], [ENText]) 
VALUES 
(1, N'lblLanguage', 0, 0, N'Tiếng Anh', N'Vietnamese'),
(2, N'lblUsername', 0, 0, N'Tên đăng nhập', N'User name'),
(3, N'lblPassword', 0, 0, N'Mật khẩu', N'Password'),
(4, N'lblBranch', 0, 0, N'Chi nhánh', N'Branch'),
(5, N'lblLogin', 0, 0, N'Đăng nhập', N'Login')

GO
SET IDENTITY_INSERT [dbo].[PageLabel] OFF
GO

INSERT INTO dbo.ErrorMessage ( ErrorMessageID, MessageID, BranchID, ENMessage, VNMessage )
VALUES 
( -1, -1, 0, N'Incorrect username or password.', N'Tên đăng nhập hoặc mật khẩu không chính xác.' ),
( -2, -2, 0, N'This user is temporary locked, please contact administrator.', N'Tài khoản tạm khóa, vui lòng liên hệ quản trị viên.' ),
( -3, -3, 0, N'This user cannot log into this branch. Please contact administrator.', N'Tài khoản này không có quyền truy cập vào chi nhánh này. Vui lòng liên hệ quản trị viên.' ),
( -4, -4, 0, N'You don''t have permission to access this page.', N'Bạn không đủ quyền hạn truy cập trang này.' ),
( -5, -5, 0, N'Login required.', N'Bạn chưa đăng nhập.' ),
( -6, -6, 0, N'Branch not available.', N'Chi nhánh này không tồn tại.' ),
( -7, -7, 0, N'{0} is not valid.', N'{0} không hợp lệ.' ),
( -8, -8, 0, N'The requested data does not existed.', N'Dữ liệu không tồn tại.' ),
( -9, -9, 0, N'Forbidden.', N'Không được phép.' ),
( -10, -10, 0, N'Warning', N'Cảnh báo' ),
( -11, -11, 0, N'Are you sure you want to delete this session?', N'Bạn muốn xóa phiên truy cập này?' ),
( -12, -12, 0, N'Error', N'Lỗi' )

GO