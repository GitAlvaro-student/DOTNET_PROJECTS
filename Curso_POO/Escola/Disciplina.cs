using System.Net.Http.Headers;

class Disciplina
{
    public List<Aluno> alunos = new List<Aluno>();
    public string Nome { get; set; }

    public void ExibirInfo()
    {
        Console.WriteLine($"Disciplina: {this.Nome}");
        Console.WriteLine("\nAluno Matriculados\n" +
            "******************************************");
        foreach (Aluno aluno in alunos)
        {
            Console.WriteLine(aluno.Nome);
        }
    }
    public void AddAluno(Aluno aluno)
    {
        alunos.Add(aluno);
    } 
}