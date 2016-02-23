-- SP_CUOTAS_BUSCAR 3,0,0,'cancelado','0','0'

--exec SP_CUOTAS_BUSCAR @CodigoContrato=3,@CodigoResidente=0,@CodigoVivienda=0,@Estado_Cuota=N'''''',@FechaIni=N'''''',@FechaFin=N''''''
ALTER PROC [DBO].[SP_CUOTAS_BUSCAR]
(
	@CodigoContrato		Int,
	@CodigoResidente	Int,
	@CodigoVivienda		Int,
	@Estado_Cuota		Varchar(20),
	@FechaIni			Varchar(10),
	@FechaFin			Varchar(10)
)
AS
BEGIN
	DECLARE
		@DFechIni	DATETIME,
		@DFechFin	DATETIME

	IF(@FechaIni!='0')
	BEGIN 
		SET @DFechIni = CAST(@FechaIni AS datetime)
	END

	IF(@FechaFin!='0')
		SET @DFechFin = CAST(@FechaFin AS datetime)
	
	IF(@Estado_Cuota = 'TODOS')
		Set @Estado_Cuota = '0'

	Select
		a.CodigoCuota,
		a.NumSequencial,
		a.CodigoContrato,
		b.CostoMensual,
		a.FechaVencimiento,
		a.FechaPago,
		a.Estado_Cuota,
		a.Estado,
		a.UsuarioCreacion,
		a.FechaCreacion,
		a.UsuarioModificacion,
		a.FechaModificacion,
		c.Codigo As CodigoResidente,
		c.Ape_Paterno+' '+ c.Ape_Materno+', '+ c.Nombres As Residente,
		d.CodigoVivienda,
		e.NombreUbicacion +' - ' +  Cast(d.NumeroVivienda As Varchar) As Vivienda
	From t_cuotas a (Nolock)
	Inner Join t_contrato b (Nolock) ON a.CodigoContrato = b.CodigoContrato
	Inner Join t_residente c (Nolock) ON b.CodigoResidente = c.Codigo
	Inner Join t_vivienda d (Nolock) ON b.CodigoVivienda = d.CodigoVivienda
	Inner Join t_ubicacion e (Nolock) On d.CodigoUbicacion = e.CodigoUbicacion
	Where (a.CodigoContrato = @CodigoContrato Or @CodigoContrato = 0)
	  And (b.CodigoResidente = @CodigoResidente Or @CodigoResidente = 0)
	  And (b.CodigoVivienda = @CodigoVivienda Or @CodigoVivienda = 0)
	  --agregar parametros de consultar cuota
	  And (a.Estado_Cuota = @Estado_Cuota Or @Estado_Cuota = '0')
	  And (a.FechaVencimiento >= @DFechIni Or @DFechIni Is NULL)
	  And (a.FechaVencimiento <= @DFechFin Or @DFechFin Is NULL)
			
END