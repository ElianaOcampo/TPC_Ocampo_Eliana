CREATE DATABASE OCAMPO_DB
GO
USE OCAMPO_DB
GO
CREATE TABLE MARCAS(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	NOMBRE VARCHAR(50) NOT NULL CHECK(LEN(NOMBRE)>0),
	ESTADO BIT DEFAULT(1)
)

CREATE TABLE CATEGORIAS(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	NOMBRE VARCHAR(50) NOT NULL CHECK(LEN(NOMBRE)>0),
	ESTADO BIT DEFAULT(1)
)

CREATE TABLE TELEFONOS(
	ID BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	NUMERO INT NOT NULL CHECK(NUMERO>0),
	TIPOTEL VARCHAR(20) NOT NULL CHECK(LEN(TIPOTEL)>0)
)

CREATE TABLE DOMICILIOS(
	ID BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	CALLE VARCHAR(30) NOT NULL CHECK(LEN(CALLE)>0),
	ALTURA INT NOT NULL CHECK(ALTURA>0),
	CODIGO_POSTAL INT NOT NULL CHECK(CODIGO_POSTAL>0),
	LOCALIDAD VARCHAR(20) NOT NULL CHECK(LEN(LOCALIDAD)>0)
)

CREATE TABLE PROVEEDORES(
	CUIT BIGINT NOT NULL PRIMARY KEY,
	RAZON_SOCIAL VARCHAR(50) NOT NULL CHECK(LEN(RAZON_SOCIAL)>0),
	CONTACTO VARCHAR(50) NOT NULL CHECK(LEN(CONTACTO)>0),
	IDTELEFONO BIGINT NOT NULL FOREIGN KEY REFERENCES TELEFONOS(ID),
	ESTADO BIT DEFAULT(1)
)

CREATE TABLE EMPLEADOS(
	DNI INT NOT NULL PRIMARY KEY,
	APELLIDO VARCHAR(30) NOT NULL CHECK(LEN(APELLIDO)>0),
	NOMBRE VARCHAR(30) NOT NULL CHECK(LEN(NOMBRE)>0),
	MAIL VARCHAR(50) NOT NULL CHECK(LEN(MAIL)>0),
	IDTELEFONO BIGINT NOT NULL FOREIGN KEY REFERENCES TELEFONOS(ID),
	IDDOMICILIO BIGINT NOT NULL FOREIGN KEY REFERENCES DOMICILIOS(ID),
	CUIL BIGINT NOT NULL CHECK(CUIL>0),
	TIPO VARCHAR(20) NOT NULL CHECK(LEN(TIPO)>0),
	ESTADO BIT DEFAULT(1)
)

CREATE TABLE CLIENTES(
	DNI INT NOT NULL PRIMARY KEY,
	APELLIDO VARCHAR(30) NOT NULL CHECK(LEN(APELLIDO)>0),
	NOMBRE VARCHAR(30) NOT NULL CHECK(LEN(NOMBRE)>0),
	MAIL VARCHAR(50) NOT NULL CHECK(LEN(MAIL)>0),
	IDTELEFONO BIGINT NOT NULL FOREIGN KEY REFERENCES TELEFONOS(ID),
	IDDOMICILIO BIGINT NOT NULL FOREIGN KEY REFERENCES DOMICILIOS(ID),
	ESTADO BIT DEFAULT(1)
)

CREATE TABLE USUARIOS(
	NOMBRE VARCHAR(20) NOT NULL PRIMARY KEY CHECK(LEN(NOMBRE)>3),
	CODIGO VARCHAR(15) NOT NULL CHECK(LEN(CODIGO)>3),
	PERMISO INT NOT NULL DEFAULT(1),
	DNI INT NOT NULL,
	ESTADO BIT DEFAULT(1)
)

