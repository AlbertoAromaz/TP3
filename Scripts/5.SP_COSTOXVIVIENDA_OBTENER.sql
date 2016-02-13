--exec SP_COSTOXVIVIENDA_OBTENER_COSTO_MENSUAL 1,'20160207'
CREATE PROC [DBO].[SP_COSTOXVIVIENDA_OBTENER_COSTO_MENSUAL]
(
	@codigoVivienda			INT,
	@fechaContrato			SMALLDATETIME


)
AS
BEGIN
	SELECT COSTO 
	FROM t_costoxvivienda c (NOLOCK)
	WHERE c.CodigoVivienda = @codigoVivienda
	  AND @fechaContrato BETWEEN c.FechaIniVigencia  AND c.FechaFinVigencia

END;
GO