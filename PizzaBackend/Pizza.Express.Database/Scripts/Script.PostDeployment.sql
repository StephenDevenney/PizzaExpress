/*
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
--------------------------------------------------------------------------------------
*/

-- Enum.Security
INSERT INTO [enum.security].[UserRole] ([RoleName])
VALUES (N'Admin'),
(N'User')

INSERT INTO [enum.security].[AppIdleSecs] ([IdleTime], [Description])
VALUES (10800, N'3 Hours'),
(3600, N'1 Hour'),
(1200, N'20 Minutes'),
(300, N'5 Minutes'),
(60, N'1 Minute'),
(0, N'Off')

-- SECURITY
INSERT INTO [security].[User] ([FK_UserRoleId], [UserName]) 
VALUES (1, N'AdminUser'),
(2, N'GeneralUser')