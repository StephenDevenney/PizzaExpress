/*
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
--------------------------------------------------------------------------------------
*/

-- Enum.Security
INSERT INTO [enum.security].[ClientRole] ([RoleName])
VALUES (N'Admin'),
(N'Client')

INSERT INTO [enum.security].[NavMenu] ([NavMenuName], [NavMenuTitle], [NavMenuRoute]) 
VALUES (N'Dashboard', N'View Current Order', N'dashboard'),
(N'Pizza', N'View Pizzas', N'pizza'),
(N'Basket', N'View Current Order', N'basket'),
(N'Admin', N'Manage Orders', N'admin')

-- Enum.Pizza
INSERT INTO [enum.pizza].[Status] ([Description])
VALUES (N'Registered'),
(N'Preparation'),
(N'Ready to be delivered'),
(N'Delivered')

INSERT INTO [enum.pizza].[Pizza] ([Name], [Description], [Price])
VALUES (N'Buffalo', N'Pepperoni, Ham, Bacon, Chicken', 13.99),
(N'Premium Big Buffalo', N'Pepperoni, Ham, Bacon, Chicken, Beefballs, Sausage', 15.99),
(N'Hot Apache', N'Pepperoni, Onions, Jalapeño Peppers', 13.99),
(N'The Big Chief', N'Pepperoni, Beefballs, Sausage', 13.99),
(N'Bacon Apache', N'Bacon, Mushroom, Onion', 13.99),
(N'Cajun Apache', N'Cajun Chicken, Fresh Tomatoes, Jalapeño Peppers', 13.99),
(N'Vegetarian', N'Sweetcorn, Mushroom, Onions, Peppers, Cherry Tomatoes', 13.99),
(N'Wigwammer', N'Pepperoni, Extra Pepperoni', 13.99),
(N'Buffalo Extra Spicy Stuffed Crust', N'Sriracha & Pepperoni Crust, Pepperoni, Ham, Bacon, Chicken', 14.99)

-- SECURITY
INSERT INTO [security].[Client] ([FK_ClientRoleId], [ClientName], [Address], [PhoneNumber]) 
VALUES (1, N'AdminUser', N'123 Fake Street', N'0867777777'),
(2, N'ClientUser', N'742 Evergreen Terrace', N'0876666666')

INSERT INTO [security].[NavMenuRole] ([FK_NavMenuId], [FK_ClientRoleId]) 
VALUES (1, 1),
(1, 2),
(2, 1),
(2, 2),
(3, 1),
(3, 2),
(4, 1)