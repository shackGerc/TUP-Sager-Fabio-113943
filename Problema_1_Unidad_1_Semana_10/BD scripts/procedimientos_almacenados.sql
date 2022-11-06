alter proc pa_recuperar_asignaturas
as
	select cod_asignatura 'Código', nombre 'Nombre' from asignaturas
	order by nombre

create proc pa_insertar_carrera
@nombre varchar(100),
@new_cod_carrera int output
as
	insert into carreras(nombre) values(@nombre);
	set @new_cod_carrera = SCOPE_IDENTITY();

create proc pa_insertar_detalleCarrera
@anioCursado tinyint,
@cuatrimestre tinyint,
@cod_asignatura int,
@cod_carrera int
as
	insert into detalleCarreras(anio_cursado, cuatrimestre, cod_asignatura, cod_carrera)
	values(@anioCursado, @cuatrimestre, @cod_asignatura, @cod_carrera)

create proc pa_consultar_carreras
as
	select cod_carrera, nombre from carreras
	order by cod_carrera

alter proc pa_consultar_detalleCarrera
as
	select anio_cursado, cuatrimestre, a.cod_asignatura 'cod_asignatura', 
	a.nombre 'nombre asignatura', cod_carrera
	from detalleCarreras as dc join asignaturas as a on dc.cod_asignatura = a.cod_asignatura
	order by cod_carrera

alter proc pa_consultar_carreras
as
	select cod_carrera, nombre, bajada_logicamente
	from carreras
	order by cod_carrera

create proc pa_actualizar_carrera
@cod_carrera int,
@nombre varchar(100),
@bajada_logicamente bit
as
	update carreras
	set nombre=@nombre, bajada_logicamente = @bajada_logicamente
	where cod_carrera = @cod_carrera


create proc pa_borrar_detalles_carrera
@cod_carrera int
as
	delete detalleCarreras
	where cod_carrera = @cod_carrera

create proc pa_consultar_asignaturas
as
	select cod_asignatura 'Código', nombre Nombre
	from asignaturas


alter proc pa_consultar_cantidad_materias_x_carrera
	as
	select c.nombre Carrera, count(cod_asignatura) 'Cantidad_materias'
	from carreras c join detalleCarreras dc on c.cod_carrera=dc.cod_carrera
	group by c.cod_carrera, c.nombre

alter proc comprobarUsuario
@nombreUsuario varchar(100), @contrasenia varchar(100), @resultado bit output
as
begin
	if(exists (select * from Usuarios where nombre=@nombreUsuario  and PWDCOMPARE(@contrasenia, 
	contrasenia) = 1))
		set @resultado = 1
	else
		set @resultado = 0
end