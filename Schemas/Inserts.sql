INSERT INTO aluno(nome, usuario, senha, ativo) VALUES('Gerson Mollo', 'Teste 1', 'U2VuaGExMjMq', 1)
INSERT INTO aluno(nome, usuario, senha, ativo) VALUES('Daiane Camargo', 'Teste 2', 'U2VuaGExMjMq', 1)
INSERT INTO aluno(nome, usuario, senha, ativo) VALUES('Leona', 'Teste 3', 'U2VuaGExMjMq', 1)
INSERT INTO aluno(nome, usuario, senha, ativo) VALUES('Yummi', 'Teste 4', 'U2VuaGExMjMq', 1)

INSERT INTO turma(curso_id, turma, ano, ativo) VALUES(1, 'Turma 1', 2000, 1)
INSERT INTO turma(curso_id, turma, ano, ativo) VALUES(2, 'Turma 2', 2001, 1)
INSERT INTO turma(curso_id, turma, ano, ativo) VALUES(3, 'Turma 3', 2002, 1)
INSERT INTO turma(curso_id, turma, ano, ativo) VALUES(4, 'Turma 4', 2003, 1)

INSERT INTO aluno_turma(aluno_id, turma_id, ativo) VALUES(1, 2, 1)
INSERT INTO aluno_turma(aluno_id, turma_id, ativo) VALUES(2, 3, 1)
INSERT INTO aluno_turma(aluno_id, turma_id, ativo) VALUES(3, 4, 1)
INSERT INTO aluno_turma(aluno_id, turma_id, ativo) VALUES(4, 1, 1)
