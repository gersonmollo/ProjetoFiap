CREATE TABLE aluno (
    id INT NOT NULL IDENTITY,
	nome VARCHAR(255),
	usuario VARCHAR(45),
	senha VARCHAR(50),
	ativo int,
    PRIMARY KEY (id)
);

CREATE TABLE turma (
    id INT NOT NULL IDENTITY,
	curso_id INT,
	turma VARCHAR(45),
    ano INT,
	ativo int,
	PRIMARY KEY (id)
);

CREATE TABLE aluno_turma (
	id INT NOT NULL IDENTITY,
	aluno_id INT,
	turma_id INT,
	ativo int,
    FOREIGN KEY (aluno_id) REFERENCES aluno(id),
	FOREIGN KEY (turma_id) REFERENCES turma(id)
);