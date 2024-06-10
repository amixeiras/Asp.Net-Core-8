if(exists(select 1 from sys.objects where name='filmes' and type='U' and schema_id=SCHEMA_ID('movie')))
	drop table movie.filmes
GO
CREATE table movie.filmes
(
	cod int identity Primary Key,
	nome varchar(500),
	classificacao_idade int,
	data_lancamento datetime,
	diretor varchar(300),
	produtora varchar(1000),
	producao varchar(1000),
	data_inclusao datetime
)