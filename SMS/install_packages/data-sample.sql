SET NOCOUNT ON;

SET IDENTITY_INSERT [dbo].[Branch] ON 

GO
INSERT [dbo].[BRANCH] ([ID], [VNNAME], [ENNAME], [CURRENCYID], [USESERVICEFEE], [SERVICEFEE], [USEDISCOUNTONPRODUCT], [USEKITCHENFUNCTION], [ENABLE], [SEQ], [CREATEDDATE], [CREATEDUSER], [MODIFIEDDATE], [MODIFIEDUSER]) VALUES (1, N'Default Branch', N'Default Branch', 1, 0, CAST(20000.00 AS Numeric(12, 2)), 0, 0, 1, 1, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Branch] OFF
GO

INSERT INTO BRANCHINFO ( ID, COMPANYCODE, COMPANYNAME, PHONE, FAX, EMAIL, TAXCODE, ADDRESS )
VALUES (1, 'COMPANYCODE', 'Company Name', '08-9898-548', '08-9898-548', 'info@company.com', '849-89AR', '1 Homepage - SMS' )
GO

INSERT [dbo].[PAGELABEL] ([LABELID], [BRANCHID], [PAGEID], [VNTEXT], [ENTEXT]) 
VALUES 
(N'lblLanguage', 1, 0, N'Tiếng Anh', N'Vietnamese'),
(N'lblEditLabel', 1, 0, N'Sửa tên hiển thị', N'Edit label'),
(N'lblUser', 1, 0, N'Người dùng', N'User'),
(N'lblNoRecords', 1, 0, N'Không có dữ liệu.', N'No records found.'),
(N'lblSearch', 1, 0, N'Tìm kiếm', N'Search')
GO