CREATE TABLE PRODUCTOS(
	ID BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	DESCRIPCION VARCHAR(60) NOT NULL CHECK(LEN(DESCRIPCION)>0),
	STOCK_ACTUAL INT NOT NULL CHECK(STOCK_ACTUAL>0),
	STOCK_MINIMO INT NOT NULL CHECK(STOCK_MINIMO>0),
	PRECIO_COMPRA DECIMAL NOT NULL CHECK(PRECIO_COMPRA>0),
	IDMARCA INT NOT NULL FOREIGN KEY REFERENCES MARCAS(ID),
	IDCATEGORIA INT NOT NULL FOREIGN KEY REFERENCES CATEGORIAS(ID),
	ESTADO BIT DEFAULT(1)
)

CREATE TABLE PRODUCTOSXPROVEEDORES(
	IDPRODUCTO BIGINT NOT NULL FOREIGN KEY REFERENCES PRODUCTOS(ID),
	IDPROVEEDOR BIGINT NOT NULL FOREIGN KEY REFERENCES PROVEEDORES(CUIT),
	PRECIO INT NOT NULL
	PRIMARY KEY(IDPRODUCTO,IDPROVEEDOR)
)

CREATE TABLE COMPRAS(
	ID BIGINT NOT NULL PRIMARY KEY,
	PROVEEDOR BIGINT NOT NULL FOREIGN KEY REFERENCES PROVEEDORES(CUIT),
	COSTO_TOTAL INT NULL CHECK(COSTO_TOTAL>0),
	METODOPAGO VARCHAR(10) NULL,
	TARJETA BIGINT NULL,
	CODIGO INT NULL,
	FECHA DATE DEFAULT(GETDATE()),
	ESTADO BIT DEFAULT(1)
)

CREATE TABLE VENTAS(
	ID BIGINT NOT NULL PRIMARY KEY,
	IDEMPLEADO INT NOT NULL FOREIGN KEY REFERENCES EMPLEADOS(DNI),
	DNICLIENTE INT NOT NULL FOREIGN KEY REFERENCES CLIENTES(DNI),
	COSTO_TOTAL INT NULL,
	METODOPAGO VARCHAR(10) NULL,
	TARJETA BIGINT NULL,
	CODIGO INT NULL,
	FECHA DATE DEFAULT(GETDATE()),
	ESTADO BIT DEFAULT(0)
)

CREATE TABLE FACTURA(
	ID BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	IDPRODUCTO BIGINT NOT NULL FOREIGN KEY REFERENCES PRODUCTOS(ID),
	CANTIDAD INT NOT NULL CHECK(CANTIDAD>0),
	COSTO INT NOT NULL CHECK(COSTO>0),
	SUB_TOTAL INT NOT NULL CHECK(SUB_TOTAL>0)
)

CREATE TABLE FACTURAXCOMPRA(
	IDFACTURA BIGINT NOT NULL FOREIGN KEY REFERENCES FACTURA(ID),
	IDCOMPRA BIGINT NOT NULL FOREIGN KEY REFERENCES COMPRAS(ID)
	PRIMARY KEY(IDFACTURA,IDCOMPRA)
)

CREATE TABLE FACTURAXVENTA(
	IDFACTURA BIGINT NOT NULL FOREIGN KEY REFERENCES FACTURA(ID),
	IDVENTA BIGINT NOT NULL FOREIGN KEY REFERENCES VENTAS(ID)
	PRIMARY KEY(IDFACTURA,IDVENTA)
)

---
GO
CREATE PROCEDURE sp_AGREGAR_CLIENTE(
	@DNI INT, @APELLIDO VARCHAR(30), @NOMBRE VARCHAR(30), @MAIL VARCHAR(50),
	@NUMERO INT, @TIPOTEL VARCHAR(20), @CALLE VARCHAR(30), @ALTURA INT,
	@CODPOS INT, @LOCALIDAD VARCHAR(20)
)AS
BEGIN
	BEGIN TRY
	INSERT INTO TELEFONOS(NUMERO,TIPOTEL) VALUES (@NUMERO,@TIPOTEL)
	INSERT INTO DOMICILIOS(CALLE,ALTURA,CODIGO_POSTAL,LOCALIDAD)
	VALUES (@CALLE,@ALTURA,@CODPOS,@LOCALIDAD)
	DECLARE @IDTEL BIGINT = (SELECT TOP(1) ID FROM TELEFONOS ORDER BY ID DESC)
	DECLARE @IDDOM BIGINT = (SELECT TOP(1) ID FROM DOMICILIOS ORDER BY ID DESC)
	INSERT INTO CLIENTES(DNI,APELLIDO,NOMBRE,MAIL,IDTELEFONO,IDDOMICILIO) 
	VALUES (@DNI,@APELLIDO,@NOMBRE,@MAIL,@IDTEL,@IDDOM)
	END TRY
	
	BEGIN CATCH
	PRINT ERROR_MESSAGE()
	END CATCH
