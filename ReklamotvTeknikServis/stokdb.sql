USE ReklamStokTakip
GO
/****** Object:  Table [dbo].[BirlestirilenParcalar]    Script Date: 28.10.2015 15:06:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BirlestirilenParcalar](
	[BirlestirilenParcalarId] [int] IDENTITY(1,1) NOT NULL,
	[StokId] [int] NULL,
	[BirlestirilenUrunId] [int] NULL,
 CONSTRAINT [PK_BirlestirilenParcalar] PRIMARY KEY CLUSTERED 
(
	[BirlestirilenParcalarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BirlestirilenUrun]    Script Date: 28.10.2015 15:06:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BirlestirilenUrun](
	[BirlestirilenUrunId] [int] IDENTITY(1,1) NOT NULL,
	[BirlestirilenUrunAdi] [varchar](100) NULL,
	[BirlestirilenUrunParcalari] [varchar](300) NULL,
	[UrunOlusturmaTarihi] [datetime] NULL,
	[UrunStokId] [int] NULL,
 CONSTRAINT [PK_BirlestirilenUrun] PRIMARY KEY CLUSTERED 
(
	[BirlestirilenUrunId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Firmalar]    Script Date: 28.10.2015 15:06:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Firmalar](
	[FirmaId] [int] IDENTITY(1,1) NOT NULL,
	[FirmaAdi] [varchar](100) NULL,
	[FirmaAdresi] [varchar](500) NULL,
	[FirmaTelNo] [varchar](50) NULL,
	[FirmaAlınanSatilan] [int] NULL,
 CONSTRAINT [PK_Firmalar] PRIMARY KEY CLUSTERED 
(
	[FirmaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GenelUrunler]    Script Date: 28.10.2015 15:06:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GenelUrunler](
	[Urun_id] [int] IDENTITY(1,1) NOT NULL,
	[Urun_adi] [varchar](100) NULL,
	[Urun_kodu] [varchar](100) NULL,
	[Urun_Ol_Tarih] [datetime] NULL,
 CONSTRAINT [PK_GenelUrunler] PRIMARY KEY CLUSTERED 
(
	[Urun_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PersonelTable]    Script Date: 28.10.2015 15:06:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PersonelTable](
	[Personel_id] [int] IDENTITY(1,1) NOT NULL,
	[Personel_adi] [varchar](50) NULL,
	[Personel_soyadi] [varchar](50) NULL,
	[Personel_departman] [varchar](50) NULL,
 CONSTRAINT [PK_PersonelTable] PRIMARY KEY CLUSTERED 
(
	[Personel_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ReserveUrunler]    Script Date: 28.10.2015 15:06:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReserveUrunler](
	[ReseverId] [int] IDENTITY(1,1) NOT NULL,
	[UrunStokId] [int] NULL,
	[ReserveUrunAdet] [float] NULL,
	[ReserveTarihi] [datetime] NULL,
	[ReserveYapilanFirma] [int] NULL,
 CONSTRAINT [PK_ReserveUrunler] PRIMARY KEY CLUSTERED 
(
	[ReseverId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SatilanUrunler]    Script Date: 28.10.2015 15:06:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SatilanUrunler](
	[SatilanUrun_id] [int] IDENTITY(1,1) NOT NULL,
	[SatilanUrun_adi] [varchar](100) NULL,
	[SatanPersonel] [int] NULL,
	[UrununSatilisTarihi] [datetime] NULL,
	[UrunSatisFiyati] [decimal](19, 5) NULL,
	[UrunTur_id] [int] NOT NULL,
	[UrunStok_id] [int] NULL,
	[UrunToplamKar] [float] NULL,
	[SatilanUrunAdet] [float] NULL,
	[FirmaId] [int] NULL,
 CONSTRAINT [PK_SatilanUrunler] PRIMARY KEY CLUSTERED 
(
	[SatilanUrun_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SikayetTur]    Script Date: 28.10.2015 15:06:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SikayetTur](
	[SikayetTurId] [int] IDENTITY(1,1) NOT NULL,
	[SikayetAciklama] [varchar](500) NULL,
 CONSTRAINT [PK_SikayetTur] PRIMARY KEY CLUSTERED 
(
	[SikayetTurId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SikayetUrunler]    Script Date: 28.10.2015 15:06:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SikayetUrunler](
	[SikayetId] [int] IDENTITY(1,1) NOT NULL,
	[SatilanUrunId] [int] NULL,
	[UrunStokId] [int] NULL,
	[SikayetTuruId] [int] NULL,
	[FirmaId] [int] NULL,
	[UrunAdet] [float] NULL,
	[SikayetTarihi] [datetime] NULL,
 CONSTRAINT [PK_SikayetUrunler] PRIMARY KEY CLUSTERED 
(
	[SikayetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StoktakiUrunler]    Script Date: 28.10.2015 15:06:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StoktakiUrunler](
	[UrunStok_id] [int] IDENTITY(1,1) NOT NULL,
	[UrunAlisFiyati] [decimal](19, 5) NULL,
	[UrunTur_id] [int] NULL,
	[UrunAdi] [varchar](100) NULL,
	[UrunAdet] [float] NULL,
	[UrunGirisTarihi] [datetime] NULL,
	[FirmaId] [int] NULL,
 CONSTRAINT [PK_StoktakiUrunler] PRIMARY KEY CLUSTERED 
(
	[UrunStok_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[BirlestirilenParcalar] ON 

INSERT [dbo].[BirlestirilenParcalar] ([BirlestirilenParcalarId], [StokId], [BirlestirilenUrunId]) VALUES (36, 1004, 1005)
INSERT [dbo].[BirlestirilenParcalar] ([BirlestirilenParcalarId], [StokId], [BirlestirilenUrunId]) VALUES (37, 1004, 1006)
INSERT [dbo].[BirlestirilenParcalar] ([BirlestirilenParcalarId], [StokId], [BirlestirilenUrunId]) VALUES (38, 1004, 1005)
INSERT [dbo].[BirlestirilenParcalar] ([BirlestirilenParcalarId], [StokId], [BirlestirilenUrunId]) VALUES (39, 1004, 1006)
INSERT [dbo].[BirlestirilenParcalar] ([BirlestirilenParcalarId], [StokId], [BirlestirilenUrunId]) VALUES (40, 1004, 1005)
INSERT [dbo].[BirlestirilenParcalar] ([BirlestirilenParcalarId], [StokId], [BirlestirilenUrunId]) VALUES (41, 1004, 1006)
SET IDENTITY_INSERT [dbo].[BirlestirilenParcalar] OFF
SET IDENTITY_INSERT [dbo].[Firmalar] ON 

INSERT [dbo].[Firmalar] ([FirmaId], [FirmaAdi], [FirmaAdresi], [FirmaTelNo], [FirmaAlınanSatilan]) VALUES (1, N'Reklamotv', N'Teknokent', N'05373603204', 1)
SET IDENTITY_INSERT [dbo].[Firmalar] OFF
SET IDENTITY_INSERT [dbo].[GenelUrunler] ON 

INSERT [dbo].[GenelUrunler] ([Urun_id], [Urun_adi], [Urun_kodu], [Urun_Ol_Tarih]) VALUES (1002, N'18 inç Otobüs İçi Led Ekran', N'RNB001', CAST(0x0000A52500C7203D AS DateTime))
INSERT [dbo].[GenelUrunler] ([Urun_id], [Urun_adi], [Urun_kodu], [Urun_Ol_Tarih]) VALUES (1003, N'denemeürün', N'12345', CAST(0x0000A52500ED6135 AS DateTime))
SET IDENTITY_INSERT [dbo].[GenelUrunler] OFF
SET IDENTITY_INSERT [dbo].[PersonelTable] ON 

INSERT [dbo].[PersonelTable] ([Personel_id], [Personel_adi], [Personel_soyadi], [Personel_departman]) VALUES (1002, N'Mustafa', N'Fidan', N'Yazılım')
INSERT [dbo].[PersonelTable] ([Personel_id], [Personel_adi], [Personel_soyadi], [Personel_departman]) VALUES (1003, N'Muhammed', N'Rafiuzzaman', N'Yazılım')
INSERT [dbo].[PersonelTable] ([Personel_id], [Personel_adi], [Personel_soyadi], [Personel_departman]) VALUES (1004, N'Bahadır', N'Ünal', N'Yönetim')
INSERT [dbo].[PersonelTable] ([Personel_id], [Personel_adi], [Personel_soyadi], [Personel_departman]) VALUES (1005, N'Hüseyin', N'Alsanabani', N'Yazılım')
SET IDENTITY_INSERT [dbo].[PersonelTable] OFF
SET IDENTITY_INSERT [dbo].[ReserveUrunler] ON 

INSERT [dbo].[ReserveUrunler] ([ReseverId], [UrunStokId], [ReserveUrunAdet], [ReserveTarihi], [ReserveYapilanFirma]) VALUES (1, 1004, 30, NULL, 1)
INSERT [dbo].[ReserveUrunler] ([ReseverId], [UrunStokId], [ReserveUrunAdet], [ReserveTarihi], [ReserveYapilanFirma]) VALUES (2, 1005, 40, CAST(0x0000A53200C8D72C AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[ReserveUrunler] OFF
SET IDENTITY_INSERT [dbo].[SatilanUrunler] ON 

INSERT [dbo].[SatilanUrunler] ([SatilanUrun_id], [SatilanUrun_adi], [SatanPersonel], [UrununSatilisTarihi], [UrunSatisFiyati], [UrunTur_id], [UrunStok_id], [UrunToplamKar], [SatilanUrunAdet], [FirmaId]) VALUES (1, N'Deneme', 1004, CAST(0x0000A52500F156EA AS DateTime), CAST(300.00000 AS Decimal(19, 5)), 1002, 1004, 20, NULL, NULL)
INSERT [dbo].[SatilanUrunler] ([SatilanUrun_id], [SatilanUrun_adi], [SatanPersonel], [UrununSatilisTarihi], [UrunSatisFiyati], [UrunTur_id], [UrunStok_id], [UrunToplamKar], [SatilanUrunAdet], [FirmaId]) VALUES (2, N'Deneme', 1005, CAST(0x0000A52500F257B5 AS DateTime), CAST(300.00000 AS Decimal(19, 5)), 1002, 1005, 20, 10, NULL)
SET IDENTITY_INSERT [dbo].[SatilanUrunler] OFF
SET IDENTITY_INSERT [dbo].[SikayetTur] ON 

INSERT [dbo].[SikayetTur] ([SikayetTurId], [SikayetAciklama]) VALUES (1003, N'Deneme Şikayet')
SET IDENTITY_INSERT [dbo].[SikayetTur] OFF
SET IDENTITY_INSERT [dbo].[SikayetUrunler] ON 

INSERT [dbo].[SikayetUrunler] ([SikayetId], [SatilanUrunId], [UrunStokId], [SikayetTuruId], [FirmaId], [UrunAdet], [SikayetTarihi]) VALUES (1, 1, 1004, 1003, 1, 3, CAST(0x0000A55500000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[SikayetUrunler] OFF
SET IDENTITY_INSERT [dbo].[StoktakiUrunler] ON 

INSERT [dbo].[StoktakiUrunler] ([UrunStok_id], [UrunAlisFiyati], [UrunTur_id], [UrunAdi], [UrunAdet], [UrunGirisTarihi], [FirmaId]) VALUES (1004, CAST(399.00000 AS Decimal(19, 5)), 1002, N'Deneme6', NULL, CAST(0x0000A52500C8E2F5 AS DateTime), NULL)
INSERT [dbo].[StoktakiUrunler] ([UrunStok_id], [UrunAlisFiyati], [UrunTur_id], [UrunAdi], [UrunAdet], [UrunGirisTarihi], [FirmaId]) VALUES (1005, CAST(300.00000 AS Decimal(19, 5)), 1002, N'deneme7', 10, CAST(0x0000A52500E5C5D8 AS DateTime), NULL)
INSERT [dbo].[StoktakiUrunler] ([UrunStok_id], [UrunAlisFiyati], [UrunTur_id], [UrunAdi], [UrunAdet], [UrunGirisTarihi], [FirmaId]) VALUES (1006, CAST(300.00000 AS Decimal(19, 5)), 1002, N'StokÜrün', 20, CAST(0x0000A52500EDC88E AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[StoktakiUrunler] OFF
ALTER TABLE [dbo].[BirlestirilenParcalar]  WITH CHECK ADD  CONSTRAINT [FK_BirlestirilenParcalar_StoktakiUrunler] FOREIGN KEY([StokId])
REFERENCES [dbo].[StoktakiUrunler] ([UrunStok_id])
GO
ALTER TABLE [dbo].[BirlestirilenParcalar] CHECK CONSTRAINT [FK_BirlestirilenParcalar_StoktakiUrunler]
GO
ALTER TABLE [dbo].[BirlestirilenUrun]  WITH CHECK ADD  CONSTRAINT [FK_BirlestirilenUrun_StoktakiUrunler] FOREIGN KEY([UrunStokId])
REFERENCES [dbo].[StoktakiUrunler] ([UrunStok_id])
GO
ALTER TABLE [dbo].[BirlestirilenUrun] CHECK CONSTRAINT [FK_BirlestirilenUrun_StoktakiUrunler]
GO
ALTER TABLE [dbo].[ReserveUrunler]  WITH CHECK ADD  CONSTRAINT [FK_ReserveUrunler_Firmalar] FOREIGN KEY([ReserveYapilanFirma])
REFERENCES [dbo].[Firmalar] ([FirmaId])
GO
ALTER TABLE [dbo].[ReserveUrunler] CHECK CONSTRAINT [FK_ReserveUrunler_Firmalar]
GO
ALTER TABLE [dbo].[ReserveUrunler]  WITH CHECK ADD  CONSTRAINT [FK_ReserveUrunler_StoktakiUrunler] FOREIGN KEY([UrunStokId])
REFERENCES [dbo].[StoktakiUrunler] ([UrunStok_id])
GO
ALTER TABLE [dbo].[ReserveUrunler] CHECK CONSTRAINT [FK_ReserveUrunler_StoktakiUrunler]
GO
ALTER TABLE [dbo].[SatilanUrunler]  WITH CHECK ADD  CONSTRAINT [FK_SatilanUrunler_Firmalar] FOREIGN KEY([FirmaId])
REFERENCES [dbo].[Firmalar] ([FirmaId])
GO
ALTER TABLE [dbo].[SatilanUrunler] CHECK CONSTRAINT [FK_SatilanUrunler_Firmalar]
GO
ALTER TABLE [dbo].[SatilanUrunler]  WITH CHECK ADD  CONSTRAINT [FK_SatilanUrunler_GenelUrunler] FOREIGN KEY([UrunTur_id])
REFERENCES [dbo].[GenelUrunler] ([Urun_id])
GO
ALTER TABLE [dbo].[SatilanUrunler] CHECK CONSTRAINT [FK_SatilanUrunler_GenelUrunler]
GO
ALTER TABLE [dbo].[SatilanUrunler]  WITH CHECK ADD  CONSTRAINT [FK_SatilanUrunler_PersonelTable] FOREIGN KEY([SatanPersonel])
REFERENCES [dbo].[PersonelTable] ([Personel_id])
GO
ALTER TABLE [dbo].[SatilanUrunler] CHECK CONSTRAINT [FK_SatilanUrunler_PersonelTable]
GO
ALTER TABLE [dbo].[SatilanUrunler]  WITH CHECK ADD  CONSTRAINT [FK_SatilanUrunler_StoktakiUrunler] FOREIGN KEY([UrunStok_id])
REFERENCES [dbo].[StoktakiUrunler] ([UrunStok_id])
GO
ALTER TABLE [dbo].[SatilanUrunler] CHECK CONSTRAINT [FK_SatilanUrunler_StoktakiUrunler]
GO
ALTER TABLE [dbo].[SikayetUrunler]  WITH CHECK ADD  CONSTRAINT [FK_SikayetUrunler_Firmalar] FOREIGN KEY([FirmaId])
REFERENCES [dbo].[Firmalar] ([FirmaId])
GO
ALTER TABLE [dbo].[SikayetUrunler] CHECK CONSTRAINT [FK_SikayetUrunler_Firmalar]
GO
ALTER TABLE [dbo].[SikayetUrunler]  WITH CHECK ADD  CONSTRAINT [FK_SikayetUrunler_SatilanUrunler] FOREIGN KEY([SatilanUrunId])
REFERENCES [dbo].[SatilanUrunler] ([SatilanUrun_id])
GO
ALTER TABLE [dbo].[SikayetUrunler] CHECK CONSTRAINT [FK_SikayetUrunler_SatilanUrunler]
GO
ALTER TABLE [dbo].[SikayetUrunler]  WITH CHECK ADD  CONSTRAINT [FK_SikayetUrunler_SikayetTur] FOREIGN KEY([SikayetTuruId])
REFERENCES [dbo].[SikayetTur] ([SikayetTurId])
GO
ALTER TABLE [dbo].[SikayetUrunler] CHECK CONSTRAINT [FK_SikayetUrunler_SikayetTur]
GO
ALTER TABLE [dbo].[SikayetUrunler]  WITH CHECK ADD  CONSTRAINT [FK_SikayetUrunler_StoktakiUrunler] FOREIGN KEY([UrunStokId])
REFERENCES [dbo].[StoktakiUrunler] ([UrunStok_id])
GO
ALTER TABLE [dbo].[SikayetUrunler] CHECK CONSTRAINT [FK_SikayetUrunler_StoktakiUrunler]
GO
ALTER TABLE [dbo].[StoktakiUrunler]  WITH CHECK ADD  CONSTRAINT [FK_StoktakiUrunler_Firmalar] FOREIGN KEY([FirmaId])
REFERENCES [dbo].[Firmalar] ([FirmaId])
GO
ALTER TABLE [dbo].[StoktakiUrunler] CHECK CONSTRAINT [FK_StoktakiUrunler_Firmalar]
GO
ALTER TABLE [dbo].[StoktakiUrunler]  WITH CHECK ADD  CONSTRAINT [FK_StoktakiUrunler_GenelUrunler] FOREIGN KEY([UrunTur_id])
REFERENCES [dbo].[GenelUrunler] ([Urun_id])
GO
ALTER TABLE [dbo].[StoktakiUrunler] CHECK CONSTRAINT [FK_StoktakiUrunler_GenelUrunler]
GO
