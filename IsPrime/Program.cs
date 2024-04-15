using Shared;

Console.WriteLine("*** ES NUMERO PRIMO? ***");
Console.WriteLine("------------------------");

var answer = string.Empty;
var options = new List<string> { "s", "n" };
do
{
    var n = ConsoleExtension.GetInt("Ingrese el N°: ");
    var isPrime = MyMath.IsPrime(n);

    Console.WriteLine($"El número {n} {(isPrime ? "SI" : "NO")} es primo");

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