END
----
GO
CREATE PROCEDURE sp_MODIFICAR_CLIENTE(
	@DNI INT, @APELLIDO VARCHAR(30), @NOMBRE VARCHAR(30), @MAIL VARCHAR(50),
	@NUMERO INT, @TIPOTEL VARCHAR(20), @CALLE VARCHAR(30), @ALTURA INT,
	@CODPOS INT, @LOCALIDAD VARCHAR(20)
)AS
BEGIN
DECLARE @IDTEL BIGINT = (SELECT IDTELEFONO FROM CLIENTES WHERE DNI=@DNI)
DECLARE @IDDOM BIGINT = (SELECT IDDOMICILIO FROM CLIENTES WHERE DNI=@DNI)
	BEGIN TRY
	IF(SELECT DNI FROM CLIENTES WHERE DNI=@DNI OR MAIL=@MAIL)>0
	BEGIN
	UPDATE TELEFONOS SET NUMERO=@NUMERO,TIPOTEL=@TIPOTEL WHERE ID=@IDTEL 
	UPDATE DOMICILIOS SET CALLE=@CALLE,ALTURA=@ALTURA,CODIGO_POSTAL=@CODPOS,LOCALIDAD=@LOCALIDAD WHERE ID=@IDDOM
	UPDATE CLIENTES SET APELLIDO=@APELLIDO,NOMBRE=@NOMBRE,MAIL=@MAIL WHERE DNI=@DNI
	END
	END TRY
	
	BEGIN CATCH
	PRINT ERROR_MESSAGE()
	END CATCH
END
----
GO
CREATE PROCEDURE sp_AGREGAR_EMPLEADO(
	@DNI INT, @APELLIDO VARCHAR(30), @NOMBRE VARCHAR(30), @MAIL VARCHAR(50),
	@CUIL BIGINT, @TIPO VARCHAR(20),
	@NUMERO INT, @TIPOTEL VARCHAR(20), @CALLE VARCHAR(30), @ALTURA INT,
	@CODPOS INT, @LOCALIDAD VARCHAR(20)
)AS
BEGIN
	BEGIN TRY
	INSERT INTO TELEFONOS(NUMERO,TIPOTEL) VALUES (@NUMERO,@TIPOTEL)
	INSERT INTO DOMICILIOS(CALLE,ALTURA,CODIGO_POSTAL,LOCALIDAD)
	VALUES (@CALLE,@ALTURA,@CODPOS,@LOCALIDAD)
	DECLARE @IDTEL BIGINT = (SELECT TOP(1) ID FROM TELEFONOS ORDER BY ID DESC)
	DECLARE @IDDOM BIGINT = (SELECT TOP(1) ID FROM DOMICILIOS ORDER BY ID DESC)
	INSERT INTO EMPLEADOS(DNI,APELLIDO,NOMBRE,MAIL,CUIL,TIPO,IDTELEFONO,IDDOMICILIO) 
	VALUES (@DNI,@APELLIDO,@NOMBRE,@MAIL,@CUIL,@TIPO,@IDTEL,@IDDOM)
	END TRY
	
	BEGIN CATCH
	PRINT ERROR_MESSAGE()
	END CATCH
