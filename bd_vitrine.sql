CREATE DATABASE bd_vitrine
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

--drop table categoria_tb
create table categoria_tb(
	
	IdCategoria serial not null primary key,
	NomeCategoria varchar(150),
	Descricao varchar(300),
	ImagemBase64 varchar
);


 


--drop table catalogos_tb
create table catalogos_tb(
	
	IdCatalogo serial not null primary key,
	IdCategoria integer not null,
	DescricaoCatalogo varchar(300),
	CONSTRAINT id_categoria_fk foreign key (IdCategoria)
	REFERENCES categoria_tb(IdCategoria)
);

--drop table produto_tb
create table produto_tb(
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


create table solicitacao_orcamento_tb(
	IdSolicitacao serial not null primary key,
	NomeSolicitacao varchar(200),
	CelularSolicitacao varchar(20),
	EmailSolicitacao varchar(150),
	EnderecoSolicitacao varchar(300),
	DescricaoSolicitacao varchar(300),
	DataSolicitacao timestamp not null
);


create table anexo_solicitacao_tb(
		id_anexo serial not null primary key,
		IdSolicitacao integer not null,
		anexo_base64 varchar not null,
		extensao_arquivo varchar(10),
		constraint IdSolicitacao_FK foreign key(IdSolicitacao)
		references solicitacao_orcamento_tb(IdSolicitacao)
);


create table servico_realizado_tb(
      IdServico serial not null primary key,
	  IdCategoria integer not null,
	  DescricaoServico varchar (300),
	  DataServico timestamp not null,
	  ResumoServico varchar (300),
	  EnderecoServico varchar (300),
	  CONSTRAINT IdCategoria_fk FOREIGN key(IdCategoria)
	  REFERENCES categoria_tb(IdCategoria)
);


create table anexo_servico_realizado_tb(
		IdAnexo serial not null primary key,
		IdServico integer not null,
		AnexoBase64 varchar not null,
		ExtensaoArquivo varchar(10),
		constraint IdServico_FK foreign key(IdServico)
		references servico_realizado_tb(IdServico)
);


