CREATE TABLE fornecedores (
	id INT AUTO_INCREMENT PRIMARY KEY,
	nome VARCHAR(100) NOT NULL,
	cnpj VARCHAR(18) NOT NULL UNIQUE,
	endereco VARCHAR(255),
	telefone VARCHAR(20),
	email VARCHAR(100),
	responsavel VARCHAR(100),
	created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);