// ESTE BANCO POSSUI RELACIONAMENTO DE BD, PARA CADA USUÁRIO PODER TER SEUS PRÓPRIOS
// PRODUTOS EXIBIDOS EM SUA PRÓPRIA PÁGINA. CADA USUÁRIO TERIA SUA PRÓPRIA LOJA.

create database sitetrab;
use sitetrab;

create table users(
	user_id				int					auto_increment primary key,
    user_nome			varchar(80)			not null,
    user_sobrenome		varchar(100)		not null,
    user_email			varchar(150)		not null unique,
    user_senha			varchar(150)		not null,
    user_telefone		varchar(20)			not null,
    user_cpf			varchar(11)			not null,
    user_sexo			char(1)				not null,
    user_nivel			char(1)				not null
);

create table product (
	pd_id				int					auto_increment primary key,
    user_id				int,
	pd_nome				varchar(80)			not null,
    pd_image			varchar(255)		not null,
	pd_desc				varchar(1000)		not null,
    pd_price			float				not null,
    foreign key (user_id) references users (user_id)
);

insert into users(user_nome, user_sobrenome, user_email, user_senha, user_telefone, user_cpf, user_sexo, user_nivel)
VALUES
("Padrão", "Padrão", "admin@admin.com","$2a$10$l4jeq9j5dl8C84cRzjZY0umdxwAD.NcvInf/rr77KHtTWaNH9Aekq","0000000","00000000","M","A");

insert into product(pd_nome, user_id, pd_image, pd_desc, pd_price)
VALUES
("Vitória", 1,
"70-imagens-evangelicas-para-plaquinhas-gospel-evangelicas-placas-decorativas-para-paredes.jpg",
"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s", 
0.0),
("Cerveja", 1,
"cerveja.jpg",
"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s", 
12.5),
("Lobo", 1,
"def69643889ee29e232637646e839064.jpg",
"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s", 
50.3),
("Flor", 1,
"iStock-536613027.jpg",
"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s", 
22.5),
("Ponte", 1,
"download.jfif",
"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s", 
24.5),
("Bola", 1,
"images.jfif",
"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s", 
567.5);