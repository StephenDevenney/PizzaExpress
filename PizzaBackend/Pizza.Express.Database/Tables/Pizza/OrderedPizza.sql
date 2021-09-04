CREATE TABLE [pizza].[OrderedPizza]
(
	[OrderedPizzaId] INT IDENTITY(1,1) PRIMARY KEY, 
    [FK_OrderId] INT NOT NULL, 
    [FK_PizzaId] INT NOT NULL, 
    [PizzaCount] INT DEFAULT 1, 

    CONSTRAINT [OrderedPizza_Order_StatusId] FOREIGN KEY ([FK_OrderId]) REFERENCES [pizza].[Order] (OrderId),
    CONSTRAINT [OrderedPizza_Pizza_PizzaId] FOREIGN KEY ([FK_PizzaId]) REFERENCES [enum.pizza].[Pizza] (PizzaId)
)
