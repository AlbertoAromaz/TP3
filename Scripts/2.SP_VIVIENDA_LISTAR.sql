
-- execute SP_VIVIENDA_LISTAR
CREATE PROC [DBO].[SP_VIVIENDA_LISTAR]
AS
BEGIN
	SELECT 
		[CodigoVivienda],TV.[CodigoTipoVivienda],U.[CodigoUbicacion],[NumeroVivienda],[Metraje],
		[TieneSalaComedor],[NroCuartos],[NroBano],V.[UsuarioCreacion],V.[UsuarioModificacion],
		[NombreTipoVivienda],[NombreUbicacion]
	FROM t_VIVIENDA V (NOLOCK)
	INNER JOIN T_TIPOVIVIENDA TV (NOLOCK) ON V.CodigoTipoVivienda = TV.CodigoTipoVivienda
	INNER JOIN T_UBICACION U(NOLOCK) ON V.CodigoUbicacion = U.CodigoUbicacion
	

END;
GO