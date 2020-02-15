CREATE DATABASE InscripcionDb	
GO
USE InscripcionDb
GO
CREATE TABLE Estudiantes
(
EstudianteId int primary key identity,
Nombre varchar(40),
Telefono varchar(15),
Cedula varchar(18),
Direccion varchar(max),
FechaNacimiento date,
Balance decimal
);
CREATE TABLE Inscripcion
(
InscripcionId int primary key identity,
Fecha date,
EstudianteId int,
Comentario varchar(50),
Balance decimal,
Monto decimal
);