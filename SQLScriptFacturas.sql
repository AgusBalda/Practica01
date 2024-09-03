CREATE TABLE Formas_Pago(
	id int identity(1,1),
	nombre varchar(100)
	constraint PK_Formas_Pago primary key (id)
)

CREATE TABLE Articulos (
	id int identity(1,1),
	nombre varchar(50),
	precion_unitario decimal(10,2)
	constraint PK_Articulo primary key (id)
)

CREATE TABLE Facturas (
	id int identity(1,1),
	fecha date,
	id_forma_pago int,
	cliente varchar(50)
	constraint PK_Facturas primary key (id)
	constraint FK_Formas_Pago foreign key (id_Forma_Pago) references Formas_Pago (id)
)

CREATE TABLE Detalle_Facturas (
	id int identity(1,1),
	cantidad int,
	id_factura int,
	id_articulo int
	constraint PK_Detalle_Facturas primary key (id)
	constraint FK_Facturas foreign key (id_factura) references Facturas (id),
	constraint FK_Articulos foreign key (id_articulo) references Articulos (id)
)