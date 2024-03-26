using Shared;

Console.WriteLine("*** SERIE DE NUMEROS: SUMATORIA Y PROMEDIO ***");
Console.WriteLine("----------------------------------------------");

var answer = string.Empty;
var options = new List<string> { "s", "n" };
do
{
    

    var n = ConsoleExtension.GetInt("Cuántos números desea:  ");
    double sum = 0;

    Console.WriteLine("*** CALCULOS ***");
    for (int i = 1; i<=n; i++)
    {
        Console.Write($"{i}\t");
        sum += i;
    }
    double promedio = sum / n;

    Console.WriteLine("");
    Console.WriteLine($"La suma es.......: {sum,20:N0}");
    Console.WriteLine($"El promedio es...: {promedio,20:N2}");
    
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