END
----
GO
CREATE PROCEDURE sp_MODIFICAR_EMPLEADO(
	@DNI INT, @APELLIDO VARCHAR(30), @NOMBRE VARCHAR(30), @MAIL VARCHAR(50),
	@CUIL BIGINT, @TIPO VARCHAR(20),
	@NUMERO INT, @TIPOTEL VARCHAR(20), @CALLE VARCHAR(30), @ALTURA INT,
	@CODPOS INT, @LOCALIDAD VARCHAR(20)
)AS
BEGIN
DECLARE @IDTEL BIGINT = (SELECT IDTELEFONO FROM EMPLEADOS WHERE DNI=@DNI)
DECLARE @IDDOM BIGINT = (SELECT IDDOMICILIO FROM EMPLEADOS WHERE DNI=@DNI)
	BEGIN TRY
	IF(SELECT DNI FROM EMPLEADOS WHERE DNI=@DNI)>0
	BEGIN
	UPDATE TELEFONOS SET NUMERO=@NUMERO,TIPOTEL=@TIPOTEL WHERE ID=@IDTEL 
	UPDATE DOMICILIOS SET CALLE=@CALLE,ALTURA=@ALTURA,CODIGO_POSTAL=@CODPOS,LOCALIDAD=@LOCALIDAD WHERE ID=@IDDOM
	UPDATE EMPLEADOS SET APELLIDO=@APELLIDO,NOMBRE=@NOMBRE,MAIL=@MAIL,CUIL=@CUIL,TIPO=@TIPO WHERE DNI=@DNI
	END
	END TRY
	
	BEGIN CATCH
	PRINT ERROR_MESSAGE()
	END CATCH
END
----
GO
CREATE PROCEDURE sp_AGREGAR_PROVEEDOR(
	@CUIT INT, @RAZON_SOCIAL VARCHAR(30), @CONTACTO VARCHAR(30),
	@NUMERO INT, @TIPOTEL VARCHAR(20)
)AS
BEGIN
	BEGIN TRY
	INSERT INTO TELEFONOS(NUMERO,TIPOTEL) VALUES (@NUMERO,@TIPOTEL)
	DECLARE @IDTEL BIGINT = (SELECT TOP(1) ID FROM TELEFONOS ORDER BY ID DESC)
	INSERT INTO PROVEEDORES(CUIT,RAZON_SOCIAL,CONTACTO,IDTELEFONO) 
	VALUES (@CUIT,@RAZON_SOCIAL,@CONTACTO,@IDTEL)
	END TRY
	
	BEGIN CATCH
	PRINT ERROR_MESSAGE()
	END CATCH
END
----
GO
CREATE PROCEDURE sp_MODIFICAR_PROVEEDOR(
	@CUIT INT, @RAZON_SOCIAL VARCHAR(30), @CONTACTO VARCHAR(30),
	@NUMERO INT, @TIPOTEL VARCHAR(20)
)AS
BEGIN
DECLARE @IDTEL BIGINT = (SELECT IDTELEFONO FROM PROVEEDORES WHERE CUIT=@CUIT)
	BEGIN TRY
	IF(SELECT CUIT FROM PROVEEDORES WHERE CUIT=@CUIT)>0
	BEGIN
	UPDATE TELEFONOS SET NUMERO=@NUMERO,TIPOTEL=@TIPOTEL WHERE ID=@IDTEL 
	UPDATE PROVEEDORES SET RAZON_SOCIAL=@RAZON_SOCIAL,CONTACTO=@CONTACTO WHERE CUIT=@CUIT
	END
	END TRY
	
	BEGIN CATCH
	PRINT ERROR_MESSAGE()
	END CATCH
END
----
GO
CREATE PROCEDURE sp_AGREGAR_PRODUCTO(
	@MARCA INT, @CATEGORIA INT, @DESCRIPCION VARCHAR(60), @STOCK_ACTUAL INT,
	@STOCK_MINIMO INT, @PRECIO FLOAT
)AS
BEGIN
	BEGIN TRY
	INSERT INTO PRODUCTOS(DESCRIPCION,STOCK_ACTUAL,STOCK_MINIMO,PRECIO_COMPRA,IDCATEGORIA,IDMARCA)
	VALUES (@DESCRIPCION,@STOCK_ACTUAL,@STOCK_MINIMO,@PRECIO,@CATEGORIA,@MARCA)
	END TRY
	
	BEGIN CATCH
	PRINT ERROR_MESSAGE()
	END CATCH
