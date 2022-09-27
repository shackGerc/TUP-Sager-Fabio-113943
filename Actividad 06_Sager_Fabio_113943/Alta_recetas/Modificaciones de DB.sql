use recetas_db
go

--Tablas
--Tipos Recetas
create table Tipos_de_Receta(
id_tipo int identity(1,1),
tipo varchar(50)
constraint pk_tipo_receta primary key(id_tipo)
)
GO

-- Inserts de tipos
insert into Tipos_de_Receta
values('Ensalada')
insert into Tipos_de_Receta
values('Mariscos')
insert into Tipos_de_Receta
values('China')
insert into Tipos_de_Receta
values('Rapida')
GO

alter table Recetas
drop column id_tipo
GO

alter table Recetas
add constraint fk_recetas_tipoReceta foreign key(tipo_receta)
references Tipos_de_receta(id_tipo)
GO

--Detalles Receta
Alter table Detalles_Receta
add constraint fk_detalle_receta foreign key (id_receta)
references Recetas(id_receta)

--Ingredientes
Alter table Ingredientes
drop constraint FK_Ingredientes_Ingredientes

--Procedimientos almacenados
CREATE PROC [SP_CONSULTAR_TIPOS_RECETA]
AS
BEGIN
	SELECT id_tipo, tipo
	from Tipos_de_Receta
END

create proc SP_PROXIMO_ID_RECETA
@next int OUTPUT
AS
BEGIN
SET @next = (SELECT MAX(id_receta)+1 from Recetas)
END

/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_RECETA]    Script Date: 27/9/2022 18:16:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_INSERTAR_RECETA] 
	@tipo_receta int,
	@nombre varchar(50),
	@cheff varchar(100),
	@new_id_receta int OUTPUT
AS
BEGIN
	INSERT INTO Recetas (nombre, cheff , tipo_receta)
    VALUES (@nombre,@cheff,@tipo_receta );
	SET @new_id_receta = SCOPE_IDENTITY()
END

create proc SP_CONSULTAR_RECETAS
	@tipo_receta int,
	@nombre varchar(50)
as
begin
	select nombre, tipo_receta, cheff
	from Recetas
	where nombre=@nombre and tipo_receta=@tipo_receta
end
