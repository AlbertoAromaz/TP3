USE [DBCondominio]

GO

-- SELECT * FROM [t_ubicacion]
INSERT INTO [dbo].[t_ubicacion]
           ([NombreUbicacion]
           ,[Estado]
           ,[UsuarioCreacion]
           ,[FechaCreacion]
           ,[UsuarioModificacion]
           ,[FechaModificacion])
     VALUES
           ('UBICACION 1' ,0 ,'AZAMORA' ,'07-02-2016','AZAMORA','07-02-2016')
GO

-- SELECT * FROM [t_vivienda]
INSERT INTO [dbo].[t_vivienda]
           ([CodigoTipoVivienda]
           ,[CodigoUbicacion]
           ,[NumeroVivienda]
           ,[Metraje]
           ,[TieneSalaComedor]
           ,[NroCuartos]
           ,[NroBano]
           ,[Estado]
           ,[UsuarioCreacion]
           ,[FechaCreacion]
           ,[UsuarioModificacion]
           ,[FechaModificacion])
     VALUES
           (1           ,5           ,1           ,34           ,0           ,5           ,234           ,1
           ,'AZAMORA'           ,'07-02-2016'           ,'AZAMORA'           ,'07-02-2016')
GO


-- SELECT * FROM [t_residente]
INSERT INTO [dbo].[t_residente]
           ([TipoDoc]
           ,[NroDoc]
           ,[Nombres]  
		   ,[Ape_Paterno]
		   ,[Ape_Materno] )
     VALUES
           ('02','41764224','ALBERTO','ZAMORA','SALAS')
GO


-- SELECT * FROM [t_contrato]

create procedure SP_CONTRATO_INSERTAR (
@CodigoContrato int out ,
@CodigoVivienda int,
@CodigoResidente int,
@FechaContrato datetime,
@FechaIniResidencia datetime,
@CostoMensual decimal,
@Periodo int,
@Estado char,
@UsuarioCreacion varchar,
@FechaCreacion datetime

)
AS
BEGIN

INSERT INTO [dbo].[t_contrato]
           ([CodigoVivienda]
           ,[CodigoResidente]
           ,[FechaContrato]
           ,[FechaIniResidencia]
           ,[CostoMensual]
           ,[Periodo]
           ,[Estado]
           ,[UsuarioCreacion]
           ,[FechaCreacion]
			)
     VALUES
           (@CodigoVivienda, 
		    @CodigoResidente, 
			@FechaContrato,
			@FechaIniResidencia, 
			@CostoMensual, 
			@Periodo,
			@estado, 
			@UsuarioCreacion, 
			@FechaCreacion
			)
		  
 set @CodigoContrato = @@IDENTITY

END
GO


DECLARE @CodigoContrato INT
-- PARA PROBAR TU STORED
EXEC SP_CONTRATO_INSERTAR  @CodigoContrato OUTPUT,
1, 
		    9, 
			'20150202',
			'20150202',
	20.0, 
			'2015',
			'1', 
			'A',
			'20161201'
SELECT @CodigoContrato

SELECT * FROM [dbo].[t_contrato]