END
----
GO
CREATE PROCEDURE sp_MODIFICAR_PRODUCTO(
	@MARCA INT, @CATEGORIA INT, @DESCRIPCION VARCHAR(60), @STOCK_ACTUAL INT,
	@ID BIGINT, @STOCK_MINIMO INT, @PRECIO FLOAT
)AS
BEGIN
	BEGIN TRY
	IF(SELECT ID FROM PRODUCTOS WHERE ID=@ID)>0
	BEGIN
	UPDATE PRODUCTOS SET DESCRIPCION=@DESCRIPCION,STOCK_ACTUAL=@STOCK_ACTUAL,STOCK_MINIMO=@STOCK_MINIMO,
	PRECIO_COMPRA=@PRECIO,IDCATEGORIA=@CATEGORIA,IDMARCA=@MARCA WHERE ID=@ID
	END
	END TRY
	
	BEGIN CATCH
	PRINT ERROR_MESSAGE()
	END CATCH
END
---
GO
CREATE PROCEDURE sp_MODIFICAR_STOCK(
	@STOCK_ACTUAL INT,@ID BIGINT
)AS
BEGIN
	BEGIN TRY
	IF(SELECT ID FROM PRODUCTOS WHERE ID=@ID)>0
	BEGIN
	UPDATE PRODUCTOS SET STOCK_ACTUAL=@STOCK_ACTUAL WHERE ID=@ID
	END
	END TRY
	
	BEGIN CATCH
	PRINT ERROR_MESSAGE()
	END CATCH
END
---
GO
CREATE PROCEDURE sp_MODIFICAR_PRECIO(
	@PRECIO_NUEVO INT,@ID BIGINT
)AS
BEGIN
	BEGIN TRY
	IF(SELECT ID FROM PRODUCTOS WHERE ID=@ID)>0
	BEGIN
	UPDATE PRODUCTOS SET PRECIO_COMPRA=@PRECIO_NUEVO WHERE ID=@ID
	END
	END TRY
	
	BEGIN CATCH
	PRINT ERROR_MESSAGE()
	END CATCH
END
----
GO
CREATE PROCEDURE sp_AGREGAR_VENTA(
	 @ID BIGINT, @IDEMPLEADO INT, @DNICLIENTE INT
)AS
BEGIN
	BEGIN TRY
	INSERT INTO VENTAS(ID,IDEMPLEADO,DNICLIENTE) VALUES (@ID,@IDEMPLEADO,@DNICLIENTE)
	END TRY
	
	BEGIN CATCH
	PRINT ERROR_MESSAGE()
	END CATCH
END
----
GO
CREATE PROCEDURE sp_MODIFICAR_VENTA(
	 @ID BIGINT, @COSTOTOTAL INT, @METODOPAGO VARCHAR(10),
	 @TARJETA INT, @CODIGO INT
)AS
BEGIN
	BEGIN TRY
	UPDATE VENTAS SET COSTO_TOTAL=@COSTOTOTAL,METODOPAGO=@METODOPAGO,TARJETA=@TARJETA,CODIGO=@CODIGO,ESTADO=1
	WHERE ID=@ID
	END TRY
	
	BEGIN CATCH
	PRINT ERROR_MESSAGE()
	END CATCH
END
----
GO
CREATE PROCEDURE sp_AGREGAR_FACTURAXVENTA(
	 @ID BIGINT, @IDPRODUCTO BIGINT, @COSTO INT, @CANTIDAD INT, @SUBTOTAL INT
)AS
BEGIN
	BEGIN TRY
	INSERT INTO FACTURA(IDPRODUCTO,COSTO,CANTIDAD,SUB_TOTAL)
	VALUES (@IDPRODUCTO,@COSTO,@CANTIDAD,@SUBTOTAL)
	
	DECLARE @IDF BIGINT = (SELECT TOP(1) ID FROM FACTURA ORDER BY ID DESC)
	DECLARE @IDV BIGINT = (SELECT TOP(1) ID FROM VENTAS ORDER BY ID DESC)
	
	INSERT INTO FACTURAXVENTA(IDFACTURA, IDVENTA) VALUES (@IDF,@IDV)
	END TRY
	
	BEGIN CATCH
	PRINT ERROR_MESSAGE()
	END CATCH
