USE [TraCuuThuatNgu]
GO
/****** Object:  Table [dbo].[ThuatNgu]    Script Date: 04/04/2013 17:04:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThuatNgu](
	[MucTu] [nvarchar](256) NOT NULL,
	[Nghia] [nvarchar](500) NULL,
 CONSTRAINT [PK_ThuatNgu] PRIMARY KEY CLUSTERED 
(
	[MucTu] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LichSu]    Script Date: 04/04/2013 17:04:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichSu](
	[TuKhoa] [nvarchar](256) NULL,
	[CoTrongDuLieu] [bit] NULL,
	[MaTaiKhoan] [uniqueidentifier] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[YeuThich]    Script Date: 04/04/2013 17:04:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[YeuThich](
	[MucTu] [nvarchar](256) NOT NULL,
	[MaTaiKhoan] [uniqueidentifier] NOT NULL,
	[NgayDang] [datetime] NULL,
 CONSTRAINT [PK_YeuThich] PRIMARY KEY CLUSTERED 
(
	[MucTu] ASC,
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BinhLuan]    Script Date: 04/04/2013 17:04:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BinhLuan](
	[MaBinhLuan] [int] IDENTITY(1,1) NOT NULL,
	[MucTu] [nvarchar](256) NULL,
	[NoiDung] [nvarchar](500) NULL,
	[MaTaiKhoan] [uniqueidentifier] NULL,
	[NgayDang] [datetime] NULL,
 CONSTRAINT [PK_BinhLuan] PRIMARY KEY CLUSTERED 
(
	[MaBinhLuan] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_BinhLuan_NgayDang]    Script Date: 04/04/2013 17:04:41 ******/
ALTER TABLE [dbo].[BinhLuan] ADD  CONSTRAINT [DF_BinhLuan_NgayDang]  DEFAULT (getdate()) FOR [NgayDang]
GO
/****** Object:  ForeignKey [FK_BinhLuan_aspnet_Users]    Script Date: 04/04/2013 17:04:41 ******/
ALTER TABLE [dbo].[BinhLuan]  WITH CHECK ADD  CONSTRAINT [FK_BinhLuan_aspnet_Users] FOREIGN KEY([MaTaiKhoan])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
ALTER TABLE [dbo].[BinhLuan] CHECK CONSTRAINT [FK_BinhLuan_aspnet_Users]
GO
/****** Object:  ForeignKey [FK_BinhLuan_ThuatNgu]    Script Date: 04/04/2013 17:04:41 ******/
ALTER TABLE [dbo].[BinhLuan]  WITH CHECK ADD  CONSTRAINT [FK_BinhLuan_ThuatNgu] FOREIGN KEY([MucTu])
REFERENCES [dbo].[ThuatNgu] ([MucTu])
GO
ALTER TABLE [dbo].[BinhLuan] CHECK CONSTRAINT [FK_BinhLuan_ThuatNgu]
GO
/****** Object:  ForeignKey [FK_YeuThich_aspnet_Users]    Script Date: 04/04/2013 17:04:41 ******/
ALTER TABLE [dbo].[YeuThich]  WITH CHECK ADD  CONSTRAINT [FK_YeuThich_aspnet_Users] FOREIGN KEY([MaTaiKhoan])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
ALTER TABLE [dbo].[YeuThich] CHECK CONSTRAINT [FK_YeuThich_aspnet_Users]
GO
/****** Object:  ForeignKey [FK_YeuThich_ThuatNgu]    Script Date: 04/04/2013 17:04:41 ******/
ALTER TABLE [dbo].[YeuThich]  WITH CHECK ADD  CONSTRAINT [FK_YeuThich_ThuatNgu] FOREIGN KEY([MucTu])
REFERENCES [dbo].[ThuatNgu] ([MucTu])
GO
ALTER TABLE [dbo].[YeuThich] CHECK CONSTRAINT [FK_YeuThich_ThuatNgu]
GO
