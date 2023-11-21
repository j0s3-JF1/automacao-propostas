create database EloDB;
use EloDB;

-- TABELA DE EQUIPAMENTOS / PRODUTOR --

CREATE TABLE EQUIPAMENTO(
	NUMSERIE VARCHAR(255) NOT NULL PRIMARY KEY,
    FABRICANTE VARCHAR(255),
    MODELO VARCHAR(255),
    TENSAOMIN INT,
    TENSAOMAX INT,
    CORRENTE FLOAT,
    POTENCIA FLOAT,
    CHOOPER VARCHAR(3),
    STATUS VARCHAR(100),
    LOCALIZACAO VARCHAR(100),
    CADASTRADO VARCHAR(255)
);



CREATE TABLE CARACTERISTICA(
	ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    DIGITAL_INPUT INT,
    DIGITAL_OUTPUT INT,
    ANALOG_INPUT INT,
    ANALOG_OUTPUT INT,
    LARGURA FLOAT,
    ALTURA FLOAT,
    PROFUNDIDADE FLOAT,
    FAMILIA VARCHAR(255),
    
    NUMSERIE VARCHAR(255),
    
    FOREIGN KEY (NUMSERIE) REFERENCES EQUIPAMENTO(NUMSERIE)
);

CREATE TABLE PLACA_IO(
	ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	FABRICANTE VARCHAR(255),
    MODELO VARCHAR(255),
    DIGITAL_INPUT INT,
    DIGITAL_OUTPUT INT,
    ANALOG_INPUT INT,
    ANALOG_OUTPUT INT,
    CONFIG VARCHAR(3),
    STATUS VARCHAR(100),
    FAMILIA VARCHAR(255),
    CADASTRADO VARCHAR(255)
);

CREATE TABLE PLACA_COMUNICACAO(
	ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    FABRICANTE VARCHAR(255),
    MODELO VARCHAR(255),
    PROTOCOLO VARCHAR(255),
    STATUS VARCHAR(100),
    FAMILIA VARCHAR(255),
    CADASTRADO VARCHAR(255)
);

CREATE TABLE PLACA_ENCODER(
	ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    FABRICANTE VARCHAR(255),
    MODELO VARCHAR(255),
    TIPO VARCHAR(255),
    STATUS VARCHAR(100),
    FAMILIA VARCHAR(255),
    CADASTRADO VARCHAR(255)
);

-- STATUS DE EQUIPAMENTO / PRODUTO -- 
CREATE TABLE STATUS_EQUIPAMENTO(
	ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    STATUS VARCHAR(255)
);

CREATE TABLE STATUS_PLACA_IO(
	ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    STATUS VARCHAR(255)
);

CREATE TABLE STATUS_PLACA_COMUNICACAO(
	ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    STATUS VARCHAR(255)
);

CREATE TABLE STATUS_PLACA_ENCODER(
	ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    STATUS VARCHAR(255)
);

-- CHECK - LIST --
CREATE TABLE DADOS_CLIENTE(
	ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    NOME VARCHAR(255),
    EMPRESA VARCHAR(255),
    CNPJ VARCHAR(100),
    ENDERECO VARCHAR(300),
    EMAIL VARCHAR(255),
    TELEFONE VARCHAR(255),
    FONE VARCHAR(255)
);

CREATE TABLE DADOS_MOTOR(
	ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    TENSAO INT,
    CORRENTE FLOAT,
    POTENCIA FLOAT,
    VELOCIDADE INT,
    FATOR FLOAT
);

CREATE TABLE DADOS_APLICACAO(
	ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    TIPO VARCHAR(255),
    ENTRADAS_DIGITAIS INT,
    SAIDAS_DIGITAIS INT,
    ENTRADAS_ANALOGICAS INT,
    SAIDAS_ANALOGICAS INT,
    PROTOCOLO VARCHAR(100),
    ENCODER VARCHAR(100),
    AMBIENTE VARCHAR(100)
);


CREATE TABLE DADOS_ADICIONAIS(
	ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    LARGURA FLOAT,
    ALTURA FLOAT,
    PROFUNDIDADE FLOAT,
    DIAS INT,
    PROFISSIONAL VARCHAR(20),
    SUPORTE VARCHAR(20)
);

CREATE TABLE DADOS_REDE(
	ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    TENSAO VARCHAR(255),
    FUSIVEIS VARCHAR(255),
    DISJUNTOR VARCHAR(255),
    FECHAMENTO VARCHAR(100),
    CARACTERISTICA VARCHAR(255)
);

