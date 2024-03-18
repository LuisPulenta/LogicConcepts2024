using Shared;

Console.WriteLine("*** DESCUENTOS ***");
Console.WriteLine("------------------");

var answer = string.Empty;
var options = new List<string> { "s", "n" };
do
{
    var desktops = ConsoleExtension.GetInt("Ingrese N° de Escritorios.........: ");
    Console.WriteLine                     ("-----------------------------------");
    Console.WriteLine($"El valor a pagar es...............: {CalculateValue(desktops):C2}");
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

//-------------------------------------------------
decimal CalculateValue(int desktops)
{
    decimal price = 1000M;
    float discount;
    if (desktops < 5)
    {
        discount = 0.1f;
    }
    else if (desktops < 10)
    {
        discount = 0.2f;
    }
    else
    {
        discount = 0.4f;
    }
    return desktops * price * (decimal)(1 - discount);
}
