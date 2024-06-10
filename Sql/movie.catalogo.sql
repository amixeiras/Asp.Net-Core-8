if(exists(select 1 from sys.objects where name='catalogo' and type='U' and schema_id=SCHEMA_ID('movie')))
	drop table movie.catalogo
GO
CREATE table movie.catalogo
(
	cod int identity Primary Key,
	cod_filme int not null,
	valor decimal(2,2),
	data_inclusao datetime
)

alter table movie.catalogo add constraint fk_catalogo_filmes foreign key(cod_filme)
references movie.filmes(cod)