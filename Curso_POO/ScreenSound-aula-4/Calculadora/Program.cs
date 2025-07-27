using Calculadora.Modelos;
Console.Write("Simbolo da Operação: ");
string op = Console.ReadLine();
Console.Write("1: ");
int num1 = int.Parse(Console.ReadLine());
Console.Write("2: ");
int num2 = int.Parse(Console.ReadLine());
Maquina calc = new(op, num1, num2);
calc.ExibirResultado(calc);