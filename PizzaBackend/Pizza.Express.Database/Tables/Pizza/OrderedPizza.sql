CREATE TABLE [pizza].[OrderedPizza]
(
	[OrderedPizzaId] INT IDENTITY(1,1) PRIMARY KEY, 
    [FK_OrderId] INT NOT NULL, 
    [FK_PizzaId] INT NOT NULL, 

    CONSTRAINT [OrderedPizza_Order_StatusId] FOREIGN KEY ([FK_OrderId]) REFERENCES [pizza].[Order] (OrderId),
    --CONSTRAINT [OrderedPizza_Pizza_StatusId] FOREIGN KEY ([FK_PizzaId]) REFERENCES [pizza].[Status] (StatusId)
)
