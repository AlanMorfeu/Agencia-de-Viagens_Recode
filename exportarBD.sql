USE [CrudTripTravel]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 20/12/2021 17:27:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 20/12/2021 17:27:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[id_clientes] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](max) NULL,
	[email] [nvarchar](max) NULL,
	[telefone] [nvarchar](max) NULL,
 CONSTRAINT [PK_clientes] PRIMARY KEY CLUSTERED 
(
	[id_clientes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[destinos]    Script Date: 20/12/2021 17:27:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[destinos](
	[id_destinos] [int] IDENTITY(1,1) NOT NULL,
	[destino] [nvarchar](max) NULL,
	[local_destino] [nvarchar](max) NULL,
	[data] [nvarchar](max) NULL,
 CONSTRAINT [PK_destinos] PRIMARY KEY CLUSTERED 
(
	[id_destinos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[promocoes]    Script Date: 20/12/2021 17:27:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[promocoes](
	[id_promocoes] [int] IDENTITY(1,1) NOT NULL,
	[id_clientes] [int] NOT NULL,
	[id_destinos] [int] NOT NULL,
	[promocao] [nvarchar](max) NULL,
 CONSTRAINT [PK_promocoes] PRIMARY KEY CLUSTERED 
(
	[id_promocoes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211219222020_Inicial', N'3.1.22')
GO
SET IDENTITY_INSERT [dbo].[clientes] ON 

INSERT [dbo].[clientes] ([id_clientes], [nome], [email], [telefone]) VALUES (2, N'Alan', N'alan@dev', N'123')
INSERT [dbo].[clientes] ([id_clientes], [nome], [email], [telefone]) VALUES (3, N'David', N'rico@saude', N'321')
INSERT [dbo].[clientes] ([id_clientes], [nome], [email], [telefone]) VALUES (4, N'Fran', N'ceu@ceu', N'412')
SET IDENTITY_INSERT [dbo].[clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[destinos] ON 

INSERT [dbo].[destinos] ([id_destinos], [destino], [local_destino], [data]) VALUES (1, N'Cristo Redentor', N'Rio de Janeiro - Rj', N'A partir de 31/12/21 á 10/01/22')
INSERT [dbo].[destinos] ([id_destinos], [destino], [local_destino], [data]) VALUES (2, N'Coliseu ', N'Roma - Itália', N'A partir de 31/01/22 á 10/03/22')
INSERT [dbo].[destinos] ([id_destinos], [destino], [local_destino], [data]) VALUES (3, N'Chichén Itzá ', N' Yucatán - México', N'A partir de 25/01/22 á 10/03/22')
INSERT [dbo].[destinos] ([id_destinos], [destino], [local_destino], [data]) VALUES (4, N'Machu Picchu', N'Cusco - Peru', N'A partir de 15/01/22 á 10/04/22')
INSERT [dbo].[destinos] ([id_destinos], [destino], [local_destino], [data]) VALUES (5, N'Muralha da China', N'China', N'A partir de 20/02/22 á 10/03/22')
INSERT [dbo].[destinos] ([id_destinos], [destino], [local_destino], [data]) VALUES (6, N'As Ruínas de Petra ', N'Jordânia no Oriente Médio', N'A partir de 03/01/22 á 10/06/22')
INSERT [dbo].[destinos] ([id_destinos], [destino], [local_destino], [data]) VALUES (7, N'Taj Mahal ', N'Agra -India', N'A partir de 30/13/22 á 10/05/22')
SET IDENTITY_INSERT [dbo].[destinos] OFF
GO
SET IDENTITY_INSERT [dbo].[promocoes] ON 

INSERT [dbo].[promocoes] ([id_promocoes], [id_clientes], [id_destinos], [promocao]) VALUES (2, 2, 1, N'100% de desconto')
INSERT [dbo].[promocoes] ([id_promocoes], [id_clientes], [id_destinos], [promocao]) VALUES (3, 4, 7, N'50% de desconto')
SET IDENTITY_INSERT [dbo].[promocoes] OFF
GO
ALTER TABLE [dbo].[promocoes]  WITH CHECK ADD  CONSTRAINT [FK_promocoes_clientes_id_clientes] FOREIGN KEY([id_clientes])
REFERENCES [dbo].[clientes] ([id_clientes])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[promocoes] CHECK CONSTRAINT [FK_promocoes_clientes_id_clientes]
GO
ALTER TABLE [dbo].[promocoes]  WITH CHECK ADD  CONSTRAINT [FK_promocoes_destinos_id_destinos] FOREIGN KEY([id_destinos])
REFERENCES [dbo].[destinos] ([id_destinos])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[promocoes] CHECK CONSTRAINT [FK_promocoes_destinos_id_destinos]
GO
