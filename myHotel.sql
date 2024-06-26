USE [myHotel]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 24.04.2021 00:15:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[cid] [int] IDENTITY(1,1) NOT NULL,
	[cname] [varchar](250) NOT NULL,
	[mobile] [varchar](30) NOT NULL,
	[nationality] [varchar](250) NOT NULL,
	[gender] [varchar](50) NOT NULL,
	[dob] [varchar](50) NOT NULL,
	[idproof] [varchar](250) NOT NULL,
	[addres] [varchar](350) NOT NULL,
	[checkin] [varchar](250) NOT NULL,
	[checkout] [varchar](250) NULL,
	[chekout] [varchar](250) NOT NULL,
	[roomid] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employee]    Script Date: 24.04.2021 00:15:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee](
	[eid] [int] IDENTITY(1,1) NOT NULL,
	[ename] [varchar](250) NOT NULL,
	[mobile] [varchar](30) NOT NULL,
	[gender] [varchar](50) NOT NULL,
	[emailid] [varchar](120) NOT NULL,
	[username] [varchar](150) NOT NULL,
	[pass] [varchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[eid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rooms]    Script Date: 24.04.2021 00:15:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rooms](
	[roomid] [int] IDENTITY(1,1) NOT NULL,
	[roomNo] [varchar](250) NOT NULL,
	[roomType] [varchar](250) NOT NULL,
	[bed] [varchar](250) NOT NULL,
	[price] [bigint] NOT NULL,
	[booked] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[roomid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[customer] ON 

INSERT [dbo].[customer] ([cid], [cname], [mobile], [nationality], [gender], [dob], [idproof], [addres], [checkin], [checkout], [chekout], [roomid]) VALUES (1, N'Rabia', N'5315676565', N'Turkish', N'Female', N'11 Ekim 2000 Çarşamba', N'888-555-666-333', N'Basaksehir,Turkey', N'21.04.2021', N'23 Nisan 2021 Cuma', N'YES', 2)
INSERT [dbo].[customer] ([cid], [cname], [mobile], [nationality], [gender], [dob], [idproof], [addres], [checkin], [checkout], [chekout], [roomid]) VALUES (2, N'Arda', N'5311233212', N'Turkish', N'Male', N'16 Temmuz 1999 Cuma', N'333-222-444-777', N'Bakırkoy', N'21.04.2021', NULL, N'NO', 3)
INSERT [dbo].[customer] ([cid], [cname], [mobile], [nationality], [gender], [dob], [idproof], [addres], [checkin], [checkout], [chekout], [roomid]) VALUES (3, N'Kadri', N'5449999999', N'Turkish', N'Male', N'13 Temmuz 1995 Perşembe', N'3333-2222-1111-333', N'Sirinevler', N'22.04.2021', NULL, N'NO', 4)
INSERT [dbo].[customer] ([cid], [cname], [mobile], [nationality], [gender], [dob], [idproof], [addres], [checkin], [checkout], [chekout], [roomid]) VALUES (4, N'Melis', N'5300000000', N'Turkish', N'Female', N'29 Aralık 1998 Salı', N'333-222-111-666', N'Beylikdüzü', N'22.04.2021', N'22 Nisan 2021 Perşembe', N'YES', 7)
INSERT [dbo].[customer] ([cid], [cname], [mobile], [nationality], [gender], [dob], [idproof], [addres], [checkin], [checkout], [chekout], [roomid]) VALUES (5, N'Hakkı', N'5311111212', N'Turkish', N'Male', N'7 Haziran 1990 Perşembe', N'2222-8888-5555-666', N'Adıyaman', N'23.04.2021', N'23 Nisan 2021 Cuma', N'YES', 9)
INSERT [dbo].[customer] ([cid], [cname], [mobile], [nationality], [gender], [dob], [idproof], [addres], [checkin], [checkout], [chekout], [roomid]) VALUES (6, N'Asuman', N'5444098978', N'Turkish', N'Female', N'15 Haziran 1980 Pazar', N'2222-0000-777-666', N'Yesilkoy', N'23.04.2021', NULL, N'NO', 13)
INSERT [dbo].[customer] ([cid], [cname], [mobile], [nationality], [gender], [dob], [idproof], [addres], [checkin], [checkout], [chekout], [roomid]) VALUES (7, N'Mursel', N'5313976767', N'Turkish', N'Male', N'11 Temmuz 1985 Perşembe', N'555-8888-000', N'Ikitelli', N'23.04.2021', N'23 Nisan 2021 Cuma', N'YES', 14)
INSERT [dbo].[customer] ([cid], [cname], [mobile], [nationality], [gender], [dob], [idproof], [addres], [checkin], [checkout], [chekout], [roomid]) VALUES (8, N'Bora', N'5376768787', N'Turkish', N'Male', N'22 Şubat 1990 Perşembe', N'333-222-777-9999', N'Esenyurt', N'23.04.2021', NULL, N'NO', 5)
INSERT [dbo].[customer] ([cid], [cname], [mobile], [nationality], [gender], [dob], [idproof], [addres], [checkin], [checkout], [chekout], [roomid]) VALUES (9, N'Emir', N'5315678787', N'Turkish', N'Male', N'31 Ocak 1900 Çarşamba', N'5555-444-007-666', N'Denizli', N'23.04.2021', N'23 Nisan 2021 Cuma', N'YES', 11)
SET IDENTITY_INSERT [dbo].[customer] OFF
GO
SET IDENTITY_INSERT [dbo].[employee] ON 

INSERT [dbo].[employee] ([eid], [ename], [mobile], [gender], [emailid], [username], [pass]) VALUES (1, N'Meryem ', N'5317260245', N'Female', N'm567@hotmail.com', N'mcevikk', N'pass')
INSERT [dbo].[employee] ([eid], [ename], [mobile], [gender], [emailid], [username], [pass]) VALUES (2, N'Seda', N'5409877878', N'Female', N'seda_3456@gmail.com', N'sedaa', N'pass')
INSERT [dbo].[employee] ([eid], [ename], [mobile], [gender], [emailid], [username], [pass]) VALUES (3, N'Ali', N'5467777767', N'Male', N'alic34@gmail.com', N'aliii', N'pass')
INSERT [dbo].[employee] ([eid], [ename], [mobile], [gender], [emailid], [username], [pass]) VALUES (4, N'Celal', N'5123211212', N'Male', N'celalc12@hotmail.com', N'celac', N'pass')
INSERT [dbo].[employee] ([eid], [ename], [mobile], [gender], [emailid], [username], [pass]) VALUES (6, N'Rabia', N'5312348787', N'Female', N'rce345@hotmail.com', N'rabiacevikk', N'pass')
SET IDENTITY_INSERT [dbo].[employee] OFF
GO
SET IDENTITY_INSERT [dbo].[rooms] ON 

INSERT [dbo].[rooms] ([roomid], [roomNo], [roomType], [bed], [price], [booked]) VALUES (1, N'100', N'Ac', N'Single', 5000, N'YES')
INSERT [dbo].[rooms] ([roomid], [roomNo], [roomType], [bed], [price], [booked]) VALUES (2, N'102', N'Ac', N'Single', 5000, N'YES')
INSERT [dbo].[rooms] ([roomid], [roomNo], [roomType], [bed], [price], [booked]) VALUES (3, N'201', N'Ac', N'Double', 8000, N'YES')
INSERT [dbo].[rooms] ([roomid], [roomNo], [roomType], [bed], [price], [booked]) VALUES (4, N'302', N'Ac', N'Triple', 6000, N'YES')
INSERT [dbo].[rooms] ([roomid], [roomNo], [roomType], [bed], [price], [booked]) VALUES (5, N'303', N'Ac', N'Single', 5000, N'YES')
INSERT [dbo].[rooms] ([roomid], [roomNo], [roomType], [bed], [price], [booked]) VALUES (6, N'304', N'Non-Ac', N'Single', 3500, N'NO')
INSERT [dbo].[rooms] ([roomid], [roomNo], [roomType], [bed], [price], [booked]) VALUES (7, N'401', N'Non-Ac', N'Triple', 5000, N'YES')
INSERT [dbo].[rooms] ([roomid], [roomNo], [roomType], [bed], [price], [booked]) VALUES (8, N'13', N'Non-Ac', N'Single', 900, N'NO')
INSERT [dbo].[rooms] ([roomid], [roomNo], [roomType], [bed], [price], [booked]) VALUES (9, N'556', N'Ac', N'Triple', 570, N'YES')
INSERT [dbo].[rooms] ([roomid], [roomNo], [roomType], [bed], [price], [booked]) VALUES (10, N'45', N'Non-Ac', N'Double', 600, N'NO')
INSERT [dbo].[rooms] ([roomid], [roomNo], [roomType], [bed], [price], [booked]) VALUES (11, N'57', N'Ac', N'Double', 700, N'YES')
INSERT [dbo].[rooms] ([roomid], [roomNo], [roomType], [bed], [price], [booked]) VALUES (12, N'88', N'Non-Ac', N'Single', 1500, N'NO')
INSERT [dbo].[rooms] ([roomid], [roomNo], [roomType], [bed], [price], [booked]) VALUES (13, N'96', N'Ac', N'Single', 2000, N'YES')
INSERT [dbo].[rooms] ([roomid], [roomNo], [roomType], [bed], [price], [booked]) VALUES (14, N'7', N'Non-Ac', N'Double', 1100, N'YES')
SET IDENTITY_INSERT [dbo].[rooms] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__rooms__6C3BFE6CF45477E8]    Script Date: 24.04.2021 00:15:18 ******/
ALTER TABLE [dbo].[rooms] ADD UNIQUE NONCLUSTERED 
(
	[roomNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[customer] ADD  DEFAULT ('NO') FOR [chekout]
GO
ALTER TABLE [dbo].[rooms] ADD  DEFAULT ('NO') FOR [booked]
GO
ALTER TABLE [dbo].[customer]  WITH CHECK ADD FOREIGN KEY([roomid])
REFERENCES [dbo].[rooms] ([roomid])
GO
