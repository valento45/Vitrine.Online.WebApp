CREATE DATABASE bd_vitrine
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;


create table categoria_tb(
	
	IdCategoria serial not null primary key,
	NomeCategoria varchar(150),
	Descricao varchar(300)
);



create  table catalogos_tb(
	
	IdCatalogo serial not null primary key,
	IdCategoria integer not null,
	DescricaoCatalogo varchar(300),
	CONSTRAINT id_categoria_fk foreign key (IdCategoria)
	REFERENCES categoria_tb(IdCategoria)
);


create  table produto_tb(
	IdProduto serial not null primary key,
	IdCatalogo integer,
	NomeProduto varchar(150),
	DescricaoProduto varchar(300),
	ImagemBase64 varchar,	
	ValorProduto decimal,
	DataVencimento timestamp,
	Quantidade integer,
	CONSTRAINT id_catalogo_fk FOREIGN KEY (IdCatalogo)
	REFERENCES catalogos_tb(IdCatalogo)

);

CREATE  table solicitaco_orcamento_tb(
	
	IdSolicitacao serial not null primary key,
    NomeSolicitacao varchar (100),
	CelularSolicitacao varchar (20),
	EmailSolicitacao varchar (100) not null,
	EnderecoSolicitacao varchar (100),
	DescricaoSolicitacao varchar (100),
	DataSolicitacao TIMESTAMP
);

create table anexo_solicitacao_tb(
		id_anexo serial not null primary key,
		IdSolicitacao integer not null,
		anexo_base64 varchar not null,
		extensao_arquivo varchar(10),
		constraint IdSolicitacao foreign key(IdSolicitacao)
		references solicitaco_orcamento_tb(IdSolicitacao)
);


