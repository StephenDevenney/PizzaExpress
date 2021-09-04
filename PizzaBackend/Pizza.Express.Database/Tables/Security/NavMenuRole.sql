CREATE TABLE [security].[NavMenuRole]
(
	[NavMenuRoleId] INT IDENTITY(1,1) PRIMARY KEY, 
    [FK_NavMenuId] INT NOT NULL, 
    [FK_ClientRoleId] INT NOT NULL

    CONSTRAINT [NavMenu_NavMenuId] FOREIGN KEY ([FK_NavMenuId]) REFERENCES [enum.security].[NavMenu] (NavMenuId)
    CONSTRAINT [NavMenu_User_ClientRoleId] FOREIGN KEY ([FK_ClientRoleId]) REFERENCES [enum.security].[ClientRole] (ClientRoleId)
)
