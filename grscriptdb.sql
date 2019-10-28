create table usuario (
	usuarioid int generated always as identity primary key,
    nombre varchar not null,
	correo varchar not null,
	clave varchar not null,
	tipo int not null,
	cuenta int not null
)

create table categoria (
	categoriaid int generated always as identity primary key,
    nombre VARCHAR not null
)

create table servicio (
	servicioid int generated always as identity primary key,
    nombre varchar not null,
	categoriaid int not null
)

create table banca (
	bancaid int generated always as identity primary key,
	banco varchar not null,
    cuenta varchar not null
)


create table tecnico (
	tecnicoid int generated always as identity primary key,
    nombre varchar not null,
	telefono varchar not null,
	direccion varchar not null,
	servicioid int not null,
	categoriaid int not null,
	usuarioid int not null,
	bancaid int not null
)

alter table tecnico add constraint fk_servicioid 
foreign key (servicioid) references servicio(servicioid);

alter table tecnico add constraint fk_categoriaid
foreign key (categoriaid) references categoria(categoriaid);

alter table tecnico add constraint fk_usuarioid 
foreign key (usuarioid) references usuario(usuarioid);

alter table tecnico add constraint fk_bancaid 
foreign key (bancaid) references banca(bancaid);

create table anuncio (
	anuncioid int generated always as identity primary key,
    titulo varchar not null,
	mensaje varchar not null,
	tecnicoid int not null
)

alter table anuncio add constraint fk_tecnicoid 
foreign key (tecnicoid) references tecnico(tecnicoid);

create table contrato (
	contratoid int generated always as identity primary key,
    descripcion varchar not null,
	tecnicoid int not null
)

alter table contrato add constraint fk_tecnicoid 
foreign key (tecnicoid) references tecnico(tecnicoid);

create table cliente (
	clienteid int generated always as identity primary key,
    nombre varchar not null,
	direccion varchar not null,
	telefono varchar not null,
	correo varchar not null,
	bancaid int not null,
	usuarioid int not null
)

alter table cliente add constraint fk_bancaid
foreign key (bancaid) references banca(bancaid);

alter table cliente add constraint fk_usuarioid 
foreign key (usuarioid) references usuario(usuarioid);

create table cotizacion (
	cotizacionid int generated always as identity primary key,
    descripcion varchar not null,
	clienteid int not null
)

alter table cotizacion add constraint fk_clienteid
foreign key (clienteid) references cliente(clienteid);

create table evaluacion (
	evaluacionid int generated always as identity primary key,
    puntuacion int not null,
	comentario varchar not null,
	clienteid int not null,
	tecnicoid int not null,
	categoriaid int not null
)

alter table evaluacion add constraint fk_clienteid
foreign key (clienteid) references cliente(clienteid);

alter table evaluacion add constraint fk_tecnicoid
foreign key (tecnicoid) references tecnico(tecnicoid);

alter table evaluacion add constraint fk_categoriaid
foreign key (categoriaid) references categoria(categoriaid);

create table historialtecnico (
	historialtecnicoid int generated always as identity primary key,
    tecnicoid int not null,
	servicioid int not null
)

alter table historialtecnico add constraint fk_tecnicoid
foreign key (tecnicoid) references tecnico(tecnicoid);

alter table historialtecnico add constraint fk_servicioid
foreign key (servicioid) references servicio(servicioid);

create table pago (
	pagoid int generated always as identity primary key,
    monto float not null,
	tarjeta varchar not null,
	tarjetahabiente varchar not null,
	fechadeexpiracion varchar not null,
	cleinteid int not null,
	tecnicoid int not null,
	servicioid int not null
)

alter table pago add constraint fk_tecnicoid
foreign key (tecnicoid) references tecnico(tecnicoid);

alter table pago add constraint fk_servicioid
foreign key (servicioid) references servicio(servicioid);

alter table pago add constraint fk_clienteid
foreign key (cleinteid) references cliente(clienteid);


insert into categoria (nombre) values ('Electronica');
insert into categoria (nombre)  values ('Hardware PC');
insert into categoria  (nombre) values ('Telefonia');
select * from categoria

insert into servicio (nombre, categoriaid) values ('Lavadoras',1);
insert into servicio (nombre, categoriaid) values ('Reparamiento de PCs', 2);
insert into servicio (nombre, categoriaid) 
values ('Reparamiento de telefonos', 3);
select * from servicio

insert into usuario (nombre, correo, clave, tipo, cuenta) 
values ('Oscar Mendez', 'osc.mendez@unitec.edu', 'holaqhace', 1, 2);

insert into usuario (nombre, correo, clave, tipo, cuenta) 
values ('Marcialin', 'Marcialin@unitec.edu', '12345', 1, 3);

insert into banca (banco, cuenta) 
values ('Occidente', '233493764')

insert into banca (banco, cuenta) 
values ('Ficosha', '8709777')

insert into tecnico (nombre, telefono, direccion, servicioid, usuarioid, bancaid)
values ('Oscar Mendez', '98242108', 'Stan Cruz de Yojoa', 1, 1, 1)

insert into tecnico (nombre, telefono, direccion, servicioid, usuarioid, bancaid)
values ('Marcialin', '9824287', 'San Pedro Sula', 2, 2, 2)

insert into anuncio (titulo, mensaje, tecnicoid)
values ('LavaDoc','Reparamos todo tipo de lavadoras',1);

insert into anuncio (titulo, mensaje, tecnicoid)
values ('PCDoc','Reparamos todo tipo de pcs',2);


