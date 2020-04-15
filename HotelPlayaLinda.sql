

CREATE  DATABASE DDJK;
USE DDJK
GO

--------------------------
-- Definicion de tablas --
--------------------------


DROP TABLE IF EXISTS Mapa;
CREATE TABLE Mapa(dummy int);
ALTER TABLE Mapa ADD idMapa int identity(1,1);
ALTER TABLE Mapa ADD latitudOrigen varchar(max);
ALTER TABLE Mapa ADD longitudOrigen varchar(max);
ALTER TABLE Mapa ADD latitudDestino varchar(max);
ALTER TABLE Mapa ADD longitudDestino varchar(max);
ALTER TABLE Mapa ADD CONSTRAINT PK_Mapa PRIMARY KEY (idMapa);
ALTER TABLE Mapa DROP COLUMN dummy;

DROP TABLE IF EXISTS Cliente;
CREATE TABLE Cliente(dummy int);
ALTER TABlE Cliente ADD idCliente int IDENTITY(1,1);
ALTER TABLE Cliente ADD pasaporte varchar(25);
ALTER TABLE Cliente ADD nombre varchar(50);
ALTER TABLE Cliente ADD primerApellido varchar(50);
ALTER TABLE Cliente ADD segundoApellido varchar(50);
ALTER TABLE Cliente ADD edad tinyint;
ALTER TABLE Cliente ADD nacionalidad varchar(25);
ALTER TABLE Cliente ADD correo varchar(50);
ALTER TABLE Cliente ADD CONSTRAINT PK_Cliente PRIMARY KEY (idCliente);
ALTER TABLE Cliente DROP COLUMN dummy;

DROP TABLE IF EXISTS Habitacion;
CREATE TABLE Habitacion(dummy int);
ALTER TABLE Habitacion ADD idHabitacion tinyint IDENTITY(1,1);
ALTER TABLE Habitacion ADD tipoHabitacion tinyint;
ALTER TABLE Habitacion ADD idCliente int;
ALTER TABLE Habitacion ADD vacante tinyint;
ALTER TABLE Habitacion ADD capacidad tinyint;
ALTER TABLE Habitacion ADD CONSTRAINT PK_Habitacion PRIMARY KEY (idHabitacion);
ALTER TABLE Habitacion ADD CONSTRAINT FK_idCliente FOREIGN KEY (idCliente ) REFERENCES Cliente(idCliente)  ON UPDATE CASCADE
ALTER TABLE Habitacion DROP COLUMN dummy;

DROP TABLE IF EXISTS Reservacion;
CREATE TABLE Reservacion(dummy int);
ALTER TABLE Reservacion ADD idReservacion int IDENTITY(1,1);
ALTER TABLE Reservacion ADD idHabitacion tinyint;
ALTER TABLE Reservacion ADD idCliente int;
ALTER TABLE Reservacion ADD fechaLlegada date;
ALTER TABLE Reservacion ADD fechaSalida date;
ALTER TABLE Reservacion ADD CONSTRAINT PK_Reservacion PRIMARY KEY (idReservacion);
ALTER TABLE Reservacion   ADD CONSTRAINT FK_idCliente1 FOREIGN KEY (idCliente)  REFERENCES Cliente(idCliente)  
ALTER TABLE Reservacion   ADD CONSTRAINT FK_idHabitacion  FOREIGN KEY (idHabitacion )REFERENCES Habitacion(idHabitacion )  ON UPDATE CASCADE
ALTER TABLE Reservacion DROP COLUMN dummy;






DROP TABLE IF EXISTS TipoHabitacion;
CREATE TABLE TipoHabitacion(dummy int);
ALTER TABLE TipoHabitacion ADD idTipoHabitacion int IDENTITY(1,1);
ALTER TABLE TipoHabitacion ADD nombreTipoHabitacion varchar(25);
ALTER TABLE TipoHabitacion ADD precioBase int;
ALTER TABLE TipoHabitacion ADD CONSTRAINT PK_TipoHabitacion PRIMARY KEY(idTipoHabitacion);
ALTER TABLE TipoHabitacion DROP COLUMN dummy;