END
---
GO
CREATE PROCEDURE sp_AGREGAR_COMPRA(
	 @ID BIGINT, @IDPROVEEDOR INT
)AS
BEGIN
	BEGIN TRY
	INSERT INTO COMPRAS(ID,PROVEEDOR) VALUES (@ID,@IDPROVEEDOR)
	END TRY
	
	BEGIN CATCH
	PRINT ERROR_MESSAGE()
	END CATCH
END
----
GO
CREATE PROCEDURE sp_MODIFICAR_COMPRA(
	 @ID BIGINT, @COSTOTOTAL INT, @METODOPAGO VARCHAR(10),
	 @TARJETA INT, @CODIGO INT
)AS
BEGIN
	BEGIN TRY
	UPDATE COMPRAS SET COSTO_TOTAL=@COSTOTOTAL,METODOPAGO=@METODOPAGO,TARJETA=@TARJETA,CODIGO=@CODIGO,ESTADO=1
	WHERE ID=@ID
	END TRY
	
	BEGIN CATCH
	PRINT ERROR_MESSAGE()
	END CATCH
END
----
GO
CREATE PROCEDURE sp_AGREGAR_FACTURAXCOMPRA(
	 @ID BIGINT, @IDPRODUCTO BIGINT, @COSTO INT, @CANTIDAD INT, @SUBTOTAL INT
)AS
BEGIN
	BEGIN TRY
	INSERT INTO FACTURA(IDPRODUCTO,COSTO,CANTIDAD,SUB_TOTAL)
	VALUES (@IDPRODUCTO,@COSTO,@CANTIDAD,@SUBTOTAL)
	
	DECLARE @IDF BIGINT = (SELECT TOP(1) ID FROM FACTURA ORDER BY ID DESC)
	DECLARE @IDC BIGINT = (SELECT TOP(1) ID FROM COMPRAS ORDER BY ID DESC)
	
	INSERT INTO FACTURAXCOMPRA(IDFACTURA, IDCOMPRA) VALUES (@IDF,@IDC)
	END TRY
	
	BEGIN CATCH
	PRINT ERROR_MESSAGE()
	END CATCH
END
---
GO
CREATE PROCEDURE sp_AGREGAR_USUARIO(
	 @DNI INT, @NOMBRE VARCHAR(20), @CODIGO INT, @PERMISO INT
)AS
BEGIN
	BEGIN TRY
	INSERT INTO USUARIOS(DNI,NOMBRE,CODIGO,PERMISO)
	VALUES (@DNI,@NOMBRE,@CODIGO,@PERMISO)
	END TRY
	
	BEGIN CATCH
	PRINT ERROR_MESSAGE()
	END CATCH
END
---
GO
CREATE PROCEDURE sp_ACTUALIZAR_PRECIO(
	 @IDPROD BIGINT, @PRECIO INT
)AS
BEGIN
	BEGIN TRY
	UPDATE PRODUCTOS SET PRECIO_COMPRA=@PRECIO,ESTADO=1 WHERE ID=@IDPROD
	END TRY
	
	BEGIN CATCH
	PRINT ERROR_MESSAGE()
	END CATCH
END
---
GO
CREATE PROCEDURE sp_ACTUALIZAR_PRODUCTOSXPROVEEDORES(
	 @IDPROD BIGINT, @IDPROV BIGINT, @PRECIO INT
)AS
BEGIN
	BEGIN TRY
	IF(SELECT IDPRODUCTO FROM PRODUCTOSXPROVEEDORES WHERE IDPRODUCTO=@IDPROD AND IDPROVEEDOR=@IDPROV)>=1
		BEGIN
		UPDATE PRODUCTOSXPROVEEDORES SET PRECIO=@PRECIO WHERE IDPRODUCTO=@IDPROD AND IDPROVEEDOR=@IDPROV
		END
	ELSE
		BEGIN
		INSERT INTO PRODUCTOSXPROVEEDORES (IDPRODUCTO,IDPROVEEDOR,PRECIO) VALUES (@IDPROD,@IDPROV,@PRECIO)
		END
	END TRY
	
	BEGIN CATCH
	PRINT ERROR_MESSAGE()
	END CATCH
