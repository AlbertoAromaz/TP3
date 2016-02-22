USE DBCondominio
GO

INSERT INTO [dbo].[t_tipovivienda]([NombreTipoVivienda]) VALUES('Casa')
INSERT INTO [dbo].[t_tipovivienda]([NombreTipoVivienda]) VALUES('Departamento')
INSERT INTO [dbo].[t_tipovivienda]([NombreTipoVivienda]) VALUES('Duplex')


INSERT INTO [dbo].[t_ubicacion]([NombreUbicacion]) VALUES('Zona A')
INSERT INTO [dbo].[t_ubicacion]([NombreUbicacion]) VALUES('Zona B')
INSERT INTO [dbo].[t_ubicacion]([NombreUbicacion]) VALUES('Zona D')
INSERT INTO [dbo].[t_ubicacion]([NombreUbicacion]) VALUES('Zona E')


INSERT INTO [dbo].[T_VIVIENDA](
				[CodigoTipoVivienda],[CodigoUbicacion],[NumeroVivienda],[Metraje],[TieneSalaComedor],
				[NroCuartos],[NroBano],[Estado],[UsuarioCreacion],[FechaCreacion],[UsuarioModificacion],[FechaModificacion])
		VALUES(1,1,101,100,1,2,1,1,'',GETDATE(),'',GETDATE())


INSERT INTO [dbo].[t_costoxvivienda](
					[CodigoVivienda],[FechaIniVigencia],[FechaFinVigencia],[Costo],[Estado],[UsuarioCreacion],[FechaCreacion],[UsuarioModificacion],[FechaModificacion])
	   VALUES(1,'20160101','20160131',1000,1,'',GETDATE(),'',GETDATE())

	   
INSERT INTO [dbo].[t_costoxvivienda](
					[CodigoVivienda],[FechaIniVigencia],[FechaFinVigencia],[Costo],[Estado],[UsuarioCreacion],[FechaCreacion],[UsuarioModificacion],[FechaModificacion])
	   VALUES(1,'20160201','20160331',1100,1,'',GETDATE(),'',GETDATE())

INSERT INTO [dbo].[t_costoxvivienda](
			[CodigoVivienda],[FechaIniVigencia],[FechaFinVigencia],[Costo],[Estado],[UsuarioCreacion],[FechaCreacion],[UsuarioModificacion],[FechaModificacion])
VALUES(1,'20160401','20160531',1200,1,'',GETDATE(),'',GETDATE())



--- vivienda 2
INSERT INTO [dbo].[t_costoxvivienda](
					[CodigoVivienda],[FechaIniVigencia],[FechaFinVigencia],[Costo],[Estado],[UsuarioCreacion],[FechaCreacion],[UsuarioModificacion],[FechaModificacion])
	   VALUES(2,'20160101','20160131',1000,1,'',GETDATE(),'',GETDATE())

	   
INSERT INTO [dbo].[t_costoxvivienda](
					[CodigoVivienda],[FechaIniVigencia],[FechaFinVigencia],[Costo],[Estado],[UsuarioCreacion],[FechaCreacion],[UsuarioModificacion],[FechaModificacion])
	   VALUES(2,'20160201','20160331',1100,1,'',GETDATE(),'',GETDATE())

INSERT INTO [dbo].[t_costoxvivienda](
			[CodigoVivienda],[FechaIniVigencia],[FechaFinVigencia],[Costo],[Estado],[UsuarioCreacion],[FechaCreacion],[UsuarioModificacion],[FechaModificacion])
VALUES(2,'20160401','20160531',1200,1,'',GETDATE(),'',GETDATE())



--- vivienda 3
INSERT INTO [dbo].[t_costoxvivienda](
					[CodigoVivienda],[FechaIniVigencia],[FechaFinVigencia],[Costo],[Estado],[UsuarioCreacion],[FechaCreacion],[UsuarioModificacion],[FechaModificacion])
	   VALUES(3,'20160101','20160131',1000,1,'',GETDATE(),'',GETDATE())

	   
INSERT INTO [dbo].[t_costoxvivienda](
					[CodigoVivienda],[FechaIniVigencia],[FechaFinVigencia],[Costo],[Estado],[UsuarioCreacion],[FechaCreacion],[UsuarioModificacion],[FechaModificacion])
	   VALUES(3,'20160201','20160331',1100,1,'',GETDATE(),'',GETDATE())

INSERT INTO [dbo].[t_costoxvivienda](
			[CodigoVivienda],[FechaIniVigencia],[FechaFinVigencia],[Costo],[Estado],[UsuarioCreacion],[FechaCreacion],[UsuarioModificacion],[FechaModificacion])
VALUES(3,'20160401','20160531',1200,1,'',GETDATE(),'',GETDATE())


-- Vivienda 4
INSERT INTO [dbo].[t_costoxvivienda](
					[CodigoVivienda],[FechaIniVigencia],[FechaFinVigencia],[Costo],[Estado],[UsuarioCreacion],[FechaCreacion],[UsuarioModificacion],[FechaModificacion])
	   VALUES(4,'20160101','20160131',1000,1,'',GETDATE(),'',GETDATE())

	   
INSERT INTO [dbo].[t_costoxvivienda](
					[CodigoVivienda],[FechaIniVigencia],[FechaFinVigencia],[Costo],[Estado],[UsuarioCreacion],[FechaCreacion],[UsuarioModificacion],[FechaModificacion])
	   VALUES(4,'20160201','20160331',1100,1,'',GETDATE(),'',GETDATE())

INSERT INTO [dbo].[t_costoxvivienda](
			[CodigoVivienda],[FechaIniVigencia],[FechaFinVigencia],[Costo],[Estado],[UsuarioCreacion],[FechaCreacion],[UsuarioModificacion],[FechaModificacion])
VALUES(4,'20160401','20160531',1200,1,'',GETDATE(),'',GETDATE())


SELECT * FROM T_COSTOXVIVIENDA