DROP TABLE IF EXISTS Empleado;
CREATE TABLE Empleado(dummy int);
ALTER TABLE Empleado ADD idEmpleado smallint IDENTITY(1,1);
ALTER TABLE Empleado ADD tipoEmpleado tinyint;
ALTER TABLE Empleado ADD idUsuario varchar(50);
ALTER TABLE Empleado ADD contrasenna varchar(256);
ALTER TABLE Empleado ADD CONSTRAINT PK_Empleado PRIMARY KEY (idEmpleado);
ALTER TABLE Empleado DROP COLUMN dummy;


DROP TABLE IF EXISTS Promocion;
CREATE TABLE Promocion(dummy int);
ALTER TABLE Promocion ADD idPromocion smallint IDENTITY(1,1);
ALTER TABLE Promocion ADD fechaInicio date;
ALTER TABLE Promocion ADD fechaFinal date;
ALTER TABLE Promocion ADD informacion varchar(300);
ALTER TABLE Promocion ADD rebaja int;
ALTER TABLE Promocion DROP COLUMN dummy;
ALTER TABLE Promocion ADD CONSTRAINT PK_Promocion PRIMARY KEY(idPromocion);

DROP TABLE IF EXISTS Publicidad;
CREATE TABLE Publicidad(dummy int);
ALTER TABLE Publicidad ADD idPublicidad smallint IDENTITY(1,1);
ALTER TABLE Publicidad ADD rutaImagen varchar(255);
ALTER TABLE Publicidad ADD link varchar(255);
ALTER TABLE Publicidad DROP COLUMN dummy;
ALTER TABLE Publicidad ADD CONSTRAINT PK_Publicidad PRIMARY KEY(idPublicidad);



DROP TABLE IF EXISTS informacionTexto;
CREATE TABLE informacionTexto(dummy int);
ALTER TABLE informacionTexto ADD idInformacionTexto int IDENTITY(1,1);
ALTER TABLE informacionTexto ADD rutaImagen varchar(255) NULL ;
ALTER TABLE informacionTexto ADD contenido varchar(max) NULL;
ALTER TABLE informacionTexto ADD titulo varchar(255) NULL;
ALTER TABLE informacionTexto ADD tipoInformacion int NOT NULL;
ALTER TABLE informacionTexto DROP COLUMN dummy;
ALTER TABLE informacionTexto ADD CONSTRAINT PK_informacionTexto PRIMARY KEY(idInformacionTexto);


--------------------------
-- FIN Definicion de tablas --
--------------------------




--------------------------------
-- Procedimientos Almacenados --
--------------------------------
ALTER PROCEDURE PA_RegistrarCliente(
@pasaporte  varchar(25) ,
@nombre   nvarchar(50),
@apellido1   nvarchar(50),
@apellido2   nvarchar(50),
@edad int  NULL,
@correo nvarchar(255),
@nacionalidad  varchar(25) NULL
)
AS SET NOCOUNT ON;
INSERT INTO Cliente (pasaporte,nombre,primerApellido,segundoApellido,edad,nacionalidad,correo)
VALUES(@pasaporte,@nombre,@apellido1,@apellido2,@edad,@correo,@nacionalidad )
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_ModificarCliente(
@idCliente  int  ,
@pasaporte  varchar(25) ,
@nombre   nvarchar(50)   NULL,
@apellido1   nvarchar(50)   NULL,
@apellido2   nvarchar(50)  NULL,
@edad int   NULL,
@correo nvarchar(255)    NULL,
@nacionalidad  varchar(25)   NULL
)
AS SET NOCOUNT ON;
UPDATE Cliente  set pasaporte=@pasaporte,
nombre=@nombre,
primerApellido=@apellido1,
segundoApellido=@apellido2,
edad=@edad,
correo=@correo,
nacionalidad=@nacionalidad  WHERE idCliente=@idCliente  
GO
-------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE PA_EliminarCliente(
@idCliente  int) 
AS SET NOCOUNT ON;
Delete From Cliente  WHERE idCliente=@idCliente  
GO
-------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE PA_ListarClientes
AS SET NOCOUNT ON;
Select  idCliente, pasaporte, nombre, primerApellido, segundoApellido, edad, correo, nacionalidad From Cliente   
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_FiltrarClienteById(@idCliente  int)
AS SET NOCOUNT ON;
Select  idCliente, pasaporte, nombre, primerApellido, segundoApellido, edad, correo, nacionalidad From Cliente    where idCliente=@idCliente  
GO

