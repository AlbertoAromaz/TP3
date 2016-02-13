
CREATE PROC SP_RESIDENTE_VALIDAR
(
 @TipoDoc VARCHAR(2),
 @NroDoc  VARCHAR(10),
 @EXISTE  VARCHAR(1)  OUT
)
AS
BEGIN
	SET @EXISTE = 'N'
		
	IF EXISTS (SELECT '1' FROM dbo.t_residente 
			WHERE TipoDoc = @TipoDoc AND NroDoc =@NroDoc )
	BEGIN 
		SET @EXISTE = 'S'	
	END
	
END
