CREATE TABLE [product].[BasketItems]
(
	[BasketItemId] INT IDENTITY(1,1) PRIMARY KEY,
    [FK_ClientId] INT NOT NULL, 
    [FK_ProductId] INT NOT NULL, 
    [ProductCount] INT DEFAULT 1, 

    CONSTRAINT [BasketItems_Client_clientId] FOREIGN KEY ([FK_ClientId]) REFERENCES [security].[Client] (ClientId),
    CONSTRAINT [BasketItems_Product_ProductId] FOREIGN KEY ([FK_ProductId]) REFERENCES [enum.product].[Product] (ProductId)
)
