CREATE DATABASE bd_vitrine
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;


create IF NOT EXISTS table categoria_tb(
	
	IdCategoria serial not null primary key,
	NomeCategoria varchar(150),
	Descricao varchar(300)
);



create IF NOT EXISTS table catalogos_tb(
	
	IdCatalogo serial not null primary key,
	IdCategoria integer not null,
	DescricaoCatalogo varchar(300),
	CONSTRAINT id_categoria_fk foreign key (IdCategoria)
	REFERENCES categoria_tb(IdCategoria)
);


create IF NOT EXISTS table produto_tb(
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




