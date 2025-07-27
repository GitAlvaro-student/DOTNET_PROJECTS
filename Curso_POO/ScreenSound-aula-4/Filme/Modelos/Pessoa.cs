using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Filme.Modelos
{
    internal class Pessoa
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Idade { get; set; }
        public void GerarJson(Pessoa pessoa)
        {
            var json = JsonSerializer.Serialize(pessoa);
            string nomeDoArquivo = $"info_{Nome}.json";
            File.WriteAllText(nomeDoArquivo, json);
            Console.WriteLine($"Arquivo Gerado. Caminho: {Path.GetFullPath(nomeDoArquivo)}");
        }
        public void LerJson(string nomeDoArquivo)
        {
            var arquivo = File.ReadAllText(nomeDoArquivo);
            var jsonPessoa = JsonSerializer.Deserialize<Pessoa>(arquivo);
            jsonPessoa!.ExibirInfo();
        }
        public static void GerarJsonPessoas(List<Pessoa> pessoas)
        {
            var json = JsonSerializer.Serialize(pessoas);
            string nomeDoArquivo = $"info_Pessoas.json";
            File.WriteAllText(nomeDoArquivo, json);
            Console.WriteLine($"Arquivo Gerado. Caminho: {Path.GetFullPath(nomeDoArquivo)}");
        }
        public static void LerJsonPessoas(string nomeDoArquivo)
        {
            var arquivo = File.ReadAllText(nomeDoArquivo);
            var jsonPessoa = JsonSerializer.Deserialize<List<Pessoa>>(arquivo);
            foreach (var pessoa in jsonPessoa)
            {
                pessoa.ExibirInfo();
            }
        }

        public void ExibirInfo()
        {
            Console.WriteLine($"{Nome} --||-- {Email} --||-- {Idade}");
        }
    }
}
