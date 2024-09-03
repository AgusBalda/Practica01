/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_FACTURAS]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RECUPERAR_FACTURAS] 
AS
BEGIN
	SELECT * FROM Facturas
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GUARDAR_FACTURA]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GUARDAR_FACTURA]
@id int ,
@cliente varchar(50),
@forma_pago int,
@fecha date
AS
BEGIN 
	IF @id = 0
		BEGIN
			insert into Facturas(cliente, id_forma_pago, fecha, esta_activo) 
			values (@cliente,@forma_pago,@fecha, 1)
		END
	ELSE
		BEGIN
			update Facturas
			set cliente= @cliente, id_forma_pago= @forma_pago, fecha=@fecha
			where id=@id
		END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_FACTURA_CODIGO]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RECUPERAR_FACTURAS_CODIGO] 
	@id int
AS
BEGIN
	SELECT * FROM Facturas where id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_REGISTRAR_BAJA_FACTURA]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_REGISTRAR_BAJA_FACTURA] 
	@id int 

AS
BEGIN
	UPDATE Facturas SET esta_activo = 0 WHERE id = @id;
END
GO