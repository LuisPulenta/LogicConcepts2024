﻿using Shared;
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("*** ECUACION CUADRATICA ***");
Console.WriteLine("---------------------------");

var answer = string.Empty;
var options = new List<string> { "s", "n" };
do
{
    var a = ConsoleExtension.GetDouble("Ingrese valor de a: ");
    var b = ConsoleExtension.GetDouble("Ingrese valor de b: ");
    var c = ConsoleExtension.GetDouble("Ingrese valor de c: ");

    var solution = QuadraticSolution(a,b,c);

    Console.WriteLine($"X1 = {solution.X1:N5}");
    Console.WriteLine($"X2 = {solution.X2:N5}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]i, [N]o?: ", options);
    }
    while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

}
while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));


Console.WriteLine("--------------------------");
Console.WriteLine("***         FIN        ***");
Console.WriteLine("--------------------------");

QuadraticEquationSolution QuadraticSolution(double a, double b, double c)
{
    return new QuadraticEquationSolution
    {
        X1 = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a),
        X2 = (-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a),
    };
}


//---------------------------------------------------------------------------------------------
public class QuadraticEquationSolution
{
    public double X1 { get; set; }
    public double X2 { get; set; }
}

