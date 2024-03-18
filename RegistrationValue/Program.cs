using Shared;

Console.WriteLine("*** VALOR MATRICULA ***");
Console.WriteLine("-----------------------");

var answer = string.Empty;
var options = new List<string> { "s", "n" };
do
{
    var credits = ConsoleExtension.GetInt        ("N° de Créditos.............: ");
    var creditValue = ConsoleExtension.GetDecimal("Valor Crédito..............: ");
    var stratum = ConsoleExtension.GetInt ("Estrato Estudiante.........: ");
    Console.WriteLine                            ("-----------------------------");
    Console.WriteLine($"El Costo de la Matrícula es............: {CalculateRegistrationValue(credits,creditValue,stratum):C2}");
    Console.WriteLine($"El Valor del Subsidio es...............: {CalculateSubsidy(stratum):C2}");
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
decimal CalculateRegistrationValue(int credits, decimal creditValue,int stratum )
{
    decimal value;
    if (credits <= 20)
    {
        value = credits * creditValue;
    }
    else
    {
        value = 20 * creditValue + (credits-20) *creditValue*2;
    }

    if (stratum == 1)
    {
        return value * 0.2m;
    }
    if (stratum ==2)
    {
        return value * 0.5m;
    }
    if (stratum == 3)
    {
        return value * 0.7m;
    }
    return value;
}

//-------------------------------------------------
decimal CalculateSubsidy(int stratum)
{
    if (stratum==1) return 200000M; 
    if (stratum == 2) return 100000M;
    return 0;
}
