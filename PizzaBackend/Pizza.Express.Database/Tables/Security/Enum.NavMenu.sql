CREATE TABLE [enum.security].[NavMenu]
(
	[NavMenuId] INT IDENTITY(1,1) PRIMARY KEY, 
    [NavMenuName] NVARCHAR(50) NOT NULL, 
    [NavMenuTitle] NVARCHAR(50) NOT NULL, 
    [NavMenuRoute] NVARCHAR(50) NOT NULL
)
