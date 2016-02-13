

CREATE PROC SP_RESIDENTE_LISTAR
(
@NroDoc  VARCHAR(10),
@Nombres VARCHAR(60)
)
AS
BEGIN

SELECT [Codigo]
      ,[TipoDoc]
      ,[NroDoc]
      ,[Ape_Paterno] + ' ' + [Ape_Materno] + ' , '+ [Nombres] AS Nombres
      ,[Sexo]
      ,[Fecha_Nacimiento]
      ,[Telefono]
      ,[Celular]
      ,[Correo]
      ,[Estado]
 FROM t_residente
 WHERE 
		NroDoc like '%'+isnull(@NroDoc, '')+'%'
	AND isnull(Nombres,'') like '%'+ISNULL(@Nombres,'')+ '%'

END

 