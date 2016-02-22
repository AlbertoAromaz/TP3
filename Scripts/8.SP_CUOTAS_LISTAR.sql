-- SP_CUOTAS_LISTAR
ALTER PROC [DBO].[SP_CUOTAS_LISTAR]
AS
BEGIN
	Select
		a.CodigoCuota,
		a.NumSequencial,
		a.CodigoContrato,
		B.CostoMensual,
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
			
END