CREATE TABLE [security].[Client]
(
	[ClientId] INT IDENTITY(1,1) PRIMARY KEY, 
    [FK_ClientRoleId] INT NOT NULL, 
    [ClientName] NVARCHAR(50) NOT NULL,
    [Address] NVARCHAR(50) NOT NULL,
    [PhoneNumber] NVARCHAR(50) NOT NULL,

    CONSTRAINT [Client_Role_ClientRoleId] FOREIGN KEY ([FK_ClientRoleId]) REFERENCES [enum.security].[ClientRole] (ClientRoleId)
)
