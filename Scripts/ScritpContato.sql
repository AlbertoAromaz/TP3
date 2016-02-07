USE [DBCondominio]
GO

/****** Object:  Table [dbo].[Contrato]    Script Date: 06/02/2016 08:55:43 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[t_contrato](
	[CodigoContrato] [int] NOT NULL,
	[CodigoVivienda] [int] NOT NULL,
	[CodigoResidente] [int] NOT NULL,
	[FechaContrato] [datetime] NULL,
	[Periodo] [int] NULL,
	[Costo] [decimal](5, 2) NULL,
	[UsuarioCreacion] [varchar](50) NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModificacion] [varchar](50) NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_t_contrato] PRIMARY KEY CLUSTERED 
(
	[CodigoContrato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


