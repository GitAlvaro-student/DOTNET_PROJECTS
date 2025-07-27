// See https://aka.ms/new-console-template for more information
Aluno a1 = new Aluno();
a1.Nome = "Alvaro";

Aluno a2 = new Aluno();
a2.Nome = "Florenice";

Disciplina disc1 = new Disciplina();
disc1.Nome = "Inglês";
disc1.AddAluno(a1);
disc1.AddAluno(a2);
disc1.ExibirInfo();
