CREATE TABLE [product].[OrderedProducts]
(
	[OrderedProductId] INT IDENTITY(1,1) PRIMARY KEY, 
    [FK_OrderId] INT NOT NULL, 
    [FK_ProductId] INT NOT NULL, 
    [ProductCount] INT DEFAULT 1, 

    CONSTRAINT [OrderedProduct_Order_StatusId] FOREIGN KEY ([FK_OrderId]) REFERENCES [product].[Order] (OrderId),
    CONSTRAINT [OrderedProduct_Product_ProductId] FOREIGN KEY ([FK_ProductId]) REFERENCES [enum.product].[Product] (ProductId)
)
