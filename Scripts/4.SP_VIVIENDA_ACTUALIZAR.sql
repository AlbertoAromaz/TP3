CREATE PROC [DBO].[SP_VIVIENDA_ACTUALIZAR]
(
	@codigoVivienda			INT,
	@codigoTipoVivienda		INT,
	@codigoUbicacion		INT,
	@numeroVivienda			INT,
	@metraje				Decimal(10,2),
	@tieneSalaComedor		BIT,
	@nroCuartos				INT,
	@nroBano				INT,
	@estado					BIT,
	@usuarioModificacion	VARCHAR(60),
	@fechaModificacion		DATETIME


)
AS
BEGIN
	UPDATE T_VIVIENDA SET
		[CodigoTipoVivienda] = @codigoTipoVivienda,
		[CodigoUbicacion] = @codigoUbicacion,
		[NumeroVivienda] = @numeroVivienda,
		[Metraje]= @metraje,
		[TieneSalaComedor] = @tieneSalaComedor,
		[NroCuartos] = @nroCuartos,
		[NroBano] = @nroBano,
		[Estado] = @estado,
		[UsuarioModificacion] = @usuarioModificacion,
		[FechaModificacion] = @fechaModificacion
	WHERE [CodigoVivienda] = @codigoVivienda

END;
GO