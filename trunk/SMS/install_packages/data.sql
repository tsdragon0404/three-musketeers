SET NOCOUNT ON;

INSERT INTO [User] ( UserName, Password, IsSystemAdmin )
VALUES ( 'system', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1)
GO

INSERT INTO dbo.Page ( PageID, VNTitle, ENTitle, VNDescription, ENDescription, [Type], Area, Controller, [Action] )
VALUES 
( 0, N'Global', N'Global', N'Global', N'Global', 0, NULL, NULL, NULL ),
( 1, N'Trang chủ', N'Homepage', N'Trang chủ', N'Homepage', 0, NULL, N'Home', N'Index' ),
( 2, N'Thanh toán', N'Cashier', N'Thanh toán', N'Cashier', 1, NULL, N'Cashier', N'Index' ),
( 3, N'Bếp', N'Kitchen', N'Bếp', N'Kitchen', 1, NULL, N'Kitchen', N'Index' ),
( 4, N'Đăng nhập', N'Login', N'Đăng nhập', N'Login', 0, NULL, N'Account', N'Login' ),
( 5, N'Không có quyền truy cập', N'Access denied', N'Không có quyền truy cập', N'Access denied', 0, NULL, N'Error', N'AccessDenied' ),
( 6, N'Lỗi', N'Unknown error', N'Lỗi', N'Unknown Error', 0, NULL, N'Error', N'Unknown' ),
( 7, N'Không tìm thấy', N'File not found', N'Không tìm thấy', N'File not found', 0, NULL, N'Error', N'NotFound' ),
( 8, N'Thông tin cá nhân', N'Edit profile', N'Sửa thông tin cá nhân', N'Edit profile', 0, NULL, N'Account', N'Edit' ),
( 9, N'Kho hàng', N'Inventory', N'Kho hàng', N'Inventory', 1, NULL, N'Inventory', N'Index' ),


( 20, N'Chi nhánh', N'Branch', N'Chi nhánh', N'Branch', 1, NULL, NULL, N'#' ),
( 21, N'Label', N'Label', N'Label', N'Label', 1, N'Branch', N'GlobalLabel', N'Index' ),
( 22, N'Quyền truy cập', N'Role', N'Quyền truy cập', N'Role', 1, N'Branch', N'Role', N'Index' ),
( 23, N'Người sử dụng', N'User', N'Quản lý người dùng', N'User', 1, N'Branch', N'User', N'Index' ),

( 40, N'Dữ liệu', N'Data', N'Quản lý dữ liệu', N'Data management', 1, NULL, NULL, N'#' ),
( 41, N'Khu vực', N'Area', N'Quản lý khu vực', N'Maintain area', 1, N'BranchData', N'Area', N'Index' ),
( 42, N'Bàn', N'Table', N'Quản lý bàn', N'Maintain table', 1, N'BranchData', N'Table', N'Index' ),
( 43, N'Nhóm sản phẩm', N'Product Category', N'Quản lý nhóm sản phẩm', N'Maintain product category', 1, N'BranchData', N'ProductCategory', N'Index' ),
( 44, N'Sản phẩm', N'Product', N'Quản lý sản phẩm', N'Maintain product', 1, N'BranchData', N'Product', N'Index' ),
( 45, N'Đơn vị tính', N'Unit', N'Quản lý đơn vị tính', N'Maintain unit', 1, N'BranchData', N'Unit', N'Index' ),

( 60, N'Dashboard', N'Dashboard', N'Dashboard', N'Dashboard', 1, N'Report', N'Dashboard', N'Index' ),

( 80, N'Hệ thống', N'System', N'Hệ thống', N'System', 2, NULL, NULL, N'#' ),
( 81, N'Chi nhánh', N'Branch', N'Quản lý chi nhánh', N'Branch', 2, N'System', N'Branch', N'Index' ),
( 82, N'Người sử dụng', N'User', N'Quản lý người sử dụng', N'User', 2, N'System', N'User', N'Index' ),
( 83, N'Dữ liệu', N'Data', N'Thiết lập dữ liệu', N'Data', 2, NULL, NULL, N'#' ),
( 84, N'Thuế', N'Tax', N'Thuế', N'Tax', 2, N'SystemData', N'Tax', N'Index' ),
( 85, N'Tiền tệ', N'Currency', N'Loại tiền tệ', N'Setup currency', 2, N'SystemData', N'Currency', N'Index' ),
( 86, N'Cài đặt', N'Setting', N'Cài đặt hệ thống', N'Setting', 2, N'System', N'Configuration', N'Index' ),
( 87, N'Thông tin sử dụng', N'About', N'Thông tin sử dụng', N'About', 2, N'System', N'About', N'Index' ),
( 88, N'Quản lý truy cập', N'User Access', N'Quản lý truy cập', N'User Access', 2, N'System', N'UserAccess', N'Index' ),
( 89, N'Thiết lập kho hàng', N'Setup depot', N'Thiết lập kho hàng', N'Setup depot', 2, N'System', N'Depot', N'Index' )
GO

INSERT INTO dbo.PageMenu ( PageMenuID, GroupName, ParentID, PageID, SEQ )
VALUES 
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

