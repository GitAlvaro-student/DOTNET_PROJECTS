using AluraFlix.Filmes;

Filme movie1 = new("Até o Último Homem", 129, new List<Artista>());
Filme movie2 = new("Homem Aranha - Sem Volta Para Casa", 134, new List<Artista>());
Filme movie3 = new("Espetacular Homem Aranha", 182, new List<Artista>());

Artista ator1 = new("Andrew Garfield", 38);
ator1.FilmeAtuado(movie1);
ator1.FilmeAtuado(movie2);
ator1.FilmeAtuado(movie3);

Artista ator2 = new("Teresa Palmer", 36);
ator2.FilmeAtuado(movie1);
ator1.DetalhesDoAtor();
Console.WriteLine();
movie1.Detalhes();