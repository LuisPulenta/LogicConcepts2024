using Shared;

Console.WriteLine("*** NOMINA SENCILLA ***");
Console.WriteLine("--------------------------");

var answer = string.Empty;
var options = new List<string> { "s", "n" };
do
{
    var name = ConsoleExtension.GetString          ("Ingrese Nombre....................: ");
    var workHours = ConsoleExtension.GetFloat      ("Ingrese Número de horas trabajadas: ");
    var hourValue = ConsoleExtension.GetDecimal    ("Ingrese Valor Hora................: ");
    var salaryMinimum = ConsoleExtension.GetDecimal("Ingrese Salario mínimo mensual....: ");
    Console.WriteLine                              ("-----------------------------------");
    var salary = (decimal) workHours * hourValue;

    if (salary < salaryMinimum)
    {
        Console.WriteLine($"Nombre............................: {name}");
        Console.WriteLine($"Salario Mínimo Mensual............: {salaryMinimum:C2}");
    }
    else
    {
        Console.WriteLine($"Nombre...........................: {name}");
        Console.WriteLine                          ($"Salario Mensual..................: {salary:C2}");
    }
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
