CREATE DATABASE db_agenda_fatec;

USE db_agenda_fatec;

CREATE TABLE Cargos (

    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(255) NOT NULL UNIQUE,
    Ativo TINYINT(1) NOT NULL DEFAULT 1

);

CREATE TABLE Blocos (

    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(255) NOT NULL UNIQUE,
    Descricao VARCHAR(255) NULL DEFAULT "Nenhuma descrição.",
    Ativo TINYINT(1) NOT NULL DEFAULT 1

);

CREATE TABLE Usuarios (

    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(255) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Senha CHAR(32) NOT NULL, -- Terá algum tipo de criptografia.
    Administrador TINYINT(1) NOT NULL DEFAULT 0,
    Ativo TINYINT(1) NOT NULL DEFAULT 1,

    CargoId INT NOT NULL,
    CONSTRAINT fk_cargo_usuario FOREIGN KEY(CargoId) REFERENCES Cargo(Id)

);

CREATE TABLE Salas (

    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(255) NOT NULL UNIQUE,
    Numero VARCHAR(5) NOT NULL UNIQUE,
    Descricao VARCHAR(255) NULL DEFAULT "Nenhuma descrição.",
    Status_atual ENUM("Disponível", "Em uso", "Indisponível") NOT NULL DEFAULT "Disponível",
    Ativo TINYINT(1) NOT NULL DEFAULT 1,

    BlocoId INT NOT NULL,
    CONSTRAINT fk_bloco_sala FOREIGN KEY(BlocoId) REFERENCES Bloco(Id)

);

CREATE TABLE Equipamentos (

    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(255) NOT NULL UNIQUE,
    Descricao VARCHAR(255) NULL DEFAULT "Nenhuma descrição.",
    Ativo TINYINT(1) NOT NULL DEFAULT 1

);

CREATE TABLE Itens (

    Id INT AUTO_INCREMENT PRIMARY KEY,

    Quantidade INT NOT NULL,

    SalaId INT NOT NULL,
    CONSTRAINT fk_sala_item FOREIGN KEY(SalaId) REFERENCES Sala(Id),

    EquipamentoId INT NOT NULL,
    CONSTRAINT fk_equipamento_item FOREIGN KEY(EquipamentoId) REFERENCES Equipamento(Id)

);

CREATE TABLE Agendamentos (

    Id INT AUTO_INCREMENT PRIMARY KEY,
    Data_Requisicao DATE NOT NULL, -- Data em que o registro foi criado.
    Hora_Requisicao TIME NOT NULL, -- Hora em que o registro foi criado.
    Data_Utilizacao DATE NOT NULL,
    Hora_Inicio_Utilizacao TIME NOT NULL,
    Hora_Fim_Utilizacao TIME NOT NULL,
    Situacao ENUM("Pendente", "Aprovado", "Negado") NOT NULL DEFAULT "Pendente",

    SalaId INT NOT NULL,
    CONSTRAINT fk_sala_agendamento FOREIGN KEY(SalaId) REFERENCES Sala(Id),
    
    RequisitorId INT NOT NULL,
    CONSTRAINT fk_requisitor_agendamento FOREIGN KEY(RequisitorId) REFERENCES Usuario(Id),

    AprovadorId INT NOT NULL,
    CONSTRAINT fk_aprovador_agendamento FOREIGN KEY(AprovadorId) REFERENCES Usuario(Id)

);

SHOW TABLES;