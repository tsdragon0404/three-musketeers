SET NOCOUNT ON;

/* Default Branch - ID: 1 */

INSERT INTO dbo.BRANDINGTEXT ( [BRANCHID], [KEY], [VNVALUE], [ENVALUE] )
VALUES 
(1, N'OrderStatus.Ordered', N'Chưa chuyển bếp', N'Ordered'),
(1, N'OrderStatus.SentToKitchen', N'Đã chuyển bếp', N'Sent to Kitchen'),
(1, N'OrderStatus.KitchenAccepted', N'Bếp nhận', N'Kitchen Accepted'),
(1, N'OrderStatus.KitchenRejected', N'Bếp trả lại', N'Kitchen Rejected'),
(1, N'OrderStatus.Done', N'Giao khách', N'Done')

GO