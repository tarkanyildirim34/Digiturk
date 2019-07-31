USE [DigiturkDb]
GO
/****** Object:  Table [dbo].[Article]    Script Date: 7/31/2019 2:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Article](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Title] [nvarchar](500) NULL,
	[Description] [nvarchar](500) NULL,
	[Body] [nvarchar](max) NULL,
	[Image] [nvarchar](500) NULL,
	[Date] [datetime] NULL,
	[Published] [bit] NULL,
	[Deleted] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArticleComment]    Script Date: 7/31/2019 2:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticleComment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArticleId] [int] NULL,
	[Content] [nvarchar](500) NULL,
	[CreateUserId] [int] NULL,
	[CreateDate] [datetime] NULL,
	[Published] [bit] NULL,
	[Deleted] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 7/31/2019 2:47:12 PM ******/
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
SET IDENTITY_INSERT [dbo].[Article] ON 

INSERT [dbo].[Article] ([Id], [UserId], [Title], [Description], [Body], [Image], [Date], [Published], [Deleted]) VALUES (1, 1, N'Tarkan 1 Makale', N'Makale 1 Açıklama', N'Makale 1 İçerik', N'test resim', CAST(N'2019-07-31T00:00:00.000' AS DateTime), 1, 0)
SET IDENTITY_INSERT [dbo].[Article] OFF
SET IDENTITY_INSERT [dbo].[ArticleComment] ON 

INSERT [dbo].[ArticleComment] ([Id], [ArticleId], [Content], [CreateUserId], [CreateDate], [Published], [Deleted]) VALUES (1, 1, N'ilk yorum', 1, CAST(N'2019-07-31T14:01:44.863' AS DateTime), 1, 0)
SET IDENTITY_INSERT [dbo].[ArticleComment] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [Surname], [UserName], [Password], [Published], [Deleted]) VALUES (1, N'Tarkan', N'Yıldırım', N'tarkan.yildirim', N'111', 1, 0)
INSERT [dbo].[User] ([Id], [Name], [Surname], [UserName], [Password], [Published], [Deleted]) VALUES (2, N'Merve', N'Yıldırım', N'merve.yildirim', N'111', 1, 0)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Article] ADD  CONSTRAINT [DF_Article_Date]  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[ArticleComment] ADD  CONSTRAINT [DF_ArticleComment_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[ArticleComment] ADD  CONSTRAINT [DF_ArticleComment_Published]  DEFAULT ((1)) FOR [Published]
GO
ALTER TABLE [dbo].[ArticleComment] ADD  CONSTRAINT [DF_ArticleComment_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
