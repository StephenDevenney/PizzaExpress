/*
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
--------------------------------------------------------------------------------------
*/

-- Enum.Security
INSERT INTO [enum.security].[ClientRole] ([RoleName])
VALUES (N'Admin'),
(N'Client')

INSERT INTO [enum.security].[AppIdleSecs] ([IdleTime], [Description])
VALUES (10800, N'3 Hours'),
(3600, N'1 Hour'),
(1200, N'20 Minutes'),
(300, N'5 Minutes'),
(60, N'1 Minute'),
(0, N'Off')

-- SECURITY
INSERT INTO [security].[Client] ([FK_ClientRoleId], [ClientName], [Address], [PhoneNumber]) 
VALUES (1, N'AdminUser', N'123 Fake Street', N'0867777777'),
(2, N'ClientlUser', N'742 Evergreen Terrace', N'0876666666')