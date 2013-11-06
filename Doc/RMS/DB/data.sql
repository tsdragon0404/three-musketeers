INSERT INTO dbo.Branch ( BranchID, VNName, ENName, Enable, SEQ ) VALUES ( NEWID(), N'Default Branch', N'Default Branch', 1, 1 )

INSERT INTO dbo.[User] ( UserID, UserCode, UserLogin, UserPassword, FirstName, LastName, CellPhone, CreatedDate )
VALUES ( NEWID(), N'system', 'system', '', N'system', N'system', '', GETDATE() )

DECLARE @BranchID VARCHAR(100),
		@UserID	VARCHAR(100);
SELECT @BranchID = BranchID FROM dbo.Branch;
SELECT @UserID = UserID FROM dbo.[User]

INSERT INTO dbo.UserBranch ( UserID, BranchID, CreatedDate )
VALUES ( @UserID, @BranchID, GETDATE() )

INSERT INTO dbo.BranchConfig ( BranchID, Currency, UseTax, Tax, UseServiceFee, ServiceFee, CreatedDate, CreatedUser)
VALUES  ( @BranchID, 'VND', 0, '', 0, 0, GETDATE(), @UserID )

INSERT INTO dbo.Customer ( CustomerID, CustomerName, BranchID, Enable, SEQ, CreatedDate, CreatedUser )
VALUES  ( NEWID(), N'Khách vãng lai', @BranchID, 1, 1, GETDATE(), @UserID )

INSERT INTO dbo.Currency ( Currency, Exchange, Enable, SEQ, CreatedDate, CreatedUser ) VALUES ( 'VND',  1, 1, 1, GETDATE(), @UserID )

INSERT INTO dbo.Tax ( Tax, Value, BranchID, Enable, SEQ, CreatedDate, CreatedUser ) VALUES  ( 'VAT', 10, @BranchID, 1, 1, GETDATE(), @UserID )
