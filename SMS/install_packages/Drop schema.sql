SET NOCOUNT ON;

DECLARE @str VARCHAR(2000) = '';
        
DECLARE cur CURSOR FAST_FORWARD READ_ONLY FOR
SELECT 'ALTER TABLE [dbo].[' + OBJECT_NAME(parent_object_id) + '] DROP CONSTRAINT [' + OBJECT_NAME(constraint_object_id) + ']'
FROM sys.foreign_key_columns
WHERE OBJECT_NAME(parent_object_id) IN ('Area', 'Branch', 'BranchInfo', 'BranchTax', 'Currency', 'Customer', 'ErrorMessage', 
                                        'Invoice', 'InvoiceDetail', 'InvoiceDiscount', 'InvoiceTable', 'Product', 'ProductCategory', 
                                        'ProductPriceHistory', 'SystemInfomation', 'Table', 'Tax', 'Unit', 'User', 'UserBranch', 
                                        'Page', 'PageLabel', 'OrderTable', 'Order', 'OrderDetail', 'OrderStatus', 'OrderDiscount',
                                        'UserBranch', 'UserConfig', 'UsersInRole', 'RolePermission', 'Role', 'ReportDatasourceParameter', 'ReportDatasource',
                                        'Report', 'PageMenu', 'Reject', 'BrandingText', 'SystemInformation', 'UploadedFile',
										'VENDOR', 'ITEM', 'DEPOT', 'DELIVERYITEM', 'DELIVERYNOTE', 'DELIVERYTYPE', 'RECEIPTITEM', 'RECEIPTNOTE', 'RECEIPTVOUCHER', 'PAYMENTVOUCHER',
										'INVENTORY')
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
    AND name IN (    'Area', 'Branch', 'BranchInfo', 'BranchTax', 'Currency', 'Customer', 'ErrorMessage', 
                    'Invoice', 'InvoiceDetail', 'InvoiceDiscount', 'InvoiceTable', 'Product', 'ProductCategory', 
                    'ProductPriceHistory', 'SystemInfomation', 'Table', 'Tax', 'Unit', 'User', 'UserBranch', 
                    'Page', 'PageLabel', 'OrderTable', 'Order', 'OrderDetail', 'OrderStatus', 'OrderDiscount',
                    'UserBranch', 'UserConfig', 'UsersInRole', 'RolePermission', 'Role', 'ReportDatasourceParameter', 'ReportDatasource',
                    'Report', 'PageMenu', 'Reject', 'BrandingText', 'SystemInformation', 'UploadedFile',
					'VENDOR', 'ITEM', 'DEPOT', 'DELIVERYITEM', 'DELIVERYNOTE', 'DELIVERYTYPE', 'RECEIPTITEM', 'RECEIPTNOTE',
					'INVENTORY', 'RECEIPTVOUCHER', 'PAYMENTVOUCHER')
OPEN cur
FETCH NEXT FROM cur INTO @str
WHILE @@FETCH_STATUS = 0
BEGIN
    EXECUTE(@str)     

FETCH NEXT FROM cur INTO @str      
END
CLOSE cur
DEALLOCATE cur