IF EXISTS ( SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_UserBranch_User' )
	ALTER TABLE [dbo].[UserBranch] DROP CONSTRAINT [FK_UserBranch_User]
GO

IF EXISTS ( SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_UserBranch_Branch' )
	ALTER TABLE [dbo].[UserBranch] DROP CONSTRAINT [FK_UserBranch_Branch]
GO

IF EXISTS ( SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_Unit_Branch' )
	ALTER TABLE [dbo].[Unit] DROP CONSTRAINT [FK_Unit_Branch]
GO

IF EXISTS ( SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_PageLabel_Page' )
	ALTER TABLE [dbo].[PageLabel] DROP CONSTRAINT [FK_PageLabel_Page]
GO

IF EXISTS ( SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_Table_Area' )
	ALTER TABLE [dbo].[Table] DROP CONSTRAINT [FK_Table_Area]
GO

IF EXISTS ( SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_ProductPriceHistory_Product' )
	ALTER TABLE [dbo].[ProductPriceHistory] DROP CONSTRAINT [FK_ProductPriceHistory_Product]
GO

IF EXISTS ( SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_ProductCategory_Branch' )
	ALTER TABLE [dbo].[ProductCategory] DROP CONSTRAINT [FK_ProductCategory_Branch]
GO

IF EXISTS ( SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_Product_Unit' )
	ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_Unit]
GO

IF EXISTS ( SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_Product_ProductCategory' )
	ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_ProductCategory]
GO

IF EXISTS ( SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_InvoiceTable_Table' )
	ALTER TABLE [dbo].[InvoiceTable] DROP CONSTRAINT [FK_InvoiceTable_Table]
GO

IF EXISTS ( SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_InvoiceTable_Invoice' )
	ALTER TABLE [dbo].[InvoiceTable] DROP CONSTRAINT [FK_InvoiceTable_Invoice]
GO

IF EXISTS ( SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_InvoiceDiscount_Invoice' )
	ALTER TABLE [dbo].[InvoiceDiscount] DROP CONSTRAINT [FK_InvoiceDiscount_Invoice]
GO

IF EXISTS ( SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_InvoiceDetail_InvoiceTable' )
	ALTER TABLE [dbo].[InvoiceDetail] DROP CONSTRAINT [FK_InvoiceDetail_InvoiceTable]
GO

IF EXISTS ( SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_Invoice_User' )
	ALTER TABLE [dbo].[Invoice] DROP CONSTRAINT [FK_Invoice_User]
GO

IF EXISTS ( SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_Invoice_Customer' )
	ALTER TABLE [dbo].[Invoice] DROP CONSTRAINT [FK_Invoice_Customer]
GO

IF EXISTS ( SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_Invoice_Branch' )
	ALTER TABLE [dbo].[Invoice] DROP CONSTRAINT [FK_Invoice_Branch]
GO

IF EXISTS ( SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_Customer_Branch' )
	ALTER TABLE [dbo].[Customer] DROP CONSTRAINT [FK_Customer_Branch]
GO

IF EXISTS ( SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_BranchTax_Tax' )
	ALTER TABLE [dbo].[BranchTax] DROP CONSTRAINT [FK_BranchTax_Tax]
GO

IF EXISTS ( SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_BranchTax_Branch' )
	ALTER TABLE [dbo].[BranchTax] DROP CONSTRAINT [FK_BranchTax_Branch]
GO

IF EXISTS ( SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_Branch_Currency' )
	ALTER TABLE [dbo].[Branch] DROP CONSTRAINT [FK_Branch_Currency]
GO

IF EXISTS ( SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_Area_Branch' )
	ALTER TABLE [dbo].[Area] DROP CONSTRAINT [FK_Area_Branch]
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserBranch]') AND type in (N'U'))
	DROP TABLE [dbo].[UserBranch]
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
	DROP TABLE [dbo].[User]
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Unit]') AND type in (N'U'))
	DROP TABLE [dbo].[Unit]
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tax]') AND type in (N'U'))
	DROP TABLE [dbo].[Tax]
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Table]') AND type in (N'U'))
	DROP TABLE [dbo].[Table]
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SystemInfomation]') AND type in (N'U'))
	DROP TABLE [dbo].[SystemInfomation]
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductPriceHistory]') AND type in (N'U'))
	DROP TABLE [dbo].[ProductPriceHistory]
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductCategory]') AND type in (N'U'))
	DROP TABLE [dbo].[ProductCategory]
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
	DROP TABLE [dbo].[Product]
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceTable]') AND type in (N'U'))
	DROP TABLE [dbo].[InvoiceTable]
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceDiscount]') AND type in (N'U'))
	DROP TABLE [dbo].[InvoiceDiscount]
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceDetail]') AND type in (N'U'))
	DROP TABLE [dbo].[InvoiceDetail]
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Invoice]') AND type in (N'U'))
	DROP TABLE [dbo].[Invoice]
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ErrorMessage]') AND type in (N'U'))
	DROP TABLE [dbo].[ErrorMessage]
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
	DROP TABLE [dbo].[Customer]
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Currency]') AND type in (N'U'))
	DROP TABLE [dbo].[Currency]
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BranchTax]') AND type in (N'U'))
	DROP TABLE [dbo].[BranchTax]
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Branch]') AND type in (N'U'))
	DROP TABLE [dbo].[Branch]
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Area]') AND type in (N'U'))
	DROP TABLE [dbo].[Area]
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PageLabel]') AND type in (N'U'))
	DROP TABLE [dbo].[PageLabel]
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Page]') AND type in (N'U'))
	DROP TABLE [dbo].[Page]
GO