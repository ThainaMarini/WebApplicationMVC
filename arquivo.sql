CREATE TABLE Users (
    id INT IDENTITY(1,1) PRIMARY KEY,
    email VARCHAR(50),
    senha VARCHAR(20),
    nome VARCHAR(50)
);

INSERT INTO Users (email, senha, nome)
VALUES ('exemplo@email.com', 'senha123', 'João da Silva');