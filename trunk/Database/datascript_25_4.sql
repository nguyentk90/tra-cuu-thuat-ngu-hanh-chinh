USE [TraCuuThuatNgu]
GO
/****** Object:  Table [dbo].[Topic]    Script Date: 04/25/2013 17:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Topic](
	[TopicId] [varchar](10) NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_Topic] PRIMARY KEY CLUSTERED 
(
	[TopicId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Test]    Script Date: 04/25/2013 17:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test](
	[TestId] [int] NOT NULL,
	[TestName] [nvarchar](250) NULL,
 CONSTRAINT [PK_Test] PRIMARY KEY CLUSTERED 
(
	[TestId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Synset]    Script Date: 04/25/2013 17:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Synset](
	[SynsetId] [int] IDENTITY(1,1) NOT NULL,
	[Category] [varchar](1) NOT NULL,
	[Words] [nvarchar](512) NULL,
	[Def] [nvarchar](512) NOT NULL,
	[Exa] [nvarchar](512) NULL,
 CONSTRAINT [PK_Synset] PRIMARY KEY CLUSTERED 
(
	[SynsetId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SearchHistory]    Script Date: 04/25/2013 17:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SearchHistory](
	[Keyword] [nvarchar](256) NOT NULL,
	[IsExist] [bit] NOT NULL,
	[Counter] [int] NOT NULL,
	[DateModify] [datetime] NOT NULL,
 CONSTRAINT [PK_SearchHistory] PRIMARY KEY CLUSTERED 
(
	[Keyword] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entry]    Script Date: 04/25/2013 17:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Entry](
	[HeadWord] [nvarchar](256) NOT NULL,
	[WordType] [varchar](1) NOT NULL,
 CONSTRAINT [PK_ThuatNgu] PRIMARY KEY CLUSTERED 
(
	[HeadWord] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Relation]    Script Date: 04/25/2013 17:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Relation](
	[SynsetId] [int] NOT NULL,
	[HeadWord] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_Relation] PRIMARY KEY CLUSTERED 
(
	[SynsetId] ASC,
	[HeadWord] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserHistory]    Script Date: 04/25/2013 17:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserHistory](
	[HistoryId] [int] IDENTITY(1,1) NOT NULL,
	[Keyword] [nvarchar](256) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[DateModify] [datetime] NULL,
 CONSTRAINT [PK_UserHistory_1] PRIMARY KEY CLUSTERED 
(
	[HistoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profile]    Script Date: 04/25/2013 17:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profile](
	[UserId] [uniqueidentifier] NOT NULL,
	[Fullname] [nvarchar](256) NULL,
	[Birthday] [date] NULL,
 CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Favorite]    Script Date: 04/25/2013 17:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favorite](
	[HeadWord] [nvarchar](256) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[DateAdd] [datetime] NOT NULL,
 CONSTRAINT [PK_YeuThich] PRIMARY KEY CLUSTERED 
(
	[HeadWord] ASC,
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 04/25/2013 17:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[HeadWord] [nvarchar](256) NOT NULL,
	[CmContent] [nvarchar](500) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[DateAdd] [datetime] NOT NULL,
 CONSTRAINT [PK_BinhLuan] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_BinhLuan_NgayDang]    Script Date: 04/25/2013 17:20:36 ******/
ALTER TABLE [dbo].[Comment] ADD  CONSTRAINT [DF_BinhLuan_NgayDang]  DEFAULT (getdate()) FOR [DateAdd]
GO
/****** Object:  ForeignKey [FK_BinhLuan_aspnet_Users]    Script Date: 04/25/2013 17:20:36 ******/
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_BinhLuan_aspnet_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_BinhLuan_aspnet_Users]
GO
/****** Object:  ForeignKey [FK_BinhLuan_ThuatNgu]    Script Date: 04/25/2013 17:20:36 ******/
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_BinhLuan_ThuatNgu] FOREIGN KEY([HeadWord])
REFERENCES [dbo].[Entry] ([HeadWord])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_BinhLuan_ThuatNgu]
GO
/****** Object:  ForeignKey [FK_YeuThich_aspnet_Users]    Script Date: 04/25/2013 17:20:36 ******/
ALTER TABLE [dbo].[Favorite]  WITH CHECK ADD  CONSTRAINT [FK_YeuThich_aspnet_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
ALTER TABLE [dbo].[Favorite] CHECK CONSTRAINT [FK_YeuThich_aspnet_Users]
GO
/****** Object:  ForeignKey [FK_YeuThich_ThuatNgu]    Script Date: 04/25/2013 17:20:36 ******/
ALTER TABLE [dbo].[Favorite]  WITH CHECK ADD  CONSTRAINT [FK_YeuThich_ThuatNgu] FOREIGN KEY([HeadWord])
REFERENCES [dbo].[Entry] ([HeadWord])
GO
ALTER TABLE [dbo].[Favorite] CHECK CONSTRAINT [FK_YeuThich_ThuatNgu]
GO
/****** Object:  ForeignKey [FK_Profile_aspnet_Users]    Script Date: 04/25/2013 17:20:36 ******/
ALTER TABLE [dbo].[Profile]  WITH CHECK ADD  CONSTRAINT [FK_Profile_aspnet_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
ALTER TABLE [dbo].[Profile] CHECK CONSTRAINT [FK_Profile_aspnet_Users]
GO
/****** Object:  ForeignKey [FK_Relation_Entry]    Script Date: 04/25/2013 17:20:36 ******/
ALTER TABLE [dbo].[Relation]  WITH CHECK ADD  CONSTRAINT [FK_Relation_Entry] FOREIGN KEY([HeadWord])
REFERENCES [dbo].[Entry] ([HeadWord])
GO
ALTER TABLE [dbo].[Relation] CHECK CONSTRAINT [FK_Relation_Entry]
GO
/****** Object:  ForeignKey [FK_Relation_Synset]    Script Date: 04/25/2013 17:20:36 ******/
ALTER TABLE [dbo].[Relation]  WITH CHECK ADD  CONSTRAINT [FK_Relation_Synset] FOREIGN KEY([SynsetId])
REFERENCES [dbo].[Synset] ([SynsetId])
GO
ALTER TABLE [dbo].[Relation] CHECK CONSTRAINT [FK_Relation_Synset]
GO
/****** Object:  ForeignKey [FK_UserHistory_aspnet_Users1]    Script Date: 04/25/2013 17:20:36 ******/
ALTER TABLE [dbo].[UserHistory]  WITH CHECK ADD  CONSTRAINT [FK_UserHistory_aspnet_Users1] FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
ALTER TABLE [dbo].[UserHistory] CHECK CONSTRAINT [FK_UserHistory_aspnet_Users1]
GO
