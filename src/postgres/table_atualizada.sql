DROP TABLE
IF EXISTS usuario;

DROP TABLE
IF EXISTS cliente;

DROP TABLE
IF EXISTS categoria_produto;

DROP TABLE
IF EXISTS produto;

DROP TABLE
IF EXISTS pedido;

DROP TABLE
IF EXISTS item_pedido;

DROP TABLE
IF EXISTS pagamento;

DROP TABLE
IF EXISTS promocao;

DROP TABLE
IF EXISTS item_promocao;

DROP TABLE
IF EXISTS historico_uso_promocao;

CREATE TABLE usuario (
    id serial
    ,nome VARCHAR(255)
    ,email VARCHAR(255)
    ,senha VARCHAR(255)
    ,tipo SMALLINT
    ,STATUS bool
    ,PRIMARY KEY (id)
    );

CREATE TABLE cliente (
	id serial
	,nome VARCHAR(255)
	,cpf VARCHAR(255)
	,email VARCHAR(255)
	,telefone VARCHAR(255)
	,aniversario TIMESTAMP
	,PRIMARY KEY (id)
	);

CREATE TABLE categoria_produto (
	id serial
	,nome VARCHAR(255)
	,PRIMARY KEY (id)
	);

CREATE TABLE produto (
	id serial
	,nome VARCHAR(255)
	,id_categoria INT
	,STATUS bool
	,preco numeric
	,PRIMARY KEY (id)
	,CONSTRAINT fk_categoria FOREIGN KEY (id_categoria) REFERENCES categoria_produto(id)
	);

CREATE TABLE pedido (
	id serial
	,data_pedido DATE
	,STATUS SMALLINT
	,id_cliente INT
	,horario_inicio TIMESTAMP
	,horario_fim TIMESTAMP
	,valor_pedido numeric
	,PRIMARY KEY (id)
	,CONSTRAINT fk_cliente FOREIGN KEY (id_cliente) REFERENCES cliente(id)
	);

CREATE TABLE item_pedido (
	id_pedido INT
	,id_produto INT
	,preco_itempedido numeric
	,CONSTRAINT fk_pedido FOREIGN KEY (id_pedido) REFERENCES pedido(id)
	,CONSTRAINT fk_produto FOREIGN KEY (id_produto) REFERENCES produto(id)
	);

CREATE TABLE pagamento (
	id_pedido INT
	,forma_pagamento SMALLINT
	,CONSTRAINT fk_pedido FOREIGN KEY (id_pedido) REFERENCES pedido(id)
	);

CREATE TABLE promocao (
	id serial
	,texto VARCHAR(255)
	,STATUS bool
	,PRIMARY KEY (id)
	);

CREATE TABLE item_promocao (
	id_promocao INT
	,id_produto INT
	,desconto numeric
	,CONSTRAINT fk_promocao FOREIGN KEY (id_promocao) REFERENCES promocao(id)
	,CONSTRAINT fk_produto FOREIGN KEY (id_produto) REFERENCES produto(id)
	);

CREATE TABLE historico_uso_promocao (
	id_promocao INT
	,id_cliente INT
	,utilizado bool
	,CONSTRAINT fk_promocao FOREIGN KEY (id_promocao) REFERENCES promocao(id)
	,CONSTRAINT fk_cliente FOREIGN KEY (id_cliente) REFERENCES cliente(id)
	);






----------------_SEED--------------
INSERT INTO public.categoria_produto
(id, nome)
VALUES(1, 'Bebida');
INSERT INTO public.categoria_produto
(id, nome)
VALUES(2, 'Lanche');
INSERT INTO public.categoria_produto
(id, nome)
VALUES(3, 'Sobremesa');






INSERT INTO public.cliente
(id, nome, cpf, email, telefone, aniversario)
VALUES(1, 'Artur', '12345678', 'email@teste.com', '79999999999', '2020-01-24 23:11:42.873');
INSERT INTO public.cliente
(id, nome, cpf, email, telefone, aniversario)
VALUES(2, 'Yan', '22222222', 'yan@yahoo.com', '79999999999', '2003-02-02 00:00:00.000');
INSERT INTO public.cliente
(id, nome, cpf, email, telefone, aniversario)
VALUES(3, 'Henrique', '66666666', 'henrique@bol.com', '11999999999', '2004-02-03 00:00:00.000');
INSERT INTO public.cliente
(id, nome, cpf, email, telefone, aniversario)
VALUES(4, 'Jurandir', '77777777', 'jurandir@outlook.com', '81999999999', '2008-02-03 00:00:00.000');
INSERT INTO public.cliente
(id, nome, cpf, email, telefone, aniversario)
VALUES(5, 'Calabreso', '88888888', 'calabreso@aurora.com', '71999999999', '1999-02-03 00:00:00.000');







