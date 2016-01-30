
-- execute SP_VIVIENDA_BUSCAR 0,0,0
CREATE PROC [DBO].[SP_VIVIENDA_BUSCAR]
(
	@codigoTipoVivienda INT,
	@codigoUbicacion	INT,
	@numeroVivienda		INT
)
AS
BEGIN
	SELECT 
		[CodigoVivienda],TV.[CodigoTipoVivienda],U.[CodigoUbicacion],[NumeroVivienda],[Metraje],
		[TieneSalaComedor],[NroCuartos],[NroBano],V.[UsuarioCreacion],V.[UsuarioModificacion],
		[NombreTipoVivienda],[NombreUbicacion]
	FROM t_VIVIENDA V (NOLOCK)
	INNER JOIN T_TIPOVIVIENDA TV (NOLOCK) ON V.CodigoTipoVivienda = TV.CodigoTipoVivienda
	INNER JOIN T_UBICACION U(NOLOCK) ON V.CodigoUbicacion = U.CodigoUbicacion
	WHERE (TV.CodigoTipoVivienda = @codigoTipoVivienda OR @codigoTipoVivienda=0)
	  AND (U.CodigoUbicacion = @codigoUbicacion OR @codigoUbicacion=0)
	  AND (V.NumeroVivienda = @numeroVivienda OR @numeroVivienda=0)
	

END;
GO