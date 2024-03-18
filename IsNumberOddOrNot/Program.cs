using Shared;

Console.WriteLine("*** NUMERO PAR O IMPAR ***");
Console.WriteLine("--------------------------");

var answer = string.Empty;
var options = new List<string> { "s", "n" };
do
{
    var number = ConsoleExtension.GetInt("Ingrese Número ENTERO: ");
    if (number % 2 == 0)
        {
            Console.WriteLine($"{number} es PAR");
        }
        else
        {
            Console.WriteLine($"{number} es IMPAR");
        }
    
    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]i, [N]o?: ", options);
    }
    while (!options.Any(x=>x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
    
}
while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("--------------------------");
Console.WriteLine("***         FIN        ***");
Console.WriteLine("--------------------------");