-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_RegistrarHabitacion(
@tipoHabitacion  tinyint,
@idCliente  int NULL,
@vacante   nvarchar(50)  NULL,
@capacidad   tinyint NULL)
AS SET NOCOUNT ON;
INSERT INTO Habitacion (tipoHabitacion,idCliente,vacante,capacidad)VALUES(@tipoHabitacion,@idCliente,
@vacante,@capacidad )
GO
-------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE PA_ModificarHabitacion(
@idHabitacion  int  NULL ,
@tipoHabitacion  tinyint,
@idCliente  int   NULL,
@vacante   nvarchar(50)   NULL,
@capacidad   tinyint
)
AS SET NOCOUNT ON;
UPDATE Habitacion  set tipoHabitacion=@tipoHabitacion,
vacante=@vacante,
idCliente=@idCliente,
capacidad=@capacidad
  WHERE idHabitacion=@idHabitacion  
GO

-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_EliminarHabitacion(
@idHabitacion  int ) 
AS SET NOCOUNT ON;
Delete From Habitacion WHERE idHabitacion=@idHabitacion  
GO

-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_ListarHabitacion
AS SET NOCOUNT ON;
Select  idHabitacion , idCliente, vacante, capacidad From Habitacion   
GO

-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_FiltrarHabitacionById(@idHabitacion   int )
AS SET NOCOUNT ON;
Select  idHabitacion , idCliente, vacante, capacidad  From Habitacion    where idHabitacion =@idHabitacion   
GO

