-- EXEC SP_CONTRATO_VALIDACIONES 1,1,'20160115'
CREATE PROC [DBO].[SP_CONTRATO_VALIDACIONES]
(
	@CodigoVivienda		Int,
	@CodigoResidente	Int,
	@FechaIniResidencia	Datetime
)
AS
Begin
	DECLARE
		@EXIST_VIVIENDA_DISPONIBLE	INT,
		@EXIST_RESIDENTE_MOROSO		INT

	SELECT
		@EXIST_VIVIENDA_DISPONIBLE=1, @EXIST_RESIDENTE_MOROSO = 0

	-- valida si la vivienda se encuentra disponible
	IF EXISTS(SELECT '1'
			 FROM t_contrato TC(NOLOCK)
			 WHERE TC.CodigoVivienda = @CodigoVivienda
			   AND (@FechaIniResidencia>= tc.FechaIniResidencia and @FechaIniResidencia<= DATEADD(MM,tc.Periodo,tc.FechaIniResidencia)))
	BEGIN
		PRINT 'HOLA'
		SET @EXIST_VIVIENDA_DISPONIBLE = 0
	END

	-- Valida si el residente cuenta con deudas pendientes
	IF EXISTS ( SELECT '1'
				FROM t_cuotas a (NOLOCK)
				INNER JOIN t_contrato b (NOLOCK) on a.CodigoContrato = b.CodigoContrato 
				WHERE b.CODIGORESIDENTE = @CodigoResidente
				  AND a.Estado_Cuota = 'Pendiente'
	    	  )
	BEGIN
		SET @EXIST_RESIDENTE_MOROSO = 1
	END

	SELECT
		@EXIST_VIVIENDA_DISPONIBLE EXIST_VIVIENDA_DISPONIBLE,
		@EXIST_RESIDENTE_MOROSO EXIST_RESIDENTE_MOROSO

End