INSERT INTO public.pedido
(id, data_pedido, status, id_cliente, horario_inicio, horario_fim, valor_pedido)
VALUES(3, '2024-01-24', 0, 1, '2024-01-24 21:05:28.602', '-infinity', 15.0);
INSERT INTO public.pedido
(id, data_pedido, status, id_cliente, horario_inicio, horario_fim, valor_pedido)
VALUES(4, '2024-01-24', 0, 1, '2024-01-24 21:08:34.219', '-infinity', 15.0);
INSERT INTO public.pedido
(id, data_pedido, status, id_cliente, horario_inicio, horario_fim, valor_pedido)
VALUES(5, '2024-01-24', 0, 1, '2024-01-24 21:10:19.295', '-infinity', 15.0);
INSERT INTO public.pedido
(id, data_pedido, status, id_cliente, horario_inicio, horario_fim, valor_pedido)
VALUES(6, '2024-01-24', 0, 1, '2024-01-24 21:10:39.708', '-infinity', 15.0);
INSERT INTO public.pedido
(id, data_pedido, status, id_cliente, horario_inicio, horario_fim, valor_pedido)
VALUES(7, '2024-01-24', 0, 1, '2024-01-24 21:13:36.538', '-infinity', 15.0);
INSERT INTO public.pedido
(id, data_pedido, status, id_cliente, horario_inicio, horario_fim, valor_pedido)
VALUES(9, '2024-01-24', 4, 1, '2024-01-24 21:53:42.029', '2024-01-24 21:54:44.353', 15.0);
INSERT INTO public.pedido
(id, data_pedido, status, id_cliente, horario_inicio, horario_fim, valor_pedido)
VALUES(8, '2024-01-24', 4, 1, '2024-01-24 21:15:41.073', '2024-01-25 21:30:55.096', 15.0);







INSERT INTO public.produto
(id, nome, id_categoria, status, preco)
VALUES(1, 'Coca', 1, true, 5.0);
INSERT INTO public.produto
(id, nome, id_categoria, status, preco)
VALUES(2, 'Agua', 1, true, 2.0);
INSERT INTO public.produto
(id, nome, id_categoria, status, preco)
VALUES(3, 'Agua de Coco', 1, true, 3.0);
INSERT INTO public.produto
(id, nome, id_categoria, status, preco)
VALUES(4, 'Hamburguer', 2, true, 25.0);
INSERT INTO public.produto
(id, nome, id_categoria, status, preco)
VALUES(5, 'Coxinha', 2, true, 7);
INSERT INTO public.produto
(id, nome, id_categoria, status, preco)
VALUES(6, 'Pastel Frango', 2, true, 4);
INSERT INTO public.produto
(id, nome, id_categoria, status, preco)
VALUES(7, 'Empada', 2, true, 2);







INSERT INTO public.promocao
(id, texto, status)
VALUES(1, 'Frete Gratis', true);
INSERT INTO public.promocao
(id, texto, status)
VALUES(2, '10% desconto na empada', true);
INSERT INTO public.promocao
(id, texto, status)
VALUES(3, 'Pastel Grátis', true);
INSERT INTO public.promocao
(id, texto, status)
VALUES(4, 'Compre bebida e ganhe pastel', true);
INSERT INTO public.promocao
(id, texto, status)
VALUES(5, 'Tudo pela metade do dobro', true);
INSERT INTO public.promocao
(id, texto, status)
VALUES(6, 'Compre 2 pague 3', true);





INSERT INTO public.usuario
(id, nome, email, senha, tipo, status)
VALUES(1, 'Claudinho', 'claudinho@music.com', '**********', 0, true);
INSERT INTO public.usuario
(id, nome, email, senha, tipo, status)
VALUES(2, 'Buchecha', 'buchecha@sound.com', '**********', 1, true);


--------------------------------------------------------

alter sequence cliente_id_seq restart with 6;
alter sequence categoria_produto_id_seq restart with 4;
alter sequence produto_id_seq restart with 8;
alter sequence promocao_id_seq restart with 7;
alter sequence pedido_id_seq restart with 9;
alter sequence usuario_id_seq restart with 3;