( 24, N'MainMenu', 0, 9, 40 ),
( 25, N'MainMenu', 9, 89, 11 ),

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

INSERT [dbo].[PageLabel] ([LabelID], [BranchID], [PageID], [VNText], [ENText]) 
VALUES 
(N'lblLanguage', 0, 0, N'Tiếng Anh', N'Vietnamese'),
(N'lblUsername', 0, 0, N'Tên đăng nhập', N'User name'),
(N'lblPassword', 0, 0, N'Mật khẩu', N'Password'),
(N'lblBranch', 0, 0, N'Chi nhánh', N'Branch'),
(N'lblLogin', 0, 0, N'Đăng nhập', N'Login')
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
( -12, -12, 0, N'Error', N'Lỗi' ),
( -13, -13, 0, N'Success', N'Thành công' ),
( -14, -14, 0, N'Error occurs. Please contact administrator.', N'Có lỗi xảy ra. Vui lòng liên hệ quản trị viên' ),
( -15, -15, 0, N'System data have been reseted.', N'Đã hoàn thành làm mới dữ liệu hệ thống.' ),
( -16, -16, 0, N'This browser does not support FileReader. Please contact administrator.', N'Trình duyệt không hỗ trợ FileReader. Vui lòng liên hệ quản trị viên.' ),
( -17, -17, 0, N'Incorrect file format. Please try again.', N'Không hỗ trợ định dạng này. Vui lòng thử lại' ),
( -18, -18, 0, N'Yes', N'Có' ),
( -19, -19, 0, N'No', N'Không' ),
( -20, -20, 0, N'Ok', N'Chấp nhận' ),
( -21, -21, 0, N'Cancel', N'Hủy bỏ' ),
( -22, -22, 0, N'Something went wrong.</br><a class="{0}">Click here</a> for more detail.', N'Có lỗi xảy ra.</br><a class="{0}">Nhấn vào đây</a> để xem chi tiết.' ),

( -23, -23, 0, N'First', N'Đầu' ),
( -24, -24, 0, N'Last', N'Cuối' ),
( -25, -25, 0, N'Next', N'Tiếp' ),
( -26, -26, 0, N'Previous', N'Trước' ),
( -27, -27, 0, N'No data available', N'Không có dữ liệu' ),
( -28, -28, 0, N'Showing _START_ to _END_ of _TOTAL_ entries', N'Dòng _START_ đến _END_ trên tổng số _TOTAL_ dòng' ),
( -29, -29, 0, N'No entries', N'Không có dòng nào' ),
( -30, -30, 0, N'(filtered from _MAX_ total entries)', N'(lọc trong tổng _MAX_ dòng)' ),
( -31, -31, 0, N'Show _MENU_ entries', N'Hiển thị _MENU_ dòng' ),
( -32, -32, 0, N'Search:', N'Tìm kiếm' ),
( -33, -33, 0, N'No matching records found', N'Không có dữ liệu phù hợp' ),
( -34, -34, 0, N'Cannot get user config. Please contact administrator.', N'Không thể lấy dữ liệu người dùng. Vui lòng liên hệ quản trị viên.' ),
( -35, -35, 0, N'This user is suspended at this branch. Please contact administrator.', N'Tài khoản này đã bị khóa tại chi nhánh này. Vui lòng liên hệ quản trị viên.' )
GO

INSERT INTO [dbo].[Currency] ([Name], [Description], [Exchange], [Enable], [SEQ], [CreatedDate], [CreatedUser]) 
VALUES
(N'₫', N'VND(₫) - Viet Nam Dong', 1, 1, 1, GETDATE(), N'system'),
(N'$', N'USD($) - United States Dollar', 1, 1, 2, GETDATE(), N'system'),
(N'¥', N'JPT(¥) - Japan Yen', 1, 1, 3, GETDATE(), N'system'),
(N'₩', N'KRW(₩) - Korea Won', 1, 1, 4, GETDATE(), N'system')
GO

INSERT INTO [dbo].[Tax] ([Name], [Description], [Value], [Enable], [SEQ], [CreatedDate], [CreatedUser])
VALUES (N'VAT', N'Value-added tax', 10, 1, 1, GETDATE(), N'system')
GO

INSERT INTO SystemInformation(Name, Description, Value, Type)
VALUES
('ProductName', 'Product name', 'SMS - Shop management system', 1),
('ProductVersion', 'Product version', '1.0.0', 1),
('ServerApplication', 'Server application', 'Internet Information Services (IIS) 8.0', 1),
('DatabaseApplication', 'Database application', RTRIM(LEFT(CAST(@@VERSION AS VARCHAR(500)), CHARINDEX(CHAR(9), CAST(@@VERSION AS VARCHAR(500)), 0) - 2)), 1),
('DevelopedBy', 'Developed by', 'SOLA Solutions', 1),

( N'SmtpHost', 'Host', N'smtp.gmail.com', 2 ),
( N'SmtpPort', 'Port number', N'587', 2 ),
( N'SmtpUser', 'User name', N'smstest987', 2 ),
( N'SmtpPass', 'Password', N'testingemail', 2 ),
( N'FileUploadPath', 'Physical path', N'C:\Program Files (x86)\SOLA Solutions\SMS\FileUpload\', 2 )
GO