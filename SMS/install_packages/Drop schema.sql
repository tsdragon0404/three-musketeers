﻿DECLARE @str VARCHAR(2000) = '';
        
DECLARE cur CURSOR FAST_FORWARD READ_ONLY FOR
SELECT 'ALTER TABLE [dbo].[' + OBJECT_NAME(parent_object_id) + '] DROP CONSTRAINT [' + OBJECT_NAME(constraint_object_id) + ']'
FROM sys.foreign_key_columns
WHERE OBJECT_NAME(parent_object_id) IN ('Area', 'Branch', 'BranchTax', 'Currency', 'Customer', 'ErrorMessage', 
										'Invoice', 'InvoiceDetail', 'InvoiceDiscount', 'InvoiceTable', 'Product', 'ProductCategory', 
										'ProductPriceHistory', 'SystemInfomation', 'Table', 'Tax', 'Unit', 'User', 'UserBranch', 
										'Page', 'PageLabel', 'OrderTable', 'Order', 'OrderDetail', 'OrderStatus', 'OrderDiscount')    
OPEN cur
FETCH NEXT FROM cur INTO @str
WHILE @@FETCH_STATUS = 0
BEGIN
	EXECUTE(@str)     

FETCH NEXT FROM cur INTO @str      
END
CLOSE cur
DEALLOCATE cur

DECLARE cur CURSOR FAST_FORWARD READ_ONLY FOR
SELECT 'DROP TABLE [dbo].[' + name + ']'
FROM sys.objects
WHERE type = 'U'
	AND name IN (	'Area', 'Branch', 'BranchTax', 'Currency', 'Customer', 'ErrorMessage', 
					'Invoice', 'InvoiceDetail', 'InvoiceDiscount', 'InvoiceTable', 'Product', 'ProductCategory', 
					'ProductPriceHistory', 'SystemInfomation', 'Table', 'Tax', 'Unit', 'User', 'UserBranch', 
					'Page', 'PageLabel', 'OrderTable', 'Order', 'OrderDetail', 'OrderStatus', 'OrderDiscount')
OPEN cur
FETCH NEXT FROM cur INTO @str
WHILE @@FETCH_STATUS = 0
BEGIN
	EXECUTE(@str)     

FETCH NEXT FROM cur INTO @str      
END
CLOSE cur
DEALLOCATE cur