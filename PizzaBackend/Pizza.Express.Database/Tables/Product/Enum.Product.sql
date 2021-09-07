CREATE TABLE [enum.product].[Product]
(
	[ProductId] INT IDENTITY(1,1) PRIMARY KEY,
	[FK_ProductTypeId] INT NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(100) NOT NULL,
	[Price] DECIMAL(10,2) NOT NULL,
	[ImageLink] NVARCHAR(MAX) NOT NULL,

	CONSTRAINT [Product_ProductType_ProductTypeId] FOREIGN KEY ([FK_ProductTypeId]) REFERENCES [enum.product].[ProductTypes] (ProductTypeId)
)
