USE DDJK;

--------------------------
-- Definicion de tablas --
--------------------------

DROP TABLE IF EXISTS Cliente;
CREATE TABLE Cliente(dummy int);
ALTER TABlE Cliente ADD COLUMN idCliente int IDENTITY(1,1);
ALTER TABLE Cliente ADD COLUMN pasaporte varchar(25);
ALTER TABLE Cliente ADD COLUMN nombre varchar(50);
ALTER TABLE Cliente ADD COLUMN primerApellido varchar(50);
ALTER TABLE Cliente ADD COLUMN segundoApellido varchar(50);
ALTER TABLE Cliente ADD COLUMN edad tinyint;
ALTER TABLE Cliente ADD COLUMN nacionalidad varchar(25);
ALTER TABLE Cliente ADD COLUMN correo varchar(50);
ALTER TABLE Cliente DROP COLUMN dummy;

DROP TABLE IF EXISTS Habitacion;
CREATE TABLE Habitacion(dummy int);
ALTER TABLE Habitacion ADD COLUMN idHabitacion tinyint IDENTITY(1,1);
ALTER TABLE Habitacion ADD COLUMN tipoHabitacion tinyint;
ALTER TABLE Habitacion ADD COLUMN idCliente int;
ALTER TABLE Habitacion ADD COLUMN vacante tinyint;
ALTER TABLE Habitacion ADD COLUMN capacidad tinyint;
ALTER TABLE Habitacion DROP COLUMN dummy;

DROP TABLE IF EXISTS Reservacion;
CREATE TABLE Reservacion(dummy int);
ALTER TABLE Reservacion ADD COLUMN idReservacion int IDENTITY(1,1);
ALTER TABLE Reservacion ADD COLUMN idHabitacion tinyint;
ALTER TABLE Reservacion ADD COLUMN idCliente int;
ALTER TABLE Reservacion ADD COLUMN fechaLlegada date;
ALTER TABLE Reservacion ADD COLUMN fechaSalida date;
ALTER TABLE Reservacion DROP COLUMN dummy;

DROP TABLE IF EXISTS TipoHabitacion;
CREATE TABLE TipoHabitacion(dummy int);
ALTER TABLE TipoHabitacion ADD COLUMN idTipoHabitacion int IDENTITY(1,1);
ALTER TABLE TipoHabitacion ADD COLUMN nombreTipoHabitacion varchar(25);
ALTER TABLE TipoHabitacion ADD COLUMN precioBase int;
ALTER TABLE TipoHabitacion DROP COLUMN dummy;

DROP TABLE IF EXISTS Empleado;
CREATE TABLE Empleado(dummy int);
ALTER TABLE Empleado ADD COLUMN idEmpleado smallint IDENTITY(1,1);
ALTER TABLE Empleado ADD COLUMN tipoEmpleado tinyint;
ALTER TABLE Empleado ADD COLUMN idUsuario varchar(50);
ALTER TABLE Empleado ADD COLUMN contrasenna varchar(256);
ALTER TABLE Empleado DROP COLUMN dummy;


DROP TABLE IF EXISTS Promocion;
CREATE TABLE Promocion(dummy int);
ALTER TABLE Promocion ADD COLUMN idPromocion smallint IDENTITY(1,1);
ALTER TABLE Promocion ADD COLUMN fechaInicio date;
ALTER TABLE Promocion ADD COLUMN fechaFinal date;
ALTER TABLE Promocion ADD COLUMN informacion varchar(300);
ALTER TABLE Promocion ADD COLUMN rebaja int;
ALTER TABLE Promocion DROP COLUMN dummy;

--------------------------
-- Definicion de tablas --
--------------------------