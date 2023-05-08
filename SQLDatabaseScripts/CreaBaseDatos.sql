CREATE DATABASE PruebaAlgarTech;
GO
USE PruebaAlgarTech;
GO
CREATE TABLE Pedido
(
	idPedido int Primary Key identity(1,1),
	idCliente int not null,
	valorTotal numeric not null 
);
GO
CREATE TABLE DetalllePedido
(
	idPedido int foreign key references Pedido(idPedido),
	cantidad int not null,
	vlUnit numeric,
	producto varchar(200)
);
GO
CREATE TABLE Cliente
(
	idCliente int primary key identity(1,1),
	cedula varchar(50) not null unique,
	direccionEntrega varchar(200) not null
);
GO
CREATE PROC AddPedido
	@idCliente int,
	@valorTotal numeric
AS
INSERT INTO Pedido(idCliente,valorTotal) VALUES(@idCliente, @valorTotal)
SELECT @@IDENTITY AS 'Id'; 
GO

CREATE PROC ModifyPedido
	@idPedido int,
	@idCliente int,
	@valorTotal numeric
AS
UPDATE Pedido SET idCliente=@idCliente ,valorTotal=@valorTotal WHERE idPedido=@idPedido
GO

CREATE PROC ShowPedidos
	@idPedido int null
AS
	SELECT * FROM Pedido WHERE idPedido=@idPedido OR @idPedido=NULL
GO

CREATE PROC AddCliente
	@cedula varchar(50),
	@direccion varchar(200)
AS
IF NOT EXISTS(SELECT cedula FROM Cliente WHERE cedula=@cedula)
BEGIN
INSERT INTO Cliente(cedula,direccionEntrega) VALUES(@cedula, @direccion)
SELECT @@IDENTITY AS 'Id'
END
ELSE 
SELECT idCliente FROM Cliente WHERE cedula=@cedula
GO

CREATE PROC AddDetalle
	@idPedido int,
	@cantidad int,
	@vlUnit numeric,
	@producto varchar(200)
AS
INSERT INTO DetalllePedido(idPedido,cantidad,vlUnit,producto) VALUES(@idPedido,@cantidad,@vlUnit,@producto)
GO

INSERT INTO Cliente(cedula,direccionEntrega) VALUES('978878','Calle 123 #12-3')
GO