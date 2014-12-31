SET NOCOUNT ON;

SET IDENTITY_INSERT [dbo].[Branch] ON 

GO
INSERT [dbo].[Branch] ([BranchID], [VNName], [ENName], [CurrencyID], [UseServiceFee], [ServiceFee], [UseDiscountOnProduct], [UseKitchenFunction], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (1, N'Default Branch', N'Default Branch', 1, 0, CAST(20000.00 AS Numeric(12, 2)), 0, 0, 1, 1, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Branch] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 

GO
INSERT [dbo].[ProductCategory] ([ProductCategoryID], [ProductCategoryCode], [VNName], [ENName], [VNDescription], [ENDescription], [BranchID], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (1, N'MONAN', N'Món ăn', N'Food', NULL, NULL, 1, 1, 1, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[ProductCategory] ([ProductCategoryID], [ProductCategoryCode], [VNName], [ENName], [VNDescription], [ENDescription], [BranchID], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (2, N'NUOCUONG', N'Nước uống', N'Soft drink', NULL, NULL, 1, 1, 2, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[ProductCategory] ([ProductCategoryID], [ProductCategoryCode], [VNName], [ENName], [VNDescription], [ENDescription], [BranchID], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (3, N'KHAC', N'Khác', N'Other', NULL, NULL, 1, 1, 3, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[Unit] ON 

GO
INSERT [dbo].[Unit] ([UnitID], [BranchID], [VNName], [ENName], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (1, 1, N'Dĩa', N'Plate', 1, 1, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Unit] ([UnitID], [BranchID], [VNName], [ENName], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (2, 1, N'Ký', N'Kg', 1, 2, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Unit] ([UnitID], [BranchID], [VNName], [ENName], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (3, 1, N'Cái', N'Piece', 1, 3, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Unit] ([UnitID], [BranchID], [VNName], [ENName], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (4, 1, N'Chai', N'Bottle', 1, 4, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Unit] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

GO
INSERT [dbo].[Product] ([ProductID], [ProductCode], [VNName], [ENName], [VNDescription], [ENDescription], [UnitID], [ProductCategoryID], [Price], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (1, N'COM001', N'Cơm trắng', N'Rice', NULL, NULL, 1, 1, CAST(25000.00 AS Numeric(12, 2)), 1, 1, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Product] ([ProductID], [ProductCode], [VNName], [ENName], [VNDescription], [ENDescription], [UnitID], [ProductCategoryID], [Price], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (2, N'COM002', N'Cơm gà', N'Chicken rice', NULL, NULL, 1, 1, CAST(35000.00 AS Numeric(12, 2)), 1, 2, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Product] ([ProductID], [ProductCode], [VNName], [ENName], [VNDescription], [ENDescription], [UnitID], [ProductCategoryID], [Price], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (3, N'BIA001', N'Bia Heineken', N'Heineken', NULL, NULL, 4, 2, CAST(20000.00 AS Numeric(12, 2)), 1, 3, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Product] ([ProductID], [ProductCode], [VNName], [ENName], [VNDescription], [ENDescription], [UnitID], [ProductCategoryID], [Price], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (4, N'BIA002', N'Bia Tiger', N'Tiger', NULL, NULL, 4, 2, CAST(17000.00 AS Numeric(12, 2)), 1, 4, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Product] ([ProductID], [ProductCode], [VNName], [ENName], [VNDescription], [ENDescription], [UnitID], [ProductCategoryID], [Price], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (5, N'LAU001', N'Lẩu gà', N'Hot pot 1', NULL, NULL, 3, 1, CAST(150000.00 AS Numeric(12, 2)), 1, 5, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Product] ([ProductID], [ProductCode], [VNName], [ENName], [VNDescription], [ENDescription], [UnitID], [ProductCategoryID], [Price], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (6, N'LAU002', N'Lẩu dê', N'Hot pot 2', NULL, NULL, 3, 1, CAST(170000.00 AS Numeric(12, 2)), 1, 6, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Product] ([ProductID], [ProductCode], [VNName], [ENName], [VNDescription], [ENDescription], [UnitID], [ProductCategoryID], [Price], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (7, N'KHAC001', N'Dưa leo', N'Cucumber', NULL, NULL, 2, 1, CAST(15000.00 AS Numeric(12, 2)), 1, 7, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Product] ([ProductID], [ProductCode], [VNName], [ENName], [VNDescription], [ENDescription], [UnitID], [ProductCategoryID], [Price], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (11, N'KHAC001', N'Khăn lạnh', N'Towels', NULL, NULL, 3, 3, CAST(5000.00 AS Numeric(12, 2)), 1, 8, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Area] ON 

GO
INSERT [dbo].[Area] ([AreaID], [VNName], [ENName], [BranchID], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (1, N'Khu vực 1', N'Area 1', 1, 1, 1, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Area] ([AreaID], [VNName], [ENName], [BranchID], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (2, N'Khu vực 2', N'Area 2', 1, 1, 2, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Area] ([AreaID], [VNName], [ENName], [BranchID], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (3, N'Khu vực 3', N'Area 3', 1, 1, 3, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Area] ([AreaID], [VNName], [ENName], [BranchID], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (4, N'Khu vực 4', N'Area 4', 1, 1, 4, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Area] ([AreaID], [VNName], [ENName], [BranchID], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (5, N'Khu vực 5', N'Area 5', 1, 1, 5, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Area] ([AreaID], [VNName], [ENName], [BranchID], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (6, N'Khu vực 6', N'Area 6', 1, 1, 6, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Area] OFF
GO
SET IDENTITY_INSERT [dbo].[Table] ON 

GO
INSERT [dbo].[Table] ([TableID], [VNName], [ENName], [AreaID], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (1, N'Bàn 1', N'Table 1', 1, 1, 1, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Table] ([TableID], [VNName], [ENName], [AreaID], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (2, N'Bàn 2', N'Table 2', 1, 1, 2, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Table] ([TableID], [VNName], [ENName], [AreaID], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (3, N'Bàn 3', N'Table 3', 1, 1, 3, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Table] ([TableID], [VNName], [ENName], [AreaID], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (4, N'Bàn 4', N'Table 4', 1, 1, 4, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Table] ([TableID], [VNName], [ENName], [AreaID], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (5, N'Bàn 5', N'Table 5', 2, 1, 5, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Table] ([TableID], [VNName], [ENName], [AreaID], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (6, N'Bàn 6', N'Table 6', 2, 1, 6, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Table] ([TableID], [VNName], [ENName], [AreaID], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (7, N'Bàn 7', N'Table 7', 2, 1, 7, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Table] ([TableID], [VNName], [ENName], [AreaID], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (8, N'Bàn 8', N'Table 8', 3, 1, 8, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Table] ([TableID], [VNName], [ENName], [AreaID], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (9, N'Bàn 9', N'Table 9', 3, 1, 9, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Table] ([TableID], [VNName], [ENName], [AreaID], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (10, N'Bàn 10', N'Table 10', 3, 1, 10, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Table] ([TableID], [VNName], [ENName], [AreaID], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (11, N'Bàn 11', N'Table 11', 4, 1, 11, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Table] ([TableID], [VNName], [ENName], [AreaID], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (12, N'Bàn 12', N'Table 12', 4, 1, 12, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Table] ([TableID], [VNName], [ENName], [AreaID], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (13, N'Bàn 13', N'Table 13', 5, 1, 13, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Table] ([TableID], [VNName], [ENName], [AreaID], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (14, N'Bàn 14', N'Table 14', 5, 1, 14, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Table] ([TableID], [VNName], [ENName], [AreaID], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (15, N'Bàn 15', N'Table 15', 6, 1, 15, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Table] ([TableID], [VNName], [ENName], [AreaID], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (16, N'Bàn 16', N'Table 16', 6, 1, 16, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
INSERT [dbo].[Table] ([TableID], [VNName], [ENName], [AreaID], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (17, N'Bàn 17', N'Table 17', 6, 1, 17, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Table] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

GO
INSERT [dbo].[Customer] ([CustomerID], [CustomerCode], [CustomerName], [BranchID], [Enable], [SEQ], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (1, N'DEFAULT', N'Khách vãng lai / Anonymous', 1, 1, 1, CAST(0x0000A33B00000000 AS DateTime), N'system', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO

INSERT INTO BranchInfo ( BranchID, CompanyCode, CompanyName, Phone, Fax, Email, TaxCode, Address )
VALUES (1, 'COMPANYCODE', 'Company Name', '08-9898-548', '08-9898-548', 'info@company.com', '849-89AR', '1 Homepage - SMS' )
GO

INSERT [dbo].[PageLabel] ([LabelID], [BranchID], [PageID], [VNText], [ENText]) 
VALUES 
(N'lblLanguage', 1, 0, N'Tiếng Anh', N'Vietnamese'),
(N'lblEditLabel', 1, 0, N'Sửa tên hiển thị', N'Edit label'),
(N'lblUser', 1, 0, N'Người dùng', N'User'),
(N'lblNoRecords', 1, 0, N'Không có dữ liệu.', N'No records found.'),
(N'lblSearch', 1, 0, N'Tìm kiếm', N'Search')
GO
