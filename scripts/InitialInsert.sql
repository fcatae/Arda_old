USE [Arda_Permissions]
GO
SET IDENTITY_INSERT [dbo].[Modules] ON 

INSERT [dbo].[Modules] ([ModuleID], [Endpoint], [ModuleName]) VALUES (1, N'https://localhost:44304/', N'Users')
INSERT [dbo].[Modules] ([ModuleID], [Endpoint], [ModuleName]) VALUES (3, N'https://localhost:44304/', N'Account')
INSERT [dbo].[Modules] ([ModuleID], [Endpoint], [ModuleName]) VALUES (4, N'https://localhost:44304/', N'FiscalYear')
INSERT [dbo].[Modules] ([ModuleID], [Endpoint], [ModuleName]) VALUES (6, N'https://localhost:44304/', N'Dashboard')
INSERT [dbo].[Modules] ([ModuleID], [Endpoint], [ModuleName]) VALUES (7, N'https://localhost:44304/', N'Categories')
INSERT [dbo].[Modules] ([ModuleID], [Endpoint], [ModuleName]) VALUES (8, N'https://localhost:44304/', N'Complexities')
INSERT [dbo].[Modules] ([ModuleID], [Endpoint], [ModuleName]) VALUES (9, N'https://localhost:44304/', N'Metrics')
INSERT [dbo].[Modules] ([ModuleID], [Endpoint], [ModuleName]) VALUES (10, N'https://localhost:44304/', N'Workloads')
SET IDENTITY_INSERT [dbo].[Modules] OFF
SET IDENTITY_INSERT [dbo].[Resources] ON 

