using Shared;

Console.WriteLine("*** SERIE DE FIBONACCI ***");
Console.WriteLine("--------------------------");

var answer = string.Empty;
var options = new List<string> { "s", "n" };
do
{
    var n = ConsoleExtension.GetInt("Cuantos términos quiere: ");
    var sum = 0;

    double a = 0;
    double b = 1;
    double c = 0;

    Console.Write($"{a:N0}\t{b:N0}\t");

    for ( int i = 2; i<n; i++)
    {
        c = a + b;
        Console.Write($"{c:N0}\t");
        a= b;
        b=c;
    }
    Console.WriteLine();

    //Console.WriteLine($"La suma es: {sum:N5}");


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

