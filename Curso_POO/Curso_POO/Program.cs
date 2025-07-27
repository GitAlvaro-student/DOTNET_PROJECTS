//Seguro insure1 = new Seguro();
//insure1.Nome = "Eletrodomésticos GE";
//insure1.Tipo = "Garantia Estendida";
//insure1.Preco = 100.20m;
//insure1.Cobertura = "Danos Elétricos";
//insure1.Vigencia = (false);


//insure1.ExibirFicha();

//List<int> lista = new List<int> { 1,2,3,4,5,6,7,8,9,10,11};
//List<int> listaImp = lista.FindAll(numero => numero % 3 == 0);
//listaImp.ForEach(numero => Console.Write($"{numero} | "));
Classificacao tipo1 = new Classificacao();
tipo1.Name = "Automovel";
Classificacao tipo2 = new Classificacao();
tipo2.Name = "Residencial";
Classificacao tipo3 = new Classificacao();
tipo3.Name = "Credito";
Classificacao tipo4 = new Classificacao();
tipo4.Name = "Cartao de Credito";


Empresa cardoso = new Empresa("Cardoso Insurance");


Portifolio port1 = new ("Personal Lines");

Seguro seg1 = new Seguro(tipo1, "AutoPlus")
{
    Cobertura = "Colisão e roubo de veículos",
    Preco = 150.25m
};


Seguro seg2 = new Seguro(tipo2, "SafeHouse")
{
    Cobertura = "Incêndio e danos elétricos",
    Preco = 250.25m
};


port1.AdicionarSeguro(seg1);
port1.AdicionarSeguro(seg2);

Portifolio port2 = new ("Bancassurance");


Seguro seg3 = new Seguro(tipo3, "SafeCredit");

Seguro seg4 = new Seguro(tipo4, "SafeCard Premium");

port2.AdicionarSeguro(seg3);
port2.AdicionarSeguro(seg4);

cardoso.AdicionarPortifolio(port1);
cardoso.AdicionarPortifolio(port2);

seg1.ExibirFicha();
seg2.ExibirFicha();
port1.ExibirSeguros();
cardoso.ExibirPortfolios();