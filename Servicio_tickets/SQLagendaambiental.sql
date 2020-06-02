--Drop database dbgestionambiental
create database dbgestionambiental

use dbgestionambiental

/*Tabla nivel academico*/
create table Nivel_Academico(
	idNA int identity(1,1) primary key,
	nombre varchar(100)
);

/*Tabla trabajo*/
create table Trabajo(
	idTrabajo int identity(1,1) primary key,
	nombre varchar(100)
);

--DROP TABLE usuario_externo /*Borra tabla*/
--Truncate table usuario_externo /*Limpia Tabla*/
/*Tabla usuario externo, FK con tabla Nivel_Academico y con Trabajo*/
create table usuario_externo(
idUsuario_Externo int identity(1,1) primary key,
idTabajo int FOREIGN KEY REFERENCES Trabajo(idTrabajo),
idNivel_Academico int FOREIGN KEY REFERENCES Nivel_Academico(idNA),
nombre_completo varchar(100),
curp varchar(30),
email varchar(100),
telefono varchar(10),
contraseña varchar(100)
);

--DROP TABLE Encargado
/*Tabla Encargado de unidad*/
create table Encargado(
RPE int identity(1,1) primary key,
nombre_completo varchar(100),
email varchar(100),
telefono varchar(10)
);

/*Tabla unidad*/
create table Unidad(
idUnidad int identity(1,1) primary key,
RPE int FOREIGN KEY REFERENCES Encargado(RPE),
nombre varchar(100)
);

/*Tabla sub unidad*/
create table Sub_Unidad(
idSubUnidad int identity(1,1) primary key,
idUnidad int FOREIGN KEY REFERENCES Unidad(idUnidad),
RPE int FOREIGN KEY REFERENCES Encargado(RPE),
nombre varchar(100)
);

/*Tabla Servicio*/
create table Servicio(
idServicio int identity(1,1) primary key,
idUnidad int FOREIGN KEY REFERENCES Unidad(idUnidad),
nombre varchar(100),
Hrs_Atencion int
);

--Drop table Ticket
--truncate table ticket
/*Tabla Ticket*/
create table Ticket(
idTicket int identity(1,1) primary key,
idServicio int FOREIGN KEY REFERENCES Servicio(idServicio),
idSolicitante int not null,
Fecha_ini DATE not null,
Fecha_fin Date,
Estatus int,
Asunto varchar(20),
CONSTRAINT idEncargado FOREIGN KEY (idSolicitante) REFERENCES  Encargado(RPE),
CONSTRAINT idUsuario_Externo FOREIGN KEY (idSolicitante) REFERENCES  usuario_externo(idUsuario_Externo)
);

--Drop table Comentario
/*Tabla comentario*/
create table Comentario(
idComentario int identity(1,1) primary key,
idTicket int FOREIGN KEY REFERENCES Ticket(idTicket),
idSolicitante int not null,
Descripcion varchar(500) not null,
--Estatus int,
HrsActivo DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
CONSTRAINT idEncargadoCom FOREIGN KEY (idSolicitante) REFERENCES  Encargado(RPE),
CONSTRAINT idUsuario_ExternoCom FOREIGN KEY (idSolicitante) REFERENCES  usuario_externo(idUsuario_Externo)
);


INSERT INTO Nivel_Academico (nombre) values ('Ninguno'),('Primaria'),('Secundaria'),('Bachillerato'),('Técnica'),('Profesional'),('Postgrado');
INSERT INTO Trabajo (nombre) values ('Ninguno'),('Gobierno'),('Industria'),('Educación');

--Drop table Encargado
--Truncate table Encargado
INSERT INTO Encargado (nombre_completo,email,telefono) values ('Marcos Algara Siller','marcos.algara@uaslp.mx','7201'),
('Zoraida Aguilar Pérez','zoraida.aguilar@uaslp.mx','7200'),
('Mariana Buendia Oliva','mariana.buendia@uaslp.mx','7213'),
('Laura Daniela Hernández Rodríguez','gestion.ambiental@uaslp.mx','7210'),
('Diana Elizabeth Navarro Flores','difusion.agenda@uaslp.mx','7212'),
('Maria Araceli Carvajal Mendoza','araceli.carvajal@uaslp.mx​','7202'),
('Marcos Daniel Rocha Castillo','imagen.agenda@uaslp.mx',''),
('Carla Gabriela Moran Flores','carla.moran@uaslp.mx','7205'),
('Ulises Saldivar Pérez','ulises.saldivar@uaslp.mx',''),
('Maria Eugenia Almendarez García','eugenia.almendarez@uaslp.mx','7203'),
('Miguel Angel González Cervantes','miguel.gonzalez@uaslp.mx','7213'),
('Jose de Jesús Mejía Saavedra','jjesus@uaslp.mx','7206'),
('Maricela Rodríguez Díaz de León','maricela.diazdeleon@uaslp.mx','7207'),
('Lorena Guadalupe Leija Martínez','lorena.leija@uaslp.mx','7204'),
('Laura Begbeder Schiel','laura.begbeder@uaslp.mx','7208');

--Drop table Unidad
--Truncate table Unidad
INSERT INTO Unidad(RPE,nombre) values (1,'Director Agenda Ambienta'),(3,'Educación e Investigación'),(4,'Gestión institucional'),
(5,'Comunicación'),(6,'Administración'),(7,'Imagen'),(10,'RTIC'),(11,'Proyectos TIC'),(12,'Coordinador Académico del PMPCA'),
(13,'Coordinación educativa');

--Truncate table Sub_Unidad
INSERT INTO Sub_Unidad(idUnidad,RPE,nombre) values (1,2,'Asistente de Dirección'),(5,8,'Asistente administración'),
(5,9,'Apoyo administrativo'),(9,14,'Asistente'),(10,14,'Asistente'),(9,15,'Seguimiento de alumnos CONACyT');

INSERT INTO Servicio(idUnidad,nombre,Hrs_Atencion) values (5,'Servicio de Difusión y Comunicación',300),(5,'Servicio de Generación de Contenidos',300),
(5,'Servicio de Fotografía',300),(5,'Servicio Audiovisual',300);

--insert into Comentario (idTicket,idSolicitante,Descripcion) values (1,2,'Ok se enviará la camara a usted Juan en alrededor de una semana')

select * from usuario_externo
select * from Nivel_Academico
select * from Trabajo
select * from Encargado
select * from Unidad
select * from Sub_Unidad
select t.* from Ticket t inner join usuario_externo u on t.idSolicitante = u.idUsuario_Externo where t.Estatus=0 and t.idSolicitante=1;
select c.* from Comentario c where c.idTicket=1;

--UPDATE Ticket SET Estatus=1, Fecha_fin=NULL where idTicket=2