CREATE TABLE PROPOSTA(
	ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY, 
    ID_CLIENTE INT NOT NULL,
    ID_MOTOR INT NOT NULL,
    ID_REDE INT NOT NULL,
    ID_APLICACAO INT NOT NULL,
    ID_ADICIONAL INT NOT NULL,
    
    FOREIGN KEY (ID_CLIENTE) REFERENCES DADOS_CLIENTE(ID),
    FOREIGN KEY (ID_MOTOR) REFERENCES DADOS_MOTOR(ID),
    FOREIGN KEY (ID_REDE) REFERENCES DADOS_REDE(ID),
    FOREIGN KEY (ID_APLICACAO) REFERENCES DADOS_APLICACAO(ID),
    FOREIGN KEY (ID_ADICIONAL) REFERENCES DADOS_ADICIONAIS(ID)
);


-- Itens -- 
CREATE TABLE FABRICANTE(
	ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    FABRICANTE VARCHAR(255)
);

CREATE TABLE CADASTRO(
	ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    NOME VARCHAR(255)
);

CREATE TABLE LOCALIZACAO(
	ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    LOCALIZACAO VARCHAR(100)
);

CREATE TABLE PROTOCOLO(
	ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    PROTOCOLO VARCHAR(255)
);

CREATE TABLE ENCODER(
	ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    ENCODER VARCHAR(255)
);

-- USUARIOS --
CREATE TABLE USUARIOS(
	ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    NOME VARCHAR(255),
    USUARIO VARCHAR(255),
    SENHA VARCHAR(255),
    ACESSO VARCHAR(255)
);

-- QUERY --
-- --
-- --
DROP TABLE  PROPOSTA;
DROP TABLE  DADOS_CLIENTE;
DROP TABLE  DADOS_MOTOR;
DROP TABLE  DADOS_REDE;
DROP TABLE DADOS_APLICACAO;
DROP TABLE  DADOS_ADICIONAIS;
DROP TABLE EQUIPAMENTO;
DROP TABLE CARACTERISTICA;
DROP TABLE PLACA_IO;
DROP TABLE PLACA_COMUNICACAO;
DROP TABLE PLACA_ENCODER;
DROP TABLE STATUS_EQUIPAMENTO;
DROP TABLE STATUS_PLACA_IO;
DROP TABLE STATUS_PLACA_COMUNICACAO;
DROP TABLE STATUS_PLACA_ENCODER;
DROP TABLE FABRICANTE;
DROP TABLE CADASTRO;
DROP TABLE LOCALIZACAO;
DROP TABLE PROTOCOLO;
DROP TABLE ENCODER;
DROP TABLE USUARIOS;

INSERT INTO STATUS_EQUIPAMENTO(STATUS) VALUE
("Defeito"),
("Aguardando"),
("Disponível"),
("Locado");

INSERT INTO STATUS_PLACA_IO(STATUS)VALUE
("Em Estoque"),
("Fora de Estoque");

INSERT INTO STATUS_PLACA_COMUNICACAO(STATUS)VALUE
("Em Estoque"),
("Fora de Estoque");

INSERT INTO STATUS_PLACA_ENCODER(STATUS)VALUE
("Em Estoque"),
("Fora de Estoque");

INSERT INTO FABRICANTE(FABRICANTE) value
("KEB"),
("DELTA"),
("EATON"),
("WEG"),
("ALLEN BRADLEY"),
("ABB"),
("SCHNEIDER"),
("YASKAWA"),
("BONFIGLIOLI"),
("DANFOSS"),
("SIEMENS"),
("VACON"),
("GEFRAN");

INSERT INTO CADASTRO(NOME) VALUE
("José Fernando"),
("Adalberon Cruz"),
("Breno Teruel"),
("Clairi"),
("Pedro Almeida"),
("Maysa"),
("Cosmo Gomes"),
("Lucas Rafael"),
("Cristiano Muniz"),
("Marcelo Nunes"),
("Carlos Henrique"),
("Carlos Roberto"),
("José Carlos Jr."),
("José Vinícius");

INSERT INTO LOCALIZACAO(LOCALIZACAO) VALUE 
("EASYL1"),
("EASYL2"),
("EASYL3"),
("EASYL4"),
("EASY0"),
("CLIENTE");

INSERT INTO PROTOCOLO(PROTOCOLO) VALUE
("NÃO"),
("ModBus TCP/IP"),
("ModBus RTU"),
("EtherNET/IP"),
("DeviceNet"),
("CanOPEN"),
("Profibus"),
("Profinet");


