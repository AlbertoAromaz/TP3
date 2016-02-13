/*
	BEGIN TRAN
	EXEC SP_CUOTAS_GENERAR 3
	SELECT * FROM T_CUOTAS

	ROLLBACK
*/
CREATE PROC [DBO].[SP_CUOTAS_GENERAR]
(
	@CodigoContrato	Int
)
AS
BEGIN

	Declare
		@Cursor					Int,
		@Periodo				Int,
		@FechaIniResidencia		Datetime

	Set @Cursor = 1

	Select 
		@Periodo = a.Periodo,
		@FechaIniResidencia = a.FechaIniResidencia
	From t_contrato a (Nolock)
	Where a.CodigoContrato = @CodigoContrato
	
	SELECT @Periodo, @FechaIniResidencia
	
	While (@Cursor <= @Periodo)
	Begin
		IF(@Cursor = 1)
		Begin
			Insert into t_cuotas([NumSequencial],[CodigoContrato],[FechaVencimiento],[Estado_Cuota],[Estado],[FechaCreacion])
			Values(@Cursor, @CodigoContrato,@FechaIniResidencia,'Pendiente',1, GETDATE())
		End
		Else
		Begin
			Insert into t_cuotas([NumSequencial],[CodigoContrato],[FechaVencimiento],[Estado_Cuota],[Estado],[FechaCreacion])
			Values(@Cursor, @CodigoContrato,DATEADD(MM,@Cursor,@FechaIniResidencia),'Pendiente',1, GETDATE())
		End
		
		Set @Cursor = @Cursor + 1

	End

END