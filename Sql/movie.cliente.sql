if(exists(select 1 from sys.objects where name='cliente' and type='U' and schema_id=SCHEMA_ID('movie')))
	drop table movie.cliente
GO
CREATE table movie.cliente
(
	cod int identity Primary Key,
	nome varchar(500),
	idade int,
	cod_endereco int not null,
	data_inclusao datetime
)

alter table movie.cliente add constraint fk_cliente_endereco foreign key(cod_endereco)
references movie.endereco(cod)