-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_RegistrarReservacion(
@idHabitacion tinyint,
@idCliente  int,
@fechaLlegada date,
@fechaSalida  date)
AS SET NOCOUNT ON;
INSERT INTO Reservacion (idHabitacion ,idCliente,fechaLlegada ,fechaSalida )
VALUES(@idHabitacion,@idCliente,
@fechaLlegada,@fechaSalida)
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_ModificarReservacion(
@idReservacion int,
@idHabitacion tinyint,
@idCliente  int,
@fechaEntrada date,
@fechaSalida  date )
AS SET NOCOUNT ON;
UPDATE Reservacion  set
idHabitacion=@idHabitacion,idCliente=@idCliente,fechaLlegada=@fechaEntrada,
fechaSalida=@fechaSalida   
  WHERE idReservacion =@idReservacion 
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_EliminarReservacion(
@idReservacion int) 
AS SET NOCOUNT ON;
Delete From Reservacion WHERE idReservacion =@idReservacion 
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_ListarReservacion
AS SET NOCOUNT ON;
Select idReservacion , idHabitacion ,idCliente,fechaLlegada ,fechaSalida
 From Reservacion
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_FiltrarReservacionById(@idReservacion int)
AS SET NOCOUNT ON;
Select   idReservacion , idHabitacion ,idCliente,fechaLlegada ,fechaSalida
From Reservacion WHERE idReservacion =@idReservacion   
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_RegistrarTipoHabitacion(
@nombreTipoHabitacion varchar(25)  NULL,
@precioBase  int   NULL
)
AS SET NOCOUNT ON;
INSERT INTO TipoHabitacion(nombreTipoHabitacion,precioBase )
VALUES(@nombreTipoHabitacion,@precioBase )
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_ModificarTipoHabitacion(
@idTipoHabitacion int,
@nombreTipoHabitacion varchar(25),
@precioBase  int)
AS SET NOCOUNT ON;
UPDATE TipoHabitacion set
nombreTipoHabitacion=@nombreTipoHabitacion,
precioBase=@precioBase  
WHERE idTipoHabitacion= @idTipoHabitacion 
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_EliminarTipoHabitacion(
@idTipoHabitacion int)
AS SET NOCOUNT ON;
Delete From TipoHabitacion WHERE idTipoHabitacion=@idTipoHabitacion 
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_ListarTipoHabitacion
AS SET NOCOUNT ON;
Select idTipoHabitacion ,nombreTipoHabitacion,precioBase From TipoHabitacion 
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_FiltrarTipoHabitacionById(@idTipoHabitacion int)
AS SET NOCOUNT ON;
Select idTipoHabitacion ,nombreTipoHabitacion,precioBase From TipoHabitacion  WHERE idTipoHabitacion=@idTipoHabitacion 
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_RegistrarEmpleado(
@tipoEmpleado tinyint,
@idUsuario varchar(50),
@contrasenna varchar(255))
AS SET NOCOUNT ON;
INSERT INTO Empleado(tipoEmpleado,idUsuario,contrasenna)
VALUES(@tipoEmpleado,@idUsuario,@contrasenna)
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_ModificarEmpleado (
@idEmpleado smallint,
@tipoEmpleado tinyint,
@idUsuario varchar(50),
@contrasenna varchar(255))
AS SET NOCOUNT ON;
UPDATE Empleado set
tipoEmpleado=@tipoEmpleado,idUsuario=@idUsuario,contrasenna=@contrasenna 
WHERE idEmpleado =@idEmpleado 
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_EliminarEmpleado(
@idEmpleado smallint )
AS SET NOCOUNT ON;
Delete From Empleado WHERE idEmpleado=@idEmpleado
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_ListarEmpleado 
AS SET NOCOUNT ON;
Select idEmpleado,tipoEmpleado,idUsuario,contrasenna
 From Empleado 
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_FiltrarEmpleadoById(@idEmpleado smallint)
AS SET NOCOUNT ON;
Select idEmpleado,tipoEmpleado,idUsuario,contrasenna
 From Empleado WHERE idEmpleado=@idEmpleado
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_RegistrarPromocion(
@fechaInicio date,
@fechaFinal date,
@informacion varchar(300),
@rebaja int)
AS SET NOCOUNT ON;
INSERT INTO Promocion(fechaInicio,fechaFinal,informacion,rebaja)
VALUES(@fechaInicio,@fechaFinal,@informacion, @rebaja)
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_ModificarPromocion (
@idPromocion smallint,
@fechaInicio date,
@fechaFinal date,
@informacion varchar(300),
@rebaja int)
AS SET NOCOUNT ON;
UPDATE Promocion set
fechaInicio=@fechaInicio ,fechaFinal=@fechaFinal,
informacion=@informacion ,rebaja=@rebaja WHERE idPromocion =@idPromocion 
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_EliminarPromocion(
@idPromocion smallint)
AS SET NOCOUNT ON;
Delete From Promocion WHERE idPromocion =@idPromocion 
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_ListarPromocion
AS SET NOCOUNT ON;
Select idPromocion,fechaInicio,fechaFinal,informacion,rebaja From Promocion 
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_FiltrarPromocionById(@idPromocion smallint)
AS SET NOCOUNT ON;
Select idPromocion,fechaInicio,fechaFinal,informacion,rebaja From Promocion  WHERE idPromocion = @idPromocion 
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_RegistrarPublicidad (
@rutaImagen varchar(255),
@link varchar(255))
AS SET NOCOUNT ON;
INSERT INTO Publicidad (rutaImagen,link )
VALUES(@rutaImagen,@link )
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_ModificarPublicidad (
@idPublicidad smallinT,
@rutaImagen varchar(255),
@link varchar(255)
)
AS SET NOCOUNT ON;
UPDATE Publicidad set
rutaImagen=@rutaImagen ,link=@link  WHERE idPublicidad=@idPublicidad 
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_EliminarPublicidad (
@idPublicidad smallint)
AS SET NOCOUNT ON;
Delete From Publicidad WHERE idPublicidad= @idPublicidad 
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_ListarPublicidad 
AS SET NOCOUNT ON;
Select idPublicidad,rutaImagen,link From Publicidad 
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_FiltrarPublicidadById(@idPublicidad smallint)
AS SET NOCOUNT ON;
Select idPublicidad ,rutaImagen,link  From Publicidad  WHERE idPublicidad=@idPublicidad
GO
-------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE PA_informacionTexto(
@rutaImagen varchar(255) NULL,
@contenido varchar(255),
@titulo varchar(255),
@tipoInformacion int)
AS SET NOCOUNT ON;
INSERT INTO informacionTexto (rutaImagen,contenido,titulo,tipoInformacion)
VALUES(@rutaImagen,@contenido,@titulo,@tipoInformacion)
GO
-------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE PA_InformacionTexto (
@idInformacionTexto int,
@rutaImagen varchar(255) NULL,
@contenido varchar(255),
@titulo varchar(255))
AS SET NOCOUNT ON;
UPDATE informacionTexto set
rutaImagen=@rutaImagen,contenido=@contenido, titulo=@titulo WHERE idInformacionTexto=@idInformacionTexto 
GO	
-------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE PA_EliminarInformacionTexto(
@idInformacionTexto int ,@tipoInformacion int)
AS SET NOCOUNT ON;
Delete From informacionTexto WHERE idInformacionTexto=@idInformacionTexto  and tipoInformacion=@tipoInformacion
GO
-------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE PA_ListarInformacionTexto(@tipoInformacion int)
AS SET NOCOUNT ON;
Select idInformacionTexto,rutaImagen,contenido,titulo  From informacionTexto WHERE tipoInformacion=@tipoInformacion
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_FiltrarinformacionTextoById(@idInformacionTexto int)
AS SET NOCOUNT ON;
Select idInformacionTexto,rutaImagen,contenido,titulo  From informacionTexto WHERE idInformacionTexto=@idInformacionTexto 
GO
-------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE PA_RegistrarGaleriaImagen(@rutaImagen varchar(255),
@tipoInformacion int)
AS SET NOCOUNT ON;
insert into informacionTexto(rutaImagen,tipoInformacion) VALUES(@rutaImagen,@tipoInformacion)
GO
-------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE PA_ListarGaleriaImagen(@tipoInformacion int)
AS SET NOCOUNT ON;
Select rutaImagen from informacionTexto where tipoInformacion=@tipoInformacion and rutaImagen IS NOT NULL
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE  PROCEDURE PA_ListarGaleriaTexto(@tipoInformacion int)
AS SET NOCOUNT ON;
Select titulo,contenido from informacionTexto where tipoInformacion=@tipoInformacion  and titulo IS NOT NULL AND contenido IS NOT NULL
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_ModificarGaleriaTexto( @contenido varchar(max),@titulo varchar(40), @tipoInformacion int)
AS SET NOCOUNT ON;
update informacionTexto set contenido=@contenido,titulo=@titulo WHERE tipoInformacion=@tipoInformacion   and rutaImagen IS NULL 
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_RegistrarGaleriaTexto( @contenido varchar(max),@titulo varchar(40), @tipoInformacion int)
AS SET NOCOUNT ON;
insert into informacionTexto(contenido,titulo,tipoInformacion) VALUES(@contenido,@titulo,@tipoInformacion)
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_ModificarCoordenadasDestino(@latitudDestino varchar(max),@longitudDestino varchar(max))
AS SET NOCOUNT ON;
Update Mapa set latitudDestino=@latitudDestino, longitudDestino=@longitudDestino
GO
-------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE PA_ModificarCoordenadasOrigen(@latitudOrigen varchar(max),@longitudOrigen varchar(max))
AS SET NOCOUNT ON;
Update Mapa set latitudOrigen=@latitudOrigen, longitudOrigen=@longitudOrigen
GO
-------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE PA_ListarCoordenadasOrigen
AS SET NOCOUNT ON;
Select latitudOrigen,longitudOrigen from Mapa
GO
-------------------------------------------------------------------------------------------------------------------------
