using System;

internal interface IArmazenar 
{ 
	void Recuperar(string file);
	void Salvar(string file);
}

internal class Arquivo : IArmazenar
{
	public void Recuperar(string file)
	{
		Console.WriteLine($"Recuperando dados do arquivo: {file}");
    }
	public void Salvar(string file)
	{
		Console.WriteLine($"Salvando dados no arquivo: {file}");
    }
}
internal class BancoDeDados : IArmazenar
{
	public void Recuperar(string file)
	{
		Console.WriteLine($"Recuperando dados do banco de dados: {file}");
	}
	public void Salvar(string file)
	{
		Console.WriteLine($"Salvando dados no banco de dados: {file}");
	}
}
