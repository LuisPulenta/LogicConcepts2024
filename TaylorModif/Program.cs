using Shared;

Console.WriteLine("*** SERIE DE TAYLOR MODIFICADA***");
Console.WriteLine("---------------------------------");

var answer = string.Empty;
var options = new List<string> { "s", "n" };
do
{
    var n = ConsoleExtension.GetInt("Cuántos términos desea: ");
    var x = ConsoleExtension.GetDouble("Digita el valor de x: ");

    double taylor = TaylorModif(x, n);

    Console.WriteLine($"f({x}) = {taylor}:N5");

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


//-----------------------------------------------------------------------------------------
double TaylorModif(double x, int n)
{
    double taylor = 0;
    for (int i = 0; i < n; i++)
    {
        taylor += Math.Pow(x, i) / MyMath.Factorial(i) * Math.Pow(-1, i);
    }
    return taylor;
}
