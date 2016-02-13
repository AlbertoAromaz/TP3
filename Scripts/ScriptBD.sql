CREATE DATABASE DBCondominio
GO

USE DBCondominio
GO



--drop table t_tipoubicacion

-- -----------------------------------------------------------------------------
-- t-ubicacion
-- -----------------------------------------------------------------------------
CREATE TABLE [dbo].[t_ubicacion](
	[CodigoUbicacion] [int] identity NOT NULL,
	[NombreUbicacion] [varchar](50) NOT NULL,
	[Estado][BIT],
	[UsuarioCreacion] [varchar](60) NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModificacion] [varchar](60) NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_t_tipoubicacion] PRIMARY KEY CLUSTERED 
(
	[CodigoUbicacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[t_ubicacion] ADD  CONSTRAINT [DF_t_ubicacion_Estado]  DEFAULT ((1)) FOR [Estado]
GO

ALTER TABLE [dbo].[t_ubicacion] ADD  CONSTRAINT [DF_t_ubicacion_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
GO


-- -----------------------------------------------------------------------------
-- t_tipovivienda
-- -----------------------------------------------------------------------------
CREATE TABLE [dbo].[t_tipovivienda](
	[CodigoTipoVivienda] [int] identity NOT NULL,
	[NombreTipoVivienda] [varchar](50) NOT NULL,
	[Estado][BIT],
	[UsuarioCreacion] [varchar](60) NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModificacion] [varchar](60) NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_t_tipovivienda] PRIMARY KEY CLUSTERED 
(
	[CodigoTipoVivienda] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[t_tipovivienda] ADD  CONSTRAINT [DF_t_tipovivienda_Estado]  DEFAULT ((1)) FOR [Estado]
GO

ALTER TABLE [dbo].[t_tipovivienda] ADD  CONSTRAINT [DF_t_tipovivienda_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
GO

-- -------------------------------------------------------------------------------------
-- t_vivienda
----------------------------------------------------------------------------------------
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
	[UsuarioCreacion] [varchar](60) NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModificacion] [varchar](60) NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_t_vivienda] PRIMARY KEY CLUSTERED 
(
	[CodigoVivienda] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
----------
ALTER TABLE [dbo].[t_vivienda]  WITH CHECK ADD  CONSTRAINT [FK_t_vivienda_t_ubicacion] FOREIGN KEY([CodigoUbicacion])
REFERENCES [dbo].[t_ubicacion] ([CodigoUbicacion])
GO
ALTER TABLE [dbo].[t_vivienda] CHECK CONSTRAINT [FK_t_vivienda_t_ubicacion]
GO
-----------
ALTER TABLE [dbo].[t_vivienda]  WITH CHECK ADD  CONSTRAINT [FK_t_vivienda_t_tipovivienda] FOREIGN KEY([CodigoTipoVivienda])
REFERENCES [dbo].[t_tipovivienda] ([CodigoTipoVivienda])
GO
ALTER TABLE [dbo].[t_vivienda] CHECK CONSTRAINT [FK_t_vivienda_t_tipovivienda]
GO

ALTER TABLE [dbo].[t_vivienda] ADD  CONSTRAINT [DF_t_vivienda_Estado]  DEFAULT ((1)) FOR [Estado]
GO

ALTER TABLE [dbo].[t_vivienda] ADD  CONSTRAINT [DF_t_vivienda_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
GO


-- ------------------------------------------------------------------------------------
-- t_residente
-- ------------------------------------------------------------------------------------
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


-- -------------------------------------------------------------------------
-- t_tarifaxvivienda
-- -------------------------------------------------------------------------
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[t_costoxvivienda](
	[CodigoCostoxVivienda] [int] IDENTITY(1,1) NOT NULL,
	[CodigoVivienda] [int] NOT NULL,
	[FechaIniVigencia] [date] NULL,
	[FechaFinVigencia] [date] NULL,
	[Costo][decimal](10,2) NOT NULL,
	[Estado] [char](1) NULL,
	[UsuarioCreacion] [varchar](60) NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModificacion] [varchar](60) NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_t_tarifaxvivienda] PRIMARY KEY CLUSTERED 
(
	[CodigoCostoxVivienda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


ALTER TABLE [dbo].[t_costoxvivienda]  WITH CHECK ADD  CONSTRAINT [FK_t_costoxvivienda] FOREIGN KEY([CodigoVivienda])
REFERENCES [dbo].[t_vivienda] ([CodigoVivienda])
GO
ALTER TABLE [dbo].[t_costoxvivienda] CHECK CONSTRAINT [FK_t_costoxvivienda]
GO

ALTER TABLE [dbo].[t_costoxvivienda] ADD  CONSTRAINT [DF_t_costoxvivienda_Estado]  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[t_costoxvivienda] ADD  CONSTRAINT [DF_t_costoxvivienda_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
GO

-- -----------------------------------------------------------------------------------------
-- t_contrato
-- -----------------------------------------------------------------------------------------
CREATE TABLE [dbo].[t_contrato](
	[CodigoContrato] [int] IDENTITY(1,1) NOT NULL,
	[CodigoVivienda] [int] NOT NULL,
	[CodigoResidente][int] NOT NULL,
	[FechaContrato] [datetime] NOT NULL,
	[FechaIniResidencia] [datetime] NULL,
	[CostoMensual][decimal](10,2) NOT NULL,
	[Periodo][int] NOT NULL,
	[Estado] [char](1) NULL,
	[UsuarioCreacion] [varchar](60) NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModificacion] [varchar](60) NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_t_contrato] PRIMARY KEY CLUSTERED 
(
	[CodigoContrato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[t_contrato]  WITH CHECK ADD  CONSTRAINT [FK_t_contrato_t_vivienda] FOREIGN KEY([CodigoVivienda])
REFERENCES [dbo].[t_vivienda] ([CodigoVivienda])
GO
ALTER TABLE [dbo].[t_contrato] CHECK CONSTRAINT [FK_t_contrato_t_vivienda]
GO

ALTER TABLE [dbo].[t_contrato]  WITH CHECK ADD  CONSTRAINT [FK_t_contrato_t_residente] FOREIGN KEY([CodigoResidente])
REFERENCES [dbo].[t_residente] ([Codigo])
GO
ALTER TABLE [dbo].[t_contrato] CHECK CONSTRAINT [FK_t_contrato_t_residente]
GO

ALTER TABLE [dbo].[t_contrato] ADD  CONSTRAINT [DF_t_contrato_Estado]  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[t_contrato] ADD  CONSTRAINT [DF_t_contrato_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
GO

-- ------------------------------------------------------------------------------------
-- t_cuotas
-- ------------------------------------------------------------------------------------
CREATE TABLE [dbo].[t_cuotas](
	[CodigoCuota] [int] IDENTITY(1,1) NOT NULL,
	[NumSequencial] [int] NOT NULL,
	[CodigoContrato][int] NOT NULL,
	[FechaVencimiento] [datetime] NOT NULL,
	[FechaPago] [datetime] NULL,
	[Estado_Cuota] [varchar](20) NULL,
	[Estado] [char](1) NULL,
	[UsuarioCreacion] [varchar](60) NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModificacion] [varchar](60) NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_t_cuotas] PRIMARY KEY CLUSTERED 
(
	[CodigoCuota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[t_cuotas]  WITH CHECK ADD  CONSTRAINT [FK_t_cuotas_t_contrato] FOREIGN KEY([CodigoContrato])
REFERENCES [dbo].[t_contrato] ([CodigoContrato])
GO
ALTER TABLE [dbo].[t_cuotas] CHECK CONSTRAINT [FK_t_cuotas_t_contrato]
GO

ALTER TABLE [dbo].[t_cuotas] ADD  CONSTRAINT [DF_t_cuotas_Estado]  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[t_cuotas] ADD  CONSTRAINT [DF_t_cuotas_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
GO