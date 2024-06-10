if(exists(select 1 from sys.objects where name='endereco' and type='U' and schema_id=SCHEMA_ID('movie')))
	drop table movie.endereco
GO
CREATE table movie.endereco
(
	cod int identity Primary Key,
	descricao varchar(2000),
	cep char(9),
	numero varchar(5),
	complemento varchar(50),
	data_inclusao datetime
)