create table categorias
(idcategoria int auto_increment not null primary key,
nomecategoria varchar(50),
descricaocategoria varchar(100));

select * from categorias;

create table unidades
(idunidade int auto_increment not null primary key,
nomeunidade varchar(50),
sigla varchar(2));

INSERT INTO `gerenciadororcamentosdb`.`unidades` (`nomeunidade`, `sigla`) VALUES ('unidade', 'un');
select * from unidades;

create table clientes
(idcliente int auto_increment not null,
nomecliente varchar(50),
cpf varchar(11),
rg varchar(10),
telefone varchar(11),
endereco varchar(50),
numero int,
bairro varchar(50),
cidade varchar(50),
uf varchar(2),
cep varchar(9),
primary key (idcliente, cpf, rg));

insert into clientes (nomeCliente, cpf, rg) values ('indefinido', '12345678910', '1234567891');
delete from clientes where idcliente=1;
select * from clientes;

create table produtos
(idproduto int auto_increment not null primary key,
nomeproduto varchar(50),
valor decimal(18.2),
descricaoproduto varchar(100),
idcategoria int not null,
idunidade int not null,
foreign key (idcategoria) references categorias (idcategoria),
foreign key (idunidade) references unidades (idunidade));

select * from produtos;

create table orcamentos
(idorcamento int not null primary key,
idcliente int not null,
foreign key (idcliente) references clientes (idcliente));

create table orcamentosprodutos
(idorcamento int not null,
idproduto int not null,
quantidade decimal(18.2),
totalitem decimal(18.2),
primary key (idorcamento, idproduto),
foreign key (idorcamento) references orcamentos (idorcamento) on delete cascade ,
foreign key (idproduto) references produtos (idproduto));

create table usuarios
(idusuario int auto_increment not null primary key,
emailusuario varchar(100),
senhausuario varchar(30));

insert into usuarios (emailusuario, senhausuario)
values ('admin', 'admin');
insert into usuarios (emailusuario, senhausuario)
values ('paula', 'paula');