CREATE DATABASE BGVitrine
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;
	
	
	
	create table bgs_cliente_tb(
		IdCliente serial not null primary key,
		RazaoSocial varchar(300) not null,
		NomeFantasia varchar(300),
		CpfCnpj bigint,
		LogoTipoBase64 varchar,
		CEP varchar(30),
		Logradouro varchar(300),
		Cidade varchar(100),
		UF varchar(5),
		Complemento varchar(300),
		Telefone varchar(100)		
	);
	
	create table bgs_tema_tb(
		IdTema serial not null primary key,
		IdCliente integer not null,
		NomeTema varchar(100) not null	,
		CONSTRAINT id_cliente_fk foreign key(IdCliente)
		references bgs_cliente_tb(IdCliente)
	);
	
	create table bgs_paleta_tema_tb(
		IdTema integer not null,
		CoresTextoNormal varchar(100),
		CoresTextoDestaque varchar(100),
		CoresFundo varchar(100),
		CoresTextoNormalSecundaria varchar(100),
		CoresTextoDestaqueSecundaria varchar(100)
		CoresFundoSecundaria varchar(100)
	);
	
	
	create table bgs_imagens_index_carousel_tb(
		IdAnexo serial not null primary key,
		IdCliente integer not null,		
		ImagemBase64 varchar not null,
		NomeImagem varchar(200),
		DescricaoImagem varchar(400),
		CONSTRAINT id_cliente_fk foreign key(IdCliente)
		references bgs_cliente_tb(IdCliente)
	);
	
	create table bgs_parametros_gerais_tb(
		IdParametro serial not null primary key,
		TitleIndexInit varchar(200),
		TextoIndexInit varchar(400),
		TitleCardUm varchar(200),
		TextoCardUm varchar(400),
		TitleCardDois varchar(200),
		TextoCardDois varchar(400)
	);
	
	