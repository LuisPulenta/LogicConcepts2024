using Shared;
using System.Xml.Serialization;

Console.WriteLine("*** NUMERO PI ***");
Console.WriteLine("-----------------");

var answer = string.Empty;
var options = new List<string> { "s", "n" };
do
{
    var n = ConsoleExtension.GetInt("Cuantos términos de precisión quieres: ");

    var e = CalculatePi(n);



    Console.WriteLine($"El número PI calculado con {n} términos de precisión es: {e}");


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
double CalculatePi(int n)
{
    double pi = 0.0;
    int signo = 1;
    double denominador = 1;

    for (int i = 0; i < n; i++)
    {
        double ter = 1 / denominador * signo;
        pi += ter;
        denominador += 2;
        signo *= -1;
    }
    return pi * 4;
}