INSERT [dbo].[Resources] ([ResourceID], [Category], [CategorySequence], [DisplayName], [ModuleID], [ResourceName], [ResourceSequence]) VALUES (1, N'Users', 1, N'Review', 1, N'Review', 1)
INSERT [dbo].[Resources] ([ResourceID], [Category], [CategorySequence], [DisplayName], [ModuleID], [ResourceName], [ResourceSequence]) VALUES (2, N'Users', 1, N'All', 1, N'Index', 2)
INSERT [dbo].[Resources] ([ResourceID], [Category], [CategorySequence], [DisplayName], [ModuleID], [ResourceName], [ResourceSequence]) VALUES (3, N'FiscalYear', 2, N'All', 4, N'Index', 1)
INSERT [dbo].[Resources] ([ResourceID], [Category], [CategorySequence], [DisplayName], [ModuleID], [ResourceName], [ResourceSequence]) VALUES (4, N'FiscalYear', 2, N'Add', 4, N'Add', 2)
INSERT [dbo].[Resources] ([ResourceID], [Category], [CategorySequence], [DisplayName], [ModuleID], [ResourceName], [ResourceSequence]) VALUES (5, N'FiscalYear', 2, N'Edit', 4, N'Index', 3)
INSERT [dbo].[Resources] ([ResourceID], [Category], [CategorySequence], [DisplayName], [ModuleID], [ResourceName], [ResourceSequence]) VALUES (6, N'FiscalYear', 2, N'Delete', 4, N'Index', 4)
INSERT [dbo].[Resources] ([ResourceID], [Category], [CategorySequence], [DisplayName], [ModuleID], [ResourceName], [ResourceSequence]) VALUES (7, N'FiscalYear', 2, N'Details', 4, N'Index', 5)
INSERT [dbo].[Resources] ([ResourceID], [Category], [CategorySequence], [DisplayName], [ModuleID], [ResourceName], [ResourceSequence]) VALUES (8, N'Categories', 3, N'All', 7, N'Index', 1)
INSERT [dbo].[Resources] ([ResourceID], [Category], [CategorySequence], [DisplayName], [ModuleID], [ResourceName], [ResourceSequence]) VALUES (9, N'Categories', 3, N'Add', 7, N'Index', 2)
INSERT [dbo].[Resources] ([ResourceID], [Category], [CategorySequence], [DisplayName], [ModuleID], [ResourceName], [ResourceSequence]) VALUES (14, N'Categories', 3, N'Edit', 7, N'Index', 3)
INSERT [dbo].[Resources] ([ResourceID], [Category], [CategorySequence], [DisplayName], [ModuleID], [ResourceName], [ResourceSequence]) VALUES (15, N'Categories', 3, N'Delete', 7, N'Index', 4)
INSERT [dbo].[Resources] ([ResourceID], [Category], [CategorySequence], [DisplayName], [ModuleID], [ResourceName], [ResourceSequence]) VALUES (16, N'Categories', 3, N'Details', 7, N'Index', 5)
INSERT [dbo].[Resources] ([ResourceID], [Category], [CategorySequence], [DisplayName], [ModuleID], [ResourceName], [ResourceSequence]) VALUES (17, N'Complexities', 4, N'All', 8, N'Index', 1)
INSERT [dbo].[Resources] ([ResourceID], [Category], [CategorySequence], [DisplayName], [ModuleID], [ResourceName], [ResourceSequence]) VALUES (18, N'Complexities', 4, N'Add', 8, N'Add', 2)
INSERT [dbo].[Resources] ([ResourceID], [Category], [CategorySequence], [DisplayName], [ModuleID], [ResourceName], [ResourceSequence]) VALUES (19, N'Complexities', 4, N'Edit', 8, N'Index', 3)
INSERT [dbo].[Resources] ([ResourceID], [Category], [CategorySequence], [DisplayName], [ModuleID], [ResourceName], [ResourceSequence]) VALUES (20, N'Complexities', 4, N'Delete', 8, N'Index', 4)
INSERT [dbo].[Resources] ([ResourceID], [Category], [CategorySequence], [DisplayName], [ModuleID], [ResourceName], [ResourceSequence]) VALUES (21, N'Complexities', 4, N'Details', 8, N'Index', 5)
INSERT [dbo].[Resources] ([ResourceID], [Category], [CategorySequence], [DisplayName], [ModuleID], [ResourceName], [ResourceSequence]) VALUES (22, N'Metrics', 5, N'All', 9, N'Index', 1)
INSERT [dbo].[Resources] ([ResourceID], [Category], [CategorySequence], [DisplayName], [ModuleID], [ResourceName], [ResourceSequence]) VALUES (23, N'Metrics', 5, N'Add', 9, N'Add', 2)
INSERT [dbo].[Resources] ([ResourceID], [Category], [CategorySequence], [DisplayName], [ModuleID], [ResourceName], [ResourceSequence]) VALUES (24, N'Metrics', 5, N'Edit', 9, N'Index', 3)
INSERT [dbo].[Resources] ([ResourceID], [Category], [CategorySequence], [DisplayName], [ModuleID], [ResourceName], [ResourceSequence]) VALUES (25, N'Metrics', 5, N'Delete', 9, N'Index', 4)
INSERT [dbo].[Resources] ([ResourceID], [Category], [CategorySequence], [DisplayName], [ModuleID], [ResourceName], [ResourceSequence]) VALUES (26, N'Metrics', 5, N'Details', 9, N'Index', 5)
INSERT [dbo].[Resources] ([ResourceID], [Category], [CategorySequence], [DisplayName], [ModuleID], [ResourceName], [ResourceSequence]) VALUES (27, N'Workloads', 6, N'All', 10, N'Index', 1)
INSERT [dbo].[Resources] ([ResourceID], [Category], [CategorySequence], [DisplayName], [ModuleID], [ResourceName], [ResourceSequence]) VALUES (28, N'Workloads', 6, N'Add', 10, N'Add', 2)
INSERT [dbo].[Resources] ([ResourceID], [Category], [CategorySequence], [DisplayName], [ModuleID], [ResourceName], [ResourceSequence]) VALUES (29, N'Workloads', 6, N'Edit', 10, N'Index', 3)
INSERT [dbo].[Resources] ([ResourceID], [Category], [CategorySequence], [DisplayName], [ModuleID], [ResourceName], [ResourceSequence]) VALUES (30, N'Workloads', 6, N'Delete', 10, N'Index', 4)
INSERT [dbo].[Resources] ([ResourceID], [Category], [CategorySequence], [DisplayName], [ModuleID], [ResourceName], [ResourceSequence]) VALUES (31, N'Workloads', 6, N'Details', 10, N'Index', 5)
SET IDENTITY_INSERT [dbo].[Resources] OFF
