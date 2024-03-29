INSERT [dbo].[Activities] ([ActivityID], [ActivityName]) VALUES (N'd33c434e-a007-4eec-b0b6-16c505b721ff', N'Development of internal content/solution')
GO
INSERT [dbo].[Activities] ([ActivityID], [ActivityName]) VALUES (N'e23d098e-013b-4afe-a966-1f515c9a1a12', N'POC')
GO
INSERT [dbo].[Activities] ([ActivityID], [ActivityName]) VALUES (N'e23d098e-013b-4afe-a966-1f515c9a1a13', N'Event organization')
GO
INSERT [dbo].[Activities] ([ActivityID], [ActivityName]) VALUES (N'e23d098e-013b-4afe-a966-1f515c9a1a14', N'Migration to the cloud')
GO
INSERT [dbo].[Activities] ([ActivityID], [ActivityName]) VALUES (N'e23d098e-013b-4afe-a966-1f515c9a1a15', N'Design session')
GO
INSERT [dbo].[Activities] ([ActivityID], [ActivityName]) VALUES (N'e23d098e-013b-4afe-a966-1f515c9a1a16', N'Workshop')
GO
INSERT [dbo].[WorkloadBacklogs] ([WBID], [WBActivityActivityID], [WBComplexity], [WBCreatedBy], [WBCreatedDate], [WBDescription], [WBEndDate], [WBExpertise], [WBStartDate], [WBTitle]) VALUES (N'd33c434e-a007-4eec-b0b6-16c505b721fe', N'e23d098e-013b-4afe-a966-1f515c9a1a12', 3, N'aljanuz@microsoft.com', CAST(N'2016-06-06 00:00:00.0000000' AS DateTime2), N'Some work to de done.', CAST(N'2016-06-30 00:00:00.0000000' AS DateTime2), 0, CAST(N'2016-03-07 00:00:00.0000000' AS DateTime2), N'LG Nova Geração - Migration to Azure')
GO
INSERT [dbo].[WorkloadBacklogs] ([WBID], [WBActivityActivityID], [WBComplexity], [WBCreatedBy], [WBCreatedDate], [WBDescription], [WBEndDate], [WBExpertise], [WBStartDate], [WBTitle]) VALUES (N'd33c434e-a007-4eec-b0b8-16c505b721fe', N'd33c434e-a007-4eec-b0b6-16c505b721ff', 4, N'aljanuz@microsoft.com', CAST(N'2016-05-01 00:00:00.0000000' AS DateTime2), N'Development of Arda, an internal tool to manage workload of teams', CAST(N'2016-06-30 00:00:00.0000000' AS DateTime2), 0, CAST(N'2016-05-02 00:00:00.0000000' AS DateTime2), N'Arda - Development of v1')
GO
INSERT [dbo].[FiscalYears] ([FiscalYearID], [FullNumericFiscalYear], [TextualFiscalYear]) VALUES (N'6b50005e-0413-4a7e-ad0d-2a249a593993', 2017, N'FY17')
GO
INSERT [dbo].[Metrics] ([MetricID], [Description], [FiscalYearFiscalYearID], [MetricCategory], [MetricName]) VALUES (N'87f6b1ee-f277-434a-8738-267f7ec56fe6', N'Generate critical mass to meet ascend program requirements.', N'6b50005e-0413-4a7e-ad0d-2a249a593993', N'Evangelism', N'Ascend')
GO
INSERT [dbo].[Metrics] ([MetricID], [Description], [FiscalYearFiscalYearID], [MetricCategory], [MetricName]) VALUES (N'0572795d-fae6-48e5-a07f-79b13c39b6d7', N'Drive ISV''s Azure consumption.', N'6b50005e-0413-4a7e-ad0d-2a249a593993', N'ISV''s', N'ISV''s consumption ')
GO
INSERT [dbo].[Metrics] ([MetricID], [Description], [FiscalYearFiscalYearID], [MetricCategory], [MetricName]) VALUES (N'8860413a-12fd-4f67-a8f6-8e9c708b1e92', N'Consuption', N'6b50005e-0413-4a7e-ad0d-2a249a593993', N'Startups', N'Azure consuption in Startups')
GO
INSERT [dbo].[Technologies] ([TechnologyID], [TechnologyName]) VALUES (N'a43254d1-d99c-43bb-a39f-7c84ae100f8f', N'Visual Studio Team Services (VSTS)')
GO
INSERT [dbo].[Technologies] ([TechnologyID], [TechnologyName]) VALUES (N'a43254d1-d19c-43bb-a39f-7c84ae1e0f8d', N'Cognitive Services')
GO
INSERT [dbo].[Technologies] ([TechnologyID], [TechnologyName]) VALUES (N'a43254d1-d99c-43bb-a39f-7c84ae1e0f8d', N'Microsoft Azure')
GO
INSERT [dbo].[Technologies] ([TechnologyID], [TechnologyName]) VALUES (N'a43253f1-d99c-43bb-a39f-7c84ae1e0f8d', N'Office 365')
GO
INSERT [dbo].[Technologies] ([TechnologyID], [TechnologyName]) VALUES (N'a43254d1-d99c-43cd-a39f-7c84ae1e0f8d', N'Windows')
GO
INSERT [dbo].[Technologies] ([TechnologyID], [TechnologyName]) VALUES (N'a43254d1-d99c-43bb-a39f-7c84ae1e0f8e', N'Visual Studio')
GO
INSERT [dbo].[Technologies] ([TechnologyID], [TechnologyName]) VALUES (N'a43254d1-d99c-43bb-a39f-7c84ae1e0f9a', N'SQL Server')
GO
INSERT [dbo].[WorkloadBacklogTechnologies] ([WBUTechnologyID], [TechnologyTechnologyID], [WorkloadBacklogWBID]) VALUES (N'2a91840e-b61d-4b9c-9434-03458060a888', N'a43254d1-d99c-43bb-a39f-7c84ae1e0f8d', N'd33c434e-a007-4eec-b0b6-16c505b721fe')
GO
INSERT [dbo].[UsersKanban] ([UniqueName]) VALUES (N'fabsanc@microsoft.com')
GO
INSERT [dbo].[WorkloadBacklogUsers] ([WBUserID], [KanbanUserUniqueName], [WorkloadBacklogWBID]) VALUES (N'6e3d145e-7dad-4e1f-97a3-3c4e6529e3a0', N'fabsanc@microsoft.com', N'd33c434e-a007-4eec-b0b6-16c505b721fe')
GO
INSERT [dbo].[WorkloadBacklogMetrics] ([WBMetricID], [MetricMetricID], [WorkloadBacklogWBID]) VALUES (N'54ccb83a-73b7-4f4c-a337-ba8f18ceb029', N'0572795d-fae6-48e5-a07f-79b13c39b6d7', N'd33c434e-a007-4eec-b0b6-16c505b721fe')
GO
