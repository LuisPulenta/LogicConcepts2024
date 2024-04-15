﻿using Shared;

Console.WriteLine("*** AÑO BISIESTO ***");
Console.WriteLine("--------------------");

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var currentYear = DateTime.Now.Year;
    var message = string.Empty;
    var year = ConsoleExtension.GetInt("Ingrese año: ");

    if (year == currentYear)
    {
        message = "es";
    }
    else if (year > currentYear)
    {
        message = "va a ser";
    }
    else
    {
        message = "fue";
    }

    var isLeapYear = DateUtilities.IsLeapYear(year);

    Console.WriteLine($"El año: {year}, {(isLeapYear ? "SI" :"NO")} {message} bisiesto.");
    
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
