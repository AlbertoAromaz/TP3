USE [DBCondominio]
GO

CREATE procedure [dbo].[SP_CONTRATO_INSERTAR] (
@CodigoContrato int out ,
@CodigoVivienda int,
@CodigoResidente int,
@FechaContrato datetime,
@FechaIniResidencia datetime,
@CostoMensual decimal,
@Periodo int,
@Estado char,
@UsuarioCreacion varchar(60),
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
