USE [DigiturkDb]
GO
/****** Object:  Table [dbo].[ActivityLog]    Script Date: 8/1/2019 1:56:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivityLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ActivityLogTypeId] [int] NOT NULL,
	[EntityId] [int] NULL,
	[EntityName] [nvarchar](400) NULL,
	[UserId] [int] NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[CreatedOnUtc] [datetime2](7) NOT NULL,
	[IpAddress] [nvarchar](200) NULL,
 CONSTRAINT [PK_ActivityLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActivityLogType]    Script Date: 8/1/2019 1:56:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivityLogType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SystemKeyword] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_ActivityLogType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Article]    Script Date: 8/1/2019 1:56:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Article](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Title] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[Image] [nvarchar](500) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Published] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArticleComment]    Script Date: 8/1/2019 1:56:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticleComment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArticleId] [int] NOT NULL,
	[Content] [nvarchar](500) NOT NULL,
	[CreateUserId] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Published] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_ArticleComment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 8/1/2019 1:56:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Published] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ActivityLog] ON 

INSERT [dbo].[ActivityLog] ([Id], [ActivityLogTypeId], [EntityId], [EntityName], [UserId], [Comment], [CreatedOnUtc], [IpAddress]) VALUES (1, 1, 5, N'Article', 1, N'Yeni Makale Eklendi', CAST(N'2019-07-31T18:22:37.6367439' AS DateTime2), N'get ip address')
INSERT [dbo].[ActivityLog] ([Id], [ActivityLogTypeId], [EntityId], [EntityName], [UserId], [Comment], [CreatedOnUtc], [IpAddress]) VALUES (2, 1, 6, N'Article', 1, N'Yeni Makale Eklendi', CAST(N'2019-07-31T18:27:10.9045877' AS DateTime2), N'get ip address')
INSERT [dbo].[ActivityLog] ([Id], [ActivityLogTypeId], [EntityId], [EntityName], [UserId], [Comment], [CreatedOnUtc], [IpAddress]) VALUES (3, 3, 6, N'Article', 1, N'Yeni Makale Yorumu Eklendi', CAST(N'2019-07-31T18:27:10.9474092' AS DateTime2), N'get ip address')
INSERT [dbo].[ActivityLog] ([Id], [ActivityLogTypeId], [EntityId], [EntityName], [UserId], [Comment], [CreatedOnUtc], [IpAddress]) VALUES (4, 1, 7, N'Article', 1, N'Yeni Makale Eklendi', CAST(N'2019-07-31T18:45:12.5844805' AS DateTime2), N'get ip address')
INSERT [dbo].[ActivityLog] ([Id], [ActivityLogTypeId], [EntityId], [EntityName], [UserId], [Comment], [CreatedOnUtc], [IpAddress]) VALUES (5, 1, 8, N'Article', 1, N'Yeni Makale Eklendi', CAST(N'2019-07-31T18:45:42.0490724' AS DateTime2), N'get ip address')
INSERT [dbo].[ActivityLog] ([Id], [ActivityLogTypeId], [EntityId], [EntityName], [UserId], [Comment], [CreatedOnUtc], [IpAddress]) VALUES (6, 1, 9, N'Article', 1, N'Yeni Makale Eklendi', CAST(N'2019-07-31T18:45:52.3809297' AS DateTime2), N'get ip address')
INSERT [dbo].[ActivityLog] ([Id], [ActivityLogTypeId], [EntityId], [EntityName], [UserId], [Comment], [CreatedOnUtc], [IpAddress]) VALUES (7, 5, 9, N'Article', 1, N'Makale Silindi', CAST(N'2019-07-31T19:06:28.1798753' AS DateTime2), N'get ip address')
INSERT [dbo].[ActivityLog] ([Id], [ActivityLogTypeId], [EntityId], [EntityName], [UserId], [Comment], [CreatedOnUtc], [IpAddress]) VALUES (8, 6, 5, N'ArticleComment', 1, N'Yeni Makale Eklendi', CAST(N'2019-07-31T22:52:57.3688496' AS DateTime2), N'get ip address')
SET IDENTITY_INSERT [dbo].[ActivityLog] OFF
SET IDENTITY_INSERT [dbo].[ActivityLogType] ON 

INSERT [dbo].[ActivityLogType] ([Id], [SystemKeyword], [Name], [Enabled]) VALUES (1, N'AddNewArticle', N'Yeni Makale Eklendi', 1)
INSERT [dbo].[ActivityLogType] ([Id], [SystemKeyword], [Name], [Enabled]) VALUES (4, N'UpdateArticle', N'Makale Güncellendi', 1)
INSERT [dbo].[ActivityLogType] ([Id], [SystemKeyword], [Name], [Enabled]) VALUES (5, N'DeleteArticle', N'Makale Silindi', 1)
INSERT [dbo].[ActivityLogType] ([Id], [SystemKeyword], [Name], [Enabled]) VALUES (6, N'AddNewComment', N'Yeni Yorum Eklendi', 1)
INSERT [dbo].[ActivityLogType] ([Id], [SystemKeyword], [Name], [Enabled]) VALUES (7, N'UpdateComment', N'Yorum Güncellendi', 1)
INSERT [dbo].[ActivityLogType] ([Id], [SystemKeyword], [Name], [Enabled]) VALUES (8, N'DeleteComment', N'Yorum Silindi', 1)
SET IDENTITY_INSERT [dbo].[ActivityLogType] OFF
SET IDENTITY_INSERT [dbo].[Article] ON 

INSERT [dbo].[Article] ([Id], [UserId], [Title], [Description], [Body], [Image], [Date], [Published], [Deleted]) VALUES (1, 1, N'Tarkan 1 Makale', N'Makale 1 Açıklama', N'Makale 1 İçerik', N'test resim', CAST(N'2019-07-31T00:00:00.000' AS DateTime), 1, 0)
SET IDENTITY_INSERT [dbo].[Article] OFF
SET IDENTITY_INSERT [dbo].[ArticleComment] ON 

INSERT [dbo].[ArticleComment] ([Id], [ArticleId], [Content], [CreateUserId], [CreateDate], [Published], [Deleted]) VALUES (6, 1, N'Test Yorum', 1, CAST(N'2019-08-01T01:55:48.680' AS DateTime), 1, 0)
SET IDENTITY_INSERT [dbo].[ArticleComment] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [Surname], [UserName], [Password], [Published], [Deleted]) VALUES (1, N'admin', N'admin', N'admin', N'123', 1, 0)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Article] ADD  CONSTRAINT [DF_Article_Date]  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[ArticleComment] ADD  CONSTRAINT [DF_ArticleComment_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[ArticleComment] ADD  CONSTRAINT [DF_ArticleComment_Published]  DEFAULT ((1)) FOR [Published]
GO
ALTER TABLE [dbo].[ArticleComment] ADD  CONSTRAINT [DF_ArticleComment_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
