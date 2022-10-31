Create database Carreras
GO

Use Carreras
GO

create table carreras (
cod_carrera int identity(1,1),
nombre varchar(100)

constraint pk_carrera primary key (cod_carrera)
)

create table asignaturas (
cod_asignatura int identity(1,1),
nombre varchar(100)

constraint pk_asignatura primary key (cod_asignatura)
)

create table detalleCarreras(
cod_detalleCarrera int identity(1,1),
anio_cursado tinyint,
cuatrimestre tinyint,
cod_asignatura int,
cod_carrera int

constraint pk_detalleCarrera primary key (cod_detalleCarrera),
constraint fk_detalleCarrera_carrera foreign key (cod_carrera)
references carreras(cod_carrera),
constraint fk_detalleCarrera_asignatura foreign key (cod_asignatura)
references asignaturas(cod_asignatura)
)

alter table carreras
add bajada_logicamente bit

select * from carreras