END

---------------------------------------------
GO
INSERT INTO CATEGORIAS(NOMBRE)
VALUES
('GALLETITAS'),
('FIDEOS'),
('ACEITE'),
('ARROZ')

INSERT INTO MARCAS(NOMBRE)
VALUES
('OREO'),
('CRIOLLITAS'),
('BAGLEY'),
('MERENGADAS'),
('LUCCHETTI'),
('MATARAZZO'),
('VICENTE'),
('MAZOLA'),
('NATURA'),
('COCINERO'),
('MOLINOS'),
('GALLO ORO')

INSERT INTO PRODUCTOS(DESCRIPCION,STOCK_ACTUAL,STOCK_MINIMO,PRECIO_COMPRA,IDMARCA,IDCATEGORIA)
VALUES
('FIDEOS TIRABUZON 500G',40,5,50,6,2),
('FIDEOS MOSTACHOLES 500G',20,5,55,5,2),
('OREO CLASICA 117G',60,3,38,1,1),
('CRIOLLITAS DE AGUA ORIGINALES 300G',10,2,48,2,1),
('SURTIDO BAGLEY 400G',20,2,50,3,1),
('NATURA BOTELLA 1L',5,2,80,9,3),
('COCINERO BOTELLA 1L',10,2,70,10,3),
('COCINERO BOTELLA 500ML',2,2,50,10,3),
('MAZOLA BOTELLA 500ML',5,2,35,8,3),
('GALLO CAJA 5PORCIONES',40,3,50,12,4),
('GALLO PAQUETE 2PORCIONES',60,4,30,12,4)

INSERT INTO TELEFONOS(NUMERO,TIPOTEL)
VALUES
(47461648,'CELULAR'),
(1556390102,'CELULAR'),
(1564771221,'CELULAR'),
(40551468,'CASA'),
(1568791203,'CELULAR'),
(1568741203,'CELULAR'),
(1563579413,'CELULAR')

INSERT INTO DOMICILIOS(CALLE,ALTURA,CODIGO_POSTAL,LOCALIDAD)
VALUES
('QUINTANA',1822,1646,'VIRREYES'),
('ALEM',7648,1646,'VIRREYES'),
('AV SOBREMONTE',2052,1648,'VICTORIA'),
('AV YRIGOYEN',288,1617,'GRAL PACHECO'),
('PASTEUR',2058,1615,'TIGRE'),
('MENDOZA',1980,1624,'DEL VISO')

INSERT INTO CLIENTES(DNI,APELLIDO,NOMBRE,IDDOMICILIO,IDTELEFONO,MAIL)
VALUES
(9587411,'JUAREZ','IVAN',3,1,'ivanj@hotmail.com'),
(9577754,'PEREZ','PAULA',5,6,'paulaperez@gmail.com'),
(2588484,'RODRIGUEZ','OSCAR',4,7,'rodriguezoscar@live.com'),
(2612336,'MENDEZ','OLIVIA',6,5,'mendezol@gmail.com'),
(3865412,'ALVAREZ','SANDRA',1,6,'sandra_alvi@hotmail.com')

INSERT INTO EMPLEADOS(DNI,APELLIDO,NOMBRE,CUIL,IDDOMICILIO,IDTELEFONO,MAIL,TIPO)
VALUES
(39342662,'OCAMPO','ELIANA',23393426624,1,2,'EOCAMPO@VENTAS.COM','GERENTE'),
(41327286,'LORENZO','ABRIL',20413272866,3,3,'ABRILO@VENTAS.COM','VENDEDOR'),
(42100987,'PANTOJA','AGUSTIN',25421009877,1,5,'APANTOJA@VENTAS.COM','VENDEDOR'),
(24710710,'PARRA','LAURA',23247107104,2,4,'LPARRA@VENTAS.COM','VENDEDOR')

