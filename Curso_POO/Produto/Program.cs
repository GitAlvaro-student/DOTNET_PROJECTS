Produto p1 = new Produto();
p1.Nome = "Bolacha";
p1.Marca = "Nestle";
p1.Preco = 5.5m;
p1.Estoque = 10;

Produto p2 = new Produto();
p2.Nome = "Macarrão";
p2.Marca = "Adria";
p2.Preco = 8.90m;
p2.Estoque = 15;

Produto p3 = new Produto();
p3.Nome = "Azeite";
p3.Marca = "Galo";
p3.Preco = 29.90m;
p3.Estoque = 5;

Estoque estoque = new Estoque();
estoque.AdicionarProdutos(p1);
estoque.AdicionarProdutos(p2);
estoque.AdicionarProdutos(p3);

estoque.ExibirProdutos();