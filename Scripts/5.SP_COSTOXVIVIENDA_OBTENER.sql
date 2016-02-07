--exec SP_COSTOXVIVIENDA_OBTENER 1,'20160207'
CREATE PROC [DBO].[SP_COSTOXVIVIENDA_OBTENER]
(
	@codigoVivienda			INT,
	@fechaContrato			DATE


)
AS
BEGIN
	SELECT COSTO 
	FROM t_costoxvivienda c (NOLOCK)
	WHERE c.CodigoVivienda = @codigoVivienda
	  AND @fechaContrato BETWEEN c.FechaIniVigencia  AND c.FechaFinVigencia

END;
GO