INSERT INTO ENCODER(ENCODER) VALUE
("NÃO"),
("TTL"),
("HTL");

select * from encoder;

INSERT INTO USUARIOS(NOME,USUARIO, SENHA, ACESSO) VALUE
("Breno Teruel","Breno.Teruel", "BT_ELOADM", "COM"),
("Adalberon Cruz","Adalberon.Cruz", "AC_ELOADM", "ALL"),
("José Fernando","Jose.Fernando", "JF_ELOADM", "ALL"),
("José Vinícius","Jose.Vinicius", "JV_ELOADM", "ALL"),
("Carlos Henrique","Carlos.Henrique", "CH_ELOADM", "COM"),
("Carlos Roberto","Carlos.Roberto", "CR_ELOADM", "COM"),
("Cosmo Gomes","Cosmo.Gomes", "CG_ELOADM", "EXP"),
("Lucas Rafael","Lucas.Rafael", "LR_ELOADM", "EXP");

SELECT
	EQUIPAMENTO.NUMSERIE AS NumSerie,
	EQUIPAMENTO.FABRICANTE AS Fabricante,
	EQUIPAMENTO.MODELO AS Modelo,
	EQUIPAMENTO.TENSAOMIN AS TensaoMin,
	EQUIPAMENTO.TENSAOMAX AS TensaoMax,
	EQUIPAMENTO.CORRENTE AS Corrente,
	EQUIPAMENTO.POTENCIA AS Potencia,
	EQUIPAMENTO.CHOOPER AS Chooper,
	EQUIPAMENTO.STATUS AS Status,
	EQUIPAMENTO.LOCALIZACAO AS Localizacao,
	EQUIPAMENTO.CADASTRADO AS Cadastrado,
	CARACTERISTICA.DIGITAL_INPUT AS EntradaDigital,
	CARACTERISTICA.DIGITAL_OUTPUT AS SaidaDigital,
	CARACTERISTICA.ANALOG_INPUT AS EntradaAnalogica,
	CARACTERISTICA.ANALOG_OUTPUT AS SaidaAnalogica,
	CARACTERISTICA.LARGURA AS Largura,
	CARACTERISTICA.ALTURA AS Altura,
	CARACTERISTICA.PROFUNDIDADE AS Profundidade,
	CARACTERISTICA.FAMILIA AS Familia
FROM
CARACTERISTICA
INNER JOIN
EQUIPAMENTO ON CARACTERISTICA.NUMSERIE = EQUIPAMENTO.NUMSERIE;

SELECT
    -- DADOS DO CLIENTE
    DADOS_CLIENTE.NOME AS Cliente,
    DADOS_CLIENTE.EMPRESA AS Empresa,
    DADOS_CLIENTE.CNPJ AS Cnpj,
    DADOS_CLIENTE.ENDERECO AS Endereco,
    DADOS_CLIENTE.EMAIL AS Email,
    DADOS_CLIENTE.TELEFONE AS Telefone,
    DADOS_CLIENTE.FONE AS Fone,
    -- DADOS DO MOTOR
    DADOS_MOTOR.TENSAO AS Tensao,
    DADOS_MOTOR.CORRENTE AS Corrente,
    DADOS_MOTOR.POTENCIA AS Potencia,
    DADOS_MOTOR.VELOCIDADE AS Velocidade,
    DADOS_MOTOR.FATOR AS Fator,
    -- DADOS DA REDE
    DADOS_REDE.TENSAO AS Rede,
    DADOS_REDE.FUSIVEIS AS Fusiveis,
    DADOS_REDE.DISJUNTOR AS Disjuntor,
    DADOS_REDE.FECHAMENTO AS Fechamento,
    DADOS_REDE.CARACTERISTICA AS Caracteristica,
    -- DADOS DA APLICACAO
    DADOS_APLICACAO.TIPO AS Tipo,
    DADOS_APLICACAO.ENTRADAS_DIGITAIS AS EntradaDigital,
    DADOS_APLICACAO.SAIDAS_DIGITAIS AS SaidaDigital,
    DADOS_APLICACAO.ENTRADAS_ANALOGICAS AS EntradaAnalog,
    DADOS_APLICACAO.SAIDAS_ANALOGICAS AS SaidaAnalog,
    DADOS_APLICACAO.PROTOCOLO AS Protocolo,
    DADOS_APLICACAO.ENCODER AS Encoder,
    DADOS_APLICACAO.AMBIENTE AS Ambiente,
    -- DADOS ADICIONAIS
    DADOS_ADICIONAIS.LARGURA AS Largura,
    DADOS_ADICIONAIS.ALTURA AS Altura,
    DADOS_ADICIONAIS.PROFUNDIDADE AS Profundidade,
    DADOS_ADICIONAIS.DIAS AS Dias,
    DADOS_ADICIONAIS.PROFISSIONAL AS Profissional,
    DADOS_ADICIONAIS.SUPORTE AS Suporte
