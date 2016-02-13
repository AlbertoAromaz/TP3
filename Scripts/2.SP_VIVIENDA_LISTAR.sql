
-- execute SP_VIVIENDA_LISTAR
CREATE PROC [DBO].[SP_VIVIENDA_LISTAR]
AS
BEGIN
	SELECT 
		[CodigoVivienda],
		TV.[CodigoTipoVivienda],
		[NombreTipoVivienda],
		U.[CodigoUbicacion],
		[NombreUbicacion],
		[NumeroVivienda],
		[Metraje],
		[TieneSalaComedor],
		[NroCuartos],
		[NroBano],
		V.[Estado],
		V.[UsuarioCreacion],
		V.[UsuarioModificacion]
	FROM t_VIVIENDA V (NOLOCK)
	INNER JOIN T_TIPOVIVIENDA TV (NOLOCK) ON V.CodigoTipoVivienda = TV.CodigoTipoVivienda
	INNER JOIN T_UBICACION U(NOLOCK) ON V.CodigoUbicacion = U.CodigoUbicacion
	

END;
GO