INSERT INTO USUARIOS(DNI,NOMBRE,CODIGO,PERMISO) VALUES
(39342662,'EOCAMPO',1234,2),
(41327286,'ALORENZO',5678,1)

INSERT INTO PROVEEDORES(CUIT, RAZON_SOCIAL, CONTACTO, IDTELEFONO)
VALUES (23457896,'DISTRIBUIDORA POP','BARZA ALEJANDRO',3),
(78944515,'ALIMENTOS DEL SUR','LINO JAVIER',4)

INSERT INTO PRODUCTOSXPROVEEDORES(IDPRODUCTO,IDPROVEEDOR,PRECIO)
VALUES (1,23457896,50),(10,23457896,50),(3,23457896,38),(4,23457896,48),(9,23457896,35),(6,23457896,80),(5,23457896,50),
(2,78944515,55),(11,78944515,30),(8,78944515,50),(7,78944515,70),(6,78944515,80),(5,78944515,50)

INSERT INTO VENTAS(ID,IDEMPLEADO,DNICLIENTE,COSTO_TOTAL,METODOPAGO,TARJETA,CODIGO,ESTADO) VALUES
(101,39342662,9587411,394,'DEBITO',164879463184,789,1),
(102,39342662,2588484,416,'EFECTIVO',NULL,NULL,1),
(103,39342662,2612336,355,'DEBITO',164864318964,654,1),
(104,41327286,9587411,660,'CREDITO',500098671205,985,1),
(105,41327286,2612336,213,'EFECTIVO',NULL,NULL,1),
(106,41327286,2588484,NULL,NULL,NULL,NULL,0),
(107,41327286,3865412,126,'EFECTIVO',NULL,NULL,1),
(108,24710710,9587411,272,'DEBITO',508499637841,547,1),
(109,24710710,9577754,NULL,NULL,NULL,NULL,0),
(110,24710710,9577754,320,'CREDITO',650078426341,365,1)

INSERT INTO COMPRAS(ID,PROVEEDOR,COSTO_TOTAL,METODOPAGO,TARJETA,CODIGO,ESTADO) VALUES
(1001,23457896,2198,'DEBITO',164879463184,789,1),
(1002,78944515,1545,'EFECTIVO',NULL,NULL,1),
(1003,23457896,20850,'DEBITO',164879463184,789,1),
(1004,78944515,5560,'CREDITO',164879463184,789,1)

INSERT INTO FACTURA(IDPRODUCTO,COSTO,CANTIDAD,SUB_TOTAL) VALUES
(1,50,2,100),(4,48,3,144),(5,50,1,50),(10,50,2,100),(3,38,7,266),(5,50,3,150),(6,80,2,160),(2,55,3,165),
(11,30,1,30),(7,70,1,70),(10,50,4,200),(4,48,5,240),(1,50,3,150), (2,55,3,165),(4,48,1,48),(1,50,1,50),
(3,38,2,76),(3,38,4,152),(10,50,1,50),(7,70,1,70),(2,55,4,220),(4,50,2,100),(1,50,8,400),(4,48,6,288),
(10,50,4,200),(6,80,12,960),(5,50,7,350),(2,55,3,165),(7,70,4,280),(8,50,10,500),(11,30,20,600),(4,48,40,1920),
(5,50,20,1000),(9,35,18,630),(6,80,30,2400),(2,55,22,1210),(7,70,10,700),(8,50,25,1250)

INSERT INTO FACTURAXVENTA(IDFACTURA, IDVENTA) VALUES
(1,101),(2,101),(3,101),(4,101),(5,102),(6,102),(7,103),
(8,103),(9,103),(10,104),(11,104),(12,104),(13,104),
(14,105),(15,105),(16,107),(17,107),(18,108),(19,108),
(20,108),(21,110),(22,110)

INSERT INTO FACTURAXCOMPRA(IDFACTURA, IDCOMPRA) VALUES
(23,1001),(24,1001),(25,1001),(26,1001),(27,1001),(28,1001),(29,1002),
(30,1002),(31,1002),(32,1002),(33,1003),(34,1003),(35,1003),(36,1004),
(37,1004),(38,1004)