FROM
    PROPOSTA
INNER JOIN
    DADOS_CLIENTE ON PROPOSTA.ID_CLIENTE = DADOS_CLIENTE.ID
INNER JOIN
    DADOS_MOTOR ON PROPOSTA.ID_MOTOR = DADOS_MOTOR.ID
INNER JOIN
    DADOS_REDE ON PROPOSTA.ID_REDE = DADOS_REDE.ID
INNER JOIN
    DADOS_APLICACAO ON PROPOSTA.ID_APLICACAO = DADOS_APLICACAO.ID
INNER JOIN
    DADOS_ADICIONAIS ON PROPOSTA.ID_ADICIONAL = DADOS_ADICIONAIS.ID
WHERE 
	DADOS_CLIENTE.ID = 1;
    
    SELECT
    -- DADOS DO CLIENTE
    DADOS_CLIENTE.NOME AS Cliente,
    DADOS_CLIENTE.EMPRESA AS Empresa,
    DADOS_CLIENTE.CNPJ AS Cnpj,
    DADOS_CLIENTE.ENDERECO AS Endereco,
    DADOS_CLIENTE.EMAIL AS Email,
    DADOS_CLIENTE.TELEFONE AS Telefone,
    DADOS_CLIENTE.FONE AS Fone,
    -- DADOS DO MOTOR
    DADOS_MOTOR.TENSAO AS Tensao,
    DADOS_MOTOR.CORRENTE AS Corrente,
    DADOS_MOTOR.POTENCIA AS Potencia,
    DADOS_MOTOR.VELOCIDADE AS Velocidade,
    DADOS_MOTOR.FATOR AS Fator,
    -- DADOS DA REDE
    DADOS_REDE.TENSAO AS Rede,
    DADOS_REDE.FUSIVEIS AS Fusiveis,
    DADOS_REDE.DISJUNTOR AS Disjuntor,
    DADOS_REDE.FECHAMENTO AS Fechamento,
    DADOS_REDE.CARACTERISTICA AS Caracteristica,
    -- DADOS DA APLICACAO
    DADOS_APLICACAO.TIPO AS Tipo,
    DADOS_APLICACAO.ENTRADAS_DIGITAIS AS EntradaDigital,
    DADOS_APLICACAO.SAIDAS_DIGITAIS AS SaidaDigital,
    DADOS_APLICACAO.ENTRADAS_ANALOGICAS AS EntradaAnalog,
    DADOS_APLICACAO.SAIDAS_ANALOGICAS AS SaidaAnalog,
    DADOS_APLICACAO.PROTOCOLO AS Protocolo,
    DADOS_APLICACAO.ENCODER AS Encoder,
    DADOS_APLICACAO.AMBIENTE AS Ambiente,
    -- DADOS ADICIONAIS
    DADOS_ADICIONAIS.LARGURA AS Largura,
    DADOS_ADICIONAIS.ALTURA AS Altura,
    DADOS_ADICIONAIS.PROFUNDIDADE AS Profundidade,
    DADOS_ADICIONAIS.DIAS AS Dias,
    DADOS_ADICIONAIS.PROFISSIONAL AS Profissional,
    DADOS_ADICIONAIS.SUPORTE AS Suporte
FROM
    PROPOSTA
INNER JOIN
    DADOS_CLIENTE ON PROPOSTA.ID_CLIENTE = DADOS_CLIENTE.ID
INNER JOIN
    DADOS_MOTOR ON PROPOSTA.ID_MOTOR = DADOS_MOTOR.ID
INNER JOIN
    DADOS_REDE ON PROPOSTA.ID_REDE = DADOS_REDE.ID
INNER JOIN
    DADOS_APLICACAO ON PROPOSTA.ID_APLICACAO = DADOS_APLICACAO.ID
WHERE 
	DADOS_CLIENTE.ID = 1;