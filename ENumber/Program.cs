using Shared;

Console.WriteLine("*** NUMERO E ***");
Console.WriteLine("----------------");

var answer = string.Empty;
var options = new List<string> { "s", "n" };
do
{
    var n = ConsoleExtension.GetInt("Cuantos términos de precisión quieres: ");

    var e = CalculateE(n);
    
    

    Console.WriteLine($"El número e calculado con {n} términos de precisión es: {e}");


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

//---------------------------------------------------------------------
double CalculateE(int n)
{
    double e = 0.0;
    
    for (int i = 0; i <= n; i++)
    {
        e += (1 / MyMath.Factorial(i));
    }
    return e;
}
