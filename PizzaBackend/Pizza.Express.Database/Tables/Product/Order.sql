CREATE TABLE [product].[Order]
(
	[OrderId] INT IDENTITY(1,1) PRIMARY KEY, 
    [FK_ClientId] INT NOT NULL, 
    [FK_StatusId] INT NOT NULL,
    [OrderCode] NVARCHAR(50) NOT NULL,

    CONSTRAINT [Order_Client_ClientId] FOREIGN KEY ([FK_ClientId]) REFERENCES [security].[Client] (ClientId),
    CONSTRAINT [Order_Status_StatusId] FOREIGN KEY ([FK_StatusId]) REFERENCES [enum.product].[Status] (StatusId)
)
