using Filme.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Filme.Filtros
{
    internal class LinqFilter
    {
        public static void FiltrarNumero(List<int> numeros)
        {
            var numFiltrados = numeros.Select(num => num).Distinct();
            Console.Write("Numeros Filtrados: ");
            foreach (var num in numFiltrados)
            {
                Console.Write($"-> {num} ");
            }
        }
        public static void FiltrarPares(List<int> numeros)
        {
            var numPares = numeros.Where(num => (num%2) == 0).Distinct();
            Console.Write("Numeros Pares: ");
            foreach (var num in numPares)
            {
                Console.Write($"-> {num} ");
            }
        }
        public static void FiltrarLivrosPorAno(List<Book> books, int ano)
        {

            var livrosPorAno = books.Where(b => b.AnoPubli >= ano).OrderBy(b => b.Titulo);
            Console.WriteLine("Livros Filtrados por Ano: ");
            foreach (var book in livrosPorAno) 
            {
                Console.WriteLine($"{book.Titulo} -> {book.Autor} -> {book.AnoPubli}");
            }
        }
        public static void FiltrarPorIdade(string nomeDoArquivo, int idade)
        {
            var arquivo = File.ReadAllText(nomeDoArquivo);
            var jsonPessoas = JsonSerializer.Deserialize<List<Pessoa>>(arquivo);
            var pessoasIdade = jsonPessoas.Where(i => i.Idade == idade);
            foreach (var item in pessoasIdade)
            {
                item.ExibirInfo();
            }
        }
    }
}
