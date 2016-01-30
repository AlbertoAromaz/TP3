USE DBCondominio
GO

--drop table t_tipoubicacion
CREATE TABLE [dbo].[t_ubicacion](
	[CodigoUbicacion] [int] identity NOT NULL,
	[NombreUbicacion] [varchar](50) NOT NULL,
	[Estado][BIT],
	[UsuarioCreacion] [varchar](50) ,
	[UsuarioModificacion] [varchar](50) ,
 CONSTRAINT [PK_t_tipoubicacion] PRIMARY KEY CLUSTERED 
(
	[CodigoUbicacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


CREATE TABLE [dbo].[t_tipovivienda](
	[CodigoTipoVivienda] [int] identity NOT NULL,
	[NombreTipoVivienda] [varchar](50) NOT NULL,
	[Estado][BIT],
	[UsuarioCreacion] [varchar](50) ,
	[UsuarioModificacion] [varchar](50) ,
 CONSTRAINT [PK_t_tipovivienda] PRIMARY KEY CLUSTERED 
(
	[CodigoTipoVivienda] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

--
-- vivienda
--------------------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_vivienda](
	[CodigoVivienda] [int] identity NOT NULL,
	[CodigoTipoVivienda] [int] NOT NULL,
	[CodigoUbicacion] [int] NOT NULL,
	[NumeroVivienda] [int] NOT NULL,
	[Metraje][decimal](10,2) not null,
	[TieneSalaComedor] [BIT] NOT NULL,
	[NroCuartos] [int] NOT NULL,
	[NroBano] [int] NOT NULL,
	[Estado][BIT],
	[UsuarioCreacion] [varchar](50) ,
	[UsuarioModificacion] [varchar](50) ,
 CONSTRAINT [PK_t_vivienda] PRIMARY KEY CLUSTERED 
(
	[CodigoVivienda] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_t_asesor_t_sede]    Script Date: 03/16/2012 23:23:06 ******/
ALTER TABLE [dbo].[t_vivienda]  WITH CHECK ADD  CONSTRAINT [FK_t_vivienda_t_ubicacion] FOREIGN KEY([CodigoUbicacion])
REFERENCES [dbo].[t_ubicacion] ([CodigoUbicacion])
GO
ALTER TABLE [dbo].[t_vivienda] CHECK CONSTRAINT [FK_t_vivienda_t_ubicacion]
GO

/****** Object:  ForeignKey [FK_t_asesor_t_sede]    Script Date: 03/16/2012 23:23:06 ******/
ALTER TABLE [dbo].[t_vivienda]  WITH CHECK ADD  CONSTRAINT [FK_t_vivienda_t_tipovivienda] FOREIGN KEY([CodigoTipoVivienda])
REFERENCES [dbo].[t_tipovivienda] ([CodigoTipoVivienda])
GO
ALTER TABLE [dbo].[t_vivienda] CHECK CONSTRAINT [FK_t_vivienda_t_tipovivienda]
GO


/****** Object:  Table [dbo].[t_residente]    Script Date: 30/01/2016 0:14:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[t_residente](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[TipoDoc] [varchar](2) NOT NULL,
	[NroDoc] [varchar](10) NOT NULL,
	[Nombres] [varchar](60) NOT NULL,
	[Ape_Paterno] [varchar](50) NOT NULL,
	[Ape_Materno] [varchar](50) NOT NULL,
	[Sexo] [char](1) NULL,
	[Fecha_Nacimiento] [datetime] NULL,
	[Telefono] [varchar](10) NULL,
	[Celular] [varchar](10) NULL,
	[Correo] [varchar](60) NULL,
	[Estado] [char](1) NULL,
	[UsuarioCreacion] [varchar](60) NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModificacion] [varchar](60) NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_t_residente] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[t_residente] ADD  CONSTRAINT [DF_t_residente_Estado]  DEFAULT ((1)) FOR [Estado]
GO

ALTER TABLE [dbo].[t_residente] ADD  CONSTRAINT [DF_t_residente_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
GO

