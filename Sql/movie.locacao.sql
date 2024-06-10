if(exists(select 1 from sys.objects where name='locacao' and type='U' and schema_id=SCHEMA_ID('movie')))
	drop table movie.locacao
GO
CREATE table movie.locacao
(
	cod int identity Primary Key,
	cod_catalogo int not null,
	cod_cliente int not null,
	data_previsao_entrega datetime,
	pago bit not null default 0,
	data_inclusao datetime
)

alter table movie.locacao add constraint fk_locacao_catalogo foreign key(cod_catalogo)
references movie.catalogo(cod)

alter table movie.locacao add constraint fk_locacao_cliente foreign key(cod_cliente)
references movie.cliente(cod)