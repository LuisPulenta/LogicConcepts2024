using Shared;

Console.WriteLine("*** NUMERO MULTIPLO ***");
Console.WriteLine("-----------------------");

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var a = ConsoleExtension.GetInt("Ingrese primer número: ");
    var b = ConsoleExtension.GetInt("Ingrese segundo número: ");
    

    if (a % b ==0)
    {
        Console.WriteLine($"{a} es múltiplo de {b}");
    }

    else if (b%a==0)
    {
        Console.WriteLine($"{b} es múltiplo de {a}");
    }

    else
    {
        Console.WriteLine($"{a} y {b} no son múltiplos ");
    }
    Console.WriteLine("------------------------");
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
