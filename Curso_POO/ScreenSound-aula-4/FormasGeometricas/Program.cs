using FormasGeometricas;

Dictionary<string, FormaGeometrica> formas = new Dictionary<string, FormaGeometrica>();

FormaGeometrica quadrado = new Quadrado(5);
FormaGeometrica triangulo = new Triangulo(5, 4);

double area = triangulo.CalcularArea();
Console.WriteLine($"Área do Quadrado: {area}");